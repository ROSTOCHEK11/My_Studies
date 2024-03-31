using ApiMiniProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiMiniProject.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class PersonController : Controller
	{
		private readonly ILogger<PersonController> _logger;

		public PersonController(ILogger<PersonController> logger)
        {
			_logger = logger;
		}


		[HttpPost]
		public void Post([FromBody] PersonModel data)
		{
			_logger.LogInformation("The person was logged as {Person}", data);
		}


        // GET: PersonController
        [HttpGet("Index")]
		public ActionResult Index()
		{
			return View();
		}



		
	}
}
