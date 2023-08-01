using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStoreApi.Application;
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
    private readonly IMovieStoreDbContext _dbContext;
    public MappingProfile()
    {
        CreateMap<Actor, ActorsViewModel>();
        CreateMap<Actor, ActorDetailViewModel>();
        CreateMap<CreateActorViewModel, Actor>();

        CreateMap<Director, DirectorsViewModel>();
        CreateMap<Director, DirectorDetailViewModel>();
        CreateMap<CreateDirectorModel, Director>();

        CreateMap<Movie, MoviesViewModel>()
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
            .ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.FirstName + " " + src.Director.LastName))
            .ForMember(dest => dest.Actors, opt => opt.MapFrom(src => src.Actors.Select(a => a.FirstName + " " + a.LastName).ToList()));

        CreateMap<Movie, MovieDetailViewModel>()
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name))
            .ForMember(dest => dest.Director, opt => opt.MapFrom(src => src.Director.FirstName + " " + src.Director.LastName));

        CreateMap<CreateMovieModel, Movie>();

        CreateMap<Genre, GenreViewModel>(); // Genres koleksiyonunu doğrudan GenreViewModel ile eşleştiriyoruz
        CreateMap<Movie, BoughtMovieModel>()
    .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
        CreateMap<BoughtMovieModel, Genre>();
        CreateMap<Movie, BoughtMovieModel>()
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src.Genre.Name));
        CreateMap<Movie, BuyMovie>();
        CreateMap<CreateCustomerModel, Customer>()
            .ForMember(dest => dest.FavoriteGenres, opt => opt.MapFrom(src => src.FavoriteGenres))
            .ForMember(dest => dest.BuyMovie, opt => opt.MapFrom(src => src.BuyMovie));
        CreateMap<Customer, CustomersViewModel>()
            .ForMember(dest => dest.FavoriteGenres, opt => opt.MapFrom(src => src.FavoriteGenres))
            .ForMember(dest => dest.BoughtMovies, opt => opt.MapFrom(src => src.BoughtMovies));

        CreateMap<Customer, CustomerDetailViewModel>()
            .ForMember(dest => dest.FavoriteGenres, opt => opt.MapFrom(src => src.FavoriteGenres))
            .ForMember(dest => dest.BoughtMovies, opt => opt.MapFrom(src => src.BoughtMovies));

        CreateMap<Actor, string>().ConvertUsing(a => a.FirstName + " " + a.LastName);
    }


}
