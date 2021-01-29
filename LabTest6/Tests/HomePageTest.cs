using LabTest6.Init;
using LabTest6.Pages;
using Xunit;

namespace LabTest6.Tests
{
    public class HomePageTests : IClassFixture<TestStartupInitializerDefault>
    {
        private readonly TestStartupInitializerDefault _initializer;
        private readonly HomePage _page;

        public HomePageTests(TestStartupInitializerDefault initializer)
        {
            _initializer = initializer;
            _page = new HomePage(initializer);
           
        }

        
        [Fact]
        public void LoginTest()
        {
            string testmail = "pepega@mail.ru";
            
            _page.Navigate();
            
            _page.LoginRefClick();
            Assert.Contains("Войти", _page.Title);
            _page.EmailEdit(testmail);
            _page.LoginClick();
        }
        

        [Fact] 
        public void RegisterTest()
        {
            string wrongfieldValue = "Testirovanie";

            string mail = "pepega@mail.ru";


            string username = "testinguusername";

            string password = "testingpassword";

            _page.Navigate();

            _page.RegisterRefClick();

            _page.RegUsernameEdit(username);
            _page.RegMailEdit(mail);
            _page.RegPasswordEdit(password);

            Assert.Equal(mail, _page.GetRegMailFText());
            Assert.Equal(username, _page.GetRegFnameText());
            Assert.Equal(password, _page.GetRegPasswordText());

            Assert.NotEqual(wrongfieldValue, _page.GetRegMailFText());
            Assert.NotEqual(wrongfieldValue, _page.GetRegFnameText());
            Assert.NotEqual(wrongfieldValue, _page.GetRegPasswordText());
            _page.RegisterClick();

        }

        [Fact]
        public void NavigationTest()
        {
            
            string wrongTitle = "Pepega";

            _page.Navigate();
            _page.TarifClick();
            Assert.Contains("Стоимость", _page.Title);
            Assert.DoesNotContain(wrongTitle, _page.Title);

            _page.Navigate();
            _page.P2Click();
            Assert.Contains("P2", _page.Title);
            Assert.DoesNotContain(wrongTitle, _page.Title);

            _page.Navigate();
            _page.DomenClick();
            Assert.Contains("домен", _page.Title);
            Assert.DoesNotContain(wrongTitle, _page.Title);

            _page.Navigate();
            _page.CommerceClick();
            Assert.Contains("Commerce", _page.Title);
            Assert.DoesNotContain(wrongTitle, _page.Title);

            _page.Navigate();
            _page.SolutionsClick();
            Assert.Contains("решений", _page.Title);
            Assert.DoesNotContain(wrongTitle, _page.Title);
        }

       
    }
}
