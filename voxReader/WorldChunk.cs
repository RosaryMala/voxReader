using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voxReader
{

    abstract class WorldChunk : IChunkData
    {
        public int index;

        public abstract string ChunkID { get; }

        public void FromByteArray(byte[] bytes)
        {
            BinaryReader dataReader = new BinaryReader(new MemoryStream(bytes), Encoding.ASCII);
            index = dataReader.ReadInt32();
            var tags = StringDict.Decode(dataReader);
            ProcessTaggedData(
                new BinaryReader(
                    new MemoryStream(
                        dataReader.ReadBytes((int)(dataReader.BaseStream.Length - dataReader.BaseStream.Position))
                        )
                    ), tags
                );
        }

        public byte[] ToByteArray()
        {
            var ms = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(ms, Encoding.ASCII);
            writer.Write(index);
            StringDict.Encode(writer, GetTags());
            Encode(writer);
            return ms.ToArray();
        }

        internal abstract void ProcessTaggedData(BinaryReader dataReader, Dictionary<string, string> tags);
        internal abstract Dictionary<string, string> GetTags();
        internal abstract void Encode(BinaryWriter writer);
    }
}
