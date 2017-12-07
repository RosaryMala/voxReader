using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voxReader
{
    class EmptyChunk : Chunk
    {
        byte[] data;

        public override void ProcessData(BinaryReader dataReader)
        {
            data = dataReader.ReadBytes((int)dataReader.BaseStream.Length);
        }
    }
}
