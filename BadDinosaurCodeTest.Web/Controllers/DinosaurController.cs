using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BadDinosaurCodeTest.Web.Models;
using BadDinosaurCodeTest.Data;
using BadDinosaurCodeTest.Data.Enums;

namespace BadDinosaurCodeTest.Web.Controllers
{
    public class DinosaurController : Controller
    {
        private readonly DataContext _db;
        public DinosaurController(DataContext dataContext)
        {
            _db = dataContext;
        }

        public async Task<ActionResult> Index()
        {
            var dinosaurs = _db.Dinosaurs
                .OrderBy(d => d.Name)
                .Select(d => new DinosaurListItemModel
                {
                    Id = d.Id,
                    Name = d.Name,
                    CreatedOn = d.CreatedOn
                })
                .ToList();

            var model = new DinosaurListViewModel
            {
                Dinosaurs = dinosaurs
            };

            return View(model);
        }

        [HttpGet]
        public async Task<ActionResult> Edit(int? id)
        {
            var dinosaur = _db.Dinosaurs.FirstOrDefault(x => x.Id == id);
            var model = new EditDinosaurViewModel()
            {
                Id = dinosaur.Id,
                Name = dinosaur.Name,
                DinosaurType = dinosaur.DinosaurType // Assuming the dinosaur already has a type set in the database
            };
            ViewBag.DinosaurTypes = Enum.GetValues(typeof(DinosaurType)).Cast<DinosaurType>();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditDinosaurViewModel model)
        {
            var dinosaur = _db.Dinosaurs.FirstOrDefault(x => x.Id == model.Id);
            dinosaur.Name = model.Name;
            dinosaur.DinosaurType = model.DinosaurType;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Dinosaur");
        }
    }
}
