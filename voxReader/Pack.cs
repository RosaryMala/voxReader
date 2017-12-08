using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voxReader
{
    class Pack : IChunkData
    {
        public int numModels;

        public string ChunkID { get { return "PACK"; } }

        public void FromByteArray(byte[] bytes)
        {
            BinaryReader reader = new BinaryReader(new MemoryStream(bytes), Encoding.ASCII);
            numModels = reader.ReadInt32();
        }

        public byte[] ToByteArray()
        {
            var ms = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(ms, Encoding.ASCII);
            writer.Write(numModels);
            return ms.ToArray();
        }
    }
}
