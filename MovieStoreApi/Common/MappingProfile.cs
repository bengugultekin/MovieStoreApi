using AutoMapper;
using MovieStoreApi.Application.ActorOperations.Commands;
using MovieStoreApi.Application.ActorOperations.Queries;

namespace MovieStoreApi;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Actor, ActorsViewModel>();
        CreateMap<Actor, ActorDetailViewModel>();
        CreateMap<CreateActorViewModel, Actor>();
    }
}
