using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voxReader
{
    class VoxFile
    {
        Chunk Main;

        internal void ReadStream(FileStream stream)
        {
            BinaryReader binaryReader = new BinaryReader(stream, Encoding.ASCII);
            var tag = binaryReader.ReadChars(4);
            var version = binaryReader.ReadInt32();
            Main = Chunk.ReadSingleChunk(binaryReader);
            Console.WriteLine(tag);
        }
    }
}
