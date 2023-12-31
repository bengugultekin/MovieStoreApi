﻿using MovieStoreApi.TokenOperations;

namespace MovieStoreApi.Application.UserOperations.Commands;

public class RefreshTokenCommand
{
    public string RefreshToken { get; set; }
    private readonly IMovieStoreDbContext _dbContext;
    private readonly IConfiguration _configuration;

    public RefreshTokenCommand(IMovieStoreDbContext dbContext, IConfiguration configuration)
    {
        _dbContext = dbContext;
        _configuration = configuration;
    }

    public Token Handle()
    {
        var user = _dbContext.Users.FirstOrDefault(x => x.RefreshToken == RefreshToken && x.RefreshTokenExpireDate > DateTime.Now);
        if (user is not null)
        {
            TokenHandler handler = new TokenHandler(_configuration);
            Token token = handler.CreateAccessToken(user);

            user.RefreshToken = token.RefreshToken;
            user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);
            _dbContext.SaveChanges();

            return token;
        }
        else
            throw new InvalidOperationException("Valid bir Refresh Token Bulunamadı!");
    }
}
