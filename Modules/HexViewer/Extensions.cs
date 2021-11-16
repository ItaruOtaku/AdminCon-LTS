/* AdminCon 6.0 Command Line Interface Edition - Source Code - Extensions.cs
 * Intro: Extension type and description reflection.
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
using System;

namespace AdminCon_CLI_dotnetEdition.Modules.HexViewer
{
    public static class Extensions
    {
        public static String Check(String extension)
        {
            String result = "";
            switch (extension.ToLower())
            {
                case ".apk":
                case ".aab":
                    result = "Android Application Package";
                    break;
                case ".acs":
                    result = "AdminCon Script File";
                    break;
                case ".acfg":
                    result = "AdminCon Config File";
                    break;
                case ".asm":
                    result = "Assembly Source File";
                    break;
                case ".asp":
                case ".aspx":
                    result = "Active Server Page";
                    break;
                case ".bat":
                case ".cmd":
                    result = "Windows NT Command Batch File";
                    break;
                case ".bin":
                    result = "Binary File";
                    break;
                case ".bmp":
                    result = "Bitmap Image";
                    break;
                case ".c":
                    result = "C Source File";
                    break;
                case ".cpp":
                case ".c++":
                    result = "C++ Source File";
                    break;
                case ".css":
                    result = "Cascading Style Sheet";
                    break;
                case ".com":
                    result = "DOS Program";
                    break;
                case ".cab":
                case ".rar":
                case ".zip":
                case ".7z":
                case ".tz":
                    result = "Compressed Folder";
                    break;
                case ".class":
                    result = "Java Bytecode File";
                    break;
                case ".cs":
                    result = "C# Source File";
                    break;
                case ".config":
                    result = "Configuration Source File";
                    break;
                case ".dll":
                    result = "Dynamic Link Library";
                    break;
                case ".drv":
                    result = "Windows Driver Application";
                    break;
                case ".doc":
                case ".docx":
                    result = "Microsoft Word Document";
                    break;
                case ".exe":
                    result = "Windows Executable File";
                    break;
                case ".fax":
                    result = "Fax Image";
                    break;
                case ".gho":
                    result = "Symantec Disk Clone";
                    break;
                case ".gif":
                    result = "Animated Image";
                    break;
                case ".h":
                case ".hpp":
                    result = "C/C++ Header File";
                    break;
                case ".hlp":
                    result = "Windows Help File";
                    break;
                case ".html":
                case ".htm":
                case ".xhtml":
                    result = "Hyper-text Document";
                    break;
                case ".ico":
                    result = "Icon File";
                    break;
                case ".inf":
                case ".ini":
                    result = "Windows Config Settings";
                    break;
                case ".iso":
                    result = "Disc Image";
                    break;
                case ".img":
                    result = "Disk Image";
                    break;
                case ".jar":
                case ".war":
                    result = "Java/Java Web Archive Package";
                    break;
                case ".java":
                    result = "Java Source File";
                    break;
                case ".jsp":
                    result = "Java Server Page";
                    break;
                case ".js":
                    result = "JavaScript Source File";
                    break;
                case ".json":
                    result = "JS Object Notation File";
                    break;
                case ".jpg":
                case ".jpeg":
                case ".jif":
                case ".jff":
                case ".jfif":
                    result = "JPEG Image File";
                    break;
                case ".lib":
                    result = "Static Library";
                    break;
                case ".log":
                    result = "Windows Log File";
                    break;
                case ".mp3":
                case ".wav":
                case ".flac":
                    result = "Audio Source File";
                    break;
                case ".mp4":
                case ".wmv":
                case ".mkv":
                case ".mov":
                case ".avi":
                    result = "Video Source File";
                    break;
                case ".midi":
                    result = "Digital Instrument File";
                    break;
                case ".mam":
                case ".maq":
                case ".mar":
                case ".mdb":
                case ".mdn":
                case ".mdw":
                    result = "Microsoft Access Source File";
                    break;
                case ".mpeg":
                case ".mpe":
                case ".mpg":
                    result = "MPEG Animation File";
                    break;
                case ".msi":
                    result = "Windows Installer";
                    break;
                case ".msn":
                    result = "Microsoft Web Document";
                    break;
                case ".o":
                    result = "Executable and Linkable Format(ELF)";
                    break;
                case ".obj":
                    result = "C/C++ Linkable File, Object 3D Source File"; ;
                    break;
                case ".php":
                case ".php3":
                    result = "PHP Source File";
                    break;
                case ".pas":
                    result = "Pascal Source File";
                    break;
                case ".phtml":
                    result = "HTML With PHP Source Code";
                    break;
                case ".pdf":
                    result = "Adobe Acrobat Document";
                    break;
                case ".psd":
                    result = "Adobe Photoshop Bitmap";
                    break;
                case ".pps":
                case ".ppt":
                    result = "Microsoft PowerPoint File";
                    break;
                case ".reg":
                    result = "Windows Registry File";
                    break;
                case ".rom":
                    result = "ROM Chip Copy";
                    break;
                case ".scr":
                    result = "Windows Screen Saver";
                    break;
                case ".sql":
                    result = "Database Query Script";
                    break;
                case ".sys":
                    result = "Windows Syetem File";
                    break;
                case ".theme":
                case ".themepack":
                    result = "Windows Theme Package";
                    break;
                case ".unity3d":
                    result = "Unity Web Player Scene";
                    break;
                case ".vb":
                    result = "Visual Basic Source File";
                    break;
                case ".vbs":
                    result = "Visual Basic Script File";
                    break;
                case ".xml":
                    result = "Extensible Markup Language Document";
                    break;
                case ".xlk":
                case ".xlm":
                case ".xls":
                case ".xlt":
                case ".xlw":
                    result = "Microsoft Excel File";
                    break;
                default:
                    result = extension + " File";
                    break;
            }
            return result;
        }
    }
}
