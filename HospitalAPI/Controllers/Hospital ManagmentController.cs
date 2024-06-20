using Microsoft.AspNetCore.Mvc;

namespace HospitalAPI.Controllers
{
    public class Hospital_ManagmentController : Controller
    {

        public IActionResult Index()
        {

            return View();
        }
    }
}
