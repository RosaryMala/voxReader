using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voxReader
{
    class Transform : TaggedChunk
    {
        public string name;
        public int shapeIndex;
        public int unknown;
        public int layer;
        public int unknown2;
        List<int> numbers = new List<int>();
        public Dictionary<string, string> subTags = new Dictionary<string, string>();

        public override void ProcessTaggedData(BinaryReader dataReader)
        {
            if (tags.ContainsKey("_name"))
                name = tags["_name"];
            shapeIndex = dataReader.ReadInt32();
            unknown = dataReader.ReadInt32();
            layer = dataReader.ReadInt32();
            unknown2 = dataReader.ReadInt32();
            int numSubTags = dataReader.ReadInt32();
            for(int i= 0; i < numSubTags; i++)
            {
                int keyLength = dataReader.ReadInt32();
                string key = new string(dataReader.ReadChars(keyLength));
                int valueLength = dataReader.ReadInt32();
                string value = new string(dataReader.ReadChars(valueLength));
                subTags[key] = value;
            }
            while (dataReader.BaseStream.Position < dataReader.BaseStream.Length)
            {
                numbers.Add(dataReader.ReadInt32());
            }
        }

        public override string ToString()
        {
            return name;
        }
    }
}
