using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voxReader
{
    class MaterialNew : TaggedChunk
    {
        public enum Type
        {
            _diffuse,
            _metal,
            _glass,
            _emit
        }

        public Type type = Type._diffuse;
        float weight;
        float rough;
        float spec;
        float ior;

        byte[] data;
        public override void ProcessTaggedData(BinaryReader dataReader)
        {
            data = dataReader.ReadBytes((int)dataReader.BaseStream.Length);
            type = (Type)Enum.Parse(typeof(Type), tags["_type"]);
            weight = float.Parse(tags["_weight"]);
            rough = float.Parse(tags["_rough"]);
            spec = float.Parse(tags["_spec"]);
            ior = float.Parse(tags["_ior"]);
        }

        public override string ToString()
        {
            return type.ToString();
        }
    }
}
