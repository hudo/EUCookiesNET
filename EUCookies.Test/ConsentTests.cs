using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EUCookies.Test
{
    [TestClass]
    public class ConsentTests
    {
        private Consent _consentUnderTest;

        private FakeCookieService _cookieService;

        [TestInitialize]
        public void Setup()
        {
            _cookieService = new FakeCookieService();
            _consentUnderTest = new Consent();
            _consentUnderTest.SetCookieService(_cookieService);
        }

        [TestMethod]
        public void Install_ReturnsString()
        {
            string html = _consentUnderTest.Install();
            Assert.IsFalse(string.IsNullOrWhiteSpace(html));
        }

        [TestMethod]
        public void Install_WithoutLink_NoAHrefHtml()
        {
            string html = _consentUnderTest.Install(linkUrl: "");

            Assert.IsFalse(string.IsNullOrWhiteSpace(html));
            Assert.IsFalse(html.Contains("<a href"));
        }

        [TestMethod]
        public void Install_WithLink_HasAHrefHtml()
        {
            string html = _consentUnderTest.Install(linkUrl: "!link!");

            Assert.IsFalse(string.IsNullOrWhiteSpace(html));
            Assert.IsTrue(html.Contains("<a href=\"!link!\""));
        }


        [TestMethod]
        public void Install_OverrideMainText_HasNewText()
        {
            string html = _consentUnderTest.Install(messageText: "!maintext!");

            Assert.IsFalse(string.IsNullOrWhiteSpace(html));
            Assert.IsTrue(html.Contains("<span class=\"cookies-eu-content-holder\">!maintext!</span>"));
        }

        [TestMethod]
        public void Install_OverrideOkText_HasNewText()
        {
            string html = _consentUnderTest.Install(okText: "!ok!");

            Assert.IsFalse(string.IsNullOrWhiteSpace(html));
            Assert.IsTrue(html.Contains("<button class=\"cookies-eu-ok\">!ok!</button>"));
        }
    }
}
