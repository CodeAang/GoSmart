using System;
using GoSmart.API.Models;
using GoSmart.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace GoSmart.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class GenerateItenary : ControllerBase
	{
		private readonly ItenaryService _service;

		public GenerateItenary(ItenaryService service)
		{
			_service = service;
		}

		[HttpPost("generate")]
		public ActionResult<ItenaryResponse> Generate([FromBody] ItenaryRequest request)
		{
			var result = _service.GenerateItenary(request);
			return Ok(result);
		}
	}
}

