using System.IO;
using System.Reflection;
using EUCookies.Localizations;

namespace EUCookies
{
    public class Consent
    {
        private static object _lock = new object();
        private const string CookieName = "cookie_eu_consented";

        private ICookieService _cookieService = new CookieService();

        /// <summary>
        /// Creates an instance of Consent class
        /// </summary>
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

        /// <summary>
        /// Inject HTML that displays warning
        /// </summary>
        /// <param name="linkUrl">URL for 'learn more'</param>
        /// <param name="overrideMainText">Override text for mail message</param>
        /// <param name="overrideLearnMoreText">Override text for 'Learn more' link</param>
        /// <param name="overrideOkText">Override text for OK button</param>
        /// <returns>HTML string that displays message on the bottom of the web page</returns>
        public string Install(string linkUrl = null, string overrideMainText = null, string overrideLearnMoreText = null, string overrideOkText = null)
        {
            if (_cookieService.Read(CookieName) != "true")
            {
                var assembly = Assembly.GetAssembly(typeof(Consent));

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

        /// <summary>
        /// Replace service for reading/writing cookies. Used for testing, where HttpContext is not available
        /// </summary>
        /// <param name="service">Implementation of ICookieService interface</param>
        /// <returns>return this, just so it can be used fluently:)</returns>
        public Consent SetCookieService(ICookieService service)
        {
            _cookieService = service;
            return this;
        }
    }
}
