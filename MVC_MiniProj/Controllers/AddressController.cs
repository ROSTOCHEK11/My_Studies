using Microsoft.AspNetCore.Mvc;
using MVC_MiniProj.Models;

namespace MVC_MiniProj.Controllers
{
    public class AddressController : Controller
    {

        private readonly ILogger<AddressController> _logger;

        public AddressController(ILogger<AddressController> logger)
        {
            _logger = logger;
        }


        // GET: AddressController
        public ActionResult Index()
        {
            return View();
        }

        // GET: AddressController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AddressController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(AddressModel data)
        {

            if(ModelState.IsValid == false)
            {
                _logger.LogWarning("The user submitted an Invalid Address upon Create");
                return View();
            }

            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
