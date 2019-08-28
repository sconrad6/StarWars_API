using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Star_Wars_API.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Star_Wars_API.Controllers
{
    public class StarWarsController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public async Task<People> GetPerson(int Id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://swapi.co");
            var response = await client.GetAsync($"api/people/{Id}/");
            var result = await response.Content.ReadAsAsync<People>();
            return result;
        }

        public IActionResult GetPersonById(int Id)
        {
            var result = GetPerson(Id).Result;
            return View("PersonResult", result);
        }

        public async Task<Planet> GetPlanet(int Id)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://swapi.co");
            var response = await client.GetAsync($"api/planets/{Id}/");
            var result = await response.Content.ReadAsAsync<Planet>();
            return result;
        }

        public IActionResult GetPlanetById(int Id)
        {
            var result = GetPlanet(Id).Result;
            return View("PlanetResult", result);
        }
    }
}
