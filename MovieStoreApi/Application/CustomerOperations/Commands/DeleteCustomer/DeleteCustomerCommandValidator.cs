using FluentValidation;

namespace MovieStoreApi.Application.CustomerOperations.Commands;

public class DeleteCustomerCommandValidator : AbstractValidator<DeleteCustomerCommand>
{
    public DeleteCustomerCommandValidator()
    {
        RuleFor(x => x.CustomerId).GreaterThan(0);
    }
}
