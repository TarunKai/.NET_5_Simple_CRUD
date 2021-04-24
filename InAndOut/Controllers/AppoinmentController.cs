using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
	
	[Route("App/[Controller]/[action]")]
	public class AppoinmentController : Controller
	{
		
		public IActionResult Index([FromQuery]int id)
		{
			return Ok("Your id is: " + id);
		}

		[Route("{id?}")]
		public IActionResult Cre([FromRoute] int id)
		{
			return Ok("You are in cre your id is : "+ id);
		}

	}
}
