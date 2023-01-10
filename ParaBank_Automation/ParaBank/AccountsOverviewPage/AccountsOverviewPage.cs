using OpenQA.Selenium;
using System;

namespace ParaBank_Automation
{
    public class AccountsOverviewPage : CorePage
    {
        #region Locators
        By AccountsOverviewloc = By.LinkText("Accounts Overview");
        By Accountloc = By.LinkText("14343");
        By MonthDropDownloc = By.Id("month");
        By TypeDropDownloc = By.Id("transactionType");
        By GoBtnloc = By.XPath("//tbody/tr[3]/td[2]/input[1]");
        By AssertTransactionloc = By.CssSelector("div:nth-child(2) div.ng-scope:nth-child(1) div.ng-scope:nth-child(2) p.ng-scope:nth-child(4) > b:nth-child(1)");
        #endregion

        public void AccountsOverview(string monthValue, string typeValue, string expectedtext)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            Click(AccountsOverviewloc);
            Click(Accountloc);
            SelectDropDownMenu(MonthDropDownloc, monthValue);
            SelectDropDownMenu(TypeDropDownloc, typeValue);
            Click(GoBtnloc);
            AssertEqual(AssertTransactionloc,expectedtext);
        }

    }
}