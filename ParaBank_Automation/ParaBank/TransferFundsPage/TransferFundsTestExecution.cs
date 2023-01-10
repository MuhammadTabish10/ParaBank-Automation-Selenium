using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Diagnostics;
using System.Security.Policy;
using static MongoDB.Driver.WriteConcern;

namespace ParaBank_Automation
{
    [TestClass]
    public class TransferFundsTestExecution
    {
        #region Initializations and Cleanups

        public TestContext instance;
        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        { }

        [ClassCleanup]
        public static void ClassCleanup()
        { }

        [TestInitialize]
        public void TestInit()
        {
            CorePage.SeleniumInit(ConfigurationManager.AppSettings["Browser"].ToString());
            CorePage.driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["url"].ToString());
        }

        [TestCleanup]
        public void TestCleanup()
        {
            CorePage.TakeScreenShot();
            CorePage.driver.Close();
        }

        #endregion

        LoginPage loginPage = new LoginPage();
        TransferFundsPage transferFundsPage = new TransferFundsPage();

        [TestMethod]
        [TestCategory("Positive"), TestCategory("TransferFunds")]
        [Owner("Tabish")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "TransferFundsTC_001", DataAccessMethod.Sequential)]
        public void TransferFundsTC_001()
        {
            #region DataFromXML
            string amount = TestContext.DataRow["amount"].ToString();
            string fromAcc = TestContext.DataRow["fromAcc"].ToString();
            string toAcc = TestContext.DataRow["toAcc"].ToString();
            string expected = TestContext.DataRow["expected"].ToString();
            #endregion
            loginPage.Login("john", "demo", "Log Out");
            transferFundsPage.TransferFunds(amount,fromAcc,toAcc,expected);
        }

        [TestMethod]
        [TestCategory("Negative"), TestCategory("TransferFunds")]
        [Owner("Tabish")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "TransferFundsWithEmptyAmountTC_002", DataAccessMethod.Sequential)]
        public void TransferFundsWithEmptyAmountTC_002()
        {
            #region DataFromXML
            string fromAcc = TestContext.DataRow["fromAcc"].ToString();
            string toAcc = TestContext.DataRow["toAcc"].ToString();
            string expected = TestContext.DataRow["expected"].ToString();
            #endregion
            loginPage.Login("john", "demo", "Log Out");
            transferFundsPage.TransferFunds(fromAcc, toAcc, expected);
        }
    }
}
