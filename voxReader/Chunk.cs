using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voxReader
{
    /// <summary>
    /// Empty Chunk Type. Ignores all data.
    /// </summary>
    class Chunk : IEnumerable<Chunk>
    { 
        public List<Chunk> Children = new List<Chunk>();

        IChunkData data;

        internal void Decode(BinaryReader binaryReader)
        {
            string id = new string(binaryReader.ReadChars(4));
            int dataSize = binaryReader.ReadInt32();
            int childrenSize = binaryReader.ReadInt32();
            switch (id)
            {
                case "PACK":
                    data = new Pack();
                    break;
                case "SIZE":
                    data = new Size();
                    break;
                case "XYZI":
                    data = new Xyzi();
                    break;
                case "RGBA":
                    data = new Rgba();
                    break;
                case "nTRN":
                    data = new Transform();
                    break;
                case "nGRP":
                    data = new Group();
                    break;
                default:
                    data = new UnknownData(id);
                    break;
            }
            data.FromByteArray(binaryReader.ReadBytes(dataSize));
            var childrenStart = binaryReader.BaseStream.Position;
            while (binaryReader.BaseStream.Position < (childrenStart + childrenSize))
            {
                Chunk child = new Chunk();
                child.Decode(binaryReader);
                Children.Add(child);
            }
        }

        internal byte[] ToByteArray()
        {
            var dataBytes = data.ToByteArray();
            List<byte[]> childrenBytes = new List<byte[]>();
            int childrenSize = 0;
            foreach (var child in Children)
            {
                var childByte = child.ToByteArray();
                childrenSize += childByte.Length;
                childrenBytes.Add(childByte);
            }
            MemoryStream ms = new MemoryStream();
            BinaryWriter br = new BinaryWriter(ms);
            br.Write(data.ChunkID.ToCharArray());
            br.Write(dataBytes.Length);
            br.Write(childrenSize);
            br.Write(dataBytes);
            foreach (var item in childrenBytes)
            {
                br.Write(item);
            }
            return ms.ToArray();
        }

        public override string ToString()
        {
            if (data != null)
                return data.ChunkID;
            else
                return base.ToString();
        }

        public IEnumerator<Chunk> GetEnumerator()
        {
            return ((IEnumerable<Chunk>)Children).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<Chunk>)Children).GetEnumerator();
        }
    }
}
