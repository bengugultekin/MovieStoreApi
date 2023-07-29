using FluentValidation;

namespace MovieStoreApi.Application.DirectorOperations.Queries;

public class GetDirectorDetailQueryValidator : AbstractValidator<GetDirectorDetailQuery>
{
    public GetDirectorDetailQueryValidator()
    {
        RuleFor(query => query.DirectorId).GreaterThan(0);
    }
}
