using AutoMapper;
using GradeBookMicroservice.Application.Models.Lesson;
using GradeBookMicroservice.Application.Services.Abstractions;
using GradeBookMicroservice.Domain.Entities;
using GradeBookMicroservice.Domain.Repositories.Abstractions;
using GradeBookMicroservice.Domain.ValueObjects;

namespace GradeBookMicroservice.Application.Services;

public class LessonsApplicationService(IRepository<Lesson, Guid> lessonsRepository,
                                        IRepository<Teacher, Guid> teachersRepository,
                                        IGroupsRepository groupsRepository,
                                        IMapper mapper) : ILessonsApplicationService
{
    public async Task<LessonModel?> CreateLessonAsync(CreateLessonModel lessonInfo)
    {
        var teacher = await teachersRepository.GetByIdAsync(lessonInfo.TeacherId);
        if (teacher is null)
            return null;
        var group = await groupsRepository.GetByIdAsync(lessonInfo.GroupId);
        if (group is null)
            return null;
        var lesson = new Lesson(group, teacher, lessonInfo.Description, lessonInfo.ClassTime, new LessonTopic(lessonInfo.Topic));
        lesson = await lessonsRepository.AddAsync(lesson);
        await teachersRepository.UpdateAsync(teacher);
        return mapper.Map<LessonModel>(lesson);
    }

    public async Task DeleteLessonAsync(Guid id)
    {
        var lesson = await lessonsRepository.GetByIdAsync(id);
        if (lesson is null)
            return;
        await lessonsRepository.DeleteAsync(lesson);
    }

    public async Task<IEnumerable<LessonModel>> GetAllLessonsAsync()
    {
        var lessons = await lessonsRepository.GetAllAsync();
        return lessons.Select(mapper.Map<LessonModel>);
    }

    public async Task<LessonModel?> GetLessonByIdAsync(Guid id)
    {
        var lesson = await lessonsRepository.GetByIdAsync(id);
        return lesson is null ? null : mapper.Map<LessonModel>(lesson);
    }

    public async Task UpdateLessonAsync(LessonModel lesson)
    {
        var entity = await lessonsRepository.GetByIdAsync(lesson.Id);
        if(entity is null)
            return;
        var update = mapper.Map<Lesson>(lesson);
        await lessonsRepository.UpdateAsync(update);
    }
}
