using OpenQA.Selenium;
using System;

namespace ParaBank_Automation
{
    public class OpenNewAccountPage : CorePage
    {
        #region Locators
        By OpenNewAccountloc = By.LinkText("Open New Account");
        By AccountIdDropDownloc = By.Id("fromAccountId");
        By AccountDropDownloc = By.Id("type");
        By OpenBtnloc = By.XPath("//body/div[@id='mainPanel']/div[@id='bodyPanel']/div[@id='rightPanel']/div[1]/div[1]/form[1]/div[1]/input[1]");
        By AssertNewAccountloc = By.XPath("//h1[contains(text(),'Account Opened!')]");
        #endregion

        public void OpenNewAccount(string typeValue, string accountId, string expectedtext)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);
            Click(OpenNewAccountloc);
            SelectDropDownMenu(AccountDropDownloc, typeValue);
            SelectDropDownMenu(AccountIdDropDownloc, accountId);
            Click(OpenBtnloc);
            AssertEqual(AssertNewAccountloc, expectedtext);

        }

    }
}