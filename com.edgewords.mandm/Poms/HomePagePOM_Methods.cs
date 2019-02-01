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
        // Define all Methods here:
        public HomePagePOM SearchForItem(String item)
        {
            SearchField.Clear();
            SearchField.Click();
            SearchField.SendKeys(item);
            SearchField.SendKeys(Keys.Enter);

            return this;
        }

    }
}
