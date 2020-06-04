using testAAP.DB;
using Microsoft.AspNetCore.Mvc;


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
