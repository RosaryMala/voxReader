using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voxReader
{
    class UnknownData : IChunkData
    {
        public UnknownData(string id)
        {
            this.id = id;
        }

        public string ChunkID
        {
            get { return id; }
        }

        readonly string id;

        public byte[] bytes;

        public void FromByteArray(byte[] bytes)
        {
            this.bytes = bytes;
        }

        public byte[] ToByteArray()
        {
            return bytes;
        }
    }
}
