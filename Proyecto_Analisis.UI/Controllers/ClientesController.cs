using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Proyecto_Analisis.BL;
using Proyecto_Analisis.Model;

namespace Proyecto_Analisis.UI.Controllers
{
    public class ClientesController : Controller
    {

        private readonly IRepositorioDelProyecto Repositorio;

        public ClientesController (IRepositorioDelProyecto repositorio)
        {
            Repositorio = repositorio;
        }

        // GET: ClientesController
        public ActionResult Index()
        {
            List<Persona> paqueteria;

            paqueteria = Repositorio.ObtenerTodosLosClientes();

            return View(paqueteria);
        }

        // GET: ClientesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Persona persona)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Repositorio.AgregarCliente(persona);

                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return View();
                }


            }
            catch
            {
                return View();
            }
        }

        // GET: PaquetesRecibidos/Edit/5
        public ActionResult Edit(int Id)
        {
            Persona persona;
            persona = Repositorio.ObtenerPorId(Id);

            return View(persona);
        }

        // POST: Libros/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Persona persona)
        {
            try
            {
                Repositorio.actualizarCliente(persona);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ClientesController/Delete/5
        public ActionResult Delete(int id)
        {
            Persona persona;
            persona = Repositorio.ObtenerPorId(id);

            return View(persona);
        }

        // POST: ClientesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Persona persona)
        {
            try
            {
                Repositorio.EliminarCliente(persona);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
