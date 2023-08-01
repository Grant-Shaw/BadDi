using BadDinosaurCodeTest.Data;
using BadDinosaurCodeTest.Data.Enums;
using BadDinosaurCodeTest.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BadDinosaurCodeTest.Web.Controllers;

public class DinosaurController : Controller
{
    private readonly DataContext _db;
    private readonly ILogger<DinosaurController> _logger;
    public DinosaurController(DataContext dataContext, ILogger<DinosaurController> logger)
    {
        _logger = logger;
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
                CreatedOn = d.CreatedOn,
                DinosaurType = d.DinosaurType

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
        var dinosaur = await _db.Dinosaurs.FirstOrDefaultAsync(x => x.Id == id);
        var model = new EditDinosaurViewModel()
        {
            Id = dinosaur.Id,
            Name = dinosaur.Name,
            DinosaurType = dinosaur.DinosaurType,
            TeamId = dinosaur.TeamId
        };
        ViewBag.DinosaurTypes = Enum.GetValues(typeof(DinosaurType)).Cast<DinosaurType>();
        ViewBag.Teams = await _db.Teams.ToListAsync();
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Edit(EditDinosaurViewModel model)
    {
        try
        {
            var dinosaur = await _db.Dinosaurs.FirstOrDefaultAsync(x => x.Id == model.Id);

            if (dinosaur == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                dinosaur.Name = model.Name;
                dinosaur.DinosaurType = model.DinosaurType;
                dinosaur.TeamId = model.TeamId;
                await _db.SaveChangesAsync();
                return RedirectToAction("Index", "Dinosaur");
            }
            else
            {

                ViewBag.DinosaurTypes = Enum.GetValues(typeof(DinosaurType)).Cast<DinosaurType>();
                ViewBag.Teams = await _db.Teams.ToListAsync();
                return View(model);
            }
        }
        catch (Exception ex)
        {
            _logger.LogError("An unexpected error occured {Exception}", ex);
            return RedirectToAction("Error", "Home");
        }
    }
}
