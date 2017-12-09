using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace voxReader
{
    class Rgba : Chunk
    {
        public struct Color
        {
            public byte r, g, b, a;
            public override string ToString()
            {
                return string.Format("Color({0},{1},{2},{3})", r, g, b, a);
            }
        }
        public Color[] colors;

        //public override void ProcessData(BinaryReader dataReader)
        //{
        //    colors = new Color[256];
        //    for(int i = 0; i < 256; i++)
        //    {
        //        colors[i].r = dataReader.ReadByte();
        //        colors[i].g = dataReader.ReadByte();
        //        colors[i].b = dataReader.ReadByte();
        //        colors[i].a = dataReader.ReadByte();
        //    }
        //}
    }
}
