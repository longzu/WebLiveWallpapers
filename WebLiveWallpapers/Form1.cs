using Microsoft.Web.WebView2.Core;

namespace WebLiveWallpapers
{
    public partial class WebLiveWallpaper : Form
    {
        private string WallpaperPath = Environment.CurrentDirectory + @"\html";   //wallpaper Path
        private readonly Microsoft.Web.WebView2.WinForms.WebView2 webView21 = new(); //webview2
        public static Win32.Hooks.MouseHook mouseHook = new Win32.Hooks.MouseHook();  //MouseHook

        //  Main
        public WebLiveWallpaper()
        {
            this.StartPosition = FormStartPosition.Manual;
            InitializeComponent();
            this.Load += new EventHandler(Form1_Load);
        }

        //  Window Load 
        private void Form1_Load(object? sender, EventArgs e)
        {
            NativeMethods.SystemParametersInfo(0x1043, 0, (uint)(true ? 1 : 0), 0x1 | 0x2);
            this.FormBorderStyle = FormBorderStyle.None;
            this.Width = SystemInformation.PrimaryMonitorSize.Width;
            this.Height = SystemInformation.PrimaryMonitorSize.Height;
            webView21.Padding = new Padding(0, 0, 0, 0);
            webView21.Margin = new Padding(0, 0, 0, 0);
            webView21.Location = new Point(0, 0);
            webView21.EnsureCoreWebView2Async();
            this.Controls.Add(webView21);
            NativeMethods.SetDeskBottom(this);  // Window Bottom
            InitializeAsync();
            mouseHook.LeftDown += MouseHook_LeftDown;
            mouseHook.LeftUp += MouseHook_LeftUp;
            mouseHook.MouseMove += MouseHook_MouseMove;
            mouseHook.Start();
        }

        //  Webview2 Initialize
        async void InitializeAsync()
        {
            await webView21.EnsureCoreWebView2Async(null);
            webView21.CoreWebView2.SetVirtualHostNameToFolderMapping("WebLiveWallpaper", WallpaperPath, CoreWebView2HostResourceAccessKind.Allow);
            webView21.CoreWebView2.Settings.AreDevToolsEnabled = false;
            webView21.CoreWebView2.Settings.AreDefaultContextMenusEnabled = false;
            webView21.Width = this.Width;
            webView21.Height = this.Height;
            webView21.CoreWebView2.Navigate("https://WebLiveWallpaper/index.html");
            webView21.CoreWebView2.AddHostObjectToScript("WallpaperClass", new WallpaperClass());
        }

        #region Mouse Hook
        private void MouseHook_MouseMove(object? sender, MouseEventArgs e)
        {
            FuncMouseEvent(0x0200, 1, e);
        }
        private void MouseHook_LeftUp(object? sender, MouseEventArgs e)
        {
            FuncMouseEvent(0x0202, 0, e);
        }
        private void MouseHook_LeftDown(object? sender, MouseEventArgs e)
        {
            FuncMouseEvent(0x0201, 0, e);
        }
        private void FuncMouseEvent(int msg, uint i, MouseEventArgs e)
        {
            if (NativeMethods.GetForegroundWindow() == GetDesktopWindow(DesktopWindow.SHELLDLL_DefViewParent))
            {
                try
                {
                    NativeMethods.PostMessage(NativeMethods.GetWebHwnd(webView21.Handle), msg, i, (uint)(e.X + (e.Y << 16)));
                }
                catch { }
            }
            Thread.Sleep(10);
        }

        private enum DesktopWindow
        {
            ProgMan,
            SHELLDLL_DefViewParent,
            SHELLDLL_DefView,
            SysListView32,
        }
        private static IntPtr GetDesktopWindow(DesktopWindow desktopWindow)
        {
            IntPtr _ProgMan = NativeMethods.GetShellWindow();
            IntPtr _SHELLDLL_DefViewParent = _ProgMan;
            IntPtr _SHELLDLL_DefView = NativeMethods.FindWindowEx(_ProgMan, IntPtr.Zero, "SHELLDLL_DefView", null);
            IntPtr _SysListView32 = NativeMethods.FindWindowEx(_SHELLDLL_DefView, IntPtr.Zero, "SysListView32", "FolderView");
            if (_SHELLDLL_DefView == IntPtr.Zero)
            {
                NativeMethods.EnumWindows((hwnd, lParam) =>
                {

                    if (Win32.Windows.GetClassName(hwnd) == "WorkerW")
                    {
                        IntPtr WorkerW1 = hwnd;
                        IntPtr child = NativeMethods.FindWindowEx(hwnd, IntPtr.Zero, "SHELLDLL_DefView", null);
                        if (child != IntPtr.Zero)
                        {
                            _SHELLDLL_DefViewParent = hwnd;
                            _SHELLDLL_DefView = child;
                            _SysListView32 = NativeMethods.FindWindowEx(child, IntPtr.Zero, "SysListView32", "FolderView"); ;
                            return false;
                        }
                    }
                    return true;
                }, IntPtr.Zero);
            }
            switch (desktopWindow)
            {
                case DesktopWindow.ProgMan:
                    return _ProgMan;
                case DesktopWindow.SHELLDLL_DefViewParent:
                    return _SHELLDLL_DefViewParent;
                case DesktopWindow.SHELLDLL_DefView:
                    return _SHELLDLL_DefView;
                case DesktopWindow.SysListView32:
                    return _SysListView32;
                default:
                    return IntPtr.Zero;
            }
        }
        #endregion


        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.Show();
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            NativeMethods.SetDeskBottomExit();
            mouseHook.Stop();
            Application.Exit();
        }
    }
}
