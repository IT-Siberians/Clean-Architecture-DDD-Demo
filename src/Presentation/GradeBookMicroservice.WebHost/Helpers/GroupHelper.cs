using GradeBookMicroservice.Application.Services;
using GradeBookMicroservice.Application.Services.Abstractions;
using GradeBookMicroservice.Domain.Repositories.Abstractions;
using GradeBookMicroservice.Infrastructure.Repositories.Implementations.Ef;

namespace GradeBookMicroservice.WebHost.Helpers;

public static class GroupHelper
{
    public static IServiceCollection AddGroups(this IServiceCollection services)
    {
        services.AddScoped<IGroupsRepository, EfGroupRepository>();
        services.AddScoped<IGroupsApplicationService, GroupsApplicationService>();
        return services;
    }

}
