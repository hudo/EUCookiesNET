using System.IO;
using System.Net.Mail;
using System.Reflection;
using System.Web;
using EUCookies.Localizations;

namespace EUCookies
{
    public class Consent
    {
		private static object _lock = new object();
	    private const string CookieName = "cookie_eu_consented";

		private ICookieService _cookieService = new CookieService();

		public static Consent Instance
		{
			get 
			{
				lock (_lock)
				{
					return new Consent();
				}
			}
		}

	    public string Install(string linkUrl = null, string overrideMainText = null, string overrideLearnMoreText = null, string overrideOkText = null)
		{
			if (_cookieService.Read(CookieName) != "true")
			{
				var assembly = Assembly.GetAssembly(typeof (Consent));

				var hasLink = !string.IsNullOrWhiteSpace(linkUrl);

				var fileName = hasLink ? "script.html" : "scriptnolink.html";

				var reader = new StreamReader(assembly.GetManifestResourceStream("EUCookies." + fileName));
				var html = reader.ReadToEnd();

				if (hasLink)
					html = html.Replace("{learnmore}", string.IsNullOrWhiteSpace(overrideLearnMoreText)
									? Captions.LearnMore
									: overrideLearnMoreText)
								.Replace("{link}", linkUrl);

				return html
					.Replace("{text}", string.IsNullOrWhiteSpace(overrideMainText) ? Captions.Text : overrideMainText)
					.Replace("{ok}", string.IsNullOrWhiteSpace(overrideOkText) ? Captions.Ok : overrideOkText);
			}

			return string.Empty;
		}

	    public Consent SetCookieService(ICookieService service)
	    {
		    _cookieService = service;
		    return this;
	    }
    }
}
