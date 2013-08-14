using System.Web;

namespace EUCookies
{
	public class CookieService : ICookieService
	{
		public string Read(string cookieName)
		{
			if(HttpContext.Current != null && HttpContext.Current.Request.Cookies[cookieName] != null)
			{
				return HttpContext.Current.Request.Cookies[cookieName].Value;
			}

			return string.Empty;
		}

		public void Store(string cookieName, string content)
		{
			if (HttpContext.Current != null)
			{
				HttpContext.Current.Request.Cookies.Add(new HttpCookie(cookieName, content));
			}
		}
	}
}