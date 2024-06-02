using Azure;
using Azure.AI.OpenAI;
using System;
using System.Threading.Tasks;

public class AzureOpenAIService
{
    private readonly OpenAIClient _openAIClient;

    public AzureOpenAIService(string apiKey, string endpoint)
    {
        _openAIClient = new OpenAIClient(new Uri(endpoint), new AzureKeyCredential(apiKey));
    }

    
    public async Task<string> GetResponseAsync(string prompt)
    {
        try
        {
            Console.WriteLine(prompt);


            var chatCompletionsOptions = new ChatCompletionsOptions()
            {
                DeploymentName = "gpt-35-turbo-16k", 
                Messages =
                {
                    
                    new ChatRequestSystemMessage("You are a helpful assistant. You will talk like a harry potter."),
                    new ChatRequestSystemMessage(prompt)
                }
            };
            Console.WriteLine(chatCompletionsOptions);
            Response<ChatCompletions> response = await _openAIClient.GetChatCompletionsAsync(chatCompletionsOptions);
            ChatResponseMessage responseMessage = response.Value.Choices[0].Message;
            Console.WriteLine($"[{responseMessage.Role.ToString().ToUpperInvariant()}]: {responseMessage.Content}");
            return responseMessage.Content;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
            return "Something went wrong"; 
        }
    }

}
