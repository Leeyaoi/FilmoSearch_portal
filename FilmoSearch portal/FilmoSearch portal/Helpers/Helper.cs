using AutoMapper;
using FilmoSearch_portal.Models;
using FilmoSearch_portal.ViewModels.ActorViewModel;
using FilmoSearch_portal.ViewModels.FilmViewModels;
using FilmoSearch_portal.ViewModels.ReviewViewModels;
using FilmoSearch_portal.ViewModels.RoleViewModels;

namespace FilmoSearch_portal.Helpers
{
    public class Helper : Profile
    {
        public Helper()
        {
            CreateMap<Film, FilmsViewModel>().ReverseMap();
            CreateMap<CreateFilmViewModel, Film>();

            CreateMap<Actor, ActorsViewModel>().ReverseMap();
            CreateMap<CreateActorViewModel, Actor>();

            CreateMap<Review, ReviewsViewModel>().ReverseMap();
            CreateMap<CreateReviewViewModel, Review>();

            CreateMap<Role, RoleViewModel>().ReverseMap();
            CreateMap<CreateRoleViewModelToFilm,  Role>();
        }
    }
}
