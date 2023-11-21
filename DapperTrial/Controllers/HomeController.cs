using DapperTrial.DataAccess;
using DapperTrial.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DapperTrial.Controllers
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
            List<City> cityList = new CityQuery().GetCities();

            return View(cityList);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Opt1()
        {
            List<City> limited = new CityQuery().LimitCities();

            return View(limited);
        }

        public IActionResult Opt2()
        {
            List<City> codeList = new CityQuery().CitiesByCountryCode();

            return View(codeList);
        }

        public IActionResult Opt3()
        {
            List<Country>countryList = new CountryQuery().GetEuropeanCountries();
            return View(countryList);
        }

        public IActionResult Opt4()
        {
            List<City> countryCities = new CityQuery().GetCitiesInCountry();
            return View(countryCities);
        }

        public IActionResult Opt5()
        {
            List<City> asianCities = new CityQuery().GetCitiesInContinent();
            return View(asianCities);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}