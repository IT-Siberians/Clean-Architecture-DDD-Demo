﻿using GradeBookMicroservice.Application.Models.Base;
using GradeBookMicroservice.Application.Models.Grade;
using GradeBookMicroservice.Application.Models.Group;
using GradeBookMicroservice.Application.Models.Lesson;

namespace GradeBookMicroservice.Application.Models.Student;

public class StudentModel : PersonModel
{
    public IEnumerable<GradeModel> RecievedGrades {get; init;} = [];
    public IEnumerable<LessonModel> AttendedLessons{get; init;} = [];
    public required GroupModel Group{get; init;}
}
