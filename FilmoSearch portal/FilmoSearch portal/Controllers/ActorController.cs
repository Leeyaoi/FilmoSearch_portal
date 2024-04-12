using AutoMapper;
using FilmoSearch_portal.Interfaces;
using FilmoSearch_portal.Models;
using FilmoSearch_portal.ViewModels.ActorViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FilmoSearch_portal.Controllers
{
    public class ActorController : Controller
    {
        private readonly IPortal _portal;
        private readonly IMapper _mapper;

        public ActorController(IPortal portal, IMapper mapper)
        {
            _portal = portal;
            _mapper = mapper;
        }

        // GET: ActorController
        public ActionResult Index()
        {
            var model = _portal.Actor.GetAll();
            var vm = _mapper.Map<List<ActorsViewModel>>(model);
            return View(vm);
        }

        // GET: ActorController/Details/5
        public ActionResult Details(int id)
        {
            var model = _portal.Actor.GetById(id);
            var vm = _mapper.Map<ActorsViewModel>(model);
            return View(vm);
        }

        // GET: ActorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ActorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateActorViewModel vm)
        {
            try
            {
                var model = _mapper.Map<Actor>(vm);
                _portal.Actor.Insert(model);
                _portal.Save();
                return RedirectToAction("Index", "Actor");
            }
            catch
            {
                return Redirect("/Role/Error");
            }
        }

        // GET: ActorController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = _portal.Actor.GetById(id);
            var vm = _mapper.Map<ActorsViewModel>(model);
            return View(vm);
        }

        // POST: ActorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ActorsViewModel vm)
        {
            try
            {
                var model = _mapper.Map<Actor>(vm);
                _portal.Actor.Update(model);
                _portal.Save();
                return RedirectToAction("Index", "Actor");
            }
            catch
            {
                return Redirect("/Role/Error");
            }
        }

        // GET: ActorController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = _portal.Actor.GetById(id);
            var vm = _mapper.Map<ActorsViewModel>(model);
            return View(vm);
        }

        // POST: ActorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ActorsViewModel vm)
        {
            try
            {
                var model = _portal.Actor.GetById(vm.Id);
                _portal.Actor.Delete(model);
                _portal.Save();
                return RedirectToAction("Index", "Actor");
            }
            catch
            {
                return Redirect("/Role/Error");
            }
        }
    }
}
