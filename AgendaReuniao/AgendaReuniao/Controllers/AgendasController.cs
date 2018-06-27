using AgendaReuniao.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AgendaReuniao.Controllers
{
    public class AgendasController : Controller
    {
        public IActionResult Index()
        {
            MongoDbContext dbContext = new MongoDbContext();
            List<Agenda> listaAgendas = dbContext.Agendas.Find(m => true).ToList();
            return View(listaAgendas);
        }
        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            MongoDbContext dbContext = new MongoDbContext();
            var entity = dbContext.Agendas.Find(m => m.Id == id).FirstOrDefault();
            return View(entity);
        }
        [HttpPost]
        public IActionResult Edit(Agenda entity)
        {
            MongoDbContext dbContext = new MongoDbContext();
            dbContext.Agendas.ReplaceOne(m => m.Id == entity.Id, entity);
            return View(entity);
        }
        [HttpGet]
        public IActionResult Add()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            SelectListItem item1 = new SelectListItem() { Text = "Pendente", Value = "1", Selected = true };
            SelectListItem item2 = new SelectListItem() { Text = "Autorizado", Value = "2", Selected = false };
            SelectListItem item3 = new SelectListItem() { Text = "Cancelado", Value = "3", Selected = false };

            items.Add(item1);
            items.Add(item2);
            items.Add(item3);

            ViewBag.StatusItems = items;

            return View();
        }
        [HttpPost]
        public IActionResult Add(Agenda entity)
        {
            MongoDbContext dbContext = new MongoDbContext();
            entity.Id = Guid.NewGuid();
            dbContext.Agendas.InsertOne(entity);
            return RedirectToAction("Index", "Agendas");
        }
        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            MongoDbContext dbContext = new MongoDbContext();
            dbContext.Agendas.DeleteOne(m => m.Id == id);
            return RedirectToAction("Index", "Agendas");
        }
        public IActionResult List()
        {
            MongoDbContext dbContext = new MongoDbContext();
            List<Agenda> listaAgendas = dbContext.Agendas.Find(m => true).ToList();
            return View(listaAgendas);
        }

    }
}