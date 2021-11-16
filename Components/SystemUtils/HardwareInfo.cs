using System;
using System.Management;
using AdminCon_CLI_dotnetEdition.Components.ConsoleDisplay;
/* AdminCon 7.0 Command Line Interface Edition - Source Code - HardwareInfo.cs
 * Intro: Get hardware information of PC.
 * Architecture: .NET Core 3.x & .NET Framework 4.x
 * (c) 2017-2021 Project Amadeus. All rights reserved.*/
namespace AdminCon_CLI_dotnetEdition.Components.SystemUtils
{
    /// <summary>
    /// Get hardware information of PC.
    /// </summary>
    class HardwareInfo
    {
        #region Get CPU Serial Number
        //Get CPU serial number
        private String GetCPUSerialNumber()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_Processor");
                String sCPUSerialNumber = "";
                foreach (ManagementObject MGMT_OBJ in searcher.Get())
                {
                    sCPUSerialNumber = MGMT_OBJ["ProcessorId"].ToString().Trim();
                    break;
                }
                return sCPUSerialNumber;
            }
            catch
            {
                return "";
            }
        }
        #endregion

        #region Get Motherboard Serial Number
        //Get mother board serial number
        private String GetBIOSSerialNumber()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("Select * From Win32_BIOS");
                String sBIOSSerialNumber = "";
                foreach (ManagementObject MGMT_OBJ in searcher.Get())
                {
                    sBIOSSerialNumber = MGMT_OBJ.GetPropertyValue("SerialNumber").ToString().Trim();
                    break;
                }
                return sBIOSSerialNumber;
            }
            catch
            {
                return "";
            }
        }
        #endregion

        #region Get Harddrive Serial Number
        ////Get disk serial number
        private String GetHardDiskSerialNumber()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
                String sHardDiskSerialNumber = "";
                foreach (ManagementObject MGMT_OBJ in searcher.Get())
                {
                    sHardDiskSerialNumber = MGMT_OBJ["SerialNumber"].ToString().Trim();
                    break;
                }
                return sHardDiskSerialNumber;
            }
            catch
            {
                return "";
            }
        }
        #endregion

        #region Get MAC Address
        //Get MAC address
        private String GetMACAddress()
        {
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_NetworkAdapter WHERE ((MACAddress Is Not NULL) AND (Manufacturer <> 'Microsoft'))");
                String NetCardMACAddress = "";
                foreach (ManagementObject MGMT_OBJ in searcher.Get())
                {
                    NetCardMACAddress = MGMT_OBJ["MACAddress"].ToString().Trim();
                    break;
                }
                return NetCardMACAddress;
            }
            catch
            {
                return "";
            }
        }
        #endregion
        public void prInt32HardwareInfo() //PrInt32 informations
        {
            ConsoleHL.WriteOutputLine("\n\nAdditional Hardware information:\n");
            ConsoleHL.WriteOutput("\n||   BIOS Serial Number: ");
            ConsoleHL.WritePromptLine(GetBIOSSerialNumber());
            ConsoleHL.WriteOutput("\n||   CPU Serial Number: ");
            ConsoleHL.WritePromptLine(GetCPUSerialNumber());
            ConsoleHL.WriteOutput("\n||   Localdisk Serial Number: ");
            ConsoleHL.WritePromptLine(GetHardDiskSerialNumber());
            ConsoleHL.WriteOutput("\n||   MAC Address: ");
            ConsoleHL.WritePromptLine(GetMACAddress());
        }
    }
}
//Program Entry @ Program.cs