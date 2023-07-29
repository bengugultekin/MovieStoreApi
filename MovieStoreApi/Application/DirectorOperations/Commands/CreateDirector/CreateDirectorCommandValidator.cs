using FluentValidation;

namespace MovieStoreApi.Application.DirectorOperations.Command
{
    public class CreateDirectorCommandValidator : AbstractValidator<CreateDirectorCommand>
    {
        public CreateDirectorCommandValidator()
        {
            RuleFor(command => command.model.FirstName).MinimumLength(4);
            RuleFor(command => command.model.LastName).MinimumLength(4);
            RuleFor(command => command.model.DirectedByMovies).MinimumLength(4);
        }
    }
}
