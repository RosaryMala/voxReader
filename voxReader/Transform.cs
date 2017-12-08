using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voxReader
{
    class Transform : WorldChunk
    {
        public string name;
        public int shapeIndex;
        public int unknown;
        public int layer;
        public int unknown2;

        public int? posX, posY, posZ;

        List<int> numbers = new List<int>();

        internal override void ProcessTaggedData(BinaryReader dataReader, Dictionary<string, string> tags)
        {
            foreach (var tag in tags)
            {
                switch (tag.Key)
                {
                    case "_name":
                        name = tag.Value;
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            shapeIndex = dataReader.ReadInt32();
            unknown = dataReader.ReadInt32();
            layer = dataReader.ReadInt32();
            unknown2 = dataReader.ReadInt32();
            int numSubTags = dataReader.ReadInt32();
            for (int i= 0; i < numSubTags; i++)
            {
                int keyLength = dataReader.ReadInt32();
                string key = new string(dataReader.ReadChars(keyLength));
                int valueLength = dataReader.ReadInt32();
                string value = new string(dataReader.ReadChars(valueLength));
                switch (key)
                {
                    case "_t":
                        var coords = value.Split(' ');
                        posX = int.Parse(coords[0]);
                        posY = int.Parse(coords[1]);
                        posZ = int.Parse(coords[2]);
                        break;
                    default:
                        throw new NotImplementedException();
                }
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
