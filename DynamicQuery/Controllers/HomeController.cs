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

            //Gender Select 
            List<OptionList> genderList = new List<OptionList>();
            genderList.Add(new OptionList() { Value = "1", Label = "Erkek" });
            genderList.Add(new OptionList() { Value = "2", Label = "Bayan" });
            var gender = definitions.First(p => p.Field == "Gender");
            gender.Values = genderList;
            gender.Input = "select";

            //Country Select
            List<OptionList> CountryList = new List<OptionList>();
            CountryList.Add(new OptionList() { Value = "1", Label = "Türkiye" });
            CountryList.Add(new OptionList() { Value = "2", Label = "Uganda" });
            CountryList.Add(new OptionList() { Value = "3", Label = "Azarbeycan" });
            var country = definitions.First(p => p.Field == "Country");
            country.Values = CountryList;
            country.Input = "select";
            //EducationCountry Select
            var educationCountry = definitions.First(p => p.Field == "EducationCountry");
            educationCountry.Values = CountryList;
            educationCountry.Input = "select";

            //City Select
            List<OptionList> CityList = new List<OptionList>();
            CityList.Add(new OptionList() { Value = "1", Label = "Ankara" });
            CityList.Add(new OptionList() { Value = "2", Label = "Bakü" });
            CityList.Add(new OptionList() { Value = "3", Label = "Karabağ" });
            CityList.Add(new OptionList() { Value = "4", Label = "Kira" });
            CityList.Add(new OptionList() { Value = "5", Label = "Mukono" });
            CityList.Add(new OptionList() { Value = "6", Label = "Gulu" });
            var city = definitions.First(p => p.Field == "EducationCity");
            city.Values = CityList;
            city.Input = "select";

            //EducationLevel Select
            List<OptionList> EducationLevelList = new List<OptionList>();
            EducationLevelList.Add(new OptionList() { Value = "1", Label = "Ortaokul" });
            EducationLevelList.Add(new OptionList() { Value = "2", Label = "Lise" });
            EducationLevelList.Add(new OptionList() { Value = "3", Label = "Ön Lisans" });
            EducationLevelList.Add(new OptionList() { Value = "4", Label = "Lisans" });
            EducationLevelList.Add(new OptionList() { Value = "5", Label = "Yüksek Lisans" });
            EducationLevelList.Add(new OptionList() { Value = "6", Label = "Doktora" });
            var educationLevelList = definitions.First(p => p.Field == "EducationLevel");
            educationLevelList.Values = EducationLevelList;
            educationLevelList.Input = "select";

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
