using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace PL.Controllers
{
    public class AlumnoController : Controller
    {
        // GET: Alumno
        public ActionResult GetAll()
        {
            //ML.Result result = BL.Alumno.GetAll();
            ML.Alumno alumno =  new ML.Alumno();

            AlumnoServiceReference.AlumnoClient service = new AlumnoServiceReference.AlumnoClient();
            var result = service.GetAll();

            alumno.Alumnos = result.Objects.ToList();
            return View(alumno);
        }
        public ActionResult Form(int? idAlumno)
        { 
            if (idAlumno == 0)
            {
                return View();
            }
            else
            {
                //ML.Result result = BL.Alumno.GetById(idAlumno.Value);
                ML.Alumno alumno = new ML.Alumno();
                //alumno = (ML.Alumno)result.Object;

                AlumnoServiceReference.AlumnoClient service = new AlumnoServiceReference.AlumnoClient();
                var result = service.GetById(idAlumno.Value);

                alumno = (ML.Alumno)result.Object;
                return View(alumno);
            }
        }
        public ActionResult Delete(int idAlumno)
        {
            //ML.Result result = BL.Alumno.Delete(idAlumno);

            AlumnoServiceReference.AlumnoClient service = new AlumnoServiceReference.AlumnoClient();
            var result = service.Delete(idAlumno);

            if (result.Correct)
            {
                ViewBag.Mensaje = "Eliminado correctamente";
            }
            else
            {
                ViewBag.Mensaje = "Error al eliminar.";
            }
            return PartialView("Modal");
        }
        [HttpPost]
        public ActionResult Form(ML.Alumno alumno)
        {
            if(alumno.IdAlumno == 0)
            {
                //ML.Result result = BL.Alumno.Add(alumno);

                AlumnoServiceReference.AlumnoClient service = new AlumnoServiceReference.AlumnoClient();
                var result = service.Add(alumno);

                if (result.Correct)
                {
                    ViewBag.Mensaje = "Agregado correctamente.";
                }
                else
                {
                    ViewBag.Mensaje = "Error al agregar";
                }
            }
            else
            {
                //ML.Result result = BL.Alumno.Update(alumno);

                AlumnoServiceReference.AlumnoClient service = new AlumnoServiceReference.AlumnoClient();
                var result = service.Update(alumno);

                if(result.Correct)
                {
                    ViewBag.Mensaje = "Actualización éxitosa.";
                }
                else
                {
                    ViewBag.Mensaje = "Error al actualizar.";
                }
            }
            return PartialView("Modal");
        }
    }
}