using JsonConsumer.Json;
using JsonConsumer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace JsonConsumer.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {
        }

        public IActionResult Index()
        {
            List<OwnerModel> owners = null;

            using (var client = new WebClient())
            {
                var result = client.DownloadString("http://agl-developer-test.azurewebsites.net/people.json");
                owners = JsonConvert.DeserializeObject<List<OwnerModel>>(result);
            }

            CatsListModel vm = new CatsListModel();

            vm.MaleOwnerCats = owners.Where(o => o.gender == "Male" && o.pets != null && o.pets.Any(p=>p.type == "Cat"))
                .SelectMany(o => o.pets.Where(p=>p.type == "Cat").Select(p=>p.name))
                .OrderBy(p=>p)
                .ToList();

            vm.FemaleOwnerCats = owners.Where(o => o.gender == "Female" && o.pets != null && o.pets.Any(p => p.type == "Cat"))
                .SelectMany(o => o.pets.Where(p => p.type == "Cat").Select(p => p.name))
                .OrderBy(p => p)
                .ToList();

            return View(vm);
        }
    }
}
