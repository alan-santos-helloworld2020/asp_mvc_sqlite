using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnloadMVC.Models;

namespace OnloadMVC.Controllers
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
            return View();
        }

        public IActionResult Contato()
        {
            var model = new ContatoModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult SalvarContato(ContatoModel ct)
        {
            ct.data = DateTime.Now.ToString("dd/MM/yyyy");
            Console.WriteLine(ct.data);
            BancoModel db = new BancoModel();
            db.salvarContato(ct);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
