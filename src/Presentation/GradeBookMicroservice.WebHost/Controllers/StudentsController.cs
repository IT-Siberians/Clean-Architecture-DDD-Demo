using AutoMapper;
using GradeBookMicroservice.Application.Models.Student;
using GradeBookMicroservice.Application.Services.Abstractions;
using GradeBookMicroservice.WebHost.Requests.Student;
using GradeBookMicroservice.WebHost.Responses.Student;
using Microsoft.AspNetCore.Mvc;

namespace GradeBookMicroservice.WebHost.Controllers;
[ApiController]
[Route("/api/v1/[controller]")]
public class StudentsController(IStudentsApplicationService studentsApplicationService, IMapper mapper) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<StudentShortResponse>))]
    public async Task<IActionResult> GetAllStudents()
    {
        var students = await studentsApplicationService.GetAllStudentsAsync();
        return Ok(students.Select(mapper.Map<StudentShortResponse>));
    }
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(StudentDetailedResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<IActionResult> GetStudentById(Guid id)
    {
        var student = await studentsApplicationService.GetStudentByIdAsync(id);
        if(student is null)
            return NotFound(id);
        return Ok(mapper.Map<StudentDetailedResponse>(student));
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(StudentShortResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateStudent(CreateStudentRequest request)
    {
        var student = await studentsApplicationService.AddStudentAsync(mapper.Map<CreateStudentModel>(request));
        if(student is null)
            return BadRequest();
        return Created("",mapper.Map<StudentShortResponse>(student));
    }


}
