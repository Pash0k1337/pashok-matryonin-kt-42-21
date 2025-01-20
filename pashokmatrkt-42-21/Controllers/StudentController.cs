using Microsoft.AspNetCore.Mvc;
using pashokmatrkt_42_21.Interfaces.StudentsInterfces;
using pashokmatrkt_42_21.Filter.StudentFilters;

namespace pashokmatrkt_42_21.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly ILogger<StudentsController> _logger;
        private readonly IStudentService _studentService;

        public StudentsController(ILogger<StudentsController> logger, IStudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }
       

        [HttpPost("GetStudentsByGroup")]
        public async Task<IActionResult> GetStudentsByGroupAsync(StudentGroupFilter filter, CancellationToken cancellationToken = default)
        {
            var students = await _studentService.GetStudentsByGroupAsync(filter, cancellationToken);

            return Ok(students);
        }
        [HttpPost("GetStudentsByName")]
        public async Task<IActionResult> GetStudentsByName(StudentNameFilter filter, CancellationToken cancellationToken = default)
        {
            var students = await _studentService.GetStudentsByNameAsync(filter, cancellationToken);

            return Ok(students);
        }
        [HttpPost("GetStudentsByLastName")]
        public async Task<IActionResult> GetStudentsByLastName(StudentLastNameFilter filter, CancellationToken cancellationToken = default)
        {
            var students = await _studentService.GetStudentsByLastNameAsync(filter, cancellationToken);

            return Ok(students);
        }

    }
}
