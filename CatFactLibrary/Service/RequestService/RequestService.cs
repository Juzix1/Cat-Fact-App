using CatFactLibrary.Model;
using System.Net.Http.Json;
using System.Text.Json;

namespace CatFactLibrary.Service
{
    public class RequestService : IRequestService
    {
        private readonly HttpClient _httpClient;
        private readonly string _url = "https://catfact.ninja/fact";
        private readonly int _maxRetries = 3;
        private readonly TimeSpan _Delay = TimeSpan.FromSeconds(5);
        public RequestService()
        {
            _httpClient = new HttpClient();
            _httpClient.Timeout = TimeSpan.FromSeconds(10);
        }
        public async Task<FactModel?> GetFactAsync()
        {
            Exception lastException = null;

            for (int attempt = 0; attempt < _maxRetries; attempt++)
            {
                try
                {
                    //Checks for connection with host, if host or client is offline, it will try to retry connection up to 3 times, then shows error message
                    var result = await _httpClient.GetFromJsonAsync<FactModel>(_url);

                    if (result != null)
                    {
                        return result;
                    }
                }
                catch (HttpRequestException ex)
                {
                    lastException = ex;
                    Console.WriteLine($"Attempt {attempt + 1}/{_maxRetries} Failed - HTTP Error: {ex.Message}");
                }
                catch (TaskCanceledException ex) when (ex.InnerException is TimeoutException)
                {
                    lastException = ex;
                    Console.WriteLine($"Attempt {attempt + 1}/{_maxRetries} Failed - timeout: {ex.Message}");
                }
                catch (JsonException ex)
                {
                    lastException = ex;
                    Console.WriteLine($"Attempt {attempt + 1}/{_maxRetries} Failed - Json Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    lastException = ex;
                    Console.WriteLine($"Attempt {attempt + 1}/{_maxRetries} Failed - Error: {ex.Message}");
                }

                if (attempt < _maxRetries - 1)
                {
                    var delay = TimeSpan.FromMilliseconds(_Delay.TotalMilliseconds * Math.Pow(2, attempt));
                    Console.WriteLine($"Waiting {delay.TotalSeconds}s before next attempt");
                    await Task.Delay(delay);
                }

            }
            throw new InvalidOperationException(
            $"Failed to retrieve data after {_maxRetries} attempts. Last Error: {lastException?.Message}");
        }


    }
    }
