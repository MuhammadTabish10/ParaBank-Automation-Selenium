using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace ParaBank_Automation
{
    public class RegisterPage : CorePage
    {
        #region Locators
        By registerPageloc = By.LinkText("Register");
        By firstNameloc = By.Id("customer.firstName");
        By lastNameloc = By.Id("customer.lastName");
        By addressloc = By.Id("customer.address.street");
        By cityloc = By.Id("customer.address.city");
        By stateloc = By.Id("customer.address.state");
        By zipCodeloc = By.Id("customer.address.zipCode");
        By phoneloc = By.Id("customer.phoneNumber");
        By ssnloc = By.Id("customer.ssn");
        By userNameloc = By.Id("customer.username");
        By passwordloc = By.Id("customer.password");
        By confirmloc = By.Id("repeatedPassword");
        By registerBtnloc = By.CssSelector("table.form2:nth-child(1) tbody:nth-child(1) tr:nth-child(13) td:nth-child(2) > input.button");
        By assertRegisterSuccussloc = By.LinkText("Log Out");
        By assertFirstNameloc = By.Id("customer.firstName.errors");
        By assertLastNameloc = By.Id("customer.lastName.errors");
        By assertAddressloc = By.Id("customer.address.street.errors");
        By assertCityloc = By.Id("customer.address.city.errors");
        By assertStateloc = By.Id("customer.address.state.errors");
        By assertZipCodeloc = By.Id("customer.address.zipCode.errors");
        By assertSSNloc = By.Id("customer.ssn.errors");
        By assertUserNameloc = By.Id("customer.username.errors");
        By assertPasswordloc = By.Id("customer.password.errors");
        By assertConfirmloc = By.Id("repeatedPassword.errors");
        #endregion

        public void Register(string firstName, string lastName, string address, string city, string state, string zipCode, string phone, string ssn, string userName, string password, string confirm, string TextExpected)
        {
            Click(registerPageloc);
            Write(firstNameloc, firstName);
            Write(lastNameloc, lastName);
            Write(addressloc, address);
            Write(cityloc, city);
            Write(stateloc, state);
            Write(zipCodeloc, zipCode);
            Write(phoneloc, phone);
            Write(ssnloc, ssn);
            Write(userNameloc, userName);
            Write(passwordloc, password);
            Write(confirmloc, confirm);
            Click(registerBtnloc);


            if(password != confirm)
            {
                AssertEqual(assertConfirmloc, TextExpected);
            }
            else
            {
                AssertEqual(assertRegisterSuccussloc, TextExpected);
            }
        }

        public void RegisterWithEmptyDetails(string fnExpected, string lnExpected, string addExpected, string cExpected, string stExpected, string zcExpected, string ssnExpected, string userExpected, string passExpected, string conpassExpected)
        {
            Click(registerPageloc);
            Click(registerBtnloc);

            AssertEqual(assertFirstNameloc, fnExpected);
            AssertEqual(assertLastNameloc, lnExpected);
            AssertEqual(assertAddressloc, addExpected);
            AssertEqual(assertCityloc, cExpected);
            AssertEqual(assertStateloc, stExpected);
            AssertEqual(assertZipCodeloc, zcExpected);
            AssertEqual(assertSSNloc, ssnExpected);
            AssertEqual(assertUserNameloc, userExpected);
            AssertEqual(assertPasswordloc, passExpected);
            AssertEqual(assertConfirmloc, conpassExpected);
        }

        public void RegisterWithCreatedUserDetails(string firstName, string lastName, string address, string city, string state, string zipCode, string phone, string ssn, string userName, string password, string confirm, string TextExpected)
        {
            Click(registerPageloc);
            Write(firstNameloc, firstName);
            Write(lastNameloc, lastName);
            Write(addressloc, address);
            Write(cityloc, city);
            Write(stateloc, state);
            Write(zipCodeloc, zipCode);
            Write(phoneloc, phone);
            Write(ssnloc, ssn);
            Write(userNameloc, userName);
            Write(passwordloc, password);
            Write(confirmloc, confirm);
            Click(registerBtnloc);

            AssertEqual(assertUserNameloc, TextExpected);
        }
    }
}