using FluentValidation;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace MovieStoreApi.Application.CustomerOperations.Commands;

public class CreateCustomerCommandValidator : AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidator()
    {
        RuleFor(command => command.Model.FirstName).MinimumLength(4);
        RuleFor(command => command.Model.LastName).MinimumLength(4);
    }
}
