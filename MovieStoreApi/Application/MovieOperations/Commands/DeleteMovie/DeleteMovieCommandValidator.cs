using FluentValidation;

namespace MovieStoreApi.Application.MovieOperations.Commands;

public class DeleteMovieCommandValidator : AbstractValidator<DeleteMovieCommand>
{
    public DeleteMovieCommandValidator()
    {
        RuleFor(command => command.MovieId).GreaterThan(0);
    }
}
