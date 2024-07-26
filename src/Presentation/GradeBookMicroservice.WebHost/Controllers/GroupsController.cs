using AutoMapper;
using GradeBookMicroservice.Application.Models.Create;
using GradeBookMicroservice.Application.Services.Base;
using Microsoft.AspNetCore.Mvc;

namespace GradeBookMicroservice.WebHost;
[ApiController]
[Route("api/v1/[controller]")]
public class GroupsController(IGroupsApplicationService groupsApplicationService, IMapper mapper) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<GroupShortResponse>))]
    public async Task<IActionResult> GetAllGroups()
    {
        var groups = await groupsApplicationService.GetAllGroupsAsync();
        return Ok(groups.Select(mapper.Map<GroupShortResponse>));
    }
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GroupDetailedResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(Guid))]
    public async Task<IActionResult> GetGroupById(Guid id)
    {
        var group = await groupsApplicationService.GetGroupByIdAsync(id);
        if(group==null)
            return NotFound(id);
        return Ok(mapper.Map<GroupDetailedResponse>(group));
    }
    [HttpGet("{name}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GroupDetailedResponse))]
    [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(string))]
    public async Task<IActionResult> GetGroupByName(string name)
    {
        var group = await groupsApplicationService.GetGroupByNameAsync(name);
        if(group==null)
            return NotFound(name);
        return Ok(mapper.Map<GroupDetailedResponse>(group));
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(GroupShortResponse))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type=typeof(string))]
    public async Task<IActionResult> CreateGroup(CreateGroupRequest request)
    {
        if(await groupsApplicationService.GetGroupByNameAsync(request.Name)!=null)
            return BadRequest("Group exist yet");
        var group = await groupsApplicationService.CreateGroupAsync(mapper.Map<CreateGroupModel>(request));
        if(group==null)
            return BadRequest("group can not be created");
        return Created("", mapper.Map<GroupShortResponse>(group));

    }


}
