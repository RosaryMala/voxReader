using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voxReader
{
    class Matt : Chunk
    {
        public int id;

        public enum Type
        {
            Diffuse = 0,
            Metal = 1,
            Glass = 2,
            Emissive = 3
        }
        public Type type;
        public float weight;

        [Flags]
        public enum Properties
        {
            None = 0,
            Plastic = 1,
            Roughness = 2,
            Specular = 4,
            IOR = 8,
            Attenuation = 16,
            Power = 32,
            Glow = 64,
            isTotalPower = 128
        }
        public Properties properties;

        public override void ProcessData(BinaryReader dataReader)
        {
            id = dataReader.ReadInt32();
            type = (Type)dataReader.ReadInt32();
            weight = dataReader.ReadSingle();
            properties = (Properties)dataReader.ReadInt32();
        }
    }
}
