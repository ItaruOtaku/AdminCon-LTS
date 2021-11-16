namespace AdminCon_CLI_dotnetEdition.Modules.WebViewer
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
            this.webBrowser = new System.Windows.Forms.WebBrowser();
            this.viewSourceCodeButton = new System.Windows.Forms.Button();
            this.viewGitHubButton = new System.Windows.Forms.Button();
            this.azureDevOpsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // webBrowser
            // 
            this.webBrowser.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser.Location = new System.Drawing.Point(12, 12);
            this.webBrowser.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(776, 397);
            this.webBrowser.TabIndex = 0;
            this.webBrowser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser_DocumentCompleted);
            // 
            // viewSourceCodeButton
            // 
            this.viewSourceCodeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.viewSourceCodeButton.Location = new System.Drawing.Point(12, 415);
            this.viewSourceCodeButton.Name = "viewSourceCodeButton";
            this.viewSourceCodeButton.Size = new System.Drawing.Size(239, 23);
            this.viewSourceCodeButton.TabIndex = 1;
            this.viewSourceCodeButton.Text = "Download Source Code Or Other Releases";
            this.viewSourceCodeButton.UseVisualStyleBackColor = true;
            this.viewSourceCodeButton.Click += new System.EventHandler(this.viewSourceCodeButton_Click);
            // 
            // viewGitHubButton
            // 
            this.viewGitHubButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.viewGitHubButton.Location = new System.Drawing.Point(589, 415);
            this.viewGitHubButton.Name = "viewGitHubButton";
            this.viewGitHubButton.Size = new System.Drawing.Size(88, 23);
            this.viewGitHubButton.TabIndex = 2;
            this.viewGitHubButton.Text = "GitHub";
            this.viewGitHubButton.UseVisualStyleBackColor = true;
            this.viewGitHubButton.Click += new System.EventHandler(this.viewGitHubButton_Click);
            // 
            // azureDevOpsButton
            // 
            this.azureDevOpsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.azureDevOpsButton.Location = new System.Drawing.Point(683, 415);
            this.azureDevOpsButton.Name = "azureDevOpsButton";
            this.azureDevOpsButton.Size = new System.Drawing.Size(105, 23);
            this.azureDevOpsButton.TabIndex = 3;
            this.azureDevOpsButton.Text = "Azure DevOps";
            this.azureDevOpsButton.UseVisualStyleBackColor = true;
            this.azureDevOpsButton.Click += new System.EventHandler(this.azureDevOpsButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.azureDevOpsButton);
            this.Controls.Add(this.viewGitHubButton);
            this.Controls.Add(this.viewSourceCodeButton);
            this.Controls.Add(this.webBrowser);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "AdminCon - Free, Open-Source, Light.";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser;
        private System.Windows.Forms.Button viewSourceCodeButton;
        private System.Windows.Forms.Button viewGitHubButton;
        private System.Windows.Forms.Button azureDevOpsButton;
    }
}

