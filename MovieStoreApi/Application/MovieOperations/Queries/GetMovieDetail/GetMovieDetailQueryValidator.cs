using FluentValidation;
namespace MovieStoreApi.Application.MovieOperations.Queries;

public class GetMovieDetailQueryValidator : AbstractValidator<GetMovieDetailQuery>
{
    public GetMovieDetailQueryValidator()
    {
        RuleFor(query => query.MovieId).GreaterThan(0);
    }
}
