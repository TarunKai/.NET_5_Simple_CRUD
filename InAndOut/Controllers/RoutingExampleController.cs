using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InAndOut.Controllers
{
	[Route("admin/[Controller]")]
	public class RoutingExampleController : Controller
	{
		[Route("Index/{id?}")]
		public IActionResult Index(int id)
		{
			return Ok("Your id is: " + id);
		}
		/// <summary>
		/// only get id from route i.e. url
		/// URL : https://localhost:44300/admin/routingexample/3232
		/// </summary>
		/// <param name="id"></param>
		/// <returns></returns>

		[Route("{id?}")]
		[HttpGet]
		public IActionResult Get([FromRoute] int id)
		{
			return Ok("Your id is: " + id);
		}
		/// <summary>
		/// example of passing id and name in querystring
		/// URL : https://localhost:44300/admin/routingexample/qs?id=2323&name=tarun
		/// </summary>
		/// <param name="id"></param>
		/// <param name="name"></param>
		/// <returns></returns>
		[Route("QS")]
		[HttpGet]
		public IActionResult queryString([FromQuery] int id,string name)
		{
			return Ok("Your id is: " + id+" and name is: "+name);
		}

		#region :: Content Result ::

		public IActionResult Index()
		{
			return View();
		}

		public IActionResult partialView()
		{
			return PartialView();
		}

		public IActionResult jsonView()
		{
			return Json(new
			{
				message = "this is json result"
			});
		}

		/// <summary>
		/// Display response stream without requiring a view
		/// </summary>
		/// <returns></returns>
		public IActionResult contentResult()
		{
			return Content("this is my content");
		}

		#endregion

		#region :: status code results ::

		/// <summary>
		/// Produce status code 200 response
		/// </summary>
		/// <returns></returns>
		public IActionResult okresult()
		{
			return Ok();
		}

		/// <summary>
		/// return response of (201) with a location header
		/// this indicate that request has been fulfilled and 
		/// one or more new resources being created
		/// in below case "item" is the resourse that has been created 
		/// </summary>
		/// <returns></returns>
		public IActionResult createdResult()
		{
			return Created("https://localhost:44300/admin/",new { name="item"});
		}

		/// <summary>
		/// Result return 204 status code
		/// </summary>
		/// <returns></returns>

		public IActionResult noContent()
		{
			return NoContent();
		}

		/// <summary>
		/// produce bad request (400) response
		/// It indicate bad request by the user
		/// It does not take any argument
		/// </summary>
		/// <returns></returns>
		public IActionResult badRequest()
		{
			return BadRequest();
		}

		/// <summary>
		/// Return 401 status code. It only return status code and does not do
		/// anything else
		/// In case of Token
		/// </summary>
		/// <returns></returns>
		public IActionResult unauthorizedResult()
		{
			return Unauthorized();
		}
		/// <summary>
		/// Return 404 page not found
		/// </summary>
		/// <returns></returns>
		public IActionResult notFound()
		{
			return NotFound();
		}

		/// <summary>
		/// Return 415 status code. i.e. server cannot continue to process 
		/// the request with given payload
		/// do this by inspecting the content-type or content-encoding
		/// of current request or inspecting the incomming data directly
		/// </summary>
		/// <returns></returns>
		public IActionResult unsupportedMedia()
		{
			return new UnsupportedMediaTypeResult();
		}

		#endregion

		#region :: status code with object result ::

		/* Content Negotiation
		 * In short, content negotiation lets you choose or rather "negotiate" 
		 * the content you want in to get in response to the REST API request.
		 
		 * Status Code with Object Results
		 
		 * These action results are, for the most part, 
		 * overloads of the results seen in the previous section. 
		 * However, they are handled differently by the browser 
		 * or other requesters due to content negotiation.            
		 */

		/// <summary>
		/// Return status code 200 OK if Content Negotiation and formatting succeed
		/// </summary>
		/// <returns></returns>
		public IActionResult okObjectResult()
		{
			var result = new OkObjectResult(new
			{
				message = "200 Ok",
				currentDate = DateTime.Now
			});
		
			return result;
		}

		/// <summary>
		/// return response of (201) with a location header
		/// </summary>
		/// <returns></returns>

		public IActionResult CreatedObjectResult()
		{
			var result = new CreatedAtActionResult("createdobjectresult", "statuscodeobjects", "", new { message = "201 Created", currentDate = DateTime.Now });
			return result;
		}

		/// <summary>
		/// produce bad request (400) response with object value
		/// </summary>
		/// <returns></returns>
		public IActionResult BadRequestObjectResult()
		{
			var result = new BadRequestObjectResult(new { message = "400 Bad Request", currentDate = DateTime.Now });
			return result;
		}

		/// <summary>
		/// Return 404 page not found
		/// </summary>
		/// <returns></returns>
		public IActionResult NotFoundObjectResult()
		{
			var result = new NotFoundObjectResult(new { message = "404 Not Found", currentDate = DateTime.Now });
			return result;
		}

		#endregion

		#region ::Redirect Results ::

		/// <summary>
		/// redirects to a specified URL. Permanent 301 property is set to false
		/// </summary>
		/// <returns></returns>
		public IActionResult RedirectResult()
		{
			return Redirect("https://www.google.net");
		}

		/// <summary>
		/// redirects to a URL within the same application.
		/// </summary>
		/// <returns></returns>
		public IActionResult LocalRedirectResult()
		{
			return LocalRedirect("/redirects/target");
		}

		/// <summary>
		/// It redirect us to an Action 
		/// It takes actionName, controllerName, routeValue
		/// </summary>
		/// <returns></returns>

		public IActionResult RedirectToActionResult()
		{
			return RedirectToAction("Index","Appoinment", new { id = 99 });
		}


		#endregion

		#region ::File Results ::


		/// <summary>
		/// returns a file at a given path. In our case, the path is /wwwroot/downloads, 
		/// and so our action will look as follows
		/// </summary>
		/// <returns></returns>
		public IActionResult FileResult()
		{
			return File("~/downloads/pdf-sample.pdf", "application/pdf");
		}

		/// <summary>
		/// return the content of a given file as a byte array
		/// </summary>
		/// <returns></returns>
		public IActionResult FileContentResult()
		{
			//Get the byte array for the document
			var pdfBytes = System.IO.File.ReadAllBytes("wwwroot/downloads/pdf-sample.pdf");

			//FileContentResult needs a byte array and returns a file with the specified content type.
			return new FileContentResult(pdfBytes, "application/pdf");
		}

		/// <summary>
		/// We can also use the VirtualFileResult class to get files out of the /wwwroot folder 
		/// in our project, like so:
		/// </summary>
		/// <returns></returns>
		public IActionResult VirtualFileResult()
		{
			//Paths given to the VirtualFileResult are relative to the wwwroot folder.
			return new VirtualFileResult("/downloads/pdf-sample.pdf", "application/pdf");
		}


		#endregion

		

	}
}
