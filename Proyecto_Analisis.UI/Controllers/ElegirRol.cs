using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Proyecto_Analisis.UI.Controllers
{
    public class ElegirRol : Controller
    {
        // GET: ElegirRol
        public ActionResult Index()
        {
            return View();
        }

        // GET: ElegirRol/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ElegirRol/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ElegirRol/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ElegirRol/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ElegirRol/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ElegirRol/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ElegirRol/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
