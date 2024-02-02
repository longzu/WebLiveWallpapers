using NAudio.CoreAudioApi;
using System.Diagnostics;
using System.Management;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using Shell32;
using System.Security.Cryptography.Xml;

namespace WebLiveWallpapers
{
    [ClassInterface(ClassInterfaceType.AutoDual)]
    [ComVisible(true)]
    public class WallpaperClass
    {
        #region API
        [DllImport("user32")]
        public static extern bool ExitWindowsEx(uint uFlags, uint dwReason);
        [DllImport("PowrProf.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern bool SetSuspendState(bool hiberate, bool forceCritical, bool disableWakeEvent);
        [DllImport("user32.dll")]
        public static extern bool LockWorkStation();
        [DllImportAttribute("shell32.dll")]
        public static extern int SHEmptyRecycleBin(IntPtr handle, string root, int falgs);
        //内存
        [StructLayout(LayoutKind.Sequential)]
        public struct MemoryInfo
        {
            public uint Length;
            public uint MemoryLoad;
            public ulong TotalPhysical;//总内存
            public ulong AvailablePhysical;//可用物理内存
            public ulong TotalPageFile;
            public ulong AvailablePageFile;
            public ulong TotalVirtual;
            public ulong AvailableVirtual;
        }
        [DllImport("kernel32")]
        public static extern void GlobalMemoryStatus(ref MemoryInfo meminfo);
        MemoryInfo MemInfo = new();
        #endregion
        private bool offon()
        {
            return true;
        }

        /// <summary>
        /// Perform a system shutdown
        /// </summary>
        /// <returns></returns>
        public bool W_SysShutdown()
        {
            if (offon() == true)
            {
                try { Process.Start("shutdown", "/s /t 0"); return true; } catch { return false; }
            }
            else { return false; }
        }

        /// <summary>
        /// Perform a system reboot
        /// </summary>
        /// <returns></returns>
        public bool W_SysReboot()
        {
            if (offon() == true)
            {
                try { Process.Start("shutdown", "/r /t 0"); return true; } catch { return false; }
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Perform a system logout
        /// </summary>
        /// <returns></returns>
        public bool W_SysLogout()
        {
            if (offon() == true)
            {
                try { ExitWindowsEx(0, 0); return true; } catch { return false; }
            }
            else { return false; }
        }

        /// <summary>
        /// Perform a system lock
        /// </summary>
        /// <returns></returns>
        public bool W_SysLock()
        {
            if (offon() == true)
            {
                try { LockWorkStation(); return true; } catch { return false; }
            }
            else { return false; }
        }

        /// <summary>
        /// Perform system hibernation
        /// </summary>
        /// <returns></returns>
        public bool W_SysDormancy()
        {
            if (offon() == true)
            {
                try { SetSuspendState(true, true, true); return true; } catch { return false; }
            }
            else { return false; }
        }

        /// <summary>
        /// Executive system sleep
        /// </summary>
        /// <returns></returns>
        public bool W_SysSleep()
        {
            if (offon() == true)
            {
                try { SetSuspendState(false, true, true); return true; } catch { return false; }
            }
            else { return false; }
        }

        /// <summary>
        /// Open System Settings
        /// </summary>
        /// <returns></returns>
        public bool W_OpenSettings()
        {
            if (offon() == true)
            {
                try { Process.Start("ms-settings:"); return true; } catch { return false; }
            }
            else { return false; }
        }

        /// <summary>
        /// Open your system's default browser program
        /// </summary>
        /// <returns></returns>
        public bool W_OpenSysBrowser()
        {
            if (offon() == true)
            {
                try { Process.Start("explorer", "http://"); return true; } catch { return false; }
            }
            else { return false; }
        }

        /// <summary>
        /// Open the system default calculator program
        /// </summary>
        /// <returns></returns>
        public bool W_OpenSysCalc()
        {
            if (offon() == true)
            {
                try { Process.Start("calc.exe"); return true; } catch { return false; }
            }
            else { return false; }
        }

        /// <summary>
        /// Open the system's default Notepad program
        /// </summary>
        /// <returns></returns>
        public bool W_OpenSysNotepad()
        {
            if (offon() == true)
            {
                try { Process.Start("notepad.exe"); return true; } catch { return false; }
            }
            else { return false; }
        }

        /// <summary>
        /// Open the system's default Paint program
        /// </summary>
        /// <returns></returns>
        public bool W_OpenSysMspaint()
        {
            if (offon() == true)
            {
                try { Process.Start("mspaint.exe"); return true; } catch { return false; }
            }
            else { return false; }
        }

        /// <summary>
        /// Open local apps, folders, files
        /// </summary>
        /// <param name="path"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool W_OpenPath(string path, string data)
        {
            if (offon() == true)
            {
                try { Process.Start(path, data); return true; } catch { return false; }
            }
            else { return false; }
        }

        /// <summary>
        /// Open local apps, folders, files
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public bool W_OpenPath(string path)
        {
            if (offon() == true)
            {
                try { Process.Start(path); return true; } catch { return false; }
            }
            else { return false; }
        }

        /// <summary>
        /// Open the system recycle bin
        /// </summary>
        /// <returns></returns>
        public bool W_OpenRecyclebin()
        {
            if (offon() == true)
            {
                try { Process.Start("explorer.exe", "::{645FF040-5081-101B-9F08-00AA002F954E}"); return true; } catch { return false; }
            }
            else { return false; }
        }

        /// <summary>
        /// Open System File Manager
        /// </summary>
        /// <returns></returns>
        public bool W_OpenFileMgr()
        {
            if (offon() == true)
            {
                try { Process.Start("explorer.exe", "::{20D04FE0-3AEA-1069-A2D8-08002B30309D}"); return true; } catch { return false; }
            }
            else { return false; }
        }

        /// <summary>
        /// Open System Document Manager
        /// </summary>
        /// <returns></returns>
        public bool W_OpenDocumentMgr()
        {
            if (offon() == true)
            {
                try { Process.Start("explorer.exe", "::{450d8fba-ad25-11d0-98a8-0800361b1103}"); return true; } catch { return false; }
            }
            else { return false; }
        }

        /// <summary>
        /// Open the System Library folder
        /// </summary>
        /// <returns></returns>
        public bool W_OpenLibraryFolder()
        {
            if (offon() == true)
            {
                try { Process.Start("explorer.exe", "::{031E4825-7B94-4dc3-B131-E946B44C8DD5}"); return true; } catch { return false; }
            }
            else { return false; }
        }

        /// <summary>
        /// Set the speaker volume
        /// </summary>
        /// <param name="volume">0-100</param>
        /// <returns></returns>
        public bool W_SpeakerVolume(int volume)
        {
            if (offon() == true)
            {
                try
                {
                    var enumerator = new MMDeviceEnumerator();
                    IEnumerable<MMDevice> speakDevices = enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active).ToArray();
                    if (speakDevices.Count() > 0)
                    {

                        MMDevice mMDevice = speakDevices.ToList()[0];
                        mMDevice.AudioEndpointVolume.MasterVolumeLevelScalar = volume / 100.0f;
                    }
                    return true;
                }
                catch { return false; }
            }
            else { return false; }
        }

        /// <summary>
        /// Get the system speaker volume
        /// </summary>
        /// <returns></returns>
        public int W_SpeakerVolume()
        {
            if (offon() == true)
            {
                try
                {
                    int volume = 0;
                    var enumerator = new MMDeviceEnumerator();
                    IEnumerable<MMDevice> speakDevices = enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active).ToArray();
                    if (speakDevices.Count() > 0)
                    {
                        MMDevice mMDevice = speakDevices.ToList()[0];
                        volume = Convert.ToInt16(mMDevice.AudioEndpointVolume.MasterVolumeLevelScalar * 100);
                    }
                    return volume;
                }
                catch { return -1; }
            }
            else { return -1; }
        }

        /// <summary>
        /// Empty the system recycle bin
        /// </summary>
        /// <returns></returns>
        public bool W_RecycleSysBin()
        {
            if (offon() == true)
            {
                try { _ = SHEmptyRecycleBin(IntPtr.Zero, "", 0x000001 + 0x000002 + 0x000004); return true; } catch { return false; }
            }
            else { return false; }
        }

        /// <summary>
        /// Gets the total disk space(Byte)
        /// </summary>
        /// <param name="driveName"></param>
        /// <returns></returns>
        public long W_DiskSpace(string driveName)
        {
            if (offon() == true)
            {
                long l = 0;
                string driveNames = driveName + ":";
                try
                {
                    WqlObjectQuery wqlObjectQuery = new(string.Format("SELECT * FROM Win32_LogicalDisk WHERE DeviceID = '{0}'", driveNames.Substring(0, 2)));
                    ManagementObjectSearcher managerSearch = new ManagementObjectSearcher(wqlObjectQuery);
                    foreach (ManagementObject mobj in managerSearch.Get().Cast<ManagementObject>())
                    {
                        l = Convert.ToInt64(mobj["Size"]);
                    }
                    return l;
                }
                catch { return -1; }
            }
            else { return -1; }
        }

        /// <summary>
        /// Get free disk space(Byte)
        /// </summary>
        /// <param name="driveName"></param>
        /// <returns></returns>
        public long W_FreeDiskSpace(string driveName)
        {
            if (offon() == true)
            {
                long l = 0;
                string driveNames = driveName + ":";
                try
                {
                    WqlObjectQuery wqlObjectQuery = new(string.Format("SELECT * FROM Win32_LogicalDisk WHERE DeviceID = '{0}'", driveNames.Substring(0, 2)));
                    ManagementObjectSearcher managerSearch = new ManagementObjectSearcher(wqlObjectQuery);
                    foreach (ManagementObject mobj in managerSearch.Get().Cast<ManagementObject>())
                    {
                        l = Convert.ToInt64(mobj["FreeSpace"]);
                    }
                    return l;
                }
                catch { return -1; }
            }
            else { return -1; }
        }

        /// <summary>
        /// Get the uploaded network traffic(Byte)
        /// </summary>
        /// <returns></returns>
        public long W_TotalUploadTraffic()
        {
            if (offon() == true)
            {
                try
                {
                    NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
                    long totalUploadTraffic = 0;
                    foreach (NetworkInterface ni in interfaces)
                    {
                        totalUploadTraffic += ni.GetIPv4Statistics().BytesSent;
                    }
                    return totalUploadTraffic;
                }
                catch { return -1; }
            }
            else { return -1; }
        }

        /// <summary>
        /// Get the network traffic for the download(Byte)
        /// </summary>
        /// <returns></returns>
        public long W_TotalDownloadTraffic()
        {
            if (offon() == true)
            {
                try
                {
                    NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
                    long totalDownloadTraffic = 0;
                    foreach (NetworkInterface ni in interfaces)
                    {
                        totalDownloadTraffic += ni.GetIPv4Statistics().BytesReceived;
                    }
                    return totalDownloadTraffic;

                }
                catch { return -1; }
            }
            else { return -1; }
        }

        /// <summary>
        /// Gets the size of the total physical memory(MB)
        /// </summary>
        /// <returns></returns>
        public double W_TotalPhysicalMemory()
        {
            if (offon() == true)
            {
                double capacity;
                try
                {
                    GlobalMemoryStatus(ref MemInfo);
                    capacity = MemInfo.TotalPhysical / 1024 / 1024;
                }
                catch
                {
                    capacity = -1;
                }
                return capacity;
            }
            else { return -1; }
        }

        /// <summary>
        /// Gets the size of the physical memory that can be used(MB)
        /// </summary>
        /// <returns></returns>
        public double W_AvailablePhysicalMemory()
        {
            if (offon() == true)
            {
                double capacity;
                try
                {
                    capacity = MemInfo.AvailablePhysical / 1024 / 1024;
                }
                catch
                {
                    capacity = -1;
                }
                return capacity;
            }
            else { return -1; }
        }

        /// <summary>
        /// Gets the percentage of memory used
        /// </summary>
        /// <returns></returns>
        public uint W_RamUsage()
        {
            if (offon() == true)
            {
                uint capacity;
                try
                {
                    GlobalMemoryStatus(ref MemInfo);
                    capacity = MemInfo.MemoryLoad;
                }
                catch
                {
                    capacity = 255;
                }
                return capacity;
            }
            else { return 255; }
        }

        public PerformanceCounter CpuOccupied = new PerformanceCounter("Processor Information", "% Processor Utility", "_Total");
        /// <summary>
        /// Get CPU usage
        /// </summary>
        /// <returns></returns>
        public uint W_CpuUsage()
        {
            if (offon() == true)
            {
                try { return (uint)CpuOccupied.NextValue(); } catch { return 255; }
            }
            else { return 255; }
        }

        [DllImport("kernel32.dll")]
        static extern bool GetSystemPowerStatus(out SYSTEM_POWER_STATUS powerStatus);
        struct SYSTEM_POWER_STATUS
        {
            public byte ACLineStatus;
            public byte BatteryFlag;
            public byte BatteryLifePercent;
            public byte Reserved1;
            public uint BatteryLifeTime;
            public uint BatteryFullLifeTime;
        }
        /// <summary>
        /// Obtain AC power status;0 Offline;1 Online;255 Unknown status
        /// </summary>
        /// <returns></returns>
        public byte W_ACLineStatus()
        {
            if (offon() == true)
            {
                try
                {
                    SYSTEM_POWER_STATUS powerStatus;
                    GetSystemPowerStatus(out powerStatus);
                    return powerStatus.ACLineStatus;
                }
                catch { return 255; }
            }
            else { return 255; }
        }

        /// <summary>
        /// Obtain the battery state of charge
        /// </summary>
        /// <returns></returns>
        public byte W_BatteryFlag()
        {
            if (offon() == true)
            {
                try
                {
                    SYSTEM_POWER_STATUS powerStatus;
                    GetSystemPowerStatus(out powerStatus);
                    return powerStatus.BatteryFlag;
                }
                catch { return 255; }
            }
            else { return 255; }
        }

        /// <summary>
        /// A few percent of the battery can be fully charged.0~100
        /// </summary>
        /// <returns></returns>
        public byte W_BatteryLifePercent()
        {
            if (offon() == true)
            {
                try
                {
                    SYSTEM_POWER_STATUS powerStatus;
                    GetSystemPowerStatus(out powerStatus);
                    return powerStatus.BatteryLifePercent;
                }
                catch { return 255; }
            }
            else { return 255; }
        }

        /// <summary>
        /// The service life of a fully charged battery in seconds
        /// </summary>
        /// <returns></returns>
        public uint W_BatteryFullLifeTime()
        {
            if (offon() == true)
            {
                try
                {
                    SYSTEM_POWER_STATUS powerStatus;
                    GetSystemPowerStatus(out powerStatus);
                    return powerStatus.BatteryFullLifeTime;
                }
                catch { return 0; }
            }
            else { return 0; }
        }

        /// <summary>
        /// The remaining battery life in seconds
        /// </summary>
        /// <returns></returns>
        public uint W_BatteryLifeTime()
        {
            if (offon() == true)
            {
                try
                {
                    SYSTEM_POWER_STATUS powerStatus;
                    GetSystemPowerStatus(out powerStatus);
                    return powerStatus.BatteryLifeTime;
                }
                catch { return 0; }
            }
            else { return 0; }
        }

        /// <summary>
        /// Get if the system recycle bin is empty
        /// </summary>
        /// <returns></returns>
        public bool W_IsRecycleBinEmpty()
        {
            if (offon() == true)
            {
                try
                {
                    Shell shell = new Shell();
                    Folder recycleBin = shell.NameSpace(10);
                    FolderItems items = recycleBin.Items();
                    return items.Count == 0;
                }
                catch { return true; }
            }
            else { return true; }
        }

    }
}
