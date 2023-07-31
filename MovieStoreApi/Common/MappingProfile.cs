using AutoMapper;
using MovieStoreApi.Application.ActorOperations.Commands;
using MovieStoreApi.Application.ActorOperations.Queries;
using MovieStoreApi.Application.CustomerOperations.Commands;
using MovieStoreApi.Application.CustomerOperations.Queries;
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

        CreateMap<Movie, MoviesViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.FirstName + " " + src.Director.LastName));
        CreateMap<Movie, MovieDetailViewModel>().ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name)).ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.FirstName + " " + src.Director.LastName));
        CreateMap<CreateMovieModel, Movie>();

        CreateMap<CreateCustomerModel, Customer>();
        CreateMap<Customer, CustomersViewModel>();
        CreateMap<Customer, CustomerDetailViewModel>().ForMember(dest => dest.FavoriteGenres, opt => opt.MapFrom(src => src.Genre.Name));

    }
}
