using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voxReader
{
    class EmptyTaggedChunk : WorldChunk
    {
        byte[] data;
        Dictionary<string, string> tags;

        internal override void ProcessTaggedData(BinaryReader dataReader, Dictionary<string, string> tags)
        {
            this.tags = tags;
            data = dataReader.ReadBytes((int)dataReader.BaseStream.Length);
        }
    }
}
