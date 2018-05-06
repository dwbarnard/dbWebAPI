using System;

using Microsoft.AspNetCore.Mvc;

namespace MyWebAPI
{
    [Produces("application/json")]
	[Route("api/[controller]")]								//	     [Route("api/GetStudentGrade")]
    public class SetStudentGradeController : Controller
    {
		[HttpPost]
		public void Post([FromBody]Grade data)
		{
			var courses = Course.GetFromSession(HttpContext);
			var students = Student.GetFromSession(HttpContext);
			try
			{
				courses[data.CourseID].SetStudentGrade(data.StudentID, data.Score);
				Course.SetToSession(HttpContext, courses);
			}
			catch
			{
			}
		}
    }
}