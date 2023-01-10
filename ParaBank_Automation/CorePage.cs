using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;

namespace ParaBank_Automation
{
    public class CorePage
    {
        public static IWebDriver driver;

        public static IWebDriver SeleniumInit(string browser)
        {
            if (browser == "Chrome")
            {
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddArguments("--start-maximized");
                chromeOptions.AddArguments("--incognito");
                IWebDriver chromeDriver = new ChromeDriver(chromeOptions);
                driver = chromeDriver;
            }
            else if (browser == "Edge")
            {
                var edgeOptions = new EdgeOptions();
                edgeOptions.AddArguments("--start-maximized");
                edgeOptions.AddArguments("--incognito");
                IWebDriver edgeDriver = new EdgeDriver(edgeOptions);
                driver = edgeDriver;
            }
            return driver;
        }

        public static void Write(By locator, string value)
        {
            driver.FindElement(locator).SendKeys(value);
        }

        public static void Click(By locator)
        {
            driver.FindElement(locator).Click();
        }

        public static void AssertEqual(By locator, string expectedtext)
        {
            string actualText = driver.FindElement(locator).Text;
            Assert.AreEqual(expectedtext, actualText);
        }

        public static void SelectDropDownMenu(By locator, string value)
        {
            var select = driver.FindElement(locator);
            var selectDropDown = new SelectElement(select);
            selectDropDown.SelectByText(value);
        }

        public static void TakeScreenShot()
        {
            string path = "C:\\Users\\muham\\source\\repos\\ParaBank_Automation\\ParaBank_Automation\\ParaBank\\Screenshots\\" + DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss") + ".png";
            //string path = "C:\\Users\\muham\\source\\repos\\ParaBank_Automation\\ParaBank_Automation\\Screenshots\\"+  + DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss") + ".png";
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(path,ScreenshotImageFormat.Png);
        }
    }
}
