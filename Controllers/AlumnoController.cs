using CRUDMvcAspAlumnos.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;

namespace CRUDMvcAspAlumnos.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult Index()
        {
            try
            {
                //int edad = 18;

                //string sql = @"
                //       select a.id, a.Nombres,a.Apellidos,a.Edad,a.sexo,a.FechaRegistro,c.Nombre as NombreCiudad
                //       from Alumno a
                //       inner join Ciudad c on a.CodCiudad = c.Id
                //       where a.edad>@edad";

                using (var db = new AlumnosContext())

                {
                    var data = from a in db.alumno
                               join c in db.ciudad on a.CodCiudad equals (c.Id)
                               select new AlumnModel()
                               {
                                   Id = a.Id,
                                   Nombres = a.Nombres,
                                   Apellidos = a.Apellidos,
                                   Edad = a.Edad,
                                   Sexo = a.Sexo,
                                   NombreCiudad = c.nombre,
                                   FechaRegistro = a.FechaRegistro
                               };
                   // List<alumno> lista = db.alumno.Where(a => a.Edad > 18).ToList();
                    return View(data.ToList());
                    //return View(db.Database.SqlQuery<AlumnModel>(sql, new SqlParameter("@edad",edad)).ToList());
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpGet]
        public ActionResult Agregar() {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Agregar(alumno a) {

            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                using (var db = new AlumnosContext())
                {
                    db.alumno.Add(a);
                    a.FechaRegistro = DateTime.Now;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(" ", "Error al agregar el Alumno -" + ex.Message);
                return View();
            }

        }

        public ActionResult Editar(int id) {

            try
            {
                using (var db = new AlumnosContext())
                {
                    //alumno al = db.alumno.Where(a=>a.Id==id).FirstOrDefault();
                    alumno al2 = db.alumno.Find(id);
                    return View(al2);
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public ActionResult Agregar2() {
            return View();
        }

        public ActionResult ListaCiudades() {
            using (var db=  new AlumnosContext())
            {
                return PartialView(db.ciudad.ToList());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(alumno a) {
            try
            {
                using (var db = new AlumnosContext())
                {
                    alumno al = db.alumno.Find(a.Id);
                    al.Nombres = a.Nombres;
                    al.Apellidos = a.Apellidos;
                    al.Edad = a.Edad;
                    al.Sexo = a.Sexo;

                    db.SaveChanges();

                    return RedirectToAction("index");
                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public ActionResult Detalles(int id) {

            using (var db= new AlumnosContext())
            {
                alumno alu = db.alumno.Find(id);
                return View(alu);
            }                        
        }

        public ActionResult Eliminar(int id) {

            using (var db = new AlumnosContext())
            {
                alumno alu = db.alumno.Find(id);
                db.alumno.Remove(alu);
                db.SaveChanges();

                return RedirectToAction("Index");             
            }            
        }

        public static string NombreCiudad(int CodCiudad) {
            using (var db = new AlumnosContext())
            {
                return db.ciudad.Find(CodCiudad).nombre;
            }
        }
    }
}