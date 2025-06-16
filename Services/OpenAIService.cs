using System;
using System.Text;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc.Routing;

namespace GoSmart.API.Services;

public class OpenAIService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    public OpenAIService(IConfiguration config)
    {
        _apiKey = config["Gemini:ApiKey"];
        _httpClient = new HttpClient();
    }

    public async Task<string> GetResponseFromGPTAsync(string userMessage)
    {
        var url = $"https://generativelanguage.googleapis.com/v1beta/models/gemini-2.0-flash:generateContent?key={_apiKey}";

        var requestBody = new
        {
            contents = new[]
            {
                new {
                    parts = new[]{
                        new {text = userMessage}
                    }
                }
            }
        };

        var json = JsonSerializer.Serialize(requestBody);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        try
        {
            var response = await _httpClient.PostAsync(url, content);
            if (!response.IsSuccessStatusCode)
            {
                var error = response.Content.ReadAsStringAsync();
                throw new Exception($"Gemini API error: {response.StatusCode}\n{error}");
            }

            var responseText = await response.Content.ReadAsStringAsync();

            using var doc = JsonDocument.Parse(responseText);
            var text = doc.RootElement
                          .GetProperty("candidates")[0]
                          .GetProperty("content")
                          .GetProperty("parts")[0]
                          .GetProperty("text")
                          .GetString();

            return text;

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}
