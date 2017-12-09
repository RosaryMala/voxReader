using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voxReader
{
    class Rgba : IChunkData, IList<Rgba.Color>
    {
        public struct Color
        {
            public readonly byte r, g, b, a;
            public override string ToString()
            {
                return string.Format("Color({0},{1},{2},{3})", r, g, b, a);
            }

            public Color(byte r, byte g, byte b, byte a)
            {
                this.r = r;
                this.g = g;
                this.b = b;
                this.a = a;
            }

            static public implicit operator Color(uint value)
            {
                var bytes = BitConverter.GetBytes(value);
                return new Color(bytes[0], bytes[1], bytes[2], bytes[3]);
            }

            static public implicit operator uint(Color color)
            {
                return BitConverter.ToUInt32(new byte[] { color.r, color.g, color.b, color.a }, 0);
            }
        }

        Color[] colors = new Color[256];

        public static Rgba Default = new Rgba(
            0x00000000u, 0xffffffffu, 0xffccffffu, 0xff99ffffu, 0xff66ffffu, 0xff33ffffu, 0xff00ffffu, 0xffffccffu, 0xffccccffu, 0xff99ccffu, 0xff66ccffu, 0xff33ccffu, 0xff00ccffu, 0xffff99ffu, 0xffcc99ffu, 0xff9999ffu,
            0xff6699ffu, 0xff3399ffu, 0xff0099ffu, 0xffff66ffu, 0xffcc66ffu, 0xff9966ffu, 0xff6666ffu, 0xff3366ffu, 0xff0066ffu, 0xffff33ffu, 0xffcc33ffu, 0xff9933ffu, 0xff6633ffu, 0xff3333ffu, 0xff0033ffu, 0xffff00ffu,
            0xffcc00ffu, 0xff9900ffu, 0xff6600ffu, 0xff3300ffu, 0xff0000ffu, 0xffffffccu, 0xffccffccu, 0xff99ffccu, 0xff66ffccu, 0xff33ffccu, 0xff00ffccu, 0xffffccccu, 0xffccccccu, 0xff99ccccu, 0xff66ccccu, 0xff33ccccu,
            0xff00ccccu, 0xffff99ccu, 0xffcc99ccu, 0xff9999ccu, 0xff6699ccu, 0xff3399ccu, 0xff0099ccu, 0xffff66ccu, 0xffcc66ccu, 0xff9966ccu, 0xff6666ccu, 0xff3366ccu, 0xff0066ccu, 0xffff33ccu, 0xffcc33ccu, 0xff9933ccu,
            0xff6633ccu, 0xff3333ccu, 0xff0033ccu, 0xffff00ccu, 0xffcc00ccu, 0xff9900ccu, 0xff6600ccu, 0xff3300ccu, 0xff0000ccu, 0xffffff99u, 0xffccff99u, 0xff99ff99u, 0xff66ff99u, 0xff33ff99u, 0xff00ff99u, 0xffffcc99u,
            0xffcccc99u, 0xff99cc99u, 0xff66cc99u, 0xff33cc99u, 0xff00cc99u, 0xffff9999u, 0xffcc9999u, 0xff999999u, 0xff669999u, 0xff339999u, 0xff009999u, 0xffff6699u, 0xffcc6699u, 0xff996699u, 0xff666699u, 0xff336699u,
            0xff006699u, 0xffff3399u, 0xffcc3399u, 0xff993399u, 0xff663399u, 0xff333399u, 0xff003399u, 0xffff0099u, 0xffcc0099u, 0xff990099u, 0xff660099u, 0xff330099u, 0xff000099u, 0xffffff66u, 0xffccff66u, 0xff99ff66u,
            0xff66ff66u, 0xff33ff66u, 0xff00ff66u, 0xffffcc66u, 0xffcccc66u, 0xff99cc66u, 0xff66cc66u, 0xff33cc66u, 0xff00cc66u, 0xffff9966u, 0xffcc9966u, 0xff999966u, 0xff669966u, 0xff339966u, 0xff009966u, 0xffff6666u,
            0xffcc6666u, 0xff996666u, 0xff666666u, 0xff336666u, 0xff006666u, 0xffff3366u, 0xffcc3366u, 0xff993366u, 0xff663366u, 0xff333366u, 0xff003366u, 0xffff0066u, 0xffcc0066u, 0xff990066u, 0xff660066u, 0xff330066u,
            0xff000066u, 0xffffff33u, 0xffccff33u, 0xff99ff33u, 0xff66ff33u, 0xff33ff33u, 0xff00ff33u, 0xffffcc33u, 0xffcccc33u, 0xff99cc33u, 0xff66cc33u, 0xff33cc33u, 0xff00cc33u, 0xffff9933u, 0xffcc9933u, 0xff999933u,
            0xff669933u, 0xff339933u, 0xff009933u, 0xffff6633u, 0xffcc6633u, 0xff996633u, 0xff666633u, 0xff336633u, 0xff006633u, 0xffff3333u, 0xffcc3333u, 0xff993333u, 0xff663333u, 0xff333333u, 0xff003333u, 0xffff0033u,
            0xffcc0033u, 0xff990033u, 0xff660033u, 0xff330033u, 0xff000033u, 0xffffff00u, 0xffccff00u, 0xff99ff00u, 0xff66ff00u, 0xff33ff00u, 0xff00ff00u, 0xffffcc00u, 0xffcccc00u, 0xff99cc00u, 0xff66cc00u, 0xff33cc00u,
            0xff00cc00u, 0xffff9900u, 0xffcc9900u, 0xff999900u, 0xff669900u, 0xff339900u, 0xff009900u, 0xffff6600u, 0xffcc6600u, 0xff996600u, 0xff666600u, 0xff336600u, 0xff006600u, 0xffff3300u, 0xffcc3300u, 0xff993300u,
            0xff663300u, 0xff333300u, 0xff003300u, 0xffff0000u, 0xffcc0000u, 0xff990000u, 0xff660000u, 0xff330000u, 0xff0000eeu, 0xff0000ddu, 0xff0000bbu, 0xff0000aau, 0xff000088u, 0xff000077u, 0xff000055u, 0xff000044u,
            0xff000022u, 0xff000011u, 0xff00ee00u, 0xff00dd00u, 0xff00bb00u, 0xff00aa00u, 0xff008800u, 0xff007700u, 0xff005500u, 0xff004400u, 0xff002200u, 0xff001100u, 0xffee0000u, 0xffdd0000u, 0xffbb0000u, 0xffaa0000u,
            0xff880000u, 0xff770000u, 0xff550000u, 0xff440000u, 0xff220000u, 0xff110000u, 0xffeeeeeeu, 0xffddddddu, 0xffbbbbbbu, 0xffaaaaaau, 0xff888888u, 0xff777777u, 0xff555555u, 0xff444444u, 0xff222222u, 0xff111111u
);
        public Rgba(params uint[] nums)
        {
            if (nums.Length > 256)
                throw new ArgumentOutOfRangeException();
            for(int i = 0; i < 256; i++)
            {
                if (i < nums.Length)
                    colors[i] = nums[i];
                else
                    colors[i] = 0u;
            }
        }

        public Rgba()
        {

        }

        public string ChunkID { get { return "RGBA"; } }

        public int Count => ((IList<Color>)colors).Count;

        public bool IsReadOnly => ((IList<Color>)colors).IsReadOnly;

        public Color this[int index] { get => ((IList<Color>)colors)[index]; set => ((IList<Color>)colors)[index] = value; }

        public byte[] ToByteArray()
        {
            var ms = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(ms, Encoding.ASCII);
            foreach (var color in colors)
            {
                writer.Write(color);
            }
            return ms.ToArray();
        }

        public void FromByteArray(byte[] bytes)
        {
            BinaryReader reader = new BinaryReader(new MemoryStream(bytes), Encoding.ASCII);
            for (int i = 0; i < 256; i++)
            {
                colors[i] = reader.ReadUInt32();
            }
        }

        public int IndexOf(Color item)
        {
            return ((IList<Color>)colors).IndexOf(item);
        }

        public void Insert(int index, Color item)
        {
            ((IList<Color>)colors).Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            ((IList<Color>)colors).RemoveAt(index);
        }

        public void Add(Color item)
        {
            ((IList<Color>)colors).Add(item);
        }

        public void Clear()
        {
            ((IList<Color>)colors).Clear();
        }

        public bool Contains(Color item)
        {
            return ((IList<Color>)colors).Contains(item);
        }

        public void CopyTo(Color[] array, int arrayIndex)
        {
            ((IList<Color>)colors).CopyTo(array, arrayIndex);
        }

        public bool Remove(Color item)
        {
            return ((IList<Color>)colors).Remove(item);
        }

        public IEnumerator<Color> GetEnumerator()
        {
            return ((IList<Color>)colors).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IList<Color>)colors).GetEnumerator();
        }
    }
}
