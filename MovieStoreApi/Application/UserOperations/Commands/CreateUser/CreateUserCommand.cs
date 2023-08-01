﻿using AutoMapper;

namespace MovieStoreApi.Application.UserOperations.Commands;

public class CreateUserCommand
{
    public CreateUserModel Model { get; set; }
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateUserCommand(IMovieStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public void Handle()
    {
        var user = _dbContext.Users.SingleOrDefault(x => x.Email == Model.Email);
        if (user is not null)
        {
            throw new InvalidOperationException("Kullanıcı zaten mevcut");
        }

        user = _mapper.Map<User>(Model);

        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();
    }
}
public class CreateUserModel
{
    public string Name { get; set; }
    public string Lastname { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }

}