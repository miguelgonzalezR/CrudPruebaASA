using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrudPrueba.Models;

namespace CrudPrueba.Controllers
{
    public class EmpleadosController : Controller
    {
        // GET: Empleados
        public ActionResult Index()
        {
            using(DbModels context = new DbModels())
            {
                return View(context.empleados.ToList());
            }

            
        }

        // GET: Empleados/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.empleados.Where(x=>x.id ==id).FirstOrDefault());
            }
        }

        // GET: Empleados/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empleados/Create
        [HttpPost]
        public ActionResult Create(empleados empleados)
        {
            try
            {
                using (DbModels context = new DbModels())
                {
                    context.empleados.Add(empleados);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Empleados/Edit/5
        public ActionResult Edit(int id)
        {

            using (DbModels context = new DbModels())
            {
                return View(context.empleados.Where(x => x.id == id).FirstOrDefault());
            }

        }

        // POST: Empleados/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, empleados empleados)
        {
            try
            {
                using(DbModels context = new DbModels())
                {
                    context.Entry(empleados).State = System.Data.EntityState.Modified;
                    context.SaveChanges();  
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Empleados/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.empleados.Where(x => x.id == id).FirstOrDefault());
            }
        }

        // POST: Empleados/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (DbModels context = new DbModels())
                {
                    empleados empleado = context.empleados.Where(x=>x.id == id).FirstOrDefault();
                    context.empleados.Remove(empleado); 
                    context.SaveChanges();  
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
