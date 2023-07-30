using AutoMapper;
using MovieStoreApi.Application.ActorOperations.Commands;
using MovieStoreApi.Application.ActorOperations.Queries;
using MovieStoreApi.Application.DirectorOperations;
using MovieStoreApi.Application.DirectorOperations.Queries;
using MovieStoreApi.Application.MovieOperations.Commands;
using MovieStoreApi.Application.MovieOperations.Queries;

namespace MovieStoreApi;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Actor, ActorsViewModel>();
        CreateMap<Actor, ActorDetailViewModel>();
        CreateMap<CreateActorViewModel, Actor>();

        CreateMap<Director, DirectorsViewModel>();
        CreateMap<Director, DirectorDetailViewModel>();
        CreateMap<CreateDirectorModel, Director>();

        CreateMap<Director, MoviesViewModel>();
        CreateMap<Director, MovieDetailViewModel>();
        CreateMap<CreateMovieModel, Movie>();
    }
}
