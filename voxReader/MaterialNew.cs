using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voxReader
{
    class MaterialNew : WorldChunk
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
        internal override void ProcessTaggedData(BinaryReader dataReader, Dictionary<string, string> tags)
        {
            data = dataReader.ReadBytes((int)dataReader.BaseStream.Length);
            foreach (var tag in tags)
            {
                switch (tag.Key)
                {
                    case "_type":
                        type = (Type)Enum.Parse(typeof(Type), tag.Value);
                        break;
                    case "_weight":
                        weight = float.Parse(tag.Value);
                        break;
                    case "_rough":
                        rough = float.Parse(tag.Value);
                        break;
                    case "_spec":
                        spec = float.Parse(tag.Value);
                        break;
                    case "_ior":
                        ior = float.Parse(tag.Value);
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        public override string ToString()
        {
            return type.ToString();
        }
    }
}
