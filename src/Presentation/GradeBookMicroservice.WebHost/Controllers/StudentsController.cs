using AutoMapper;
using GradeBookMicroservice.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace GradeBookMicroservice.WebHost.Controllers;
[ApiController]
[Route("/api/v1/[controller]")]
public class StudentsController(IStudentsApplicationService studentsApplicationService, IMapper mapper) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<StudentShortResponse>))]
    public async IActionResult GetAllStudents()
    {
        var students = await studentsApplicationService.GetAllStudentsAsync();
        return Ok(students.S);
    }


}
