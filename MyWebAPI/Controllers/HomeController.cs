
using Microsoft.AspNetCore.Mvc;

namespace MyWebAPI
{
    [Produces("application/json")]
	[Route("api/[controller]")]				//			[Route("api/Home")]
    public class HomeController : Controller
    {

		public IActionResult Index()
		{
			return View();
		}

	}
}