using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BadDinosaurCodeTest.Web.Controllers;

public class TeamController : Controller
{
    public async Task<ActionResult> Index()
    {
        // TODO: Get teams.
        return View();
    }
}