using Azure;  
using Azure.AI.TextAnalytics;  
  
namespace TaskManager.Services  
{  
    public class AzureNLPService  
    {  
        private readonly TextAnalyticsClient client;  
  
        public AzureNLPService(string endpoint, string apiKey)  
        {  
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