# **WebLiveWallpaper**
## **欢迎使用WebLiveWallpaper**
这是一款可以将HTML文件设置为动态桌面壁纸的软件,同时内置了JS可调用函数.
***
### **使用简介**
---
- 你可以使用HTML前端技术制作UI,使用JS调用软件内置的接口来和操作系统进行交互.
---
- 例如制作dock栏,系统信息面板等
---
- 获取设置系统音量,获取cpu/ram使用率,流量信息,交互打开本地存在的文件,应用等.
---

- 有趣操作提示 : html中跟随鼠标的动画效果,html中鼠标单击时的动画效果都可实现,css动画和视频等.
---
- 不怎么会写html,所以只制作了一个示例用的html.更多创意需要大家来完成了.以后我会开发可以分享主题的平台.加v群(vx243745915)讨论和分享制作的主题吧!
---
- **注意事项:替换软件根目录html文件夹内网页文件更换主题!主页html文件必须为index.html**
---
![m](https://github.com/longzu/WebLiveWallpapers/assets/112999405/fc533890-081f-4462-a499-c8d5caff449a)

### **接口简介**
你可以用各种有趣的创意调用来实现动态桌面壁纸.
```JS
var wc = window.chrome.webview.hostObjects.WallpaperClass;  //声明要用的c#内部类

async function wcInvoke(){
    var get1 = await wc.W_SpeakerVolume();                  //获取系统当前音量,返回当前音量int值给ha变量,失败返回-1
    var set1 = await wc.W_SpeakerVolume(50);               //设置系统音量为(int 0-100),成功返回 true,失败返回false
    var open1 = await wc.W_OpenRecyclebin();               //打开系统回收站,成功返回true,失败返回false
    await wc.W_OpenRecyclebin();                                //打开系统回收站
    var perform1 = await wc.W_OpenPath("c:\xxx\xxx");    //打开文件夹或者文件,或者exe,成功返回true,失败返回false
}
```
|执行类|api|备注
|---| ---| ---|
|执行系统关机|W_SysShutdown()|返回bool|
|执行系统重启|W_SysReboot()|返回bool|
|执行系统注销|W_SysLogout()|返回bool|
|执行系统锁定|W_SysLock()|返回bool|
|执行系统休眠|W_SysDormancy()|返回bool|
|执行系统睡眠|W_SysSleep()|返回bool|
|打开系统设置|W_OpenSettings()|返回bool|
|打开系统默认浏览器程序|W_OpenSysBrowser()|返回bool|
|打开系统默认计算器程序|W_OpenSysCalc()|返回bool|
|打开系统默认记事本程序|W_OpenSysNotepad()|返回bool|
|打开系统默认画图程序|W_OpenSysMspaint()|返回bool|
|打开本地app,文件夹,文件|W_OpenPath(string path)|返回bool|
|打开系统回收站|W_OpenRecyclebin()|返回bool|
|打开系统文件管理器|W_OpenFileMgr()|返回bool|
|打开系统文档管理器|W_OpenDocumentMgr()|返回bool|
|打开系统库文件夹|W_OpenLibraryFolder()|返回bool|
|清空系统回收站|W_RecycleSysBin()|返回bool|
|设置扬声器音量|W_SpeakerVolume(int 0-100)|返回bool|
---
|获取类|api|备注
|---| ---| ---|
|获取系统扬声器音量|W_SpeakerVolume()|返回int(0-100),失败返回-1|
|获取回收站是否为空|W_IsRecycleBinEmpty()|返回bool|
|获取磁盘总空间|W_DiskSpace(string driveName)|返回long,失败返回-1|
|获取磁盘可用空间|W_FreeDiskSpace(string driveName)|返回long,失败返回-1|
|获取上传的网络流量(Byte)|W_TotalUploadTraffic()|返回long,失败返回-1|
|获取下载的网络流量(Byte)|W_TotalDownloadTraffic()|返回long,失败返回-1|
|获取总物理内存的大小(MB)|W_TotalPhysicalMemory()|返回double,失败返回-1|
|获取可使用的物理内存的大小(MB)|W_AvailablePhysicalMemory()|返回double,失败返回-1|
|获取已使用内存的百分比|W_RamUsage()|返回uint(0-100),失败返回255|
|获取已使用cpu的百分比|W_CpuUsage()|返回uint(0-100),失败返回255|
|获取交流电源状态|W_ACLineStatus()|返回byte: 0 Offline;1 Online;255 Unknown status|
|获取电池充电状态|W_BatteryFlag()|返回byte: 0 电池未充电且电电量为中33%-66%之间;1 高,电量大于66%;2 低,小于33%;4 极低,小于5%;8 充电中;128 没有电池;255 未知,无法读取状态|
|获取电池还有百分比能充满|W_BatteryLifePercent()|返回byte: -1未知;失败返回0|
|获取秒为单位的满电电池可使用时间|W_BatteryFullLifeTime()|返回uint: -1未知;失败返回0|
|获取秒为单位的电池剩余使用时间|W_BatteryLifeTime()|返回uint: -1未知;失败返回0|
![vx](https://github.com/longzu/WebLiveWallpapers/assets/112999405/e692a96c-fedc-4dc3-aa9a-d8e48b93f3ec)
