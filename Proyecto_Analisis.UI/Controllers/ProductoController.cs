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
    public class ProductoController : Controller
    {
        private readonly IRepositorioDelProyecto Repositorio;

        public ProductoController(IRepositorioDelProyecto repositorio)
        {
            Repositorio = repositorio;
        }

        // GET: ProductoController
        public ActionResult Index()
        {
            List<Producto> listaDeLibros;

            listaDeLibros = Repositorio.ObtenerTodosLosArticulos();

            return View(listaDeLibros);
        }

        // GET: ProductoController/Details/5
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
        public ActionResult Create(Producto producto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Repositorio.AgregarProducto(producto);

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

        // GET: ProductoController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.id = id;

            if (ModelState.IsValid)
            {
                Producto producto;
                producto = Repositorio.ObtenerProductoPorId(id);
                return View(producto);
            }
            else
            {
                return View();
            }

        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Producto producto, int id)
        {
            try
            {
                producto.ID_Producto = id;
                Repositorio.EditarProducto(producto);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Delete/5
        public ActionResult Delete(int id)
        {
            Producto producto;
            producto = Repositorio.ObtenerProductoPorId(id);

            return View(producto);
        }

        // POST: ProductoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Producto producto)
        {
            try
            {
                Repositorio.EliminarProducto(producto);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
