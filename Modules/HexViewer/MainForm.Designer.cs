/* AdminCon 6.0 Command Line Interface Edition - Source Code - MainForm.Designer.cs
 * Intro: Main Windows Form Designer for HexViewer.
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Modules.HexViewer
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.viewHexRichTextBox = new System.Windows.Forms.RichTextBox();
            this.fileInfoRichTextBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // viewHexRichTextBox
            // 
            this.viewHexRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.viewHexRichTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.viewHexRichTextBox.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewHexRichTextBox.ForeColor = System.Drawing.Color.Aqua;
            this.viewHexRichTextBox.Location = new System.Drawing.Point(12, 12);
            this.viewHexRichTextBox.Name = "viewHexRichTextBox";
            this.viewHexRichTextBox.ReadOnly = true;
            this.viewHexRichTextBox.Size = new System.Drawing.Size(329, 426);
            this.viewHexRichTextBox.TabIndex = 0;
            this.viewHexRichTextBox.Text = "";
            // 
            // fileInfoRichTextBox
            // 
            this.fileInfoRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileInfoRichTextBox.BackColor = System.Drawing.Color.Black;
            this.fileInfoRichTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fileInfoRichTextBox.ForeColor = System.Drawing.Color.White;
            this.fileInfoRichTextBox.Location = new System.Drawing.Point(347, 12);
            this.fileInfoRichTextBox.Name = "fileInfoRichTextBox";
            this.fileInfoRichTextBox.ReadOnly = true;
            this.fileInfoRichTextBox.Size = new System.Drawing.Size(441, 426);
            this.fileInfoRichTextBox.TabIndex = 1;
            this.fileInfoRichTextBox.Text = "";
            this.fileInfoRichTextBox.TextChanged += new System.EventHandler(this.fileInfoRichTextBox_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.fileInfoRichTextBox);
            this.Controls.Add(this.viewHexRichTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "AdminCon - HexViewer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox viewHexRichTextBox;
        private System.Windows.Forms.RichTextBox fileInfoRichTextBox;
    }
}

