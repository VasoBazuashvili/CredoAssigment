using StudentAPI.Db.Entities;
using StudentAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPACalculateTest
{
	public class CalculateTest
	{
		[Test(Description ="ვტესტავ ჯიფიეის ფუნქციას")]
		public void Calculate() 
		{
			//var gpaService = new GradeRepository();
			var studentGrades = new List<Grades>();
			studentGrades.Add(new Grades
			{
				Score = 87
			}) ;

			var subjects = new List<Subjects>();
			subjects.Add(new Subjects
			{
				Credits = 5
			}) ;

		}

	}
}
