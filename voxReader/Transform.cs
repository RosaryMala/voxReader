using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voxReader
{
    class Transform : WorldChunk
    {
        public string name;
        public int shapeIndex;
        public int unknown = -1;
        public int layer;
        public int unknown2 = 1;
        public bool hidden = false;

        public class Position
        {
            public int x, y, z;

            public override string ToString()
            {
                return string.Format("{0} {1} {2}", x, y, z);
            }

            public Position(string source)
            {
                var parts = source.Split(' ');
                if (parts.Length != 3)
                    throw new InvalidDataException();
                x = int.Parse(parts[0]);
                y = int.Parse(parts[1]);
                z = int.Parse(parts[2]);
            }
        }

        public Position position;

        public class Rotation
        {
            public int r;
            public override string ToString()
            {
                return r.ToString();
            }

            public Rotation(string source)
            {
                r = int.Parse(source);
            }
        }

        public Rotation rotation;

        public override string ChunkID
        {
            get { return "nTRN"; }
        }

        internal override void ProcessTaggedData(BinaryReader dataReader, Dictionary<string, string> tags)
        {
            foreach (var tag in tags)
            {
                switch (tag.Key)
                {
                    case "_name":
                        name = tag.Value;
                        break;
                    case "_hidden":
                        hidden = tag.Value == "1";
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
            shapeIndex = dataReader.ReadInt32();
            unknown = dataReader.ReadInt32();
            layer = dataReader.ReadInt32();
            unknown2 = dataReader.ReadInt32();
            var subTags = StringDict.Decode(dataReader);
            foreach (var subTag in subTags)
            {
                switch (subTag.Key)
                {
                    case "_t":
                        position = new Position(subTag.Value);
                        break;
                    case "_r":
                        rotation = new Rotation(subTag.Value);
                        break;
                    default:
                        throw new NotImplementedException();
                }
            }
        }

        internal override Dictionary<string, string> GetTags()
        {
            var tags = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(name))
                tags["_name"] = name;
            if (hidden)
                tags["_hidden"] = "1";
            return tags;
        }

        internal override void Encode(BinaryWriter writer)
        {
            writer.Write(shapeIndex);
            writer.Write(unknown);
            writer.Write(layer);
            writer.Write(unknown2);
            var subTags = new Dictionary<string, string>();
            if (position != null)
                subTags["_t"] = position.ToString();
            if (rotation != null)
                subTags["_r"] = rotation.ToString();
            StringDict.Encode(writer, subTags);
        }
    }
}
