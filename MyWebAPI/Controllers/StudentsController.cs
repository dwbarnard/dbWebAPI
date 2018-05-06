using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyWebAPI
{
    [Produces("application/json")]
    [Route("api/[controller]")]		// default was:  [Route("api/Student")]
    public class StudentsController : Controller
    {
		[HttpGet]
		public Dictionary<int, Student> Get(CheckedBox onlyShowStudentsFailingACourse)
		{
			if (onlyShowStudentsFailingACourse.IsChecked)
			{
				var allStudents = Student.GetFromSession(HttpContext);
				var filteredStudents = new Dictionary<int, Student>();

				foreach (Student student in allStudents.Values)
				{
					if (IsStudentFailingAnyCourse(student.ID))
					{
						filteredStudents.Add(student.ID, student);
					}
				}

				return filteredStudents;
			}

			return Student.GetFromSession(HttpContext);
		}

		private bool IsStudentFailingAnyCourse(int studentID)
		{
			var courses = Course.GetFromSession(HttpContext);

			foreach (Course course in courses.Values)
			{
				if (course.Grades.ContainsKey(studentID))
				{
					if (course.Grades[studentID] < 60)
					{
						return true;
					}
				}
			}

			return false;
		}
	}

}
