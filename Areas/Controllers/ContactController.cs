using Microsoft.AspNetCore.Mvc;

namespace Onur_PortfolioTemp.Areas.Admin.Controllers
{

    [Area("Admin")]
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
