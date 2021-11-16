using Microsoft.VisualBasic.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
/* AdminCon 7.0 Command Line Interface Edition - Source Code - DesktopEnvironment.cs
 * Intro: Main form of desktop environment of AdminCon.
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Modules.ACDesktop.Components
{
    public partial class DesktopEnvironment : Form
    {
        private Daemon perfMon = Daemon.GetInstance();
        private Single elapsedtime = 0f;
        public DesktopEnvironment()
        {
            InitializeComponent();
            ProcessListInit();
            this.timeTicker.Start();
            this.cpuUsageDynamicChart.ChartAreas[0].AxisY.Maximum = 100;
            this.cpuUsageDynamicChart.ChartAreas[0].AxisY.Minimum = -10;
            this.cpuUsageDynamicChart.ChartAreas[0].AxisX.Minimum = 0;
            this.cpuUsageDynamicChart.ChartAreas[0].AxisX.Maximum = 21;
        }

        private void ProcessListInit() //Initialize information of all processes.
        {
            List<Process> pArray = new List<Process>(Process.GetProcesses());
            pArray.Sort(new ProcessIDSorter());
            foreach(Process p in pArray)
            {
                string pFileName;
                try
                {
                    pFileName = p.MainModule.FileName;
                }catch(Exception)
                {
                    pFileName = "(Virtual Process)";
                }
                this.runningProcessListView.Items.Add(
                    new ListViewItem(
                        new string[]
                        {
                            p.Id+"",
                            p.ProcessName,
                            pFileName,
                            (Single)p.WorkingSet64/1024/1024+" MB"
                        }
                        )
                    );
            }
        }
        private void DesktopEnvironment_Load(Object sender, EventArgs e)
        {

        }
        private void desktopToolTip_Popup(Object sender, PopupEventArgs e)
        {

        }
        private void exitButtonPicBox_Click(Object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("You are now leaving AdminCon Desktop Environment. Confirm?",
                "AdminCon Desktop", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if(result.Equals(DialogResult.Yes))
            {
                Environment.Exit(0);
            }
        }
        private void exitButtonPicBox_MouseEnter(Object sender, EventArgs e)
        {
            ToolTip tooltip = new ToolTip();
            tooltip.ShowAlways = true;
            tooltip.SetToolTip(this.exitButtonPicBox, "Exit AC Desktop");
        }

        private void startButtonPicBox_Click(Object sender, EventArgs e)
        {

        }

        #region contextmenustrip
        private void windowsCommandPromptToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            Process.Start("cmd.exe");
        }

        private void powershellToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            Process.Start("powershell.exe");
        }

        private void adminConToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            Process.Start("ac.exe");
        }

        private void fileExplorerToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            Process.Start("explorer.exe");
        }

        private void refreshToolStripMenuItem_Click(Object sender, EventArgs e)
        {

        }
        private void contextMenuStrip_Opening(Object sender, CancelEventArgs e)
        {

        }
        private void DesktopEnvironment_MouseClick(Object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip.Show(MousePosition);
            }
        }

        private void taskManagerToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            Process.Start("taskmgr.exe");
        }

        private void performanceMonitorToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            Process.Start("perfmon.exe");
        }

        private void diskManagementToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            Process.Start("diskmgmt.msc");
        }

        private void deviceManagerToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            Process.Start("devmgmt.msc");
        }

        private void servicesToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            Process.Start("services.msc");
        }

        private void runToolStripMenuItem_Click(Object sender, EventArgs e)
        {
            StartProcessDialogForm dialogForm = new StartProcessDialogForm();
            dialogForm.Show();
        }
        #endregion

        private void DesktopEnvironment_KeyDown(Object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.LWin || e.KeyCode == Keys.RWin)
            {
                //Start
            }
            if(e.KeyCode == Keys.F12)
            {
                this.exitButtonPicBox_Click(sender, e);
            }
        }

        private void timeTicker_Tick(Object sender, EventArgs e)
        {
            //Add CPU and memory usages into chart.
            this.elapsedtime += 0.05f ;
            this.timeLabel.Text = System.DateTime.Now.ToString();
            this.diskIOSpeedLabel.Text = "Disk I/O Speed: "+Math.Round(perfMon.disk_IO_Speed / 1024 / 1024 , 2)+ " MB/sec";
            this.cpuUsageDynamicChart.Series["CPU Usage"].Points.AddXY(elapsedtime, perfMon.cpu_Usage);
            this.cpuUsageDynamicChart.Series["Memory Usage"].Points.AddXY(elapsedtime, Math.Round(perfMon.mem_Usage/(new ComputerInfo().TotalPhysicalMemory/1024), 3)*10);
            this.cpuUsageLabel.Text = Math.Round(perfMon.cpu_Usage,3)+ "%";
            this.memUsageLabel.Text = Math.Round(perfMon.mem_Usage / (new ComputerInfo().TotalPhysicalMemory / 1024), 3) * 10 + "%, "+
                Math.Round(perfMon.mem_Usage/1024, 3)+"MB";
            if (this.cpuUsageDynamicChart.Series["CPU Usage"].Points.Count > 400)
            {
                this.cpuUsageDynamicChart.Series["CPU Usage"].Points.Clear(); this.elapsedtime = 0;
            }
            if (this.cpuUsageDynamicChart.Series["Memory Usage"].Points.Count > 401)
            {
                this.cpuUsageDynamicChart.Series["Memory Usage"].Points.Clear(); this.elapsedtime = 0;
            }
        }

        private void runningProcessListView_MouseEnter(Object sender, EventArgs e)
        {
            ToolTip tooltip = new ToolTip();
            tooltip.ShowAlways = true;
            tooltip.SetToolTip(this.runningProcessListView, "Press F2 to refresh.");
        }

        private void runningProcessListView_KeyDown(Object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                this.runningProcessListView.Items.Clear();
                ProcessListInit();
            }
        }
    }
}
//Program Entry @ Launcher.cs