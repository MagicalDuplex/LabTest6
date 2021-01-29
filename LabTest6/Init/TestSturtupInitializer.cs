using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;

namespace LabTest6.Init
{
    /// <summary>
    /// Представляет собой класс, который инициализирует окружение для UI-тестирования веб-приложений.
    /// </summary>
    public abstract class TestStartupInitializer : ITestStartupInitializer, IDisposable
    {
        private Lazy<Uri> _rootUriInitializer;
        private Lazy<IWebDriver> _driverInitializer;

        public Uri RootUri => _rootUriInitializer.Value;
        public IWebDriver Driver => _driverInitializer.Value;


        protected TestStartupInitializer()
        {
            InitLazy();
        }

        private void InitLazy()
        {
            _rootUriInitializer = new Lazy<Uri>(StartAndGetRootUri);
            _driverInitializer = new Lazy<IWebDriver>(CreateWebDriver);
        }

        

        protected virtual Uri StartAndGetRootUri()
        {

            return new Uri("https://wordpress.com/ru/");
        }

        public void Dispose() => Dispose(true);

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Driver?.Dispose();
            }
        }

        public void EnsureServerRestart()
        {
            Dispose();
            InitLazy();
        }


        protected abstract IWebDriver CreateWebDriver();
    }

    public class TestStartupInitializerDefault : TestStartupInitializer
    {
        /// <inheritdoc />
        protected override IWebDriver CreateWebDriver()
        {
            var service = ChromeDriverService.CreateDefaultService();
            service.HideCommandPromptWindow = true;

            var options = new ChromeOptions();
            
            options.PageLoadStrategy = PageLoadStrategy.Eager;

            options.AddArgument("--lang=ru-ru");

            options.AddArgument("start-maximized"); // https://stackoverflow.com/a/26283818/1689770
            options.AddArgument("enable-automation"); // https://stackoverflow.com/a/43840128/1689770
            
            options.AddArgument("--no-sandbox"); //https://stackoverflow.com/a/50725918/1689770
            options.AddArgument("--disable-infobars"); //https://stackoverflow.com/a/43840128/1689770
            options.AddArgument("--disable-dev-shm-usage"); //https://stackoverflow.com/a/50725918/1689770
            options.AddArgument("--disable-browser-side-navigation"); //https://stackoverflow.com/a/49123152/1689770
            options.AddArgument("--disable-gpu"); //https://stackoverflow.com/questions/51959986/how-to-solve-selenium-chromedriver-timed-out-receiving-message-from-renderer-exc

            options.AddArgument("--window-size=1920,1080");
            var driver = new ChromeDriver(service, options, TimeSpan.FromMinutes(3));
           // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(1);
            //driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(1);
            return driver;
        }
    }
}
