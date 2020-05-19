using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_2
{
    class Bin
    {
        public static int X, Y, Z;
        public static short[] data;
        public Bin() { }

        public static void readBin(string path)
        {
            if (File.Exists(path))
            {
                BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open));

                X = reader.ReadInt32();
                Y = reader.ReadInt32();
                Z = reader.ReadInt32();

                int dataSize = X * Y * Z;
                data = new short[dataSize];
                for (int i = 0; i < dataSize; ++i)
                    data[i] = reader.ReadInt16();
            }
        }
    }
}
