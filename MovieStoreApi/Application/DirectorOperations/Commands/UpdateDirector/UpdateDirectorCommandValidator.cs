using FluentValidation;

namespace MovieStoreApi.Application.DirectorOperations.Commands;

public class UpdateDirectorCommandValidator : AbstractValidator<UpdateDirectorCommand>
{
    public UpdateDirectorCommandValidator()
    {
        RuleFor(command => command.model.FirstName).MinimumLength(4);
        RuleFor(command => command.model.LastName).MinimumLength(4);
        RuleFor(command => command.model.DirectedByMovies).MinimumLength(4);
    }
}
