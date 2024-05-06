using System.Linq;
using ZyferaSchool.DTOs;

namespace ZyferaSchool.Extensions
{
    /// <summary>
    /// Extension methods for manipulating StudentDTO objects.
    /// </summary>
    public static class StudentDTOExtensions
    {
        /// <summary>
        /// Calculates the average grades for each distinct grade code in the student's grades.
        /// </summary>
        /// <param name="studentDTO">The StudentDTO object whose grades are to be calculated.</param>
        public static void CalculateGrades(this StudentDTO studentDTO)
        {
            studentDTO.Grades = studentDTO.Grades.GroupBy(grade => grade.Code)
                                     .Select(group => new GradeDTO
                                     {
                                         Code = group.Key,
                                         Value = (int)group.Average(g => g.Value)
                                     })
                                     .ToList();
        }
    }
}
