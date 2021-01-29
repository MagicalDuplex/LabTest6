using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace LabTest6
{
    static class UtilityJSExecutor
    {
        public static IJavaScriptExecutor Scripts(this IWebDriver driver)
        {
            return (IJavaScriptExecutor)driver;
        }
    }
}
