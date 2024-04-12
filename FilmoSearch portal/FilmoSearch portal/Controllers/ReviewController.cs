using AutoMapper;
using FilmoSearch_portal.Interfaces;
using FilmoSearch_portal.Models;
using FilmoSearch_portal.ViewModels.ReviewViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace FilmoSearch_portal.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IPortal _portal;
        private IMapper _mapper;
        private static int _thisFilm;

        public ReviewController(IPortal portal, IMapper mapper)
        {
            _portal = portal;
            _mapper = mapper;
        }

        // GET: ReviewController/Details/5
        public ActionResult Details(int id)
        {
            var model = _portal.Film.Reviews.GetById(id);
            var vm = _mapper.Map<ReviewsViewModel>(model);
            vm.FilmTitle = _portal.Film.GetById(vm.FilmId).Title;
            return View(vm);
        }

        // GET: ReviewController/Create
        public ActionResult Create(int id)
        {
            var vm = new CreateReviewViewModel();
            vm.FilmId = id;
            vm.FilmTitle = _portal.Film.GetById(id).Title;
            return View(vm);
        }

        // POST: ReviewController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateReviewViewModel vm)
        {
            try
            {
                var model = _mapper.Map<Review>(vm);
                var film = _portal.Film.GetById(vm.FilmId);
                film.Reviews.Add(model);
                _portal.Save();
                return Redirect($"/Film/Details/{model.FilmId}");
            }
            catch
            {
                return Redirect("/Role/Error");
            }
        }

        // GET: ReviewController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _portal.Film.Reviews.GetById(id);
            return View(model);
        }

        // POST: ReviewController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Review model)
        {
            try
            {
                model.Film.Id = model.FilmId;
                _portal.Film.Reviews.Update(model);
                _portal.Save();
                return Redirect($"/Film/Details/{model.FilmId}");
            }
            catch
            {
                return Redirect("/Role/Error");
            }
        }

        // GET: ReviewController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _portal.Film.Reviews.GetById(id);
            var vm = _mapper.Map<ReviewsViewModel>(model);
            vm.FilmTitle = _portal.Film.GetById(vm.FilmId).Title;
            return View(vm);
        }

        // POST: ReviewController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ReviewsViewModel vm)
        {
            try
            {
                var model = _portal.Film.Reviews.GetById(vm.Id);
                _thisFilm = model.FilmId;
                _portal.Film.Reviews.Delete(model);
                _portal.Save();
                return Redirect($"/Film/Details/{_thisFilm}");
            }
            catch
            {
                return Redirect("/Role/Error");
            }
        }
    }
}
