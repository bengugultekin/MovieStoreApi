using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using MovieStoreApi.Application.DirectorOperations;
using MovieStoreApi.Application.DirectorOperations.Command;
using MovieStoreApi.Application.DirectorOperations.Commands;
using MovieStoreApi.Application.DirectorOperations.Queries;

namespace MovieStoreApi;

[ApiController]
[Route("[controller]s")]
public class DirectorController : ControllerBase
{
    private readonly IMovieStoreDbContext _context;
    private readonly IMapper _mapper;

    public DirectorController(IMovieStoreDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetDirectors()
    {
        GetDirectorsQuery query = new GetDirectorsQuery(_context, _mapper);
        var obj = query.Handle();
        return Ok(obj);
    }

    [HttpGet("{id}")]
    public ActionResult GetDirectorDetail(int id)
    {
        GetDirectorDetailQuery query = new GetDirectorDetailQuery(_context, _mapper);
        query.DirectorId = id;
        GetDirectorDetailQueryValidator validator = new GetDirectorDetailQueryValidator();
        validator.ValidateAndThrow(query);

        var obj = query.Handle();
        return Ok(obj);
    }

    [HttpPost]
    public IActionResult AddDirector([FromBody] CreateDirectorModel model)
    {
        CreateDirectorCommand command = new CreateDirectorCommand(_context, _mapper);
        command.model = model;

        CreateDirectorCommandValidator validator = new CreateDirectorCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateDirector(int id, [FromBody] UpdateDirectorModel model)
    {
        UpdateDirectorCommand command = new UpdateDirectorCommand(_context);
        command.DirectorId = id;
        command.model = model;

        UpdateDirectorCommandValidator validator = new UpdateDirectorCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteDirector(int id)
    {
        DeleteDirectorCommand command = new DeleteDirectorCommand(_context);
        command.DirectorId = id;

        DeleteDirectorCommandValidator validator = new DeleteDirectorCommandValidator();
        validator.ValidateAndThrow(command);

        command.Handle();
        return Ok();
    }
}
