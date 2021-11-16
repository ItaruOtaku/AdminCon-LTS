using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Windows.Forms;
/* AdminCon 6.0 Command Line Interface Edition - Source Code - MainForm.cs
 * Intro: Main Windows Form for HexViewer.
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Modules.HexViewer
{
    public partial class MainForm : Form
    {
        public MainForm(String[] args) //args[0]: filepath
        {
            InitializeComponent();
            this.Display(
                HexStringsFormatter(
                    GetHexStrings(args[0])
                ), 
                this.GetFileInfo(args[0]));
        }
        private List<String> GetHexStrings(String path)
        {
            try
            {
                FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                StreamReader streamReader = new StreamReader(fileStream);

                //Local variables
                String allCharsInString = streamReader.ReadToEnd();
                Char[] allChars = allCharsInString.ToCharArray();
                List<byte> allCharsInByteArray = new List<byte>();
                List<String> allCharsInHexStrings = new List<String>();
                StringBuilder byteToHexStringConverter = new StringBuilder();

                //String -> Char[] -> List<byte>
                foreach (Char c in allChars)
                {
                    allCharsInByteArray.Add((byte)c);
                }

                //List<byte> -> List<"Hex">(which is List<String>)
                foreach (byte b in allCharsInByteArray)
                {
                    byteToHexStringConverter.AppendFormat("{0:x2}", b); //Convert byte to hex String.
                    allCharsInHexStrings.Add(byteToHexStringConverter.ToString());
                    byteToHexStringConverter.Clear();
                }
                return allCharsInHexStrings;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Exception Source: "+ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
                return null;
            }
        }
        private String GetFileInfo(String path)
        {
            FileInfo fileInfo = new FileInfo(path);
            FileVersionInfo fileVersionInfo = FileVersionInfo.GetVersionInfo(path);
            List<String> fileInfoList = new List<String>();
            StringBuilder fileInfoFormatter = new StringBuilder();

            //Basic Informations:
            String fileName    = "File Name: " + fileInfo.Name;
            String filePath    = "Path:      " + fileInfo.DirectoryName;
            String fileType    = "File Type: " + Extensions.Check(fileInfo.Extension);

            //Extensive Informations:
            String productName     = "Product Name:    " + fileVersionInfo.ProductName;
            String productVersion  = "Product Version: " + fileVersionInfo.ProductVersion;
            String fileVersion     = "File Version:    " + fileVersionInfo.FileVersion;
            String companyName     = "Company:         " + fileVersionInfo.CompanyName;
            String description     = "Description:     " + fileVersionInfo.FileDescription;
            String comments        = "Comments:\n" + fileVersionInfo.Comments;

            //Build info list:
            fileInfoList.Add("Basic Information:\n");
            fileInfoList.Add(fileName);
            fileInfoList.Add(filePath);
            fileInfoList.Add(fileType);
            fileInfoList.Add("\n\nAdvanced Information:\n");
            fileInfoList.Add(productName);
            fileInfoList.Add(productVersion);
            fileInfoList.Add(fileVersion);
            fileInfoList.Add(companyName);
            fileInfoList.Add(description);
            fileInfoList.Add(comments);

            //Build String from info list:
            foreach(String s in fileInfoList)
            {
                fileInfoFormatter.Append(s + "\n");
            }
            return fileInfoFormatter.ToString();
        }
        private String HexStringsFormatter(List<String> hexStringList)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (String s in hexStringList)
            {
                stringBuilder.Append(s + "   ");
            }
            return stringBuilder.ToString();
        }
        private void Display(String hex, String fileInfo)
        {
            this.viewHexRichTextBox.Text = hex;
            this.fileInfoRichTextBox.Text = fileInfo;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void fileInfoRichTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
