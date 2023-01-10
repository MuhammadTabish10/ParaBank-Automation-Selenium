using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace ParaBank_Automation
{
    [TestClass]
    public class AccountsOverviewTestExecution
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
            CorePage.driver.Close();
        }

        #endregion

        LoginPage loginPage = new LoginPage();
        AccountsOverviewPage accountsOverviewPage = new AccountsOverviewPage();

        [TestMethod]
        [TestCategory("Positive"), TestCategory("AccountsOverview")]
        [Owner("Zaeem")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "AccountsOverviewTC_001", DataAccessMethod.Sequential)]
        public void AccountsOverviewTC_001()
        {
            #region DataFromXML
            string monthValue = TestContext.DataRow["monthValue"].ToString();
            string typeValue = TestContext.DataRow["typeValue"].ToString();
            string expectedtext = TestContext.DataRow["expectedtext"].ToString();
            #endregion
            loginPage.Login("arham1111", "123", "Log Out");
            accountsOverviewPage.AccountsOverview(monthValue, typeValue, expectedtext);
        }
    }
}
