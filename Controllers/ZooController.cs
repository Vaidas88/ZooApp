using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZooApp.Models;
using ZooApp.Services;

namespace ZooApp.Controllers
{
    public class ZooController : Controller
    {
        private readonly ZooService _zooService;
        public ZooController(ZooService zooService)
        {
            _zooService = zooService;
        }
        // GET: ZooController
        public ActionResult Index()
        {
            var result = _zooService.GetAll();
            return View(result);
        }

        // GET: ZooController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ZooController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AnimalModel animal)
        {
            _zooService.AddAnimal(animal);
            return RedirectToAction("Create");
        }

        // GET: ZooController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_zooService.GetSingle(id));
        }

        // POST: ZooController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(AnimalModel animal)
        {
            _zooService.EditAnimal(animal);
            return RedirectToAction("Index");
        }

        // GET: ZooController/Delete/5
        public ActionResult Delete(int id)
        {
            _zooService.DeleteAnimal(id);
            return RedirectToAction("Index");
        }
    }
}
