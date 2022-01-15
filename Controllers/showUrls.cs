using Microsoft.AspNetCore.Mvc;

#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8600 

namespace CattoIMGApi.Controllers
{
    public class showUrls : Controller
    {
        [Route("/")]
        public IActionResult Index()
        {
            return Json(new {userData = "/api/getUser?username=user"});
        }
    }
}
