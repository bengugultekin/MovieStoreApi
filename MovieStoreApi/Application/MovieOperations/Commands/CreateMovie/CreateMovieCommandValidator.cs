﻿using FluentValidation;

namespace MovieStoreApi.Application.MovieOperations.Commands;

public class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
{
    public CreateMovieCommandValidator()
    {
        RuleFor(command => command.model.Name).MinimumLength(0);
        RuleFor(command => command.model.PublishDate).NotEmpty().LessThan(DateTime.Now.Date);
        RuleFor(command => command.model.Genre).MinimumLength(3);
        RuleFor(command => command.model.Price).GreaterThan(0);

    }
}