using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

namespace ParaBank_Automation
{
    [TestClass]
    public class LoginTestExecution
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

        [TestMethod]
        [TestCategory("Positive"), TestCategory("Login")]
        [Owner("Tabish")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "LoginWithValidUsernamePasswordTC_001", DataAccessMethod.Sequential)]
        public void LoginWithValidUsernamePasswordTC_001()
        {
            #region DataFromXML
            string user = TestContext.DataRow["user"].ToString();
            string pass = TestContext.DataRow["pass"].ToString();
            string expectedtext = TestContext.DataRow["expectedtext"].ToString();
            #endregion
            loginPage.Login(user, pass, expectedtext);
        }

        [TestMethod]
        [TestCategory("Negative"), TestCategory("Login")]
        [Owner("Tabish")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "LoginWithInvalidUsernamePasswordTC_002", DataAccessMethod.Sequential)]
        public void LoginWithInvalidUsernamePasswordTC_002()
        {
            #region DataFromXML
            string user = TestContext.DataRow["user"].ToString();
            string pass = TestContext.DataRow["pass"].ToString();
            string expectedtext = TestContext.DataRow["expectedtext"].ToString();
            #endregion
            loginPage.LoginWithInvalidDetails(user, pass, expectedtext);
        }

        [TestMethod]
        [TestCategory("Negative"), TestCategory("Login")]
        [Owner("Tabish")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "LoginWithEmptyUsernamePasswordTC_003", DataAccessMethod.Sequential)]
        public void LoginWithEmptyUsernamePasswordTC_003()
        {
            #region DataFromXML
            string user = TestContext.DataRow["user"].ToString();
            string pass = TestContext.DataRow["pass"].ToString();
            string expectedtext = TestContext.DataRow["expectedtext"].ToString();
            #endregion
            loginPage.Login(user, pass, expectedtext);
        }
    }
}
