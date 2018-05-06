
using Microsoft.AspNetCore.Mvc;

namespace MyWebAPI.Controllers
{
    [Produces("application/json")]
	[Route("api/[controller]")]										 //	[Route("api/AddStudentToCourse")]
    public class AddStudentToCourseController : Controller
    {
		[HttpPost]
		public void Post([FromBody]Registry data)
		{
			var courses = Course.GetFromSession(HttpContext);
			var students = Student.GetFromSession(HttpContext);
			try
			{
				courses[data.CourseID].AddStudent(students[data.StudentID]);
				Course.SetToSession(HttpContext, courses);
			}
			catch
			{
			}
		}

    }
}