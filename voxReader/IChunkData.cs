using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voxReader
{
    interface IChunkData
    {
        byte[] ToByteArray();
        void FromByteArray(byte[] bytes);
        string ChunkID { get; }
    }
}
