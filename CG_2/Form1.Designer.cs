namespace CG_2
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.glControl1 = new OpenTK.GLControl();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileButton = new System.Windows.Forms.ToolStripMenuItem();
            this.режимToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quadsVisButton = new System.Windows.Forms.ToolStripMenuItem();
            this.textureVisButton = new System.Windows.Forms.ToolStripMenuItem();
            this.quadStripVisButton = new System.Windows.Forms.ToolStripMenuItem();
            this.layerTrack = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.minValueTrack = new System.Windows.Forms.TrackBar();
            this.bandwidthTrack = new System.Windows.Forms.TrackBar();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layerTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.minValueTrack)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandwidthTrack)).BeginInit();
            this.SuspendLayout();
            // 
            // glControl1
            // 
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Location = new System.Drawing.Point(12, 27);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(1280, 720);
            this.glControl1.TabIndex = 0;
            this.glControl1.VSync = false;
            this.glControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl1_Paint);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.режимToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1304, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFileButton});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // openFileButton
            // 
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(210, 22);
            this.openFileButton.Text = "Открыть";
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // режимToolStripMenuItem
            // 
            this.режимToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quadsVisButton,
            this.textureVisButton,
            this.quadStripVisButton});
            this.режимToolStripMenuItem.Name = "режимToolStripMenuItem";
            this.режимToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.режимToolStripMenuItem.Text = "Режим";
            // 
            // quadsVisButton
            // 
            this.quadsVisButton.Enabled = false;
            this.quadsVisButton.Name = "quadsVisButton";
            this.quadsVisButton.Size = new System.Drawing.Size(305, 22);
            this.quadsVisButton.Text = "Визуализация четырехугольниками";
            this.quadsVisButton.Click += new System.EventHandler(this.quadsVisButton_Click);
            // 
            // textureVisButton
            // 
            this.textureVisButton.Name = "textureVisButton";
            this.textureVisButton.Size = new System.Drawing.Size(305, 22);
            this.textureVisButton.Text = "Визуализация одной текстурой";
            this.textureVisButton.Click += new System.EventHandler(this.textureVisButton_Click);
            // 
            // quadStripVisButton
            // 
            this.quadStripVisButton.Name = "quadStripVisButton";
            this.quadStripVisButton.Size = new System.Drawing.Size(305, 22);
            this.quadStripVisButton.Text = "Визуализация лентой четырехугольников";
            this.quadStripVisButton.Click += new System.EventHandler(this.quadStripVisButton_Click);
            // 
            // layerTrack
            // 
            this.layerTrack.Location = new System.Drawing.Point(12, 766);
            this.layerTrack.Name = "layerTrack";
            this.layerTrack.Size = new System.Drawing.Size(1280, 45);
            this.layerTrack.TabIndex = 2;
            this.layerTrack.Scroll += new System.EventHandler(this.layerTrack_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 814);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(200, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Минимально отображаемое значение";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 750);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Номер слоя";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(651, 814);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(216, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Ширина полосы отображаемых значений";
            // 
            // minValueTrack
            // 
            this.minValueTrack.Location = new System.Drawing.Point(12, 830);
            this.minValueTrack.Name = "minValueTrack";
            this.minValueTrack.Size = new System.Drawing.Size(638, 45);
            this.minValueTrack.TabIndex = 6;
            this.minValueTrack.Scroll += new System.EventHandler(this.minValueTrack_Scroll);
            // 
            // bandwidthTrack
            // 
            this.bandwidthTrack.Location = new System.Drawing.Point(654, 830);
            this.bandwidthTrack.Name = "bandwidthTrack";
            this.bandwidthTrack.Size = new System.Drawing.Size(638, 45);
            this.bandwidthTrack.TabIndex = 7;
            this.bandwidthTrack.Scroll += new System.EventHandler(this.bandwidthTrack_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1304, 892);
            this.Controls.Add(this.bandwidthTrack);
            this.Controls.Add(this.minValueTrack);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.layerTrack);
            this.Controls.Add(this.glControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(1320, 931);
            this.MinimumSize = new System.Drawing.Size(1320, 931);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layerTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.minValueTrack)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bandwidthTrack)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileButton;
        private System.Windows.Forms.TrackBar layerTrack;
        private System.Windows.Forms.ToolStripMenuItem режимToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quadsVisButton;
        private System.Windows.Forms.ToolStripMenuItem textureVisButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar minValueTrack;
        private System.Windows.Forms.TrackBar bandwidthTrack;
        private System.Windows.Forms.ToolStripMenuItem quadStripVisButton;
    }
}

