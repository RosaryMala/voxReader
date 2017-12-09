using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voxReader
{
    class Xyzi : IChunkData
    {
        public struct Voxel
        {
            public byte x, y, z, i;
        }
        public List<Voxel> voxels;

        public string ChunkID { get { return "XYZI"; } }

        public byte[] ToByteArray()
        {
            var ms = new MemoryStream();
            BinaryWriter writer = new BinaryWriter(ms, Encoding.ASCII);
            writer.Write(voxels.Count);
            foreach (var voxel in voxels)
            {
                writer.Write(voxel.x);
                writer.Write(voxel.y);
                writer.Write(voxel.z);
                writer.Write(voxel.i);
            }
            return ms.ToArray();
        }

        public void FromByteArray(byte[] bytes)
        {
            BinaryReader dataReader = new BinaryReader(new MemoryStream(bytes), Encoding.ASCII);
            int numVoxels = dataReader.ReadInt32();
            voxels = new List<Voxel>(numVoxels);
            for (int i = 0; i < numVoxels; i++)
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
