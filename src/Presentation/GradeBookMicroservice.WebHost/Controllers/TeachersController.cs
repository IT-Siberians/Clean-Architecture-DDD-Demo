using AutoMapper;
using GradeBookMicroservice.Application.Models.Create;
using GradeBookMicroservice.Application.Services.Base;
using GradeBookMicroservice.WebHost.Requests.Teacher;
using GradeBookMicroservice.WebHost.Responses.Teacher;
using Microsoft.AspNetCore.Mvc;

namespace GradeBookMicroservice.WebHost.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
public class TeachersController(ITeachersApplicationService teachersApplicationService, IMapper mapper) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<TeacherShortResponse>))]
    public async Task<IActionResult> GetAllTeachers()
    {
        var teachers = await teachersApplicationService.GetTeachersAsync();
        return Ok(mapper.Map<IEnumerable<TeacherShortResponse>>(teachers));
    }
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TeacherDetailedResponse))]
    public async Task<IActionResult> GetTeacherById(Guid id)
    {
        var teacher = await teachersApplicationService.GetTeacherByIdAsync(id);
        return Ok(mapper.Map<TeacherDetailedResponse>(teacher));
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TeacherShortResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateTeacher(TeacherCreateRequest request)
    {
        var teacher = mapper.Map<CreateTeacherModel>(request);
        var createdTeacher = await teachersApplicationService.CreateTeacherAsync(teacher);
        if(createdTeacher is null)
            return BadRequest();
        return Created("", mapper.Map<TeacherShortResponse>(createdTeacher));

    }



}
