using System.Web.Mvc;

namespace EUCookies.TestWeb.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
			return View();
		}
	}
}