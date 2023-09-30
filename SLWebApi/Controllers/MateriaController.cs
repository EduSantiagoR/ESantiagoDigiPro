using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SLWebApi.Controllers
{
    [RoutePrefix("api/materia")]
    public class MateriaController : ApiController
    {
        [Route("")]
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            ML.Result result = BL.Materia.GetAll();
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK,result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest,result);
            }
        }
        [Route("{idMateria}")]
        [HttpGet]
        public IHttpActionResult GetById(int idMateria)
        {
            ML.Result result = BL.Materia.GetById(idMateria);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK,result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest,result);
            }
        }
        [Route("")]
        [HttpPost]
        public IHttpActionResult Add(ML.Materia materia)
        {
            ML.Result result = BL.Materia.Add(materia);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK,result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest,result);
            }
        }
        [Route("{idMateria}")]
        [HttpPut]
        public IHttpActionResult Update(int idMateria, [FromBody] ML.Materia materia)
        {
            materia.IdMateria = idMateria;
            ML.Result result = BL.Materia.Update(materia);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK,result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest,result);
            }
        }
        [Route("{idMateria}")]
        [HttpDelete]
        public IHttpActionResult Delete(int idMateria)
        {
            ML.Result result = BL.Materia.Delete(idMateria);
            if (result.Correct)
            {
                return Content(HttpStatusCode.OK,result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest,result);
            }
        }
    }
}
