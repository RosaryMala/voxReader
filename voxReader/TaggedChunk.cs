using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voxReader
{

    abstract class TaggedChunk : Chunk
    {
        public int index;
        public Dictionary<string, string> tags = new Dictionary<string, string>();

        public abstract void ProcessTaggedData(BinaryReader dataReader);

        public override void ProcessData(BinaryReader dataReader)
        {
            index = dataReader.ReadInt32();
            int numTags = dataReader.ReadInt32();
            for (int i = 0; i < numTags; i++)
            {
                int nameLength = dataReader.ReadInt32();
                string key = new string(dataReader.ReadChars(nameLength));
                int valueLength = dataReader.ReadInt32();
                string value = new string(dataReader.ReadChars(valueLength));
                tags[key] = value;
            }
            ProcessTaggedData(
                new BinaryReader(
                    new MemoryStream(
                        dataReader.ReadBytes((int)(dataReader.BaseStream.Length - dataReader.BaseStream.Position))
                        )
                    )
                );
        }
    }
}
