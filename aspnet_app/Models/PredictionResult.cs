namespace sınamadeneme.Models
{
	public class PredictionResult
	{
		public double LogisticHuman { get; set; }
		public double LogisticAI { get; set; }

		public double SvmHuman { get; set; }
		public double SvmAI { get; set; }

		public double RandomForestHuman { get; set; }
		public double RandomForestAI { get; set; }
	}
}
