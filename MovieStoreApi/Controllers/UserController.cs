﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieStoreApi.Application.UserOperations.Commands;
using MovieStoreApi.TokenOperations;

namespace MovieStoreApi;

[ApiController]
[Route("[controller]s")]
public class UserController : ControllerBase
{
    private readonly IMovieStoreDbContext _context;
    private readonly IMapper _mapper;
    readonly IConfiguration _configuration;

    public UserController(IMovieStoreDbContext context, IMapper mapper, IConfiguration configuration)
    {
        _context = context;
        _mapper = mapper;
        _configuration = configuration;
    }

    [HttpPost]
    public IActionResult AddUser([FromBody] CreateUserModel newUser)
    {
        CreateUserCommand command = new CreateUserCommand(_context, _mapper);
        command.Model = newUser;
        command.Handle();

        return Ok();
    }

    [HttpPost("connect/token")]
    public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login)
    {
        CreateTokenCommand command = new CreateTokenCommand(_context, _mapper, _configuration);
        command.Model = login;
        var token = command.Handle();
        return token;
    }

    [HttpGet("refreshToken")]
    public ActionResult<Token> RefreshToken([FromQuery] string token)
    {
        RefreshTokenCommand command = new RefreshTokenCommand(_context, _configuration);
        command.RefreshToken = token;
        var resultToken = command.Handle();
        return resultToken;
    }
}
