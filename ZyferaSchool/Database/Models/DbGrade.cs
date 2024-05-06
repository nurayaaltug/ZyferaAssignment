using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ZyferaSchool.Database.Models
{
    /// <summary>
    /// Represents a grade in the database.
    /// </summary>
    [Table("grade")]
    public class DbGrade
    {
        /// <summary>
        /// Primary key identifier for the grade.
        /// </summary>
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        /// <summary>
        /// Code representing the grade.
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// Numeric value of the grade.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Foreign key referencing the student associated with this grade.
        /// </summary>
        [ForeignKey(typeof(DbStudent))]
        public int StudentId { get; set; }
    }
}
