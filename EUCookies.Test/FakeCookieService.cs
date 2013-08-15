using System.Collections.Generic;

namespace EUCookies.Test
{
    public class FakeCookieService : ICookieService
    {
        public Dictionary<string, string> Cookies = new Dictionary<string, string>();

        public string Read(string cookieName)
        {
            if (!Cookies.ContainsKey(cookieName))
                return string.Empty;

            return Cookies[cookieName];
        }

        public void Store(string cookieName, string content)
        {
            Cookies.Add(cookieName, content);
        }
    }
}