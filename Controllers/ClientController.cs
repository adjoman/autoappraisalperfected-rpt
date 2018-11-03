using Microsoft.AspNetCore.Mvc;
using testAAP.DB;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace testAAP.Controllers
{
    public class IndexController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            AppraisalsContext context = HttpContext.RequestServices.GetService(typeof(AppraisalsContext)) as AppraisalsContext;

            return View(context.GetAllClients());
        }
    }
}
