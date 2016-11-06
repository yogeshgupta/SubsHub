namespace subhub
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.Brwsbtn = new System.Windows.Forms.Button();
            this.Dwnldbtn = new System.Windows.Forms.Button();
            this.Cnclbtn = new System.Windows.Forms.Button();
            this.Pathtb = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.Dirbtn = new System.Windows.Forms.RadioButton();
            this.Filebtn = new System.Windows.Forms.RadioButton();
            this.vsubdwnldr = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.subtitleLanguageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutUsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTips = new System.Windows.Forms.ToolTip(this.components);
            this.chkSmartDownload = new System.Windows.Forms.CheckBox();
            this.btnClearScreen = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // Brwsbtn
            // 
            this.Brwsbtn.Location = new System.Drawing.Point(455, 77);
            this.Brwsbtn.Name = "Brwsbtn";
            this.Brwsbtn.Size = new System.Drawing.Size(75, 23);
            this.Brwsbtn.TabIndex = 0;
            this.Brwsbtn.Text = "Browse";
            this.Brwsbtn.UseVisualStyleBackColor = true;
            this.Brwsbtn.Click += new System.EventHandler(this.Brwsbtn_Click);
            // 
            // Dwnldbtn
            // 
            this.Dwnldbtn.Location = new System.Drawing.Point(368, 109);
            this.Dwnldbtn.Name = "Dwnldbtn";
            this.Dwnldbtn.Size = new System.Drawing.Size(75, 23);
            this.Dwnldbtn.TabIndex = 1;
            this.Dwnldbtn.Text = "Download";
            this.Dwnldbtn.UseVisualStyleBackColor = true;
            this.Dwnldbtn.Click += new System.EventHandler(this.Dwnldbtn_Click);
            // 
            // Cnclbtn
            // 
            this.Cnclbtn.Location = new System.Drawing.Point(455, 109);
            this.Cnclbtn.Name = "Cnclbtn";
            this.Cnclbtn.Size = new System.Drawing.Size(75, 23);
            this.Cnclbtn.TabIndex = 2;
            this.Cnclbtn.Text = "Cancel";
            this.Cnclbtn.UseVisualStyleBackColor = true;
            this.Cnclbtn.Click += new System.EventHandler(this.Cnclbtn_Click);
            // 
            // Pathtb
            // 
            this.Pathtb.Location = new System.Drawing.Point(121, 77);
            this.Pathtb.Name = "Pathtb";
            this.Pathtb.Size = new System.Drawing.Size(322, 20);
            this.Pathtb.TabIndex = 3;
            this.Pathtb.TextChanged += new System.EventHandler(this.Pathtb_TextChanged);
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.WorkerReportsProgress = true;
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork_1);
            // 
            // Dirbtn
            // 
            this.Dirbtn.AutoSize = true;
            this.Dirbtn.Location = new System.Drawing.Point(355, 142);
            this.Dirbtn.Name = "Dirbtn";
            this.Dirbtn.Size = new System.Drawing.Size(175, 17);
            this.Dirbtn.TabIndex = 4;
            this.Dirbtn.Text = "Select Folder (Batch Download)";
            this.toolTips.SetToolTip(this.Dirbtn, "Batch Download Subtitles for all Videos in the folder and sub-folders");
            this.Dirbtn.UseVisualStyleBackColor = true;
            // 
            // Filebtn
            // 
            this.Filebtn.AutoSize = true;
            this.Filebtn.Checked = true;
            this.Filebtn.Location = new System.Drawing.Point(121, 142);
            this.Filebtn.Name = "Filebtn";
            this.Filebtn.Size = new System.Drawing.Size(116, 17);
            this.Filebtn.TabIndex = 5;
            this.Filebtn.TabStop = true;
            this.Filebtn.Text = "Select A Single File";
            this.toolTips.SetToolTip(this.Filebtn, "Download Subtitle for a Single Video file");
            this.Filebtn.UseVisualStyleBackColor = true;
            // 
            // vsubdwnldr
            // 
            this.vsubdwnldr.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vsubdwnldr.HorizontalScrollbar = true;
            this.vsubdwnldr.ItemHeight = 18;
            this.vsubdwnldr.Location = new System.Drawing.Point(15, 163);
            this.vsubdwnldr.Name = "vsubdwnldr";
            this.vsubdwnldr.Size = new System.Drawing.Size(518, 292);
            this.vsubdwnldr.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.preferencesToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(542, 24);
            this.menuStrip1.TabIndex = 7;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // preferencesToolStripMenuItem
            // 
            this.preferencesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.subtitleLanguageToolStripMenuItem});
            this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
            this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.preferencesToolStripMenuItem.Text = "Preferences";
            // 
            // subtitleLanguageToolStripMenuItem
            // 
            this.subtitleLanguageToolStripMenuItem.Name = "subtitleLanguageToolStripMenuItem";
            this.subtitleLanguageToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.subtitleLanguageToolStripMenuItem.Text = "Subtitle Language";
            this.subtitleLanguageToolStripMenuItem.Click += new System.EventHandler(this.subtitleLanguageToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectPageToolStripMenuItem,
            this.aboutUsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // projectPageToolStripMenuItem
            // 
            this.projectPageToolStripMenuItem.Name = "projectPageToolStripMenuItem";
            this.projectPageToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.projectPageToolStripMenuItem.Text = "Project page";
            this.projectPageToolStripMenuItem.Click += new System.EventHandler(this.projectPageToolStripMenuItem_Click);
            // 
            // aboutUsToolStripMenuItem
            // 
            this.aboutUsToolStripMenuItem.Name = "aboutUsToolStripMenuItem";
            this.aboutUsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutUsToolStripMenuItem.Text = "About Us";
            this.aboutUsToolStripMenuItem.Click += new System.EventHandler(this.aboutUsToolStripMenuItem_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe Print", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(102, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(330, 37);
            this.label2.TabIndex = 12;
            this.label2.Text = "SubsHub Subtitle Downloader\r\n";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::subhub.Properties.Resources.subhub1;
            this.pictureBox1.Location = new System.Drawing.Point(0, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(119, 70);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Download -";
            // 
            // chkSmartDownload
            // 
            this.chkSmartDownload.AutoSize = true;
            this.chkSmartDownload.Checked = true;
            this.chkSmartDownload.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSmartDownload.Location = new System.Drawing.Point(121, 109);
            this.chkSmartDownload.Name = "chkSmartDownload";
            this.chkSmartDownload.Size = new System.Drawing.Size(104, 17);
            this.chkSmartDownload.TabIndex = 14;
            this.chkSmartDownload.Text = "Smart Download";
            this.toolTips.SetToolTip(this.chkSmartDownload, "If Video has already got Subtitle file, it will be skipped while downloading.");
            this.chkSmartDownload.UseVisualStyleBackColor = true;
            this.chkSmartDownload.CheckedChanged += new System.EventHandler(this.chkSmartDownload_CheckedChanged);
            // 
            // btnClearScreen
            // 
            this.btnClearScreen.Location = new System.Drawing.Point(436, 461);
            this.btnClearScreen.Name = "btnClearScreen";
            this.btnClearScreen.Size = new System.Drawing.Size(97, 23);
            this.btnClearScreen.TabIndex = 15;
            this.btnClearScreen.Text = "Clear Screen";
            this.btnClearScreen.UseVisualStyleBackColor = true;
            this.btnClearScreen.Click += new System.EventHandler(this.btnClearScreen_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(542, 487);
            this.Controls.Add(this.btnClearScreen);
            this.Controls.Add(this.chkSmartDownload);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.vsubdwnldr);
            this.Controls.Add(this.Filebtn);
            this.Controls.Add(this.Dirbtn);
            this.Controls.Add(this.Pathtb);
            this.Controls.Add(this.Cnclbtn);
            this.Controls.Add(this.Dwnldbtn);
            this.Controls.Add(this.Brwsbtn);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.Text = "SubsHub -Subtitle Downloader";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Brwsbtn;
        private System.Windows.Forms.Button Dwnldbtn;
        private System.Windows.Forms.Button Cnclbtn;
        private System.Windows.Forms.TextBox Pathtb;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.RadioButton Dirbtn;
        private System.Windows.Forms.RadioButton Filebtn;
        private System.Windows.Forms.ListBox vsubdwnldr;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem projectPageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutUsToolStripMenuItem;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subtitleLanguageToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTips;
        private System.Windows.Forms.CheckBox chkSmartDownload;
        private System.Windows.Forms.Button btnClearScreen;
    }
}

