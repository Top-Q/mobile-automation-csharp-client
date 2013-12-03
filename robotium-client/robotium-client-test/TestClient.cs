using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using robotium_client;

namespace robotium_client_test
{
    [TestClass]
    public class TestClient
    {

        private string host = "127.0.0.1";
        private int port = 4321;
        MobileClient client;

        [TestInitialize]
        public void SetUp()
        {
            client = new MobileClient(host, port);
            client.Launch("com.leverate.app.Leverate");
 
        }
        
        [TestMethod]
        public void TestLogin()
        {
            client.ClickOnWebElement("cssSelector", "span.login-icon");
            client.EnterTextInWebElement("name", "userName", "265");
            client.EnterTextInWebElement("name", "password", "ab1234");
            client.ClickOnWebElement("xpath", "//span[text()='Login']");
           

        }

        [TestMethod]
        public void TestMoveToRates()
        {
            client.ClickOnWebElement("cssSelector", "market-rates-button-icon");

        }
    }
}
