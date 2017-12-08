using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voxReader
{
    static class StringDict
    {
        public static Dictionary<string, string> Decode(BinaryReader dataReader)
        {
            Dictionary<string, string> tags = new Dictionary<string, string>();
            int numTags = dataReader.ReadInt32();
            for (int i = 0; i < numTags; i++)
            {
                int nameLength = dataReader.ReadInt32();
                string key = new string(dataReader.ReadChars(nameLength));
                int valueLength = dataReader.ReadInt32();
                string value = new string(dataReader.ReadChars(valueLength));
                tags[key] = value;
            }
            return tags;
        }
    }
}
