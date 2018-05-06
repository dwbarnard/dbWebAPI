using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyWebAPI
{
	[Produces("application/json")]
	[Route("api/[controller]")]
	public class AddStudentController : Controller
	{
		[HttpPost]
		public void Post([FromBody]Student student)
		{
			var students = Student.GetFromSession(HttpContext);
			students.Add(student.ID, student);
			Student.SetToSession(HttpContext, students);
		}

		//[HttpGet]
		//public Student Get()
		//{
		//	return new Student()
		//	{
		//		Name = "Test",
		//		ID = 0
		//	};
		//}
    }
}