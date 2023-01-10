using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.IO;


namespace ParaBank_Automation
{
    [TestClass]
    public class OpenNewAccountTestExecution
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
        OpenNewAccountPage openNewAccountPage = new OpenNewAccountPage();

        [TestMethod]
        [TestCategory("Positive"), TestCategory("OpenNewAccount")]
        [Owner("Zaeem")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "OpenNewAccountTC_001", DataAccessMethod.Sequential)]
        public void OpenNewAccountTC_001()
        {
            #region DataFromXML
            string typeValue = TestContext.DataRow["typeValue"].ToString();
            string accountId = TestContext.DataRow["accountId"].ToString();
            string expectedtext = TestContext.DataRow["expectedtext"].ToString();
            #endregion
            loginPage.Login("john", "demo", "Log Out");
            openNewAccountPage.OpenNewAccount(typeValue, accountId, expectedtext);
        }
    }
}
