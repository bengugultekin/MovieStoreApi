using FluentValidation;

namespace MovieStoreApi.Application.ActorOperations.Commands;

public class CreateActorCommandValidator : AbstractValidator<CreateActorCommand>
{
    public CreateActorCommandValidator() 
    {
        RuleFor(command => command.model.FirstName).MinimumLength(4);
        RuleFor(command => command.model.LastName).MinimumLength(4);
        RuleFor(command => command.model.StarringMovies).MinimumLength(4);
    }
}
