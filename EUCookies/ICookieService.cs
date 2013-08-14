namespace EUCookies
{
	public interface ICookieService
	{
		string Read(string cookieName);

		void Store(string cookieName, string content);
	}
}