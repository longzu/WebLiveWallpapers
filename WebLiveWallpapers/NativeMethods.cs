using System.Runtime.InteropServices;

namespace WebLiveWallpapers
{
    public static class NativeMethods
    {
        #region API
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public extern static IntPtr FindWindow(string lpClassName, string? lpWindowName);
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessageTimeout(IntPtr hwnd, uint msg, IntPtr wParam, IntPtr lParam, uint fuFlage, uint timeout, IntPtr result);
        [DllImport("user32.dll")]
        public static extern bool EnumWindows(EnumWindowsProc proc, IntPtr lParam);
        public delegate bool EnumWindowsProc(IntPtr hwnd, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string className, string? winName);
        [DllImport("user32.dll")]
        public static extern bool ShowWindow(IntPtr hwnd, int nCmdShow);
        [DllImport("user32.dll")]
        public static extern IntPtr SetParent(IntPtr wpfWindow, IntPtr parentHwnd);
        [DllImport("user32.dll")]
        public static extern bool SystemParametersInfo(uint uiAction, uint uiParam, uint pvParam, uint fWinIni);
        [DllImport("user32.dll")]
        public static extern IntPtr GetShellWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetForegroundWindow();
        [DllImport("user32", SetLastError = true)]
        public static extern bool PostMessage(IntPtr hWnd, int Msg, uint wParam, uint lParam);
        #endregion


        public static void SetDeskBottom(Form Window)
        {
            IntPtr programIntPtr = FindWindow("Progman", null);
            if (programIntPtr != IntPtr.Zero)
            {
                SendMessageTimeout(programIntPtr, 0x052C, IntPtr.Zero, IntPtr.Zero, 0x0000, 1000, IntPtr.Zero);
                EnumWindows((hwnd, lParam) =>
                {
                    if (FindWindowEx(hwnd, IntPtr.Zero, "SHELLDLL_DefView", null) != IntPtr.Zero)
                    {
                        IntPtr tempHwnd = FindWindowEx(IntPtr.Zero, hwnd, "WorkerW", null);
                        ShowWindow(tempHwnd, 1);
                        SetParent(Window.Handle, tempHwnd);
                    }
                    return true;
                }, IntPtr.Zero);
            }
        }

        public static void SetDeskBottomExit()
        {
            IntPtr programIntPtr = FindWindow("Progman", null);
            if (programIntPtr != IntPtr.Zero)
            {
                SendMessageTimeout(programIntPtr, 0x052C, IntPtr.Zero, IntPtr.Zero, 0x0000, 1000, IntPtr.Zero);
                EnumWindows((hwnd, lParam) =>
                {
                    if (FindWindowEx(hwnd, IntPtr.Zero, "SHELLDLL_DefView", null) != IntPtr.Zero)
                    {
                        IntPtr tempHwnd = FindWindowEx(IntPtr.Zero, hwnd, "WorkerW", null);
                        ShowWindow(tempHwnd, 0);
                        //Thread.Sleep(200);
                        //ShowWindow(tempHwnd, 1);
                    }
                    return true;
                }, IntPtr.Zero);
            }
        }

        public static IntPtr GetWebHwnd(IntPtr webview2Hwnd)
        {
            IntPtr hwnd1 = FindWindowEx(webview2Hwnd, IntPtr.Zero, "Chrome_WidgetWin_0", null);
            IntPtr hwnd2 = FindWindowEx(hwnd1, IntPtr.Zero, "Chrome_WidgetWin_1", null);
            return hwnd2;
        }

    }
}
