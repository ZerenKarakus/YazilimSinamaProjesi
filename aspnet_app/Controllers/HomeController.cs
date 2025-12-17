using Microsoft.AspNetCore.Mvc;
using sınamadeneme.Services;
using sınamadeneme.Models;

namespace sınamadeneme.Controllers
{
	public class HomeController : Controller
	{
		private readonly IMLService _mlService;

		public HomeController(IMLService mlService)
		{
			_mlService = mlService;
		}

		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Analyze(string inputText)
		{
			if (string.IsNullOrWhiteSpace(inputText))
			{
				ViewBag.Error = "Lütfen analiz edilecek metni giriniz.";
				return View("Index");
			}

			var results = _mlService.Predict(inputText);

			return View("Result", results);
		}
	}
}
