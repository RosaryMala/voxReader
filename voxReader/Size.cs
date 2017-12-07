using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voxReader
{
    class Size : Chunk
    {
        public int x, y, z;

        public override void ProcessData(BinaryReader dataReader)
        {
            x = dataReader.ReadInt32();
            y = dataReader.ReadInt32();
            z = dataReader.ReadInt32();
        }
    }
}
