using FluentValidation;

namespace MovieStoreApi.Application.CustomerOperations.Commands;

public class UpdateCustomerCommandValidator : AbstractValidator<UpdateCustomerCommand>
{
    public UpdateCustomerCommandValidator() 
    {
        RuleFor(command => command.model.FirstName).MinimumLength(4);
        RuleFor(command => command.model.LastName).MinimumLength(4);
        RuleFor(command => command.model.FavoriteGenresId).NotEmpty();
        RuleFor(command => command.model.BuyedFilmsId).NotEmpty();
    }
}
