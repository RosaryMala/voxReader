using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voxReader
{
    abstract class RenderChunk : Chunk
    {
        //internal override void ProcessData(BinaryReader dataReader)
        //{
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
