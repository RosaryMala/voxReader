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

        public override string ChunkID => throw new NotImplementedException();

        internal override void Encode(BinaryWriter writer)
        {
            throw new NotImplementedException();
        }

        internal override Dictionary<string, string> GetTags()
        {
            throw new NotImplementedException();
        }

        internal override void ProcessTaggedData(BinaryReader dataReader, Dictionary<string, string> tags)
        {
            while (dataReader.BaseStream.Position < dataReader.BaseStream.Length)
            {
                numbers.Add(dataReader.ReadInt32());
            }
        }
    }
}
