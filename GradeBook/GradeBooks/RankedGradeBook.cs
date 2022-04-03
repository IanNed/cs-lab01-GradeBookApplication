using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5) return InvalidOperationException("At least 5 students required to start the ranking process");

            var grade = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();
            var grademax = Convert.ToInt32(Math.Ceiling(Students.Count * 0.2));

            if (grade[grademax - 1] <= averageGrade)
                return 'A';
            else if (grade[(grademax * 2) - 1] <= averageGrade)
                return 'B';
            else if (grade[(grademax * 3) - 1] <= averageGrade)
                return 'C';
            else if (grade[(grademax * 4) - 1] <= averageGrade)
                return 'D';
            else return 'F';
        }

        public override void CalculateStatistics()
        {
            if (Students.Count < 5) { 
                    Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            base.CalculateStatistics();
        }
        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.WriteLine("Ranked grading requires at least 5 students.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }

        private char InvalidOperationException(string v)
        {
            throw new NotImplementedException();
        }
    }
}
