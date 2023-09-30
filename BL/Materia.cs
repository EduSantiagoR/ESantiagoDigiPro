using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Materia
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.ControlEscolarEntities context = new DLEF.ControlEscolarEntities())
                {
                    var query = context.MateriaGetAll();
                    if(query != null)
                    {
                        result.Objects = new List<object>();
                        foreach(var registro in query)
                        {
                            ML.Materia materia = new ML.Materia();
                            materia.IdMateria = registro.IdMateria;
                            materia.Nombre = registro.Nombre;
                            materia.Costo = registro.Costo;
                            result.Objects.Add(materia);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al consultar las materias.";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result GetById(int idMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.ControlEscolarEntities context = new DLEF.ControlEscolarEntities())
                {
                    var query = context.MateriaGetById(idMateria);
                    if(query != null)
                    {
                        foreach (var data in query)
                        {
                            result.Object = new object();
                            ML.Materia materia = new ML.Materia();
                            materia.IdMateria = data.IdMateria;
                            materia.Nombre = data.Nombre;
                            materia.Costo = data.Costo;
                            result.Object = materia;
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al consultar la materia.";
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
        public static ML.Result Add(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.ControlEscolarEntities context = new DLEF.ControlEscolarEntities())
                {
                    var rowsAffected = context.MateriaAdd(materia.Nombre,materia.Costo);
                    if(rowsAffected > 0 )
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al agregar materia.";
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
        public static ML.Result Update(ML.Materia materia)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.ControlEscolarEntities context = new DLEF.ControlEscolarEntities())
                {
                    var rowsAffected = context.MateriaUpdate(materia.IdMateria,materia.Nombre,materia.Costo);
                    if(rowsAffected > 0 )
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al actualizar.";
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
        public static ML.Result Delete(int idMateria)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(DLEF.ControlEscolarEntities context = new DLEF.ControlEscolarEntities())
                {
                    var rowsAffected = context.MateriaDelete(idMateria);
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
