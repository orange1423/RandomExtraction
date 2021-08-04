namespace RandomExtraction
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox_Extraction = new System.Windows.Forms.TextBox();
            this.button_Start = new System.Windows.Forms.Button();
            this.textBox_hitokoto = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.pictureBox_ = new System.Windows.Forms.PictureBox();
            this.pictureBox_MessageForm = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_MessageForm)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox_Extraction
            // 
            this.textBox_Extraction.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Extraction.Font = new System.Drawing.Font("方正启功行楷 简", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_Extraction.Location = new System.Drawing.Point(500, 371);
            this.textBox_Extraction.Name = "textBox_Extraction";
            this.textBox_Extraction.ReadOnly = true;
            this.textBox_Extraction.Size = new System.Drawing.Size(600, 55);
            this.textBox_Extraction.TabIndex = 0;
            this.textBox_Extraction.TabStop = false;
            this.textBox_Extraction.Text = "咕咕咕";
            this.textBox_Extraction.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_Extraction.DoubleClick += new System.EventHandler(this.MainForm_DoubleClick);
            // 
            // button_Start
            // 
            this.button_Start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Start.Location = new System.Drawing.Point(740, 461);
            this.button_Start.Name = "button_Start";
            this.button_Start.Size = new System.Drawing.Size(120, 50);
            this.button_Start.TabIndex = 0;
            this.button_Start.Text = "Start";
            this.button_Start.UseVisualStyleBackColor = true;
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // textBox_hitokoto
            // 
            this.textBox_hitokoto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_hitokoto.Font = new System.Drawing.Font("方正启功行楷 简", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox_hitokoto.Location = new System.Drawing.Point(50, 60);
            this.textBox_hitokoto.Multiline = true;
            this.textBox_hitokoto.Name = "textBox_hitokoto";
            this.textBox_hitokoto.ReadOnly = true;
            this.textBox_hitokoto.Size = new System.Drawing.Size(1500, 120);
            this.textBox_hitokoto.TabIndex = 1;
            this.textBox_hitokoto.TabStop = false;
            // 
            // pictureBox_
            // 
            this.pictureBox_.Image = global::RandomExtraction.Properties.Resources.竹子;
            this.pictureBox_.Location = new System.Drawing.Point(35, 550);
            this.pictureBox_.Name = "pictureBox_";
            this.pictureBox_.Size = new System.Drawing.Size(300, 350);
            this.pictureBox_.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_.TabIndex = 3;
            this.pictureBox_.TabStop = false;
            // 
            // pictureBox_MessageForm
            // 
            this.pictureBox_MessageForm.Image = global::RandomExtraction.Properties.Resources.花草;
            this.pictureBox_MessageForm.Location = new System.Drawing.Point(1280, 700);
            this.pictureBox_MessageForm.Name = "pictureBox_MessageForm";
            this.pictureBox_MessageForm.Size = new System.Drawing.Size(300, 200);
            this.pictureBox_MessageForm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox_MessageForm.TabIndex = 2;
            this.pictureBox_MessageForm.TabStop = false;
            // 
            // MainForm
            // 
            this.AcceptButton = this.button_Start;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1600, 882);
            this.Controls.Add(this.pictureBox_);
            this.Controls.Add(this.pictureBox_MessageForm);
            this.Controls.Add(this.textBox_hitokoto);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.textBox_Extraction);
            this.Font = new System.Drawing.Font("方正启功行楷 简", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.Name = "MainForm";
            this.Opacity = 0.8D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.DoubleClick += new System.EventHandler(this.MainForm_DoubleClick);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_MessageForm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Extraction;
        private System.Windows.Forms.Button button_Start;
        private System.Windows.Forms.TextBox textBox_hitokoto;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.PictureBox pictureBox_MessageForm;
        private System.Windows.Forms.PictureBox pictureBox_;
    }
}

