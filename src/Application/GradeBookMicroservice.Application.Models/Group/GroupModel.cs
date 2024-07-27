﻿using GradeBookMicroservice.Application.Models.Student;

namespace GradeBookMicroservice.Application.Models.Group;

public class GroupModel : IModel<Guid>
{
    public required Guid Id {get; init;}
    public required string Name {get; init;}
    public required string Description {get; init;}
    public IEnumerable<StudentModel> Students{get; init;} = [];
}
