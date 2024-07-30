﻿using GradeBookMicroservice.Application.Models.Base;

namespace GradeBookMicroservice.Application.Models;

public abstract class PersonCreateModel : ICreateModel
{
    public required string Name {get; init;}
}
