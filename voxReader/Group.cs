using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voxReader
{
    class Group : WorldChunk
    {
        public List<int> contents = new List<int>();

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
            int numItems = dataReader.ReadInt32();
            for (int i = 0; i < numItems; i++)
            {
                contents.Add(dataReader.ReadInt32());
            }
        }
    }
}
