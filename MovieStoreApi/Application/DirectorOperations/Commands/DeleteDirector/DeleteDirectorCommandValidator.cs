using FluentValidation;
namespace MovieStoreApi.Application.DirectorOperations.Commands;

public class DeleteDirectorCommandValidator : AbstractValidator<DeleteDirectorCommand>
{
    public DeleteDirectorCommandValidator()
    {
        RuleFor(command => command.DirectorId).GreaterThan(0);
    }
}
