using StudentAPI.Db;

namespace StudentAPI.Services
{
	public interface ICalculateGpaService
	{
		Task<double> CalculateGPA(int id);
		Task UpdateStudentGPA(int studentId);
	}
	public class CalculateGpaService : ICalculateGpaService
	{
		private readonly StudentDbContext _db;

		public CalculateGpaService(StudentDbContext db)
		{
			_db = db;
		}

		public async Task<double> CalculateGPA(int id)
		{
			var student = await _db.Students.FindAsync(id);

			if (student == null)
			{
				throw new ArgumentException("student not found");
			}

			var studentGrades = _db.Grades.Where(g => g.StudentId == id);

			if (!studentGrades.Any())
			{
				throw new ArgumentException("student's grade not found");
			}

			double totalCredits = 0;
			double total = 0;

			foreach (var grade in studentGrades)
			{
				var subject = await _db.Subjects.FindAsync(grade.SubjectId);

				if (subject == null)
				{
					throw new ArgumentException("Subject grade not found");
				}

				if (grade.Score >= 91 && grade.Score <= 100)
				{
					total += 4 * subject.Credits;
					totalCredits += subject.Credits;
				}
				else if (grade.Score >= 81 && grade.Score <= 90)
				{
					total += 3 * subject.Credits;
					totalCredits += subject.Credits;
				}
				else if (grade.Score >= 71 && grade.Score <= 80)
				{
					total += 2 * subject.Credits;
					totalCredits += subject.Credits;
				}
				else if (grade.Score >= 61 && grade.Score <= 70)
				{
					total += 1 * subject.Credits;
					totalCredits += subject.Credits;
				}
				else if (grade.Score >= 51 && grade.Score <= 60)
				{
					total += 0.5 * subject.Credits;
					totalCredits += subject.Credits;
				}
			}

			student.GPA = total / totalCredits;
			await _db.SaveChangesAsync();
			return student.GPA;
		}

		public async Task UpdateStudentGPA(int studentId)
		{
			var gpa = await CalculateGPA(studentId);
			var student = await _db.Students.FindAsync(studentId);
			student!.GPA = gpa;
			await _db.SaveChangesAsync();
		}
	}
}
