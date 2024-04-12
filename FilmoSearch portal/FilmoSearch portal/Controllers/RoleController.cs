using AutoMapper;
using FilmoSearch_portal.Interfaces;
using FilmoSearch_portal.Models;
using FilmoSearch_portal.ViewModels.RoleViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.Elfie.Serialization;

namespace FilmoSearch_portal.Controllers
{
	public class RoleController : Controller
	{
		private readonly IPortal _portal;
		private readonly IMapper _mapper;

		private static int _currentFilm = 1;
        private static int _currentActor = -1;

        public RoleController(IPortal portal, IMapper mapper)
		{
			_portal = portal;
			_mapper = mapper;
		}

		public ActionResult Error()
		{
			return View();
		}

		public ActionResult ShowActors(int filmId)
		{
			var film = _portal.Film.GetById(filmId);
			_currentFilm = filmId;
			_currentActor = -1;
			return View(film);
		}

        public ActionResult ShowFilms(int actorId)
        {
            var actor = _portal.Actor.GetById(actorId);
            _currentFilm = -1;
            _currentActor = actorId;
            return View(actor);
        }

        // GET: RoleController/Create
        public ActionResult CreateToFilm()
		{
			var actors = _portal.Actor.GetAll();
			var selectList = new List<SelectListItem>();
			foreach(var item in actors)
			{
				selectList.Add(new SelectListItem(item.FirstName+" "+item.LastName, item.Id.ToString()));
			}
			var vm = new CreateRoleViewModelToFilm();
			vm.Actors = selectList;
			vm.FilmId = _currentFilm;
			vm.FilmTitle = _portal.Film.GetById(_currentFilm).Title;
			return View(vm);
		}

        public ActionResult CreateToActor()
        {
            var films = _portal.Film.GetAll();
            var selectList = new List<SelectListItem>();
            foreach (var item in films)
            {
                selectList.Add(new SelectListItem(item.Title, item.Id.ToString()));
            }
            var vm = new CreateRoleViewModelToActor();
            vm.Films = selectList;
            vm.ActorId = _currentActor;
			var actor = _portal.Actor.GetById(_currentActor);
            vm.ActorName = actor.FirstName +" "+ actor.LastName;
            return View(vm);
        }

        // POST: RoleController/Create
        [HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(CreateRoleViewModelToFilm vm)
		{
			try
			{
				var model = _mapper.Map<Role>(vm);
                _portal.Film.GetById(model.FilmId).Roles.Add(model);
                _portal.Save();
                if (_currentFilm > 0 && _currentActor < 0)
                {
					return RedirectToAction("ShowActors", new { filmId = _currentFilm });
				}
                if (_currentFilm < 0 && _currentActor > 0)
				{
                    return RedirectToAction("ShowFilms", new { actorId = _currentActor });
				}
				return Redirect("/Film/Index");
            }
			catch
			{
				return View("Error");
			}
		}

		// GET: RoleController/Edit/5
		public ActionResult Edit(int filmId, int actorId)
		{
			var role = _portal.Film.GetById(filmId).Roles.FirstOrDefault(r => r.ActorId == actorId)!;
            var vm = _mapper.Map<RoleViewModel>(role);
            vm.ActorName = role.Actor!.FirstName + " " + role.Actor.LastName;
            vm.FilmTitle = role.Film!.Title;
            return View(vm);
		}

		// POST: RoleController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(RoleViewModel vm)
		{
			try
			{
				var model = _mapper.Map<Role>(vm);
				var film = _portal.Film.GetById(model.FilmId);
				film.Roles[film.Roles.FindIndex(r => r.ActorId == vm.ActorId)] = model;
				_portal.Save();
                if (_currentFilm > 0 && _currentActor < 0)
                {
                    return RedirectToAction("ShowActors", new { filmId = _currentFilm });
                }
                if (_currentFilm < 0 && _currentActor > 0)
                {
                    return RedirectToAction("ShowFilms", new { actorId = _currentActor });
                }
                return Redirect("/Film/Index");
            }
			catch
			{
                return View("Error");
            }
		}

		// GET: RoleController/Delete/5
		public ActionResult Delete(int filmId, int actorId)
        {
            var role = _portal.Film.GetById(filmId).Roles.FirstOrDefault(r => r.ActorId == actorId)!;
            var vm = _mapper.Map<RoleViewModel>(role);
            vm.ActorName = role.Actor!.FirstName + " " + role.Actor.LastName;
            vm.FilmTitle = role.Film!.Title;
            return View(vm);
        }

		// POST: RoleController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(RoleViewModel vm, int filmId, int actorId)
		{
			try
			{
                var model = _portal.Film.GetById(filmId).Roles.FirstOrDefault(r => r.ActorId == actorId);
                _portal.Film.GetById(filmId).Roles.Remove(model!);
                _portal.Save();
                if (_currentFilm > 0 && _currentActor < 0)
                {
                    return RedirectToAction("ShowActors", new { filmId = _currentFilm });
                }
                if (_currentFilm < 0 && _currentActor > 0)
                {
                    return RedirectToAction("ShowFilms", new { actorId = _currentActor });
                }
                return Redirect("/Film/Index");
            }
			catch
			{
                return View("Error");
            }
		}
	}
}
