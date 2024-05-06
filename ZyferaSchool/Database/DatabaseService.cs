using Microsoft.Extensions.Logging;
using SQLite;
using SQLiteNetExtensions.Extensions;
using System.IO;
using ZyferaSchool.Database.Models;
using ZyferaSchool.DTOs;

namespace ZyferaSchool.Database
{
    /// <summary>
    /// Service for interacting with the database.
    /// </summary>
    public class DatabaseService
    {
        private readonly ILogger<DatabaseService> _logger;
        private readonly SQLiteConnection _connection;

        /// <summary>
        /// Constructor for initializing the DatabaseService.
        /// </summary>
        /// <param name="logger">Logger instance for logging.</param>
        public DatabaseService(ILogger<DatabaseService> logger)
        {
            _logger = logger;

            var databasePath = Path.Combine(Path.GetTempPath(), "ZyferaSchool", "Data.db");
            Directory.CreateDirectory(Path.GetDirectoryName(databasePath));
            _logger.LogInformation("Database path is '{databasePath}'", databasePath);

            _connection = new SQLiteConnection(databasePath);
            _connection.CreateTable<DbStudent>();
            _connection.CreateTable<DbGrade>();
        }

        /// <summary>
        /// Inserts a student into the database.
        /// </summary>
        /// <param name="studentDTO">StudentDTO object representing the student to insert.</param>
        public void Insert(StudentDTO studentDTO)
        {
            _connection.InsertWithChildren(DbStudent.FromDto(studentDTO));
        }
    }
}
