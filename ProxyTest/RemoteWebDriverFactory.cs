using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading;
using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace ProxyTest
{
    public class RemoteWebDriverFactory : WebDriverFactory
    {
        private static readonly TimeSpan NodeRebootTimeout = TimeSpan.FromMinutes(2);

        private readonly TimeSpan _commandTimeout;

        private readonly String _hubHost;

        private readonly Int32 _hubPort;

        private readonly ILog _logger = LogManager.GetLogger(typeof(RemoteWebDriverFactory));

        private readonly Lazy<IFileDetector> _lazyFileDetector = new Lazy<IFileDetector>(
            () => new LocalFileDetector()
        );

        /// <summary>
        ///     Creates new instance of RemoteWebDriverFactory
        /// </summary>
        /// <param name="browserType">Browser Type</param>
        /// <param name="hubHost">Selenium Hub host</param>
        /// <param name="hubPort">Selenium hub port</param>
        /// <param name="commandTimeout">
        ///     how long WebDriver will wait for remote server response
        /// </param>
        public RemoteWebDriverFactory(BrowserType browserType, String hubHost, Int32 hubPort, TimeSpan commandTimeout) : base(browserType)
        {
            _hubHost = hubHost;
            _hubPort = hubPort;
            _commandTimeout = commandTimeout;
        }

        private ICapabilities tesst1()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.PlatformName = "Android";
            chromeOptions.UseSpecCompliantProtocol = true;

            chromeOptions.AddArgument("--disable-notifications");
            chromeOptions.AddArgument("--ignore-certificate-errors");

            chromeOptions.AddAdditionalCapability("platformVersion", "11", true);
            chromeOptions.AddAdditionalCapability("deviceName", "Galaxy Note 10 Plus", true);
            //chromeOptions.AddAdditionalCapability("w3c", false, true);

            //chromeOptions.AddAdditionalCapability("tunnel", true, true);
            return chromeOptions.ToCapabilities();
        }


        private ICapabilities opts()
        {
            //var chromeOptions = new ChromeOptions();
            //chromeOptions.BrowserVersion = "99.0";
            //chromeOptions.AddArgument("--disable-notifications");
            //chromeOptions.AddAdditionalCapability("build", "your build name", true);
            //chromeOptions.AddAdditionalCapability("name", "your test name", true);
            //chromeOptions.AddAdditionalCapability("platform", "Android", true);
            //chromeOptions.AddAdditionalCapability("tunnel", true, true);


            //chromeOptions.AddArgument("--disable-notifications");
            //chromeOptions.PlatformName = "Android";
            //chromeOptions.UseSpecCompliantProtocol = true;
            //chromeOptions.AddAdditionalCapability("deviceName", "Galaxy S10");
            //chromeOptions.AddAdditionalCapability("platformVersion", "11");

            var capabilities = new DesiredCapabilities();

            Dictionary<string, object> ltOptions = new Dictionary<string, object>();
            ltOptions.Add("user", "oleksandr.polazhynets");
            ltOptions.Add("accessKey", "gb2rWBKvLhP8juyJTjTNxPRafvqDNWEbDUcHpA9vzA9O9xnW9A");
            ltOptions.Add("build", "your build name");
            ltOptions.Add("name", "your test name");
            ltOptions.Add("platformName", "Android");
            ltOptions.Add("deviceName", "Galaxy S10");
            ltOptions.Add("platformVersion", "11");
            ltOptions.Add("w3c", "true");
            //ltOptions.Add("tunnel", true);
            capabilities.SetCapability("LT:Options", ltOptions);


            //chromeOptions.
            //chromeOptions.AddAdditionalCapability("name", "Mobile");
            //chromeOptions.AddAdditionalCapability("user", "oleksandr.polazhynets");
            //chromeOptions.AddAdditionalCapability("accessKey", "gb2rWBKvLhP8juyJTjTNxPRafvqDNWEbDUcHpA9vzA9O9xnW9A");

            //chromeOptions.AddAdditionalCapability("tunnel", true);
            //return chromeOptions.ToCapabilities();

            return capabilities;
        }

        private ICapabilities test()
        {
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--disable-notifications");
            //chromeOptions.AddAdditionalCapability("name", "single_test");
            //chromeOptions.AddAdditionalCapability("user", "oleksandr.polazhynets");
            //chromeOptions.AddAdditionalCapability("accessKey", "gb2rWBKvLhP8juyJTjTNxPRafvqDNWEbDUcHpA9vzA9O9xnW9A");

            var capabilities = new DesiredCapabilities();

            capabilities.SetCapability("tunnel", true);

            //capabilities.SetCapability("platformName", "Android");
            //capabilities.SetCapability("deviceName", "Galaxy S10");
            //capabilities.SetCapability("platformVersion", "11");
            //capabilities.SetCapability("w3c", false);
            capabilities.SetCapability("platform", "Windows 10");
            capabilities.SetCapability("browser", "Chrome");
            capabilities.SetCapability("version", "99");

            capabilities.SetCapability(ChromeOptions.Capability, chromeOptions);

            return capabilities;
            //Driver = new RemoteWebDriver(new Uri("http://" + "username" + ":" + "accesskey" + "@hub.lambdatest.com" + "/wd/hub/"), chromeOptions.ToCapabilities());
        }

        private ICapabilities foo()
        {


            var capabilities = new DesiredCapabilities();
            capabilities.SetCapability("name", "Iphone_emulator");
            //capabilities.SetCapability("user", "oleksandr.polazhynets");
            //capabilities.SetCapability("accessKey", "gb2rWBKvLhP8juyJTjTNxPRafvqDNWEbDUcHpA9vzA9O9xnW9A");
            //capabilities.SetCapability("name", "test");
            ////capabilities.SetCapability("platformName", "iOS");
            ////capabilities.SetCapability("deviceName", "iPhone 13 Pro");
            ////capabilities.SetCapability("platformVersion", "15.0");

            //capabilities.SetCapability("platformName", "Android");
            //capabilities.SetCapability("deviceName", "Galaxy S10");
            //capabilities.SetCapability("platformVersion", "11");
            //capabilities.SetCapability("w3c", false);
            //capabilities.SetCapability("appiumVersion", "1.17.0");
            //capabilities.SetCapability("platformName", "Android");
            //capabilities.SetCapability("deviceName", "Galaxy S21 5G");
            //capabilities.SetCapability("platformVersion", "11");

            //======================= real devices
            //capabilities.SetCapability("platformName", "iOS");
            //capabilities.SetCapability("deviceName", "iPhone 13");
            //capabilities.SetCapability("isRealMobile", true);
            //capabilities.SetCapability("platformVersion", "15.0");
            //capabilities.SetCapability("platformName", "Android");
            //capabilities.SetCapability("deviceName", "Galaxy Note20 Ultra 5G");
            //capabilities.SetCapability("isRealMobile", true);
            //capabilities.SetCapability("platformVersion", "11");
            //=========================== desktop
            capabilities.SetCapability("platform", "Windows 10"); // Selected Operating System
            capabilities.SetCapability("browser", "Chrome"); // Selected browser name
            capabilities.SetCapability("version", "99");
            capabilities.SetCapability("network", true);

            capabilities.SetCapability("tunnel", true);
            capabilities.SetCapability("tunnelName", "LambdaTest_uz004");// Selected browser version
            //capabilities.SetCapability("resolution", "1024x768"); // Selected screen resolution
            //capabilities.SetCapability("selenium_version", "3.13.0");
            return capabilities;
        }

        protected override IWebDriver CreateWebDriver(OpenQA.Selenium.Proxy proxy, string culture)
        {
            //var hubUri = new Uri($"http://{_hubHost}:{_hubPort}/wd/hub");
            //var hubUri = new Uri($"https://oleksandr.polazhynets:gb2rWBKvLhP8juyJTjTNxPRafvqDNWEbDUcHpA9vzA9O9xnW9A@hub.lambdatest.com/wd/hub");
            //var hubUri = new Uri($"https://hub.lambdatest.com/wd/hub");

            //var hubUri = new Uri($"https://beta-hub.lambdatest.com/wd/hub");

            var hubUri = new Uri($"http://{_hubHost}:{_hubPort}/wd/hub");
            //var capabilities = DriverOptions.ForRemoteBrowser(BrowserType, proxy, culture);

            //if (BrowserType.Equals(BrowserType.Android) || BrowserType.Equals(BrowserType.IOS))
            //{
            //hubUri = new Uri($"https://oleksandr.polazhynets:gb2rWBKvLhP8juyJTjTNxPRafvqDNWEbDUcHpA9vzA9O9xnW9A@hub.lambdatest.com/wd/hub");
            hubUri = new Uri($"https://dl-visual-testing:FIistq21kEplnJUFxiMzeFZPtFWVoQFJIKBpx0Qkel1btjXKgG@hub.lambdatest.com/wd/hub");
            //hubUri = new Uri($"https://oleksandr.polazhynets:gb2rWBKvLhP8juyJTjTNxPRafvqDNWEbDUcHpA9vzA9O9xnW9A@beta-hub.lambdatest.com/wd/hub");

            var capabilities = foo();
            //}
            //var capabilities = DriverOptions.ForRemoteBrowser(BrowserType, proxy,culture);


            //var capabilities = test();//DriverOptions.ForRemoteBrowser(BrowserType, proxy,culture);

            for (var i = 0; ; i++)
            {
                RemoteWebDriver wd = null;

                try
                {
                    //192.168.128.42:55439
                    //HttpCommandExecutor commandExecutor = new HttpCommandExecutor(new Uri("https://username:accesskey@hub.lambdatest.com/"), TimeSpan.FromSeconds(60));
                    //commandExecutor.Proxy = new WebProxy($"{proxy.)}:proxy_port", false)};


                    wd = new RemoteWebDriver(hubUri, capabilities, _commandTimeout)
                    {
                        FileDetector = _lazyFileDetector.Value
                    };

                    wd.Navigate().GoToUrl("about:blank");

                    return wd;
                }
                catch (Exception ex)
                {
                    _logger.Error("Failed to create RemoteWebDriver", ex);

                    if (wd != null)
                    {
                        wd.Quit();
                        wd.Dispose();
                    }

                    if (i >= 5)
                    {
                        throw;
                    }

                    if (IsNodeRebootTriggeredError(ex))
                    {
                        _logger.WarnFormat("There are no nodes matching requested capabilities. Waiting for node to reboot for {0}.", NodeRebootTimeout);

                        Thread.Sleep(NodeRebootTimeout);
                    }
                }
            }
        }

        private static bool IsNodeRebootTriggeredError(Exception ex)
        {
            if (ex == null)
            {
                return false;
            }

            return ex.Message.Contains("Empty pool of VM for setup Capabilities")
                   || ex.Message.Contains("Error forwarding the new session")
                   || ex.Message.Contains("Could not find a connected Android device.")
                   || ex.Message.Contains("was not in the list of connected devices");
        }

    }
}