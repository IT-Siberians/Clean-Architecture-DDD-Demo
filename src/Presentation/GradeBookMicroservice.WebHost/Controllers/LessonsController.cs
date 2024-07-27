using AutoMapper;
using GradeBookMicroservice.Application.Models.Lesson;
using GradeBookMicroservice.Application.Services.Base;
using GradeBookMicroservice.WebHost.Requests.Lesson;
using GradeBookMicroservice.WebHost.Responses.Lesson;
using Microsoft.AspNetCore.Mvc;

namespace GradeBookMicroservice.WebHost.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
public class LessonsController(ILessonsApplicationService lessonsApplicationService,
                                ITeachersApplicationService teachersApplicationService,
                                IGroupsApplicationService groupsApplicationService,
                                IMapper mapper) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<LessonShortResponse>))]
    public async Task<IActionResult> GetAllLessons()
    {
        var lessons = await lessonsApplicationService.GetAllLessonsAsync();
        return Ok(lessons.Select(mapper.Map<LessonShortResponse>));
    }
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LessonDetailedResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Guid))]
    public async Task<IActionResult> GetLesson(Guid id)
    {
        var lesson = await lessonsApplicationService.GetLessonByIdAsync(id);
        if(lesson is null)
            return NotFound(id);
        return Ok(mapper.Map<LessonDetailedResponse>(lesson));
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(LessonShortResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    public async Task<IActionResult> CreateLesson(CreateLessonRequest request)
    {
        var teacher = await teachersApplicationService.GetTeacherByIdAsync(request.TeacherId);
        if(teacher is null)
            return BadRequest("Teacher not found");
        var group = await groupsApplicationService.GetGroupByIdAsync(request.GroupId);
        if(group is null)
            return BadRequest("Group not found");
        var lesson = await lessonsApplicationService.CreateLessonAsync(mapper.Map<CreateLessonModel>(request));
        if(lesson is null)
            return BadRequest();
        return Created("", mapper.Map<LessonShortResponse>(lesson));

    }

}
