using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voxReader
{
    class Xyzi : Chunk
    {
        public struct Voxel
        {
            public byte x, y, z, i;
        }
        public List<Voxel> voxels;

        public override void ProcessData(BinaryReader dataReader)
        {
            int numVoxels = dataReader.ReadInt32();
            voxels = new List<Voxel>(numVoxels);
            for(int i = 0; i < numVoxels; i++)
            {
                var voxel = new Voxel();
                voxel.x = dataReader.ReadByte();
                voxel.y = dataReader.ReadByte();
                voxel.z = dataReader.ReadByte();
                voxel.i = dataReader.ReadByte();
                voxels.Add(voxel);
            }
        }
    }
}
