using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CG_2
{
    public partial class Form1 : Form
    {
        static int MINIMUM_CT_VALUE = 0, MAXIMUM_CT_VALUE = 3000; // 24399;

        bool NeedReload = false, DataIsLoaded = false;
        int CurrentLayer = 0, FrameCount;
        string VisMode = "quads";
        DateTime NextFPSUpdate = DateTime.Now.AddSeconds(1);

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Application.Idle += Application_Idle;
        }

        private void Application_Idle(object sender, EventArgs e)
        {
            if (glControl1.IsIdle)
            {
                DisplayFPS();
                glControl1.Invalidate();
            }
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Bin.readBin(dialog.FileName);
                layerTrack.Minimum = 0;
                layerTrack.Maximum = Bin.Z - 1;
                minValueTrack.Minimum = MINIMUM_CT_VALUE;
                minValueTrack.Maximum = MAXIMUM_CT_VALUE - 255;
                View.MinValue = minValueTrack.Value;
                bandwidthTrack.Minimum = 255;
                bandwidthTrack.Maximum = MAXIMUM_CT_VALUE - minValueTrack.Value;
                View.ValueBandwidth = bandwidthTrack.Value;
                View.SetupView(glControl1.Width, glControl1.Height);
                DataIsLoaded = true;
                NeedReload = true;
            }
        }

        private void layerTrack_Scroll(object sender, EventArgs e)
        {
            CurrentLayer = layerTrack.Value;
            NeedReload = true;
        }

        private void minValueTrack_Scroll(object sender, EventArgs e)
        {
            View.MinValue = minValueTrack.Value;
            bandwidthTrack.Maximum = MAXIMUM_CT_VALUE - minValueTrack.Value;
            NeedReload = true;
        }

        private void bandwidthTrack_Scroll(object sender, EventArgs e)
        {
            View.ValueBandwidth = bandwidthTrack.Value;
            NeedReload = true;
        }

        private void quadsVisButton_Click(object sender, EventArgs e)
        {
            if (!DataIsLoaded)
                return;
            VisMode = "quads";
            ChangeEnabled();
        }

        private void textureVisButton_Click(object sender, EventArgs e)
        {
            if (!DataIsLoaded)
                return;
            VisMode = "texture";
            ChangeEnabled();
        }

        private void quadStripVisButton_Click(object sender, EventArgs e)
        {
            if (!DataIsLoaded)
                return;
            VisMode = "quad_strip";
            ChangeEnabled();
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            if (NeedReload)
            {
                if (VisMode == "quads")
                {
                    View.DrawQuads(CurrentLayer);
                }
                else if (VisMode == "quad_strip")
                {
                    View.DrawQuadStrip(CurrentLayer);
                }
                else if (VisMode == "texture")
                {
                    View.GenerateTextureImage(CurrentLayer);
                    View.Load2DTexture();
                    View.DrawTexture();
                    NeedReload = false;
                }
                else
                {
                    throw new NotSupportedException("Not supported visualizing type");
                }
                glControl1.SwapBuffers();
            }
        }


        private void DisplayFPS()
        {
            ++FrameCount;
            if (DateTime.Now >= NextFPSUpdate)
            {
                Text = String.Format("CT Visualizer (fps={0})", FrameCount);
                NextFPSUpdate = DateTime.Now.AddSeconds(1);
                FrameCount = 0;
            }
        }

        private void ChangeEnabled()
        {
            quadsVisButton.Enabled = VisMode != "quads";
            textureVisButton.Enabled = VisMode != "texture";
            quadStripVisButton.Enabled = VisMode != "quad_strip";
            NeedReload = true;
        }
    }
}
