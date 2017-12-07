using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voxReader
{
    class Chunk
    {
        public string ChunkID { get; }

        public List<Chunk> Children;
    }
}
