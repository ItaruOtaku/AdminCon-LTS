using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
/* AdminCon 7.0 Command Line Interface Edition - Source Code - StartProcessDialogForm.cs
 * Intro: Dialog form when trying to run a process.
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Modules.ACDesktop.Components
{
    public partial class StartProcessDialogForm : Form
    {
        public StartProcessDialogForm()
        {
            InitializeComponent();
        }

        private void OKButton_Click(Object sender, EventArgs e)
        {
            
            try
            {
                //Run Process
                Process p = new Process();
                p.StartInfo = new ProcessStartInfo(this.processNameTextBox.Text);
                p.Start();
                this.Dispose();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelButton_Click(Object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void processNameTextBox_KeyDown(Object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                this.OKButton_Click(sender, e);
            }
        }
    }
}
//Program Entry @ Launcher.cs