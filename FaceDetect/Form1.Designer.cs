namespace FaceDetect
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.functionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pb_Show = new System.Windows.Forms.PictureBox();
            this.scMain = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pal_Ctrl = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pb_Sample = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Show)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).BeginInit();
            this.scMain.Panel1.SuspendLayout();
            this.scMain.Panel2.SuspendLayout();
            this.scMain.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pal_Ctrl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Sample)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.functionToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(10, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1384, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // functionToolStripMenuItem
            // 
            this.functionToolStripMenuItem.Name = "functionToolStripMenuItem";
            this.functionToolStripMenuItem.Size = new System.Drawing.Size(81, 23);
            this.functionToolStripMenuItem.Text = "Function";
            // 
            // pb_Show
            // 
            this.pb_Show.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(211)))));
            this.pb_Show.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_Show.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_Show.Location = new System.Drawing.Point(0, 0);
            this.pb_Show.Name = "pb_Show";
            this.pb_Show.Size = new System.Drawing.Size(932, 604);
            this.pb_Show.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_Show.TabIndex = 1;
            this.pb_Show.TabStop = false;
            // 
            // scMain
            // 
            this.scMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.scMain.Location = new System.Drawing.Point(0, 29);
            this.scMain.Name = "scMain";
            // 
            // scMain.Panel1
            // 
            this.scMain.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.scMain.Panel1.Controls.Add(this.panel1);
            // 
            // scMain.Panel2
            // 
            this.scMain.Panel2.Controls.Add(this.pal_Ctrl);
            this.scMain.Size = new System.Drawing.Size(1384, 606);
            this.scMain.SplitterDistance = 934;
            this.scMain.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.pb_Show);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(934, 606);
            this.panel1.TabIndex = 0;
            // 
            // pal_Ctrl
            // 
            this.pal_Ctrl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pal_Ctrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pal_Ctrl.Controls.Add(this.button4);
            this.pal_Ctrl.Controls.Add(this.comboBox1);
            this.pal_Ctrl.Controls.Add(this.button3);
            this.pal_Ctrl.Controls.Add(this.button2);
            this.pal_Ctrl.Controls.Add(this.button1);
            this.pal_Ctrl.Controls.Add(this.textBox1);
            this.pal_Ctrl.Controls.Add(this.label1);
            this.pal_Ctrl.Controls.Add(this.pb_Sample);
            this.pal_Ctrl.Controls.Add(this.label2);
            this.pal_Ctrl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pal_Ctrl.Location = new System.Drawing.Point(0, 0);
            this.pal_Ctrl.Name = "pal_Ctrl";
            this.pal_Ctrl.Size = new System.Drawing.Size(446, 606);
            this.pal_Ctrl.TabIndex = 0;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button4.Location = new System.Drawing.Point(13, 486);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(315, 34);
            this.button4.TabIndex = 8;
            this.button4.Text = "Set Recon";
            this.button4.UseVisualStyleBackColor = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "EigenFaceReconizer",
            "FisherFaceReconizer",
            "LBPHFFaceReconizer"});
            this.comboBox1.Location = new System.Drawing.Point(121, 450);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(207, 33);
            this.comboBox1.TabIndex = 6;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.GreenYellow;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button3.Location = new System.Drawing.Point(223, 408);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(54, 34);
            this.button3.TabIndex = 5;
            this.button3.Text = ">>";
            this.button3.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Location = new System.Drawing.Point(73, 408);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(144, 34);
            this.button2.TabIndex = 4;
            this.button2.Text = "Save Sample";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.GreenYellow;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(13, 408);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 34);
            this.button1.TabIndex = 3;
            this.button1.Text = "<<";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(88, 373);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(207, 34);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(19, 370);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pb_Sample
            // 
            this.pb_Sample.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_Sample.BackColor = System.Drawing.Color.WhiteSmoke;
            this.pb_Sample.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_Sample.Location = new System.Drawing.Point(13, 10);
            this.pb_Sample.Name = "pb_Sample";
            this.pb_Sample.Size = new System.Drawing.Size(419, 354);
            this.pb_Sample.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pb_Sample.TabIndex = 0;
            this.pb_Sample.TabStop = false;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(23, 448);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 32);
            this.label2.TabIndex = 7;
            this.label2.Text = "ReconType:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1384, 635);
            this.Controls.Add(this.scMain);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form1";
            this.Text = "Face Detection";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Show)).EndInit();
            this.scMain.Panel1.ResumeLayout(false);
            this.scMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scMain)).EndInit();
            this.scMain.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.pal_Ctrl.ResumeLayout(false);
            this.pal_Ctrl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Sample)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem functionToolStripMenuItem;
        private System.Windows.Forms.PictureBox pb_Show;
        private System.Windows.Forms.SplitContainer scMain;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel pal_Ctrl;
        private System.Windows.Forms.PictureBox pb_Sample;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button4;
    }
}

