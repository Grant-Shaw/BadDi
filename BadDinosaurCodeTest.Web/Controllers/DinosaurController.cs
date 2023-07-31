using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BadDinosaurCodeTest.Web.Models;
using BadDinosaurCodeTest.Data;

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
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditDinosaurViewModel model)
        {
            var dinosaur = _db.Dinosaurs.FirstOrDefault(x => x.Id == model.Id);
            dinosaur.Name = model.Name;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", "Dinosaur");
        }
    }
}
