/* AdminCon 7.0 Command Line Interface Edition - Source Code - DesktopEnvironment.Designer.cs
 * Intro: Main form of desktop environment of AdminCon.
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Modules.ACDesktop.Components
{
    partial class DesktopEnvironment
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DesktopEnvironment));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.exitButtonPicBox = new System.Windows.Forms.PictureBox();
            this.desktopToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.windowsCommandPromptToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.powershellToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminConToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administrativeToolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.taskManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.performanceMonitorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diskManagementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deviceManagerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.servicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timeTicker = new System.Windows.Forms.Timer(this.components);
            this.timeLabel = new System.Windows.Forms.Label();
            this.runningProcessListView = new System.Windows.Forms.ListView();
            this.processID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pLocation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.memUsage = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.diskIOSpeedLabel = new System.Windows.Forms.Label();
            this.cpuUsageDynamicChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.cpuUsageLabel = new System.Windows.Forms.Label();
            this.memUsageLabel = new System.Windows.Forms.Label();
            this.xAxisMaximumLabel = new System.Windows.Forms.Label();
            this.xAxisMinimumLabel = new System.Windows.Forms.Label();
            this.logoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.exitButtonPicBox)).BeginInit();
            this.contextMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cpuUsageDynamicChart)).BeginInit();
            this.SuspendLayout();
            // 
            // exitButtonPicBox
            // 
            this.exitButtonPicBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButtonPicBox.BackColor = System.Drawing.Color.Transparent;
            this.exitButtonPicBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("exitButtonPicBox.BackgroundImage")));
            this.exitButtonPicBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.exitButtonPicBox.Location = new System.Drawing.Point(1054, 566);
            this.exitButtonPicBox.Name = "exitButtonPicBox";
            this.exitButtonPicBox.Size = new System.Drawing.Size(32, 33);
            this.exitButtonPicBox.TabIndex = 0;
            this.exitButtonPicBox.TabStop = false;
            this.exitButtonPicBox.Click += new System.EventHandler(this.exitButtonPicBox_Click);
            this.exitButtonPicBox.MouseEnter += new System.EventHandler(this.exitButtonPicBox_MouseEnter);
            // 
            // desktopToolTip
            // 
            this.desktopToolTip.Popup += new System.Windows.Forms.PopupEventHandler(this.desktopToolTip_Popup);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.windowsCommandPromptToolStripMenuItem,
            this.powershellToolStripMenuItem,
            this.adminConToolStripMenuItem,
            this.fileExplorerToolStripMenuItem,
            this.refreshToolStripMenuItem,
            this.administrativeToolsToolStripMenuItem,
            this.runToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(228, 158);
            this.contextMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip_Opening);
            // 
            // windowsCommandPromptToolStripMenuItem
            // 
            this.windowsCommandPromptToolStripMenuItem.Name = "windowsCommandPromptToolStripMenuItem";
            this.windowsCommandPromptToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.windowsCommandPromptToolStripMenuItem.Text = "Windows Command Prompt";
            this.windowsCommandPromptToolStripMenuItem.Click += new System.EventHandler(this.windowsCommandPromptToolStripMenuItem_Click);
            // 
            // powershellToolStripMenuItem
            // 
            this.powershellToolStripMenuItem.Name = "powershellToolStripMenuItem";
            this.powershellToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.powershellToolStripMenuItem.Text = "Powershell";
            this.powershellToolStripMenuItem.Click += new System.EventHandler(this.powershellToolStripMenuItem_Click);
            // 
            // adminConToolStripMenuItem
            // 
            this.adminConToolStripMenuItem.Name = "adminConToolStripMenuItem";
            this.adminConToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.adminConToolStripMenuItem.Text = "AdminCon";
            this.adminConToolStripMenuItem.Click += new System.EventHandler(this.adminConToolStripMenuItem_Click);
            // 
            // fileExplorerToolStripMenuItem
            // 
            this.fileExplorerToolStripMenuItem.Name = "fileExplorerToolStripMenuItem";
            this.fileExplorerToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.fileExplorerToolStripMenuItem.Text = "File Explorer";
            this.fileExplorerToolStripMenuItem.Click += new System.EventHandler(this.fileExplorerToolStripMenuItem_Click);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // administrativeToolsToolStripMenuItem
            // 
            this.administrativeToolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.taskManagerToolStripMenuItem,
            this.performanceMonitorToolStripMenuItem,
            this.diskManagementToolStripMenuItem,
            this.deviceManagerToolStripMenuItem,
            this.servicesToolStripMenuItem});
            this.administrativeToolsToolStripMenuItem.Name = "administrativeToolsToolStripMenuItem";
            this.administrativeToolsToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.administrativeToolsToolStripMenuItem.Text = "Administrative Tools";
            // 
            // taskManagerToolStripMenuItem
            // 
            this.taskManagerToolStripMenuItem.Name = "taskManagerToolStripMenuItem";
            this.taskManagerToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.taskManagerToolStripMenuItem.Text = "Task Manager";
            this.taskManagerToolStripMenuItem.Click += new System.EventHandler(this.taskManagerToolStripMenuItem_Click);
            // 
            // performanceMonitorToolStripMenuItem
            // 
            this.performanceMonitorToolStripMenuItem.Name = "performanceMonitorToolStripMenuItem";
            this.performanceMonitorToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.performanceMonitorToolStripMenuItem.Text = "Performance Monitor";
            this.performanceMonitorToolStripMenuItem.Click += new System.EventHandler(this.performanceMonitorToolStripMenuItem_Click);
            // 
            // diskManagementToolStripMenuItem
            // 
            this.diskManagementToolStripMenuItem.Name = "diskManagementToolStripMenuItem";
            this.diskManagementToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.diskManagementToolStripMenuItem.Text = "Disk Management";
            this.diskManagementToolStripMenuItem.Click += new System.EventHandler(this.diskManagementToolStripMenuItem_Click);
            // 
            // deviceManagerToolStripMenuItem
            // 
            this.deviceManagerToolStripMenuItem.Name = "deviceManagerToolStripMenuItem";
            this.deviceManagerToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.deviceManagerToolStripMenuItem.Text = "Device Manager";
            this.deviceManagerToolStripMenuItem.Click += new System.EventHandler(this.deviceManagerToolStripMenuItem_Click);
            // 
            // servicesToolStripMenuItem
            // 
            this.servicesToolStripMenuItem.Name = "servicesToolStripMenuItem";
            this.servicesToolStripMenuItem.Size = new System.Drawing.Size(192, 22);
            this.servicesToolStripMenuItem.Text = "Services...";
            this.servicesToolStripMenuItem.Click += new System.EventHandler(this.servicesToolStripMenuItem_Click);
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.runToolStripMenuItem.Text = "Run...";
            this.runToolStripMenuItem.Click += new System.EventHandler(this.runToolStripMenuItem_Click);
            // 
            // timeTicker
            // 
            this.timeTicker.Interval = 50;
            this.timeTicker.Tick += new System.EventHandler(this.timeTicker_Tick);
            // 
            // timeLabel
            // 
            this.timeLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timeLabel.AutoSize = true;
            this.timeLabel.BackColor = System.Drawing.Color.Transparent;
            this.timeLabel.Font = new System.Drawing.Font("Candara Light", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.timeLabel.ForeColor = System.Drawing.Color.White;
            this.timeLabel.Location = new System.Drawing.Point(889, 9);
            this.timeLabel.Name = "timeLabel";
            this.timeLabel.Size = new System.Drawing.Size(197, 26);
            this.timeLabel.TabIndex = 1;
            this.timeLabel.Text = "HH:MM, mm/dd/yyyy";
            // 
            // runningProcessListView
            // 
            this.runningProcessListView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.runningProcessListView.BackColor = System.Drawing.Color.Black;
            this.runningProcessListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.runningProcessListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.processID,
            this.pName,
            this.pLocation,
            this.memUsage});
            this.runningProcessListView.ForeColor = System.Drawing.Color.Lime;
            this.runningProcessListView.HideSelection = false;
            this.runningProcessListView.Location = new System.Drawing.Point(12, 9);
            this.runningProcessListView.Name = "runningProcessListView";
            this.runningProcessListView.Size = new System.Drawing.Size(627, 580);
            this.runningProcessListView.TabIndex = 2;
            this.runningProcessListView.UseCompatibleStateImageBehavior = false;
            this.runningProcessListView.View = System.Windows.Forms.View.Details;
            this.runningProcessListView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.runningProcessListView_KeyDown);
            this.runningProcessListView.MouseEnter += new System.EventHandler(this.runningProcessListView_MouseEnter);
            // 
            // processID
            // 
            this.processID.Text = "PID";
            // 
            // pName
            // 
            this.pName.Text = "Process Name";
            // 
            // pLocation
            // 
            this.pLocation.Text = "Location";
            // 
            // memUsage
            // 
            this.memUsage.Text = "Memory Usage";
            // 
            // diskIOSpeedLabel
            // 
            this.diskIOSpeedLabel.AutoEllipsis = true;
            this.diskIOSpeedLabel.AutoSize = true;
            this.diskIOSpeedLabel.BackColor = System.Drawing.Color.Black;
            this.diskIOSpeedLabel.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.diskIOSpeedLabel.ForeColor = System.Drawing.Color.Goldenrod;
            this.diskIOSpeedLabel.Location = new System.Drawing.Point(670, 328);
            this.diskIOSpeedLabel.Name = "diskIOSpeedLabel";
            this.diskIOSpeedLabel.Size = new System.Drawing.Size(143, 26);
            this.diskIOSpeedLabel.TabIndex = 3;
            this.diskIOSpeedLabel.Text = "Disk I/O Speed:";
            // 
            // cpuUsageDynamicChart
            // 
            this.cpuUsageDynamicChart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cpuUsageDynamicChart.BackColor = System.Drawing.Color.Transparent;
            this.cpuUsageDynamicChart.BorderlineColor = System.Drawing.Color.Transparent;
            chartArea2.BackColor = System.Drawing.Color.Transparent;
            chartArea2.BackHatchStyle = System.Windows.Forms.DataVisualization.Charting.ChartHatchStyle.Cross;
            chartArea2.BackSecondaryColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            chartArea2.Name = "ChartArea";
            this.cpuUsageDynamicChart.ChartAreas.Add(chartArea2);
            legend2.BackColor = System.Drawing.Color.Transparent;
            legend2.ForeColor = System.Drawing.Color.Yellow;
            legend2.Name = "Legend";
            this.cpuUsageDynamicChart.Legends.Add(legend2);
            this.cpuUsageDynamicChart.Location = new System.Drawing.Point(645, 53);
            this.cpuUsageDynamicChart.Name = "cpuUsageDynamicChart";
            this.cpuUsageDynamicChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            series3.BackImageAlignment = System.Windows.Forms.DataVisualization.Charting.ChartImageAlignmentStyle.Top;
            series3.BackImageTransparentColor = System.Drawing.Color.Transparent;
            series3.BorderColor = System.Drawing.Color.White;
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Lime;
            series3.Legend = "Legend";
            series3.Name = "CPU Usage";
            series3.ShadowColor = System.Drawing.Color.Transparent;
            series3.YValuesPerPoint = 2;
            series4.BackSecondaryColor = System.Drawing.Color.Transparent;
            series4.BorderColor = System.Drawing.Color.Transparent;
            series4.BorderWidth = 2;
            series4.ChartArea = "ChartArea";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.Yellow;
            series4.Legend = "Legend";
            series4.Name = "Memory Usage";
            this.cpuUsageDynamicChart.Series.Add(series3);
            this.cpuUsageDynamicChart.Series.Add(series4);
            this.cpuUsageDynamicChart.Size = new System.Drawing.Size(366, 314);
            this.cpuUsageDynamicChart.TabIndex = 4;
            this.cpuUsageDynamicChart.Text = "chart";
            // 
            // cpuUsageLabel
            // 
            this.cpuUsageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cpuUsageLabel.AutoSize = true;
            this.cpuUsageLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cpuUsageLabel.ForeColor = System.Drawing.Color.Lime;
            this.cpuUsageLabel.Location = new System.Drawing.Point(891, 186);
            this.cpuUsageLabel.Name = "cpuUsageLabel";
            this.cpuUsageLabel.Size = new System.Drawing.Size(32, 15);
            this.cpuUsageLabel.TabIndex = 5;
            this.cpuUsageLabel.Text = "NN%";
            // 
            // memUsageLabel
            // 
            this.memUsageLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.memUsageLabel.AutoSize = true;
            this.memUsageLabel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memUsageLabel.ForeColor = System.Drawing.Color.Yellow;
            this.memUsageLabel.Location = new System.Drawing.Point(891, 217);
            this.memUsageLabel.Name = "memUsageLabel";
            this.memUsageLabel.Size = new System.Drawing.Size(32, 15);
            this.memUsageLabel.TabIndex = 6;
            this.memUsageLabel.Text = "NN%";
            // 
            // xAxisMaximumLabel
            // 
            this.xAxisMaximumLabel.AutoSize = true;
            this.xAxisMaximumLabel.ForeColor = System.Drawing.Color.White;
            this.xAxisMaximumLabel.Location = new System.Drawing.Point(672, 70);
            this.xAxisMaximumLabel.Name = "xAxisMaximumLabel";
            this.xAxisMaximumLabel.Size = new System.Drawing.Size(35, 15);
            this.xAxisMaximumLabel.TabIndex = 7;
            this.xAxisMaximumLabel.Text = "100%";
            // 
            // xAxisMinimumLabel
            // 
            this.xAxisMinimumLabel.AutoSize = true;
            this.xAxisMinimumLabel.ForeColor = System.Drawing.Color.White;
            this.xAxisMinimumLabel.Location = new System.Drawing.Point(672, 313);
            this.xAxisMinimumLabel.Name = "xAxisMinimumLabel";
            this.xAxisMinimumLabel.Size = new System.Drawing.Size(21, 15);
            this.xAxisMinimumLabel.TabIndex = 8;
            this.xAxisMinimumLabel.Text = "0%";
            // 
            // logoLabel
            // 
            this.logoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.logoLabel.AutoSize = true;
            this.logoLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.logoLabel.Location = new System.Drawing.Point(773, 529);
            this.logoLabel.Name = "logoLabel";
            this.logoLabel.Size = new System.Drawing.Size(304, 34);
            this.logoLabel.TabIndex = 9;
            this.logoLabel.Text = "AmaCloud Server 2021";
            // 
            // DesktopEnvironment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1089, 601);
            this.Controls.Add(this.logoLabel);
            this.Controls.Add(this.xAxisMinimumLabel);
            this.Controls.Add(this.xAxisMaximumLabel);
            this.Controls.Add(this.memUsageLabel);
            this.Controls.Add(this.cpuUsageLabel);
            this.Controls.Add(this.diskIOSpeedLabel);
            this.Controls.Add(this.runningProcessListView);
            this.Controls.Add(this.timeLabel);
            this.Controls.Add(this.exitButtonPicBox);
            this.Controls.Add(this.cpuUsageDynamicChart);
            this.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DesktopEnvironment";
            this.Text = "DesktopEnvironment";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DesktopEnvironment_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DesktopEnvironment_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.DesktopEnvironment_MouseClick);
            ((System.ComponentModel.ISupportInitialize)(this.exitButtonPicBox)).EndInit();
            this.contextMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cpuUsageDynamicChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox exitButtonPicBox;
        private System.Windows.Forms.ToolTip desktopToolTip;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem windowsCommandPromptToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem adminConToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileExplorerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem powershellToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administrativeToolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem taskManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem performanceMonitorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diskManagementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deviceManagerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem servicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.Timer timeTicker;
        private System.Windows.Forms.Label timeLabel;
        private System.Windows.Forms.ListView runningProcessListView;
        private System.Windows.Forms.ColumnHeader processID;
        private System.Windows.Forms.ColumnHeader pName;
        private System.Windows.Forms.ColumnHeader pLocation;
        private System.Windows.Forms.ColumnHeader memUsage;
        private System.Windows.Forms.Label diskIOSpeedLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart cpuUsageDynamicChart;
        private System.Windows.Forms.Label cpuUsageLabel;
        private System.Windows.Forms.Label memUsageLabel;
        private System.Windows.Forms.Label xAxisMaximumLabel;
        private System.Windows.Forms.Label xAxisMinimumLabel;
        private System.Windows.Forms.Label logoLabel;
    }
}
//Program Entry @ Launcher.cs