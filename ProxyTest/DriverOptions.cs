using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace ProxyTest
{
    public static class DriverOptions
    {

        public static ICapabilities ForRemoteBrowser(BrowserType browserType, Proxy proxy = null, string culture = null)
        {
            return CreateDesiredCapabilities(browserType, proxy, culture);
        }

        private static ICapabilities CreateDesiredCapabilities(BrowserType browserType, Proxy proxy = null,
            string culture = null)
        {
            OpenQA.Selenium.DriverOptions browserOptions;

            switch (browserType)
            {
                case BrowserType.Chrome:
                    browserOptions = ForChrome(proxy, culture);
                    break;
                default:
                    throw new ArgumentException($"unsupported browser type [{browserType}]", nameof(browserType));
            }

            return browserOptions.ToCapabilities();
        }

        #region DesktopChrome

        public static ChromeOptions ForChrome(Proxy proxy = null, string culture = null)
        {
            var chromeOptions = BaseChromeOptions(proxy, culture);
            chromeOptions = DisableExtensionsChromeOptions(chromeOptions);

            return chromeOptions;
        }

        public static ChromeOptions BaseChromeOptions(Proxy proxy = null, string culture = null)
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments(
                "--disable-site-isolation-trials",
                "--ignore-certificate-errors",
                "--disable-translate"
            );
            chromeOptions.SetLoggingPreference(LogType.Browser, LogLevel.All);

            if (proxy != null) chromeOptions.Proxy = proxy;

            if (culture != null) chromeOptions.AddUserProfilePreference("intl.accept_languages", culture);
            return chromeOptions;
        }

        public static ChromeOptions DisableExtensionsChromeOptions(ChromeOptions chromeOptions)
        {
            chromeOptions.AddArguments("--disable-extensions");
            return chromeOptions;
        }

        #endregion

    }
}