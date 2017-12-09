using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voxReader
{

    abstract class WorldChunk : Chunk
    {
        public int index;

        //internal override void ProcessData(BinaryReader dataReader)
        //{
        //    index = dataReader.ReadInt32();
        //    var tags = StringDict.Decode(dataReader);
        //    ProcessTaggedData(
        //        new BinaryReader(
        //            new MemoryStream(
        //                dataReader.ReadBytes((int)(dataReader.BaseStream.Length - dataReader.BaseStream.Position))
        //                )
        //            ), tags
        //        );
        //}

        internal abstract void ProcessTaggedData(BinaryReader dataReader, Dictionary<string, string> tags);
    }
}
