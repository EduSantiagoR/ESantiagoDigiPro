using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BL
{
    public class AlumnoMateria
    {
        public static ML.Result GetMateriasAsignadas(int idAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.ControlEscolarEntities context = new DLEF.ControlEscolarEntities())
                {
                    var query = context.AlumnoMateriaGetMateriasAsignadas(idAlumno);
                    if(query != null)
                    {
                        result.Objects = new List<object>();
                        foreach(var item in query)
                        {
                            ML.AlumnoMateria materia = new ML.AlumnoMateria();
                            materia.Materia = new ML.Materia();
                            materia.Materia.IdMateria = item.IdMateria;
                            materia.Materia.Nombre = item.NombreMateria;
                            materia.Materia.Costo = item.Costo;
                            result.Objects.Add(materia);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al obtener las materias asignadas.";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result GetMateriasNoAsignadas(int idAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.ControlEscolarEntities context = new DLEF.ControlEscolarEntities())
                {
                    var query = context.GetMateriasNoAsignadas(idAlumno);
                    if(query != null)
                    {
                        result.Objects = new List<object>();
                        foreach(var item in query)
                        {
                            ML.AlumnoMateria materia = new ML.AlumnoMateria();
                            materia.Materia = new ML.Materia();
                            materia.Materia.IdMateria = item.IdMateria;
                            materia.Materia.Nombre = item.Nombre;
                            materia.Materia.Costo = item.Costo;
                            result.Objects.Add(materia);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al consultar las materias no asignadas";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage= ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result Add(int idAlumno, int idMatera)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.ControlEscolarEntities context = new DLEF.ControlEscolarEntities())
                {
                    var rowsAffected = context.AlumnoMateriaAdd(idAlumno, idMatera);
                    if(rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al agregar.";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result Delete(int idAlumno, int idMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.ControlEscolarEntities context = new DLEF.ControlEscolarEntities())
                {
                    var rowsAffected = context.AlumnoMateriaDelete(idAlumno,idMateria);
                    if(rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al eliminar.";
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
