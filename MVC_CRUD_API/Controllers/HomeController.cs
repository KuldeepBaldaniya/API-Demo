using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using MVC_CRUD_API.Common;
using MVC_CRUD_API.Models;
using Newtonsoft.Json;
using System.Text;
using System.Net;
using RestSharp;

namespace MVC_CRUD_API.Controllers
{
    public class HomeController : Controller
    {
        private readonly string UrlCreate = "https://localhost:7003/api/Employee/";
        private readonly RestClient _client;
        public HomeController()
        {
            _client = new RestClient("https://localhost:7003/api/Employee/CreateEmployee");
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Privacy()
        {
            return View();
        }

        #region Using HttpClient

        public async Task<JsonResult> GetData()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    string apiUrl = UrlCreate + "GetEmployee";

                    // Send an HTTP GET request to the web API.
                    HttpResponseMessage httpResponse = await client.GetAsync(apiUrl);

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        // Read the response content as a string.
                        var response = await httpResponse.Content.ReadAsStringAsync();

                        // Deserialize the JSON response into a List of EmpMVC.
                        var result = JsonConvert.DeserializeObject<ServiceResponse>(response);
                        string jsonBody = JsonConvert.SerializeObject(result.Response);

                        var employeeRequests = JsonConvert.DeserializeObject<List<EmpMVC>>(jsonBody);

                        // Return the employee list to the view.
                        return Json(employeeRequests);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
                return null;
            }
        }

        public async Task<JsonResult> GetById(Guid id)
        {
            EmpMVC empMVC = new EmpMVC();
            using (var client = new HttpClient())
            {
                try
                {
                    // Define the base URL for the web API.
                    string apiUrl = UrlCreate + "GetById/" + id;

                    // Set up the HttpClient with appropriate headers.
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Send an HTTP GET request to the web API.
                    HttpResponseMessage httpResponse = await client.GetAsync(apiUrl);

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        // Read the response content as a string.
                        var response = await httpResponse.Content.ReadAsStringAsync();

                        // Deserialize the JSON response into a List of EmpMVC.
                        var result = JsonConvert.DeserializeObject<ServiceResponse>(response);

                        var jsonString = JsonConvert.SerializeObject(result.Response);
                        empMVC = JsonConvert.DeserializeObject<EmpMVC>(jsonString);

                        // Return the employee list to the view.
                        return Json(empMVC);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return null;
        }

        public async Task<JsonResult> Update([FromBody] EmpMVC empmvc)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    // Define the base URL for the web API.
                    string apiUrl = UrlCreate + "Update";

                    // Set up the HttpClient with appropriate headers.
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    // Serialize the empmvc object and send it as a JSON request body using a PUT request.
                    var jsonString = JsonConvert.SerializeObject(empmvc);
                    var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

                    HttpResponseMessage httpResponse = await client.PutAsync(apiUrl, content);

                    if (httpResponse.IsSuccessStatusCode)
                    {
                        // Read the response content as a string.
                        var response = await httpResponse.Content.ReadAsStringAsync();

                        // Deserialize the JSON response into an EmpMVC object.
                        empmvc = JsonConvert.DeserializeObject<EmpMVC>(response);

                        // Return the updated employee object to the view.
                        return Json(apiUrl);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return null;
        }
        #endregion

        #region Using Rest-Sharp

        public async Task<JsonResult> Create([FromBody] EmpMVC empMVC)
        {
            try
            {
                var request = new RestRequest("https://localhost:7003/api/Employee/CreateEmployee", Method.Post);
                request.AddHeader("Content-Type", "application/json");

                 var dataToSend = new EmpMVC
                {
                    name = empMVC.name,
                    address = empMVC.address,
                    email = empMVC.email,
                    phone = empMVC.phone,
                };

                string jsonBody = JsonConvert.SerializeObject(dataToSend);
                request.AddParameter("application/json", jsonBody, ParameterType.RequestBody);
                request.AddJsonBody(empMVC);
                RestResponse response = _client.Execute(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var content = response.Content;
                    var data = JsonConvert.DeserializeObject<EmpMVC>(content);

                    return Json(response);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        public async Task<JsonResult> Delete(Guid id)
        {
            try
            {
                var request = new RestRequest(UrlCreate + "Delete/" + id, Method.Delete);
                request.AddParameter("Content-Type", "application/json", ParameterType.RequestBody);
                request.AddBody(id);
                RestResponse response =  _client.Execute(request);
                //var response = _client.Execute(request);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    //    var content = response.Content;
                    //    var data = JsonConvert.DeserializeObject<EmpMVC>(content);
                    return Json(response);
                }
                else
                {
                    return null;
                }
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        #endregion  
    }
}