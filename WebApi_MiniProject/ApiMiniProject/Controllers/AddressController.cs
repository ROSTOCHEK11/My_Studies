using ApiMiniProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiMiniProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AddressController : Controller
	{
		private readonly ILogger<AddressController> _logger;

		public AddressController(ILogger<AddressController> logger)
		{
			_logger = logger;
		}


		[HttpPost]
		public void Post([FromBody] AddressModel data)
		{
			_logger.LogInformation("The person was logged as {Address}", data);
		}


		// GET: PersonController
		[HttpGet("Index")]
		public ActionResult Index()
		{
			return View();
		}

	}

}
