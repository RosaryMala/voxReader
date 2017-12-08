using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voxReader
{
    class Shape : WorldChunk
    {
        List<int> numbers = new List<int>();
        internal override void ProcessTaggedData(BinaryReader dataReader, Dictionary<string, string> tags)
        {
            while (dataReader.BaseStream.Position < dataReader.BaseStream.Length)
            {
                numbers.Add(dataReader.ReadInt32());
            }
        }
    }
}
