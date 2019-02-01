using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.edgewords.mandm.Poms
{
    public partial class HomePagePOM
    {
        private IWebDriver driver;

        public HomePagePOM(IWebDriver driver)
        {
            this.driver = driver;
        }
        #region POM Locators here
        private IWebElement SearchField => driver.FindElement(By.Id("mainSearchText"));
        #endregion
    }
}
