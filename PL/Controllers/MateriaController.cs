using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class MateriaController : Controller
    {
        // GET: Materia
        public ActionResult GetAll()
        {
            //ML.Result result = BL.Materia.GetAll();
            //ML.Materia materia = new ML.Materia();
            //materia.Materias = result.Objects;

            //WebApi
            ML.Result result = new ML.Result();
            ML.Materia materia = new ML.Materia();
            materia.Materias = new List<object>();
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["UrlApi"]);
                var responseTask = client.GetAsync("materia");
                responseTask.Wait();

                var resultService = responseTask.Result;
                if (resultService.IsSuccessStatusCode)
                {
                    var readTask = resultService.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();
                    foreach(var resultMateria in readTask.Result.Objects)
                    {
                        ML.Materia resultItemsList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(resultMateria.ToString());
                        materia.Materias.Add(resultItemsList);
                    }
                }
            }
            return View(materia);
        }
        public ActionResult Form(int? idMateria)
        {
            if (idMateria == 0)
            {
                return View();
            }
            else
            {
                //ML.Result result = BL.Materia.GetById(idMateria.Value);
                //ML.Materia materia = new ML.Materia();
                //materia = (ML.Materia)result.Object;

                //WebApi
                ML.Materia materia = new ML.Materia();
                using(var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["UrlApi"]);
                    var responseTask = client.GetAsync($"materia/{idMateria.Value}");
                    responseTask.Wait();
                    var resultService = responseTask.Result;
                    if (resultService.IsSuccessStatusCode)
                    {
                        var readTask = resultService.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();
                        ML.Materia resultItem = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Materia>(readTask.Result.Object.ToString());
                        materia = resultItem;
                    }
                }
                return View(materia);
            }
        }
        public ActionResult Delete(int idMateria)
        {
            //ML.Result result = BL.Materia.Delete(idMateria);

            //WebApi
            ML.Result result = new ML.Result();
            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["UrlApi"]);
                var responseTask = client.DeleteAsync($"materia/{idMateria}");
                responseTask.Wait();
                var resultService = responseTask.Result;
                if (resultService.IsSuccessStatusCode)
                {
                    result.Correct = true;
                }
            }
            if (result.Correct)
            {
                ViewBag.Mensaje = "Eliminado correctamente.";
            }
            else
            {
                ViewBag.Mensaje = "Error al eliminar";
            }
            return PartialView("Modal");
        }

        [HttpPost]
        public ActionResult Form(ML.Materia materia)
        {
            if (ModelState.IsValid)
            {
                ML.Result result = new ML.Result(); //Usado solo en WebApi
                if (materia.IdMateria == 0)
                {
                    //ML.Result result = BL.Materia.Add(materia);

                    //WebApi
                    using(var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(ConfigurationManager.AppSettings["UrlApi"]);
                        var responseTask = client.PostAsJsonAsync("materia",materia);
                        responseTask.Wait();
                        var resultService = responseTask.Result;
                        if(resultService.IsSuccessStatusCode)
                        {
                            result.Correct = true;
                        }
                    }
                    if (result.Correct)
                    {
                        ViewBag.Mensaje = "Agregado éxitosamente.";
                    }
                    else
                    {
                        ViewBag.Mensaje = "Error al agregar.";
                    }
                }
                else
                {
                    //ML.Result result = BL.Materia.Update(materia);

                    //WebApi
                    using(var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(ConfigurationManager.AppSettings["UrlApi"]);
                        var responseTask = client.PutAsJsonAsync($"materia/{materia.IdMateria}", materia);
                        responseTask.Wait();
                        var resultService = responseTask.Result;
                        if( resultService.IsSuccessStatusCode)
                        {
                            result.Correct = true;
                        }
                    }
                    if (result.Correct)
                    {
                        ViewBag.Mensaje = "Actualización éxitosa.";
                    }
                    else
                    {
                        ViewBag.Mensaje = "Error al actualizar.";
                    }
                }
            }
            else
            {
                return View(materia);
            }
            return PartialView("Modal");

        }
    }
}