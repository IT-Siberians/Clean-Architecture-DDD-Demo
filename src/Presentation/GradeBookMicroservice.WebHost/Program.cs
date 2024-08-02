using GradeBookMicroservice.Application.Services;
using GradeBookMicroservice.Application.Services.Abstractions;
using GradeBookMicroservice.Application.Services.Mapping;
using GradeBookMicroservice.Domain.Entities;
using GradeBookMicroservice.Domain.Repositories.Abstractions;
using GradeBookMicroservice.Infrastructure.EntityFramework;
using GradeBookMicroservice.Infrastructure.Repositories.Implementations.Ef;
using GradeBookMicroservice.Infrastructure.Repositories.Implementations.InMemory;
using GradeBookMicroservice.WebHost.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddNpgsql<ApplicationDbContext>("Host=localhost;Port=5432;Username=postgres;Password=otus", options => 
{
    options.MigrationsAssembly("GradeBookMicroservice.Infrastructure.EntityFramework");

});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddGroups();
builder.Services.AddScoped<IRepository<Student,Guid>, EfRepository<Student,Guid>>();
builder.Services.AddScoped<IStudentsApplicationService, StudentsApplicationService>();
builder.Services.AddScoped<IRepository<Teacher, Guid>, InMemoryRepository<Teacher,Guid>>();
builder.Services.AddScoped<ITeachersApplicationService, TeachersApplicationService>();
builder.Services.AddScoped<IRepository<Lesson, Guid>, InMemoryRepository<Lesson,Guid>>();
builder.Services.AddScoped<ILessonsApplicationService, LessonsApplicationService>();
builder.Services.AddScoped<ITeachingApplicationService, TeachingApplicationService>();
builder.Services.AddScoped<IVisitingApplicationService, VisitingApplicationService>();
builder.Services.AddScoped<IRepository<Grade, Guid>, InMemoryRepository<Grade,Guid>>();
builder.Services.AddScoped<IAssesmentApplicationService, AssesmentApplicationService>();
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
app.MigrateDatabase<ApplicationDbContext>();
app.Run();
