using System;

namespace ProxyTest
{
    [Flags]
    public enum BrowserType
    {
        Firefox = 0x1,
        Chrome = 0x2,
        InternetExplorer = 0x4,
        Edge = 0x8,
        EmulatedTabletChrome = 0x10,
        Android = 0x20,
        IOS = 0x40,
        Safari = 0x80,
        EmulatedMobileChrome = 0x100,
        IPad = 0x200,
        AndroidNative = 0x400,
        AndroidNativeSamsung = 0x800,
        ChromeWithExtension = 0x1000,
        Any = 0xffff
    }
}