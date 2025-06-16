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
		private readonly OpenAIService _openAiService;

		public GenerateItenary(ItenaryService service, OpenAIService openAiService)
		{
			_service = service;
			_openAiService = openAiService;
		}

		[HttpPost("generate")]
		public ActionResult<ItenaryResponse> Generate([FromBody] ItenaryRequest request)
		{
			var result = _service.GenerateItenary(request);
			return Ok(result);
		}

		[HttpPost("generate/Chatgpt")]
		public async Task<IActionResult> Ask([FromBody] string question)
		{
			try
			{
				var response = _openAiService.GetResponseFromGPTAsync(question);

				return Ok(new { reply = response });
			}
			catch (Exception ex)
			{
				return StatusCode(500, $"OpenAi call failed: {ex.Message}");
			}

		}
	}
}

