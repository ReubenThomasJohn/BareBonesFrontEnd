using System.Net.Http.Headers;
using System.Text.Json;
using Newtonsoft.Json;
using StudentFrontEnd.Models;

namespace StudentFrontEnd;

public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("http://localhost:5209/");
        
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public async Task<List<Student>> GetResourceDataAsync(string endpoint)
    {
        var response = await _httpClient.GetAsync(endpoint);

        if (response.IsSuccessStatusCode)
        {
            string? stringResponse = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Student>>(stringResponse);
        }
        else {
            return new List<Student>();
        }
    }
}