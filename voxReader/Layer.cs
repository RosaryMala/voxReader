using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voxReader
{
    class Layer : WorldChunk
    {
        public string name;
        public int x;

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
            name = tags["_name"];
            x = dataReader.ReadInt32();
        }
    }
}
