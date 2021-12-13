using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ZooApp.Models;
using ZooApp.Services;

namespace ZooApp.Controllers
{
    public class SponsorController : Controller
    {
        private readonly SponsorService _sponsorService;
        private readonly ZooService _zooService;
        public SponsorController(SponsorService sponsorService, ZooService zooService)
        {
            _sponsorService = sponsorService;
            _zooService = zooService;
        }
        // GET: SponsorController
        public ActionResult Index()
        {
            var result = _sponsorService.GetAll();
            return View(result);
        }

        // GET: SponsorController/Create
        public ActionResult Create()
        {
            SponsorFormModel sponsorFormModel = new SponsorFormModel(_zooService.GetAll());
            return View(sponsorFormModel);
        }

        // POST: SponsorController/Create
        [HttpPost]
        public ActionResult Create(SponsorModel sponsor)
        {
            _sponsorService.AddSponsor(sponsor);
            return RedirectToAction("Create");
        }

        // GET: SponsorController/Edit/5
        public ActionResult Edit(int id)
        {
            SponsorFormModel sponsor = _sponsorService.GetSingle(id);
            sponsor.Animals = _zooService.GetAll();
            return View(sponsor);
        }

        // POST: SponsorController/Edit/5
        [HttpPost]
        public ActionResult Edit(SponsorModel sponsor)
        {
            _sponsorService.EditSponsor(sponsor);
            return RedirectToAction("Index");
        }

        // GET: SponsorController/Delete/5
        public ActionResult Delete(int id)
        {
            _sponsorService.DeleteSponsor(id);
            return RedirectToAction("Index");
        }
    }
}
