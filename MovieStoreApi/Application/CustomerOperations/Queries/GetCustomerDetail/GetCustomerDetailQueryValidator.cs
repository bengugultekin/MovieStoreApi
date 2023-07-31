using FluentValidation;

namespace MovieStoreApi.Application.CustomerOperations.Queries.GetCustomerDetail
{
    public class GetCustomerDetailQueryValidator : AbstractValidator<GetCustomerDetailQuery>
    {
        public GetCustomerDetailQueryValidator() 
        {
            RuleFor(x => x.CustomerId).GreaterThan(0);
        }
    }
}
