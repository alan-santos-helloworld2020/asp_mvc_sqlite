using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnloadMVC.Models;

namespace OnloadMVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            var model = new  AdminModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult LogarAdmin(AdminModel adm)    
        {
            AdminAcess admin = new AdminAcess();
            var teste = admin.buscar(adm);
           
            
            // if (teste.username != null && teste.password != null)
            if (teste != null)
            {
                return RedirectToAction("Contatos");
                
            }

            return RedirectToAction("Index");
           
        }

        public IActionResult Contatos()
        {
            BancoModel dbm = new BancoModel();   
            return View(dbm.listarContatos());

        }
    }
}