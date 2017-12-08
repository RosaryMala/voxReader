using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voxReader
{
    class EmptyRenderChunk : RenderChunk
    {
        byte[] data;
        private Dictionary<string, string> tags;

        internal override void ProcessTaggedData(BinaryReader dataReader, Dictionary<string, string> tags)
        {
            data = dataReader.ReadBytes((int)dataReader.BaseStream.Length);
            this.tags = tags;
        }
    }
}
