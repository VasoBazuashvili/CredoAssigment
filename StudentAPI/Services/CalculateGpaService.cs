using StudentAPI.Db.Entities;
using StudentAPI.Models;

namespace StudentAPI.Services
{
	public interface ICalculateGPAService
	{
		double CalculateGPA(List<StudentGrade> gradesEntity);
	}
	public class CalculateGPAService : ICalculateGPAService
	{
		public double CalculateGPA(List<StudentGrade> gradesEntity)
		{
			double totalCredits = 0;
			double total = 0;

			foreach (var grade in gradesEntity)
			{
				if (grade.Score >= 91 && grade.Score <= 100)
				{
					total += 4 * grade.Credits;
					totalCredits += grade.Credits;
				}
				else if (grade.Score >= 81 && grade.Score <= 90)
				{
					total += 3 * grade.Credits;
					totalCredits += grade.Credits;
				}
				else if (grade.Score >= 71 && grade.Score <= 80)
				{
					total += 2 * grade.Credits;
					totalCredits += grade.Credits;
				}
				else if (grade.Score >= 61 && grade.Score <= 70)
				{
					total += 1 * grade.Credits;
					totalCredits += grade.Credits;
				}
				else if (grade.Score >= 51 && grade.Score <= 60)
				{
					total += 0.5 * grade.Credits;
					totalCredits += grade.Credits;
				}
			}

			return total / totalCredits;
		}

	}
}
