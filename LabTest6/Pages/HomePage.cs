using LabTest6.Init;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace LabTest6.Pages
{
    class HomePage : TestPageBase
    {
        public override Uri Uri => new Uri(Initializer.RootUri, "");

        #region Login

        public IWebElement LoginRef => Initializer.Driver.FindElement(By.LinkText("Войти"));
        public IWebElement EmailField => Initializer.Driver.FindElement(By.Id("usernameOrEmail"));
        
        public IWebElement LoginBtn => Initializer.Driver.FindElement(By.CssSelector(".form-button"));


        public void LoginRefClick()
        {
            WebDriverWait wait1 = new WebDriverWait(Initializer.Driver, TimeSpan.FromSeconds(3));
            wait1.Until(ExpectedConditions.ElementToBeClickable(By.LinkText("Войти")));

            Initializer.Driver.Scripts().ExecuteScript("arguments[0].click();", LoginRef);

            WebDriverWait wait2 = new WebDriverWait(Initializer.Driver, TimeSpan.FromSeconds(3));
            wait2.Until(ExpectedConditions.TitleContains("Войти"));
        }

        public void EmailEdit(string text)
        {
            WebDriverWait wait = new WebDriverWait(Initializer.Driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("usernameOrEmail")));
            EmailField.SendKeys(text);
        }

        

        public void LoginClick()
        {
            WebDriverWait wait = new WebDriverWait(Initializer.Driver, TimeSpan.FromSeconds(3));
            wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".form-button")));

            Initializer.Driver.Scripts().ExecuteScript("arguments[0].click();", LoginBtn);
        }

        #endregion

        #region register

        public IWebElement RegisterRef => Initializer.Driver.FindElement(By.XPath("//a[contains(text(),'Приступайте')]"));
        public IWebElement UsernameF => Initializer.Driver.FindElement(By.XPath("//input[@id='username']"));
        
        public IWebElement MailF => Initializer.Driver.FindElement(By.XPath("//input[@id='email']"));
        public IWebElement PasswordF => Initializer.Driver.FindElement(By.XPath("//input[@id='password']"));
        
        public IWebElement RegisterBtn => Initializer.Driver.FindElement(By.XPath("//button[@type='submit']"));

        public void RegisterRefClick()
        {
            WebDriverWait wait3 = new WebDriverWait(Initializer.Driver, TimeSpan.FromSeconds(10));
            wait3.Until(ExpectedConditions.ElementToBeClickable(RegisterRef));

            Initializer.Driver.Scripts().ExecuteScript("arguments[0].click();", RegisterRef);
        }

        public void RegisterClick()
        {
            WebDriverWait wait3 = new WebDriverWait(Initializer.Driver, TimeSpan.FromSeconds(10));
            wait3.Until(ExpectedConditions.ElementToBeClickable(RegisterBtn));
            Initializer.Driver.Scripts().ExecuteScript("arguments[0].click();", RegisterBtn);
        }

        public void RegUsernameEdit(string text)
        {
            WebDriverWait wait = new WebDriverWait(Initializer.Driver, TimeSpan.FromSeconds(3));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='username']")));
            UsernameF.SendKeys(text);
        }


        public void RegMailEdit(string text)
        {
            WebDriverWait wait = new WebDriverWait(Initializer.Driver, TimeSpan.FromSeconds(3));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='email']")));
            MailF.SendKeys(text);
        }
        public void RegPasswordEdit(string text)
        {
            WebDriverWait wait = new WebDriverWait(Initializer.Driver, TimeSpan.FromSeconds(3));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[@id='password']")));
            PasswordF.SendKeys(text);
        }

        public string GetRegFnameText()
        {
            return UsernameF.GetAttribute("value");
        }



        public string GetRegMailFText()
        {
            return MailF.GetAttribute("value");
        }

        public string GetRegPasswordText()
        {
            return PasswordF.GetAttribute("value");
        }

        #endregion


        #region navigation 

        public IWebElement NavBarPopup => Initializer.Driver.FindElement(By.XPath("//button[contains(.,'Товары ')]"));
        public IWebElement TarifRef => Initializer.Driver.FindElement(By.LinkText("Тарифные планы и цены"));
        public IWebElement P2Ref => Initializer.Driver.FindElement(By.LinkText("P2: WordPress для коллег"));
        public IWebElement DomenRef => Initializer.Driver.FindElement(By.LinkText("Домен"));
        public IWebElement CommerceRef => Initializer.Driver.FindElement(By.LinkText("eCommerce"));

        public IWebElement SolutionsRef => Initializer.Driver.FindElement(By.LinkText("Автономные решения"));


        public void TarifClick()
        {
            WebDriverWait wait = new WebDriverWait(Initializer.Driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementToBeClickable(TarifRef));

            Initializer.Driver.Scripts().ExecuteScript("arguments[0].click();", TarifRef);

            WebDriverWait wait2 = new WebDriverWait(Initializer.Driver, TimeSpan.FromSeconds(10));
            wait2.Until(ExpectedConditions.TitleContains("Стоимость"));

        }

        public void P2Click()
        {
            WebDriverWait wait = new WebDriverWait(Initializer.Driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(.,'Товары ')]")));
            Actions action = new Actions(Initializer.Driver);
            action.MoveToElement(element).Perform();

            Thread.Sleep(200);

            Initializer.Driver.Scripts().ExecuteScript("arguments[0].click();", P2Ref);

            WebDriverWait wait2 = new WebDriverWait(Initializer.Driver, TimeSpan.FromSeconds(10));
            wait2.Until(ExpectedConditions.TitleContains("P2"));

        }

        public void DomenClick()
        {
            WebDriverWait wait = new WebDriverWait(Initializer.Driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(.,'Товары ')]")));
            Actions action = new Actions(Initializer.Driver);
            action.MoveToElement(element).Perform();

            Thread.Sleep(200);

            Initializer.Driver.Scripts().ExecuteScript("arguments[0].click();", DomenRef);

            WebDriverWait wait2 = new WebDriverWait(Initializer.Driver, TimeSpan.FromSeconds(10));
            wait2.Until(ExpectedConditions.TitleContains("домен"));
        }

        public void CommerceClick()
        {
            WebDriverWait wait = new WebDriverWait(Initializer.Driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(.,'Товары ')]")));
            Actions action = new Actions(Initializer.Driver);
            action.MoveToElement(element).Perform();

            Thread.Sleep(200);

            Initializer.Driver.Scripts().ExecuteScript("arguments[0].click();", CommerceRef);

            WebDriverWait wait2 = new WebDriverWait(Initializer.Driver, TimeSpan.FromSeconds(10));
            wait2.Until(ExpectedConditions.TitleContains("Commerce"));
        }

        public void SolutionsClick()
        {
            WebDriverWait wait = new WebDriverWait(Initializer.Driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//button[contains(.,'Товары ')]")));
            Actions action = new Actions(Initializer.Driver);
            action.MoveToElement(element).Perform();

            Thread.Sleep(200);

            Initializer.Driver.Scripts().ExecuteScript("arguments[0].click();", SolutionsRef);

            WebDriverWait wait2 = new WebDriverWait(Initializer.Driver, TimeSpan.FromSeconds(10));
            wait2.Until(ExpectedConditions.TitleContains("решений"));
        }


        #endregion



        public HomePage(ITestStartupInitializer initializer) : base(initializer)
        {
        }
    }
}