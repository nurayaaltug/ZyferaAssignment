using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ZyferaSchool.DTOs
{
    /// <summary>
    /// Data transfer object for representing a student.
    /// </summary>
    public class StudentDTO
    {
        /// <summary>
        /// First name of the student.
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Last name of the student.
        /// </summary>
        [Required]
        public string Surname { get; set; }

        /// <summary>
        /// Student number or identifier.
        /// </summary>
        [Required]
        public string StdNumber { get; set; }

        /// <summary>
        /// List of grades associated with the student.
        /// </summary>
        public List<GradeDTO> Grades { get; set; }
    }
}
