using BenchmarkDotNet.Attributes;
using RestSharp;

namespace API_DEMO.HttpClientDemo
{
    [MemoryDiagnoser]
    public class TodoBenchmark
    {
        private static HttpClient httpClient = new HttpClient();
        private static RestClient restClient = new RestClient("https://localhost:7003/api/Employee/GetEmployee");

        public TodoBenchmark()
        {
            httpClient.BaseAddress = new Uri("https://localhost:7003/api/Employee/GetEmployee");
        }
    }
}
