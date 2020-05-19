using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_2
{
    class View
    {
        public static void SetupView(int width, int height)
        {
            GL.ShadeModel(ShadingModel.Smooth);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, Bin.X, 0, Bin.Y, -1, 1);
            GL.Viewport(0, 0, width, height);
        }

        public static Color TransferFunction(short value)
        {
            int min = 0, max = 2000;
            int newVal = (value - min) * 255 / (max - min);
            return Color.FromArgb(newVal, newVal, newVal);
        }

        public static void DrawQuads(int layerNumber)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Begin(BeginMode.Quads);
            for (int x = 0; x < Bin.X - 1; ++x)
                for (int y = 0; y < Bin.Y - 1; ++y)
                {
                    for (int dx = 0; dx < 2; ++dx)
                        for (int dy = 0; dy < 2; ++dy)
                        {
                            short value = Bin.data[x + dx + (y + dy) * Bin.X + layerNumber * Bin.X * Bin.Y];
                            GL.Color3(TransferFunction(value));
                            GL.Vertex2(x + dx, y + dy);
                        }
                }
            GL.End();
        }
    }
}
