using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;
using System.Security.Policy;

namespace ParaBank_Automation
{
    [TestClass]
    public class RegisterTestExecution
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

        RegisterPage registerPage = new RegisterPage();

        [TestMethod]
        [TestCategory("Positive"), TestCategory("Register")]
        [Owner("Tabish")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "RegisterWithValidDetailsTC_001", DataAccessMethod.Sequential)]
        public void RegisterWithValidDetailsTC_001()
        {
            #region DataFromXML
            string firstName = TestContext.DataRow["firstName"].ToString();
            string lastName = TestContext.DataRow["lastName"].ToString();
            string address = TestContext.DataRow["address"].ToString();
            string city = TestContext.DataRow["city"].ToString();
            string state = TestContext.DataRow["state"].ToString();
            string zipCode = TestContext.DataRow["zipCode"].ToString();
            string phone = TestContext.DataRow["phone"].ToString();
            string ssn = TestContext.DataRow["ssn"].ToString();
            string userName = TestContext.DataRow["userName"].ToString();
            string password = TestContext.DataRow["password"].ToString();
            string confirm = TestContext.DataRow["confirm"].ToString();
            string TextExpected = TestContext.DataRow["TextExpected"].ToString();
            #endregion
            registerPage.Register(firstName, lastName, address, city, state, zipCode, phone, ssn, userName, password, confirm, TextExpected);
        }

        [TestMethod]
        [TestCategory("Negative"), TestCategory("Register")]
        [Owner("Tabish")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "RegisterWithEmptyDetailsTC_002", DataAccessMethod.Sequential)]
        public void RegisterWithEmptyDetailsTC_002()
        {
            #region DataFromXML
            string fnExpected = TestContext.DataRow["fnExpected"].ToString();
            string lnExpected = TestContext.DataRow["lnExpected"].ToString();
            string addExpected = TestContext.DataRow["addExpected"].ToString();
            string cExpected = TestContext.DataRow["cExpected"].ToString();
            string stExpected = TestContext.DataRow["stExpected"].ToString();
            string zcExpected = TestContext.DataRow["zcExpected"].ToString();
            string ssnExpected = TestContext.DataRow["ssnExpected"].ToString();
            string userExpected = TestContext.DataRow["userExpected"].ToString();
            string passExpected = TestContext.DataRow["passExpected"].ToString();
            string conpassExpected = TestContext.DataRow["conpassExpected"].ToString();
            #endregion
            registerPage.RegisterWithEmptyDetails(fnExpected, lnExpected, addExpected, cExpected, stExpected, zcExpected, ssnExpected, userExpected, passExpected, conpassExpected);
        }

        /*
        [TestMethod]
        [TestCategory("Negative"), TestCategory("Register")]
        [Owner("Tabish")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "RegisterWithCreatedUserDetailsTC_003", DataAccessMethod.Sequential)]
        public void RegisterWithCreatedUserDetailsTC_003()
        {
            #region DataFromXML
            string firstName = TestContext.DataRow["firstName"].ToString();
            string lastName = TestContext.DataRow["lastName"].ToString();
            string address = TestContext.DataRow["address"].ToString();
            string city = TestContext.DataRow["city"].ToString();
            string state = TestContext.DataRow["state"].ToString();
            string zipCode = TestContext.DataRow["zipCode"].ToString();
            string phone = TestContext.DataRow["phone"].ToString();
            string ssn = TestContext.DataRow["ssn"].ToString();
            string userName = TestContext.DataRow["userName"].ToString();
            string password = TestContext.DataRow["password"].ToString();
            string confirm = TestContext.DataRow["confirm"].ToString();
            string TextExpected = TestContext.DataRow["TextExpected"].ToString();
            #endregion
            registerPage.RegisterWithCreatedUserDetails(firstName, lastName, address, city, state, zipCode, phone, ssn, userName, password, confirm, TextExpected);
        }
        */

        [TestMethod]
        [TestCategory("Negative"), TestCategory("Register")]
        [Owner("Tabish")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "Data.xml", "RegisterWithNotMatchPasswordsDetailsTC_004", DataAccessMethod.Sequential)]
        public void RegisterWithNotMatchPasswordsDetailsTC_004()
        {
            #region DataFromXML
            string firstName = TestContext.DataRow["firstName"].ToString();
            string lastName = TestContext.DataRow["lastName"].ToString();
            string address = TestContext.DataRow["address"].ToString();
            string city = TestContext.DataRow["city"].ToString();
            string state = TestContext.DataRow["state"].ToString();
            string zipCode = TestContext.DataRow["zipCode"].ToString();
            string phone = TestContext.DataRow["phone"].ToString();
            string ssn = TestContext.DataRow["ssn"].ToString();
            string userName = TestContext.DataRow["userName"].ToString();
            string password = TestContext.DataRow["password"].ToString();
            string confirm = TestContext.DataRow["confirm"].ToString();
            string TextExpected = TestContext.DataRow["TextExpected"].ToString();
            #endregion
            registerPage.Register(firstName, lastName, address, city, state, zipCode, phone, ssn, userName, password, confirm, TextExpected);
        }
    }
}
