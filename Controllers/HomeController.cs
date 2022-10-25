using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using sampleApp.Models;
using sampleApp.Services.IService;
using System.Diagnostics;

namespace sampleApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPersonService _personService;

        public HomeController(ILogger<HomeController> logger, IPersonService personService)
        {
            _logger = logger;
            _personService = personService;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Index method called");
            return View(_personService.GetPersonList());
        }


        [HttpGet]
        public IActionResult AddPerson()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPerson(PersonViewModel person)
        {
            if (person is null)
            {
                throw new System.ArgumentNullException(nameof(person));
            }

            if (!ModelState.IsValid)
            {
                return View(person);
            }

            _logger.LogInformation($"AddPerson method :{JsonConvert.SerializeObject(person)}");
            _personService.AddPerson(person);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}