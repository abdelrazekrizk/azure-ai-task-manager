using Azure;
using Azure.AI.TextAnalytics;

namespace TaskManager.Services
{
    public class AzureNLPService
    {
        private readonly TextAnalyticsClient client;

        public AzureNLPService(string endpoint, string apiKey)
        {
            // Check for null or empty values to prevent CS8604 warning
            if (string.IsNullOrEmpty(endpoint))
            {
                throw new ArgumentException("Endpoint cannot be null or empty.", nameof(endpoint));
            }

            if (string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentException("API key cannot be null or empty.", nameof(apiKey));
            }

            var credential = new AzureKeyCredential(apiKey);
            client = new TextAnalyticsClient(new Uri(endpoint), credential);
        }

        public string AnalyzeTask(string taskDescription)
        {
            // Example: Analyzing sentiment (you can expand this)
            var response = client.AnalyzeSentiment(taskDescription);
            return response.Value.Sentiment.ToString();
        }
    }
}  