using FluentValidation;

namespace MovieStoreApi.Application.ActorOperations.Commands;

public class UpdateActorCommandValidator : AbstractValidator<UpdateActorCommand>
{
    public UpdateActorCommandValidator()
    {
        RuleFor(command => command.model.FirstName).MinimumLength(4);
        RuleFor(command => command.model.LastName).MinimumLength(4);
    }
}
