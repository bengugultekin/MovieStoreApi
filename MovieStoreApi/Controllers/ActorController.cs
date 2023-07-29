using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStoreApi.Application.ActorOperations.Commands;
using MovieStoreApi.Application.ActorOperations.Queries;

namespace MovieStoreApi;

[ApiController]
[Route("[controller]s")]
public class ActorController : ControllerBase
{
    private readonly IMovieStoreDbContext _context;
    private readonly IMapper _mapper;

    public ActorController(IMovieStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetActors()
    {
        GetActorsQuery query = new GetActorsQuery(_context, _mapper);
        var obj = query.Handle();
        return Ok(obj);
    }

    [HttpGet("{id}")]
    public ActionResult GetActorDetail(int id)
    {
        GetActorDetailQuery query = new GetActorDetailQuery(_context, _mapper);
        query.ActorId = id;
        GetActorDetailQueryValidator validator = new GetActorDetailQueryValidator();
        validator.ValidateAndThrow(query);

        var obj = query.Handle();
        return Ok(obj);
    }

    [HttpPost]
    public IActionResult AddActor([FromBody] CreateActorViewModel model)
    {
        CreateActorCommand command = new CreateActorCommand(_context, _mapper);
        command.model = model;

        CreateActorCommandValidator validator = new CreateActorCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateActor(int id, [FromBody] UpdateActorViewModel model)
    {
        UpdateActorCommand command = new UpdateActorCommand(_context);
        command.ActorId = id;
        command.model = model;

        UpdateActorCommandValidator validator = new UpdateActorCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteActor(int id)
    {
        DeleteActorCommand command = new DeleteActorCommand(_context);
        command.ActorId = id;

        DeleteActorCommandValidator validator = new DeleteActorCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();
        return Ok();
    }
}
