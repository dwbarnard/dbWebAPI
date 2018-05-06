using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyWebAPI
{
    [Produces("application/json")]
	[Route("api/[controller]")]										 //  [Route("api/RemoveStudentFromCourse")]
	public class RemoveStudentFromCourseController : Controller
    {
		[HttpPost]
		public void Post([FromBody]Grade data)
		{
			var courses = Course.GetFromSession(HttpContext);
			var students = Student.GetFromSession(HttpContext);
			try
			{
				courses[data.CourseID].RemoveStudent(data.StudentID);
				Course.SetToSession(HttpContext, courses);
			}
			catch
			{
			}

		}
	}
}