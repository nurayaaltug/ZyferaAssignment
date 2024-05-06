using System.ComponentModel.DataAnnotations;

namespace ZyferaSchool.DTOs
{
    /// <summary>
    /// Data transfer object for representing a grade.
    /// </summary>
    public class GradeDTO
    {
        /// <summary>
        /// Code representing the grade.
        /// </summary>
        [Required]
        public string Code { get; set; }

        /// <summary>
        /// Numeric value of the grade.
        /// </summary>
        [Required]
        [Range(0, 100)]
        public int Value { get; set; }
    }
}
