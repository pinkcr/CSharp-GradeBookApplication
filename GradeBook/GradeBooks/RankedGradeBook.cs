using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = Enums.GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked Grading requires 5 students minumum");
            }

            int gradeBoundaryA = (int) Math.Ceiling(Students.Count * 0.2) - 1;
            int gradeBoundaryB = (int) Math.Ceiling(Students.Count * 0.4) - 1;
            int gradeBoundaryC = (int) Math.Ceiling(Students.Count * 0.6) - 1;
            int gradeBoundaryD = (int) Math.Ceiling(Students.Count * 0.8) - 1;

            var orderedStudents = Students.OrderByDescending(s => s.AverageGrade).ToList();

            if (averageGrade >= orderedStudents[gradeBoundaryA].AverageGrade) 
            {
                return 'A';
            } else if (averageGrade >= orderedStudents[gradeBoundaryB].AverageGrade)
            {
                return 'B';
            } else if (averageGrade >= orderedStudents[gradeBoundaryC].AverageGrade)
            {
                return 'C';
            } else if (averageGrade >= orderedStudents[gradeBoundaryD].AverageGrade)
            {
                return 'D';
            }

            return 'F';
        }

    }
}
