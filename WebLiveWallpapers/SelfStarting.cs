using IWshRuntimeLibrary;
using System.Diagnostics;

namespace WebLiveWallpapers
{
    public class SelfStarting
    {
        private const string QuickName = "WebLiveWallpapers";

        private static string systemStartPath { get { return Environment.GetFolderPath(Environment.SpecialFolder.Startup); } }

        private static string appAllPath { get { return Process.GetCurrentProcess().MainModule.FileName; } }


        public static void SetMeAutoStart(bool onOff = true)
        {
            if (onOff)
            {
                List<string> shortcutPaths = GetQuickFromFolder(systemStartPath, appAllPath);
                if (shortcutPaths.Count >= 2)
                {
                    for (int i = 1; i < shortcutPaths.Count; i++)
                    {
                        DeleteFile(shortcutPaths[i]);
                    }
                }
                else if (shortcutPaths.Count < 1)
                {
                    CreateShortcut(systemStartPath, QuickName, appAllPath, "WebLiveWallpapers");
                }
            }
            else
            {
                List<string> shortcutPaths = GetQuickFromFolder(systemStartPath, appAllPath);
                if (shortcutPaths.Count > 0)
                {
                    for (int i = 0; i < shortcutPaths.Count; i++)
                    {
                        DeleteFile(shortcutPaths[i]);
                    }
                }
            }
        }

        private static bool CreateShortcut(string directory, string shortcutName, string targetPath, string description = null, string iconLocation = null)
        {
            try
            {
                if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);
                string shortcutPath = Path.Combine(directory, string.Format("{0}.lnk", shortcutName));
                WshShell shell = new WshShell();
                IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(shortcutPath);
                shortcut.TargetPath = targetPath;
                shortcut.WorkingDirectory = Path.GetDirectoryName(targetPath);
                shortcut.WindowStyle = 1;
                shortcut.Description = description;
                shortcut.IconLocation = string.IsNullOrWhiteSpace(iconLocation) ? targetPath : iconLocation;
                shortcut.Save();
                return true;
            }
            catch (Exception ex)
            {
                string temp = ex.Message;
                temp = "";
            }
            return false;
        }

        private static List<string> GetQuickFromFolder(string directory, string targetPath)
        {
            List<string> tempStrs = new List<string>();
            tempStrs.Clear();
            string tempStr = null;
            string[] files = Directory.GetFiles(directory, "*.lnk");
            if (files == null || files.Length < 1)
            {
                return tempStrs;
            }
            for (int i = 0; i < files.Length; i++)
            {
                tempStr = GetAppPathFromQuick(files[i]);
                if (tempStr == targetPath)
                {
                    tempStrs.Add(files[i]);
                }
            }
            return tempStrs;
        }

        private static string GetAppPathFromQuick(string shortcutPath)
        {
            if (System.IO.File.Exists(shortcutPath))
            {
                WshShell shell = new WshShell();
                IWshShortcut shortct = (IWshShortcut)shell.CreateShortcut(shortcutPath);
                return shortct.TargetPath;
            }
            else
            {
                return "";
            }
        }
        private static void DeleteFile(string path)
        {
            FileAttributes attr = System.IO.File.GetAttributes(path);
            if (attr == FileAttributes.Directory)
            {
                Directory.Delete(path, true);
            }
            else
            {
                System.IO.File.Delete(path);
            }
        }
    }
}
