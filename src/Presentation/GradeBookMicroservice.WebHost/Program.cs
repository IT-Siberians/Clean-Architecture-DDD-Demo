using GradeBookMicroservice.Application.Services;
using GradeBookMicroservice.Application.Services.Abstractions;
using GradeBookMicroservice.Application.Services.Mapping;
using GradeBookMicroservice.Domain.Entities;
using GradeBookMicroservice.Domain.Repositories.Abstractions;
using GradeBookMicroservice.Insractructure.Repositories.Implementations.InMemory;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IGroupsRepository, InMemoryGroupRepository>();
builder.Services.AddSingleton<IGroupsApplicationService, GroupsApplicationService>();
builder.Services.AddSingleton<IRepository<Student,Guid>, InMemoryRepository<Student,Guid>>();
builder.Services.AddSingleton<IStudentsApplicationService, StudentsApplicationService>();
builder.Services.AddSingleton<IRepository<Teacher, Guid>, InMemoryRepository<Teacher,Guid>>();
builder.Services.AddSingleton<ITeachersApplicationService, TeachersApplicationService>();
builder.Services.AddSingleton<IRepository<Lesson, Guid>, InMemoryRepository<Lesson,Guid>>();
builder.Services.AddSingleton<ILessonsApplicationService, LessonsApplicationService>();
builder.Services.AddSingleton<ITeachingApplicationService, TeachingApplicationService>();
builder.Services.AddAutoMapper(typeof(Program), typeof(GroupMapping));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
