using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace ParaBank_Automation
{
    public class TransferFundsPage : CorePage
    {
        #region Locators
        By transferFundsloc = By.LinkText("Transfer Funds");
        By amountloc = By.ClassName("ng-touched");
        By selectFromAccountDropDownloc = By.Id("fromAccountId");
        By selectToAccountDropDownloc = By.Id("toAccountId");
        By transferBtnloc = By.CssSelector("div.ng-scope:nth-child(1) div.ng-scope form.ng-pristine.ng-valid div:nth-child(4) > input.button");
        By assertTransferloc = By.CssSelector("div:nth-child(3) div:nth-child(2) div.ng-scope:nth-child(1) div.ng-scope > h1.title:nth-child(1)");
        By assertEmptyTransferloc = By.Id("amount.errors");

        #endregion

        public void TransferFunds(string amount, string fromAcc, string toAcc, string expected)
        {
            Click(transferBtnloc);
            Write(amountloc,amount);
            Write(selectFromAccountDropDownloc,fromAcc);
            Write(selectToAccountDropDownloc,toAcc);
            Click(transferFundsloc);

            AssertEqual(assertTransferloc, expected);
        }

        public void TransferFunds(string fromAcc, string toAcc, string expected)
        {
            Click(transferBtnloc);
            Write(selectFromAccountDropDownloc, fromAcc);
            Write(selectToAccountDropDownloc, toAcc);
            Click(transferFundsloc);

            AssertEqual(assertEmptyTransferloc, expected);
        }


    }
}