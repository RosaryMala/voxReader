using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voxReader
{
    class Pack : Chunk
    {
        public int numModels;

        public override void ProcessData(BinaryReader dataReader)
        {
            numModels = dataReader.ReadInt32();
        }
    }
}
