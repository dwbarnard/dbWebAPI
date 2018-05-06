using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyWebAPI.Controllers
{
    [Produces("application/json")]
	[Route("api/[controller]")]    
	public class AddCourseController : Controller
    {
		[HttpPost]
		public void Post([FromBody]Course course)
		{
			var courses = Course.GetFromSession(HttpContext);
			courses.Add(course.courseID, course);
			Course.SetToSession(HttpContext, courses);
		}
	}
}