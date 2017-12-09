using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voxReader
{
    class Size : IChunkData
    {
        public int x, y, z;

        public string ChunkID { get { return "SIZE"; } }

        public void FromByteArray(byte[] bytes)
        {
            BinaryReader reader = new BinaryReader(new MemoryStream(bytes), Encoding.ASCII);
            x = reader.ReadInt32();
            y = reader.ReadInt32();
            z = reader.ReadInt32();
        }


        public byte[] ToByteArray()
        {
            var ms = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(ms, Encoding.ASCII);
            writer.Write(x);
            writer.Write(y);
            writer.Write(z);
            return ms.ToArray();
        }
    }
}
