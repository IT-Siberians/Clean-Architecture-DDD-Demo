using AutoMapper;
using GradeBookMicroservice.Application.Models.Teacher;
using GradeBookMicroservice.Application.Services.Abstractions;
using GradeBookMicroservice.WebHost.Requests.Teacher;
using GradeBookMicroservice.WebHost.Responses.Grade;
using GradeBookMicroservice.WebHost.Responses.Teacher;
using Microsoft.AspNetCore.Mvc;

namespace GradeBookMicroservice.WebHost.Controllers;
[ApiController]
[Route("api/v1/[controller]")]
public class TeachersController(ITeachersApplicationService teachersApplicationService,
                                ILessonsApplicationService lessonsApplicationService,
                                ITeachingApplicationService teachingApplicationService,
                                IStudentsApplicationService studentsApplicationService,
                                IAssesmentApplicationService assesmentApplicationService,
                                IMapper mapper) : ControllerBase
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
        if (teacher is null)
            return NotFound(id);
        return Ok(mapper.Map<TeacherDetailedResponse>(teacher));
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TeacherShortResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateTeacher(TeacherCreateRequest request)
    {
        var teacher = mapper.Map<CreateTeacherModel>(request);
        var createdTeacher = await teachersApplicationService.CreateTeacherAsync(teacher);
        if (createdTeacher is null)
            return BadRequest();
        return Created("", mapper.Map<TeacherShortResponse>(createdTeacher));

    }
    [HttpPost("teach")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Guid))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    public async Task<IActionResult> TeachLesson(TeachLessonRequest request)
    {
        var teacher = await teachersApplicationService.GetTeacherByIdAsync(request.TeacherId);
        if (teacher is null)
            return NotFound(request.TeacherId);
        var lesson = await lessonsApplicationService.GetLessonByIdAsync(request.LessonId);
        if (lesson is null)
            return NotFound(request.LessonId);
        if (teacher.TeachedLessons.FirstOrDefault(l => l.Id == request.LessonId) is not null)
            return BadRequest("Lesson has beed teached yet");
        var success = await teachingApplicationService.TeachLessonAsync(mapper.Map<TeachLessonModel>(request));
        if (!success)
            return BadRequest("Lesson has been teached yet");
        return NoContent();
    }
    [HttpPost("grade")]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(GradeResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Guid))]
    public async Task<ActionResult<GradeResponse>> GradeStudentAsync(GradeStudentModelRequest request)
    {
        var teacher = await teachersApplicationService.GetTeacherByIdAsync(request.TeacherId);
        if (teacher is null)
            return NotFound(request.TeacherId);
        var student = await studentsApplicationService.GetStudentByIdAsync(request.StudentId);
        if (student is null)
            return NotFound(request.StudentId);
        var lesson = await lessonsApplicationService.GetLessonByIdAsync(request.LessonId);
        if (lesson is null)
            return NotFound(request.LessonId);
        if (teacher.TeachedLessons.FirstOrDefault(l => l.Id == lesson.Id) is null)
            return BadRequest($"Teacher have not teached this lesson with id {lesson.Id} ");
        if (student.AttendedLessons.FirstOrDefault(l => l.Id == lesson.Id) is null)
            return BadRequest($"Student have not attended this lesson with id {lesson.Id} ");
        if (student.RecievedGrades.FirstOrDefault(g => g.Lesson.Id == lesson.Id) is not null)
            return BadRequest($"Student have already graded this lesson with id {lesson.Id} ");
        var grade = await assesmentApplicationService.GradeStudentAsync(mapper.Map<GradeStudentModel>(request));
        if(grade is null)
            return BadRequest("error while put a grade");
        return Created("", mapper.Map<GradeResponse>(grade));
    }
}