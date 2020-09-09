using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DynamicQuery.Models;
using DynamicQuery.DynamicLinqQueryBuilder;
using System.Text;
using System.Text.Json;

namespace DynamicQuery.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
      
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            var definitions = typeof(PersonRecord).GetDefaultColumnDefinitionsForType(false);
            //Augment the definitions to show advanced scenarios not
            //handled by GetDefaultColumnDefinitionsForType(...)

            //Let's tweak the generated definition of FirstName to make it
            //a select element in jQuery QueryBuilder UI populated by
            //the possible values from our dataset
            //gender select 
            List<GenderList> genderList = new List<GenderList>();
            genderList.Add(new GenderList() { Value = "1", Label = "Erkek" });
            genderList.Add(new GenderList() { Value = "2", Label = "Bayan" });
            var gender = definitions.First(p => p.Field.ToLower() == "gender");
            gender.Values = genderList;
            gender.Input = "select";

            //Let's tweak birthday to use the jQuery-UI datepicker plugin instead of
            //just a text input.
            var birthday = definitions.First(p => p.Field.ToLower() == "birthday");
            birthday.Plugin = "datepicker";
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            };

            ViewBag.FilterDefinition = JsonSerializer.Serialize(definitions, options);
       
            return View();
        }

        [HttpPost]
        public JsonResult Index([FromBody]QueryBuilderFilterRule obj)
        {
            var people = PersonBuilder.GetPeople().BuildQuery(obj).ToList();
            return Json(people);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
