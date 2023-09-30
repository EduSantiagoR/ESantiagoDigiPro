using ML;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Alumno
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using(SqlConnection connection = new SqlConnection(DLEF.Conexion.Get()))
                {
                    string query = "AlumnoGetAll";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable tableAlumno = new DataTable();
                    adapter.Fill(tableAlumno);
                    if(tableAlumno.Rows.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach(DataRow row in tableAlumno.Rows)
                        {
                            ML.Alumno alumno = new ML.Alumno();
                            alumno.IdAlumno = int.Parse(row[0].ToString());
                            alumno.Nombre = row[1].ToString();
                            alumno.ApellidoPaterno = row[2].ToString();
                            alumno.ApellidoMaterno = row[3].ToString();
                            result.Objects.Add(alumno);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Sin registros en la tabla.";
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
        public static ML.Result GetById(int idAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(SqlConnection  connection = new SqlConnection(DLEF.Conexion.Get()))
                {
                    string query = "AlumnoGetById";
                    SqlCommand cmd = new SqlCommand(query,connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] collection = new SqlParameter[1];
                    collection[0] = new SqlParameter("@IdAlumno",SqlDbType.Int);
                    collection[0].Value = idAlumno;

                    cmd.Parameters.AddRange(collection);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable tablaAlumno = new DataTable();
                    adapter.Fill(tablaAlumno);
                    if(tablaAlumno.Rows.Count > 0)
                    {
                        DataRow row = tablaAlumno.Rows[0];
                        ML.Alumno alumno = new ML.Alumno();
                        alumno.IdAlumno = int.Parse(row[0].ToString());
                        alumno.Nombre = row[1].ToString();
                        alumno.ApellidoPaterno = row[2].ToString();
                        alumno.ApellidoMaterno = row[3].ToString();
                        result.Object = alumno;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Registro no encontrado";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = true;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result Add(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(SqlConnection connection = new SqlConnection(DLEF.Conexion.Get()))
                {
                    string query = "AlumnoAdd";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] collection = new SqlParameter[3];

                    collection[0] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                    collection[0].Value = alumno.Nombre;
                    collection[1] = new SqlParameter("@ApellidoPaterno",SqlDbType.VarChar);
                    collection[1].Value = alumno.ApellidoPaterno;
                    collection[2] = new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar);
                    collection[2].Value = alumno.ApellidoMaterno;

                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if(rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al agregar alumno.";
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
        public static ML.Result Update(ML.Alumno alumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(SqlConnection connection = new SqlConnection(DLEF.Conexion.Get()))
                {
                    string query = "AlumnoUpdate";
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter[] collection = new SqlParameter[4];
                    collection[0] = new SqlParameter("@IdAlumno", SqlDbType.Int);
                    collection[0].Value = alumno.IdAlumno;
                    collection[1] = new SqlParameter("@Nombre", SqlDbType.VarChar);
                    collection[1].Value = alumno.Nombre;
                    collection[2] = new SqlParameter("@ApellidoPaterno",SqlDbType.VarChar);
                    collection[2].Value = alumno.ApellidoPaterno;
                    collection[3] = new SqlParameter("@ApellidoMaterno", SqlDbType.VarChar);
                    collection[3].Value = alumno.ApellidoMaterno;

                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if(rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Error al actualizar alumno.";
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
        public static ML.Result Delete(int IdAlumno)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(SqlConnection connection = new SqlConnection(DLEF.Conexion.Get()))
                {
                    string query = "AlumnoDelete";
                    SqlCommand cmd = new SqlCommand(query,connection);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter[] collection = new SqlParameter[1];
                    collection[0] = new SqlParameter("@IdAlumno", SqlDbType.Int);
                    collection[0].Value = IdAlumno;

                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if(rowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct= false;
                        result.ErrorMessage = "Error al eliminar.";
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
    }
}
