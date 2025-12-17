using sınamadeneme.Services;
using sınamadeneme.Models;
using NUnit.Framework;
using Microsoft.AspNetCore.Mvc;
using sınamadeneme.Controllers;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace sinamadeneme.NUnitTests
{
	public class FakeHttpMessageHandler : HttpMessageHandler
	{
		protected override Task<HttpResponseMessage> SendAsync(
			HttpRequestMessage request,
			CancellationToken cancellationToken)
		{
			return Task.FromResult(new HttpResponseMessage(HttpStatusCode.InternalServerError));
		}
	}
	public class FakeMLService : IMLService
	{
		public PredictionResult Predict(string text)
		{
			return new PredictionResult
			{
				LogisticHuman = 40,
				LogisticAI = 60,
				SvmHuman = 45,
				SvmAI = 55,
				RandomForestHuman = 30,
				RandomForestAI = 70
			};
		}
	}
	[TestFixture]
	public class HomeControllerWhiteBoxTests
	{
		[Test]
		//doğru metin mi dönüyor
		public void Analyze_ValidText()
		{
			var fakeService = new FakeMLService();
			var controller = new HomeController(fakeService);

			string inputText = "Bu geçici bir test cümlesidir..";

			var result = controller.Analyze(inputText) as ViewResult;

			Assert.IsNotNull(result);
			Assert.AreEqual("Result", result.ViewName);
		}
		[Test]
		//çoklu modeller için sonuç testi
		public void Analyze_ReturnsPredictionResult()
		{
			var fakeService = new FakeMLService();
			var controller = new HomeController(fakeService);

			var result = controller.Analyze("Sample Text") as ViewResult;
			var model = result.Model as PredictionResult;

			Assert.IsNotNull(model);

			Assert.IsTrue(model.LogisticAI > 0);
			Assert.IsTrue(model.SvmAI > 0);
			Assert.IsTrue(model.RandomForestAI > 0);
		}
		[Test]
		//api hata durumu
		//public PredictionResult Predict(string text) kısmı test edilir
		public void Predict_WhenApiFails_ReturnsEmptyPredictionResult()
		{
			var handler = new FakeHttpMessageHandler();
			var httpClient = new HttpClient(handler);
			var mlService = new MLService(httpClient);

			var result = mlService.Predict("test metni");

			Assert.IsNotNull(result);
			Assert.AreEqual(0, result.LogisticHuman);
			Assert.AreEqual(0, result.LogisticAI);
		}
	}
}
