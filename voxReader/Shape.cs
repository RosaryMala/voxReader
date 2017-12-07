using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voxReader
{
    class Shape : TaggedChunk
    {
        List<int> numbers = new List<int>();
        public override void ProcessTaggedData(BinaryReader dataReader)
        {
            while (dataReader.BaseStream.Position < dataReader.BaseStream.Length)
            {
                numbers.Add(dataReader.ReadInt32());
            }
        }
    }
}
