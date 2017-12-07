using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voxReader
{
    class Group : TaggedChunk
    {
        public List<int> contents = new List<int>();
        public override void ProcessTaggedData(BinaryReader dataReader)
        {
            int numItems = dataReader.ReadInt32();
            for (int i = 0; i < numItems; i++)
            {
                contents.Add(dataReader.ReadInt32());
            }
        }
    }
}
