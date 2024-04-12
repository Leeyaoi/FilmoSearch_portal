using AutoMapper;
using FilmoSearch_portal.Interfaces;
using FilmoSearch_portal.Models;
using FilmoSearch_portal.ViewModels.FilmViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmoSearch_portal.Controllers
{
    public class FilmController : Controller
    {
        // GET: FilmController
        private readonly IPortal _portal;
        private IMapper _mapper;

        public FilmController(IPortal portal, IMapper mapper)
        {
            _portal = portal;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var model = _portal.Film.GetAll();
            var vm = _mapper.Map<List<FilmsViewModel>>(model);
            return View(vm);
        }

        // GET: FilmController/Details/5
        public ActionResult Details(int id)
        {
            var model = _portal.Film.GetById(id);
            var vm = _mapper.Map<FilmsViewModel>(model);
            return View(vm);
        }

        // GET: FilmController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FilmController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateFilmViewModel vm)
        {
            try
            {
                var model = _mapper.Map<Film>(vm);
                _portal.Film.Insert(model);
                _portal.Save();
                return Redirect("/Film/Index");
            }
            catch
            {
                return Redirect("/Role/Error");
            }
        }

        // GET: FilmController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _portal.Film.GetById(id);
            var vm = _mapper.Map<FilmsViewModel>(model);
            return View(vm);
        }

        // POST: FilmController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FilmsViewModel vm)
        {
            try
            {
                var model = _mapper.Map<Film>(vm);
                _portal.Film.Update(model);
                _portal.Save();
                return Redirect("/Film/Index");
            }
            catch
            {
                return Redirect("/Role/Error");
            }
        }

        // GET: FilmController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _portal.Film.GetById(id);
            var vm = _mapper.Map<FilmsViewModel>(model);
            return View(vm);
        }

        // POST: FilmController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(FilmsViewModel vm)
        {
            try
            {
                var model = _portal.Film.GetById(vm.Id);
                _portal.Film.Delete(model);
                _portal.Save();
                return Redirect("/Film/Index");
            }
            catch
            {
                return Redirect("/Role/Error");
            }
        }
    }
}
