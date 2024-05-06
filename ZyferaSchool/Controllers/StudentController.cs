using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ZyferaSchool.Database;
using ZyferaSchool.DTOs;
using ZyferaSchool.Extensions;

namespace ZyferaSchool.Controllers
{
    /// <summary>
    /// Controller for managing student-related operations.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> _logger;
        private readonly DatabaseService _databaseService;

        /// <summary>
        /// Constructor for initializing StudentController.
        /// </summary>
        /// <param name="logger">Logger instance for logging.</param>
        /// <param name="databaseService">Service for interacting with the database.</param>
        public StudentController(ILogger<StudentController> logger,
            DatabaseService databaseService)
        {
            _logger = logger;
            _databaseService = databaseService;
        }

        /// <summary>
        /// Endpoint for adding a new student.
        /// </summary>
        /// <param name="student">StudentDTO object containing student information.</param>
        /// <returns>An ActionResult representing the outcome of the operation.</returns>
        [HttpPost]
        public ActionResult Post([FromBody] StudentDTO student)
        {
            student.CalculateGrades();

            _databaseService.Insert(student);

            return Ok(student);
        }
    }
}

