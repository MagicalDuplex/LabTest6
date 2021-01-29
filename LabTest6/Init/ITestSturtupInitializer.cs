using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace LabTest6.Init
{
    public interface ITestStartupInitializer
    {
        /// <summary>
        /// Корневой адрес сервера для тестирования.
        /// </summary>
        Uri RootUri { get; }

        /// <summary>
        /// Драйвер для тестирования.
        /// </summary>
        IWebDriver Driver { get; }
    }
}
