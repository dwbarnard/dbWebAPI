
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyWebAPI
{
    [Produces("application/json")]
	[Route("api/[controller]")]    //	 [Route("api/Courses")]
    public class CoursesController : Controller
    {
		[HttpGet]
		public Dictionary<int, Course> Get()
		{
			return Course.GetFromSession(HttpContext);
		}

		[HttpPost]
		public void Post()
		{
			HttpContext.Session.Clear();
		}
    }
}