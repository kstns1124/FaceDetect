namespace FaceDetect
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picCapture = new System.Windows.Forms.PictureBox();
            this.txtPersonName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_Capture = new System.Windows.Forms.Button();
            this.btn_Detect = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_train = new System.Windows.Forms.Button();
            this.btn_Reconize = new System.Windows.Forms.Button();
            this.picDetected = new System.Windows.Forms.PictureBox();
            this.cb_Reconizer = new System.Windows.Forms.ComboBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.formToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.form1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.form2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.picCapture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDetected)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // picCapture
            // 
            this.picCapture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCapture.Location = new System.Drawing.Point(12, 41);
            this.picCapture.Name = "picCapture";
            this.picCapture.Size = new System.Drawing.Size(500, 500);
            this.picCapture.TabIndex = 0;
            this.picCapture.TabStop = false;
            // 
            // txtPersonName
            // 
            this.txtPersonName.Location = new System.Drawing.Point(557, 41);
            this.txtPersonName.Name = "txtPersonName";
            this.txtPersonName.Size = new System.Drawing.Size(194, 34);
            this.txtPersonName.TabIndex = 1;
            this.txtPersonName.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(531, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "ID";
            // 
            // btn_Capture
            // 
            this.btn_Capture.Location = new System.Drawing.Point(531, 303);
            this.btn_Capture.Name = "btn_Capture";
            this.btn_Capture.Size = new System.Drawing.Size(220, 31);
            this.btn_Capture.TabIndex = 3;
            this.btn_Capture.Text = "1. Capture";
            this.btn_Capture.UseVisualStyleBackColor = true;
            this.btn_Capture.Click += new System.EventHandler(this.btn_Capture_Click);
            // 
            // btn_Detect
            // 
            this.btn_Detect.Location = new System.Drawing.Point(531, 339);
            this.btn_Detect.Name = "btn_Detect";
            this.btn_Detect.Size = new System.Drawing.Size(220, 31);
            this.btn_Detect.TabIndex = 4;
            this.btn_Detect.Text = "2.  Detect";
            this.btn_Detect.UseVisualStyleBackColor = true;
            this.btn_Detect.Click += new System.EventHandler(this.btn_Detect_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.Location = new System.Drawing.Point(531, 376);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(220, 31);
            this.btn_Add.TabIndex = 5;
            this.btn_Add.Text = "3. Add";
            this.btn_Add.UseVisualStyleBackColor = true;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_train
            // 
            this.btn_train.Location = new System.Drawing.Point(531, 413);
            this.btn_train.Name = "btn_train";
            this.btn_train.Size = new System.Drawing.Size(220, 31);
            this.btn_train.TabIndex = 6;
            this.btn_train.Text = "4. Train Image";
            this.btn_train.UseVisualStyleBackColor = true;
            this.btn_train.Click += new System.EventHandler(this.btn_train_Click);
            // 
            // btn_Reconize
            // 
            this.btn_Reconize.Location = new System.Drawing.Point(531, 450);
            this.btn_Reconize.Name = "btn_Reconize";
            this.btn_Reconize.Size = new System.Drawing.Size(220, 31);
            this.btn_Reconize.TabIndex = 7;
            this.btn_Reconize.Text = "5. Reconize";
            this.btn_Reconize.UseVisualStyleBackColor = true;
            this.btn_Reconize.Click += new System.EventHandler(this.btn_Reconize_Click);
            // 
            // picDetected
            // 
            this.picDetected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picDetected.Location = new System.Drawing.Point(772, 41);
            this.picDetected.Name = "picDetected";
            this.picDetected.Size = new System.Drawing.Size(500, 500);
            this.picDetected.TabIndex = 8;
            this.picDetected.TabStop = false;
            // 
            // cb_Reconizer
            // 
            this.cb_Reconizer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Reconizer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_Reconizer.FormattingEnabled = true;
            this.cb_Reconizer.Location = new System.Drawing.Point(531, 81);
            this.cb_Reconizer.Name = "cb_Reconizer";
            this.cb_Reconizer.Size = new System.Drawing.Size(220, 33);
            this.cb_Reconizer.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.formToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1283, 28);
            this.menuStrip1.TabIndex = 10;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // formToolStripMenuItem
            // 
            this.formToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.form1ToolStripMenuItem,
            this.form2ToolStripMenuItem});
            this.formToolStripMenuItem.Name = "formToolStripMenuItem";
            this.formToolStripMenuItem.Size = new System.Drawing.Size(58, 24);
            this.formToolStripMenuItem.Text = "Form";
            // 
            // form1ToolStripMenuItem
            // 
            this.form1ToolStripMenuItem.Name = "form1ToolStripMenuItem";
            this.form1ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.form1ToolStripMenuItem.Text = "Form1";
            this.form1ToolStripMenuItem.Click += new System.EventHandler(this.form1ToolStripMenuItem_Click);
            // 
            // form2ToolStripMenuItem
            // 
            this.form2ToolStripMenuItem.Name = "form2ToolStripMenuItem";
            this.form2ToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.form2ToolStripMenuItem.Text = "Form2";
            this.form2ToolStripMenuItem.Click += new System.EventHandler(this.form2ToolStripMenuItem_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 553);
            this.Controls.Add(this.cb_Reconizer);
            this.Controls.Add(this.txtPersonName);
            this.Controls.Add(this.picDetected);
            this.Controls.Add(this.btn_Reconize);
            this.Controls.Add(this.btn_train);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.btn_Detect);
            this.Controls.Add(this.btn_Capture);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.picCapture);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("微軟正黑體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "Form3";
            this.Text = "Form3";
            this.Load += new System.EventHandler(this.Form3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picCapture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDetected)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCapture;
        private System.Windows.Forms.TextBox txtPersonName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Capture;
        private System.Windows.Forms.Button btn_Detect;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_train;
        private System.Windows.Forms.Button btn_Reconize;
        private System.Windows.Forms.PictureBox picDetected;
        private System.Windows.Forms.ComboBox cb_Reconizer;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem formToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem form1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem form2ToolStripMenuItem;
    }
}