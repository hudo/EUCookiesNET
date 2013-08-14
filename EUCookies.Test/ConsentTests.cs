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
			Assert.IsTrue(html.Contains("!link!"));
		}


		[TestMethod]
		public void Install_OverrideMainText_HasNewText()
		{
			string html = _consentUnderTest.Install(overrideMainText: "!maintext!");

			Assert.IsFalse(string.IsNullOrWhiteSpace(html));
			Assert.IsTrue(html.Contains("!maintext!"));
		}

		[TestMethod]
		public void Install_OverrideOkText_HasNewText()
		{
			string html = _consentUnderTest.Install(overrideMainText: "!ok!");

			Assert.IsFalse(string.IsNullOrWhiteSpace(html));
			Assert.IsTrue(html.Contains("!ok!"));
		}
	}
}
