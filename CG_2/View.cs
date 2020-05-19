using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CG_2
{
    class View
    {
        static Bitmap TextureImage;
        static int VBOTexture;
        public static int MinValue, ValueBandwidth;

        public static void GenerateTextureImage(int layerNumber)
        {
            TextureImage = new Bitmap(Bin.X, Bin.Y);
            for(int x = 0; x < Bin.X; ++x)
                for(int y = 0; y < Bin.Y; ++y)
                {
                    int pixelNumber = x + y * Bin.X + layerNumber * Bin.X * Bin.Y;
                    TextureImage.SetPixel(x, y, TransferFunction(Bin.data[pixelNumber]));
                }
        }

        public static void Load2DTexture()
        {
            GL.BindTexture(TextureTarget.Texture2D, VBOTexture);
            BitmapData data = TextureImage.LockBits(
                new Rectangle(0, 0, TextureImage.Width, TextureImage.Height),
                ImageLockMode.ReadOnly,
                System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(
                TextureTarget.Texture2D,
                0,
                PixelInternalFormat.Rgba,
                data.Width,
                data.Height,
                0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra,
                PixelType.UnsignedByte,
                data.Scan0);

            TextureImage.UnlockBits(data);

            GL.TexParameter(
                TextureTarget.Texture2D,
                TextureParameterName.TextureMinFilter,
                (int)TextureMinFilter.Linear);

            GL.TexParameter(
                TextureTarget.Texture2D,
                TextureParameterName.TextureMagFilter,
                (int)TextureMagFilter.Linear);

            ErrorCode errorCode = GL.GetError();
            string str = errorCode.ToString();
        }

        public static void DrawTexture()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, VBOTexture);
            GL.Begin(BeginMode.Quads);
            GL.Color3(Color.White);

            GL.TexCoord2(0f, 0f);
            GL.Vertex2(0, 0);
            GL.TexCoord2(0f, 1f);
            GL.Vertex2(0, Bin.Y);
            GL.TexCoord2(1f, 1f);
            GL.Vertex2(Bin.X, Bin.Y);
            GL.TexCoord2(1f, 0f);
            GL.Vertex2(Bin.X, 0);

            GL.End();
            GL.Disable(EnableCap.Texture2D);
        }

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
            int newVal = (value - MinValue) * 255 / ValueBandwidth;
            if (newVal < 0)
                newVal = 0;
            if (newVal > 255)
                newVal = 255;
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
                    {
                        short value = Bin.data[x + dx + (y + dx) * Bin.X + layerNumber * Bin.X * Bin.Y];
                        GL.Color3(TransferFunction(value));
                        GL.Vertex2(x + dx, y + dx);
                        value = Bin.data[x + dx + (y + 1 - dx) * Bin.X + layerNumber * Bin.X * Bin.Y];
                        GL.Color3(TransferFunction(value));
                        GL.Vertex2(x + dx, y + 1 - dx);
                    }
                }
            GL.End();
        }

        public static void DrawQuadStrip(int layerNumber)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            for (int y = 0; y < Bin.Y - 1; ++y)
            {
                GL.Begin(BeginMode.QuadStrip);
                short value = Bin.data[y * Bin.X + layerNumber * Bin.X * Bin.Y];
                GL.Color3(TransferFunction(value));
                GL.Vertex2(0, y);
                value = Bin.data[(y + 1) * Bin.X + layerNumber * Bin.X * Bin.Y];
                GL.Color3(TransferFunction(value));
                GL.Vertex2(0, y + 1);

                for (int x = 1; x < Bin.X; ++x)
                {
                    value = Bin.data[x + y * Bin.X + layerNumber * Bin.X * Bin.Y];
                    GL.Color3(TransferFunction(value));
                    GL.Vertex2(x, y);
                    value = Bin.data[x + (y + 1) * Bin.X + layerNumber * Bin.X * Bin.Y];
                    GL.Color3(TransferFunction(value));
                    GL.Vertex2(x, y + 1);
                }
                GL.End();
            }
        }
    }
}
