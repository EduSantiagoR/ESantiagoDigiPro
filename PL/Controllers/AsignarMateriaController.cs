using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class AsignarMateriaController : Controller
    {
        // GET: AsignarMateria
        public ActionResult AsignarMateria()
        {
            ML.Result result = BL.Alumno.GetAll();
            ML.Alumno alumno = new ML.Alumno();
            alumno.Alumnos = result.Objects.ToList();
            return View(alumno);
        }
        public ActionResult GetMateriasAsignadas(int idAlumno, string nombre)
        {
            ML.Result result = BL.AlumnoMateria.GetMateriasAsignadas(idAlumno);
            ML.AlumnoMateria materia = new ML.AlumnoMateria();
            materia.Materia = new ML.Materia();
            materia.Alumno = new ML.Alumno();
            Session["nombreAlumno"] = nombre;
            Session["idAlumno"] = idAlumno;
            materia.Alumno.Nombre = Session["nombreAlumno"].ToString();
            materia.Alumno.IdAlumno = int.Parse(Session["idAlumno"].ToString());
            materia.Materia.Materias = result.Objects;
            return View(materia);
        }
        public ActionResult GetMateriasNoAsignadas(int idAlumno)
        {
            ML.Result result = BL.AlumnoMateria.GetMateriasNoAsignadas(idAlumno);
            ML.AlumnoMateria materia = new ML.AlumnoMateria();
            materia.Alumno = new ML.Alumno();
            materia.Materia = new ML.Materia();
            materia.Materia.Materias = result.Objects;
            materia.Alumno.Nombre = Session["nombreAlumno"].ToString();
            materia.Alumno.IdAlumno = int.Parse(Session["idAlumno"].ToString());
            return View(materia);
        }
        public ActionResult Delete(int idAlumno, int idMateria)
        {
            ML.Result result = BL.AlumnoMateria.Delete(idAlumno, idMateria);
            if (result.Correct)
            {
                ViewBag.Mensaje = "Materia eliminada.";
                ViewBag.IdAlumno = idAlumno;
                ViewBag.NombreAlumno = Session["nombreAlumno"].ToString();
            }
            else
            {
                ViewBag.Mensaje = "Error al eliminar.";
                ViewBag.IdAlumno = idAlumno;
                ViewBag.NombreAlumno = Session["nombreAlumno"].ToString();
            }
            return PartialView("Modal");
        }
        [HttpPost]
        public ActionResult AgregarMaterias(int idAlumno, List<int> idMaterias)
        {
            int contador = 0;
            foreach(int idMateria in idMaterias)
            {
                ML.Result result = BL.AlumnoMateria.Add(idAlumno, idMateria);
                if (result.Correct)
                {
                    contador++;
                    ViewBag.Mensaje = "Agregaste un total de "+contador+" materias.";
                }
                else
                {
                    result.Correct = false;
                }
            }
            ViewBag.IdAlumno = idAlumno;
            ViewBag.NombreAlumno = Session["nombreAlumno"].ToString();
            return PartialView("Modal");
        }
    }
}