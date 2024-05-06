using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;
using System.Linq;
using ZyferaSchool.DTOs;

namespace ZyferaSchool.Database.Models
{
    /// <summary>
    /// Represents a student in the database.
    /// </summary>
    [Table("student")]
    public class DbStudent
    {
        /// <summary>
        /// Primary key identifier for the student.
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        /// <summary>
        /// First name of the student.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Last name of the student.
        /// </summary>
        public string Surname { get; set; }

        /// <summary>
        /// Student number or identifier.
        /// </summary>
        public string StdNumber { get; set; }

        /// <summary>
        /// Collection of grades associated with the student.
        /// </summary>
        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<DbGrade> Grades { get; set; }

        /// <summary>
        /// Converts a StudentDTO object to a DbStudent object.
        /// </summary>
        /// <param name="dto">StudentDTO object to convert.</param>
        /// <returns>A DbStudent object representing the DTO.</returns>
        public static DbStudent FromDto(StudentDTO dto)
        {
            return new DbStudent
            {
                Name = dto.Name,
                Surname = dto.Surname,
                StdNumber = dto.StdNumber,
                Grades = dto.Grades.Select(g => new DbGrade
                {
                    Code = g.Code,
                    Value = g.Value,
                }).ToList()
            };
        }
    }
}
