using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {

        public static string NOT_ENOUGH_STUDENTS = "Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.";
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = Enums.GradeBookType.Ranked;
        }
        public override char GetLetterGrade(double averageGrade)
        {
            if (NotEnoughStudents())
            {
                throw new InvalidOperationException(NOT_ENOUGH_STUDENTS);
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

        public override void CalculateStatistics()
        {
            if (NotEnoughStudents())
            {
                Console.WriteLine(NOT_ENOUGH_STUDENTS);
            } else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (NotEnoughStudents())
            {
                Console.WriteLine(NOT_ENOUGH_STUDENTS);
            } else
            {
                base.CalculateStudentStatistics(name);
            }
        }

        private Boolean NotEnoughStudents()
        {
            return Students.Count < 5;
        }

    }
}
