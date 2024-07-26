﻿namespace GradeBookMicroservice.Application.Models;

public class StudentModel : PersonModel
{
    public IEnumerable<GradeModel> Grades {get; init;} = [];
    public IEnumerable<LessonModel> Lessons{get; init;} = [];
    public required GroupModel Group{get; init;}
}
