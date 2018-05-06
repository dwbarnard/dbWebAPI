using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWebAPI
{
	[Serializable]
	public class Student
	{

		public const string sessionKey = "students";

		public static Dictionary<int, Student> GetFromSession(HttpContext context)
		{
			var studentData = context.Session.GetString(sessionKey);
			if (studentData == null)	// no previous students, add the first
			{
				return new Dictionary<int, Student>();
			}
			var students = JsonConvert.DeserializeObject<Dictionary<int, Student>>(studentData);	//  add to collection
			return students;
		}

		public static void SetToSession(HttpContext context, Dictionary<int, Student> students)
		{
			context.Session.SetString(sessionKey, JsonConvert.SerializeObject(students));
		}

		public int ID { get; set; }
		public String Name { get; set; }
	}
}
