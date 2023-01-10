using OpenQA.Selenium;
using System;

namespace ParaBank_Automation
{
    public class LoginPage : CorePage
    {
        #region Locators
        By Usernameloc = By.Name("username");
        By Passwordloc = By.Name("password");
        By LoginBtnloc = By.CssSelector("div:nth-child(1) div:nth-child(2) form:nth-child(1) div.login:nth-child(5) > input.button");
        By AssertLoginSuccussloc = By.LinkText("Log Out");        
        By AssertLoginErrorloc = By.ClassName("error");
        #endregion

        public void Login(string user, string pass, string expectedtext)
        {

            Write(Usernameloc, user);
            Write(Passwordloc, pass);
            Click(LoginBtnloc);

            if(user == "" && pass == "")
            {
                AssertEqual(AssertLoginErrorloc, expectedtext);
            }
            else
            {
                AssertEqual(AssertLoginSuccussloc, expectedtext);
            }
        }

        public void LoginWithInvalidDetails(string user, string pass, string expectedtext)
        {
            Write(Usernameloc, user);
            Write(Passwordloc, pass);
            Click(LoginBtnloc);

            AssertEqual(AssertLoginErrorloc, expectedtext);
        }
    }
}