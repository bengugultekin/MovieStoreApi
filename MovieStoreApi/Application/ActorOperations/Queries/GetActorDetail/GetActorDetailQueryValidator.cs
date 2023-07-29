using FluentValidation;

namespace MovieStoreApi.Application.ActorOperations.Queries;

public class GetActorDetailQueryValidator : AbstractValidator<GetActorDetailQuery>
{
    public GetActorDetailQueryValidator()
    {
        RuleFor(query => query.ActorId).GreaterThan(0);
    }
}
