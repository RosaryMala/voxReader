using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voxReader
{
    class EmptyTaggedChunk : TaggedChunk
    {
        byte[] data;

        public override void ProcessTaggedData(BinaryReader dataReader)
        {
            data = dataReader.ReadBytes((int)dataReader.BaseStream.Length);
        }
    }
}
