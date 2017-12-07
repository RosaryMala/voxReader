using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voxReader
{
    /// <summary>
    /// Empty Chunk Type. Ignores all data.
    /// </summary>
    abstract class Chunk
    {
        public string ChunkID { get; private set; }

        public List<Chunk> Children = new List<Chunk>();

        public abstract void ProcessData(BinaryReader dataReader);

        public void Read(BinaryReader binaryReader, string id)
        {
            ChunkID = id;
            int dataSize = binaryReader.ReadInt32();
            int childrenSize = binaryReader.ReadInt32();
            ProcessData(new BinaryReader(new MemoryStream(binaryReader.ReadBytes(dataSize)), Encoding.ASCII));
            var dataStart = binaryReader.BaseStream.Position;
            while(binaryReader.BaseStream.Position < (dataStart + childrenSize))
            {
                Children.Add(ReadSingleChunk(binaryReader));
            }
        }

        internal static Chunk ReadSingleChunk(BinaryReader binaryReader)
        {
            string id = new string(binaryReader.ReadChars(4));
            Chunk newChunk;
            switch (id)
            {
                case "PACK":
                    newChunk = new Pack();
                    break;
                case "SIZE":
                    newChunk = new Size();
                    break;
                case "XYZI":
                    newChunk = new Xyzi();
                    break;
                case "RGBA":
                    newChunk = new Rgba();
                    break;
                case "MATT":
                    newChunk = new Matt();
                    break;
                case "nTRN":
                    newChunk = new Transform();
                    break;
                case "nGRP":
                    newChunk = new Group();
                    break;
                case "MATL":
                    newChunk = new EmptyTaggedChunk();
                    break;
                case "nSHP":
                    newChunk = new Shape();
                    break;
                case "LAYR":
                    newChunk = new Layer();
                    break;
                default:
                    newChunk = new EmptyChunk();
                    break;
            }
            newChunk.Read(binaryReader, id);

            return newChunk;
        }

        public override string ToString()
        {
            return ChunkID;
        }
    }
}
