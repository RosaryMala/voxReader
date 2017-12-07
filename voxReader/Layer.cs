using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voxReader
{
    class Layer : TaggedChunk
    {
        public string name;
        public int x;
        public override void ProcessTaggedData(BinaryReader dataReader)
        {
            name = tags["_name"];
            x = dataReader.ReadInt32();
        }
    }
}
