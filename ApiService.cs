using System.Net.Http.Headers;
using System.Text;
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
        else
        {
            return new List<Student>();
        }
    }

    public async Task PostDataAsync(string endpoint, Student student)
    {
        var jsonData = JsonConvert.SerializeObject(student);

        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(endpoint, content);
    }

    public async Task DeleteDataAsync(string endpoint)
    {
        var response = await _httpClient.DeleteAsync(endpoint);

        if (!response.IsSuccessStatusCode)
        {
            // Handle error cases here, e.g., throw an exception or log an error
        }
    }

    public async Task UpdateDataAsync(string endpoint, Student student)
    {
        var jsonData = JsonConvert.SerializeObject(student);

        var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

        var response = await _httpClient.PutAsync(endpoint, content);

        if (!response.IsSuccessStatusCode)
        {
            // Handle error cases here, e.g., throw an exception or log an error
        }
    }
}