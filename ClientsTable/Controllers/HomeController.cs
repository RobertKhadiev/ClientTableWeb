using ClientsTable.Entities;
using ClientsTable.repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientsTable.Controllers
{
    public class HomeController : Controller
    {
        DataContext db;

        public HomeController(DataContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Table()
        {
            var Cities = db.Cities.ToList();
            return View(Cities);
        }

        [HttpGet]
        public IActionResult Buy(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            var st = "STRINGUS";
            ViewBag.Smth = st;
            return View();
        }

        [HttpPost]
        public string AddClient(ClientEntity client)
        {
            db.Clients.Add(client);
            // сохраняем в бд все изменения
            db.SaveChanges();
            return "Клиент " + client.Name + ", успешно сохранён.";
        }
    }
}
