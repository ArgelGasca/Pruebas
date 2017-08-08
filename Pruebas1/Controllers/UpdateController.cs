using System.Web.Http;
using Pruebas1.Models;
using System.Collections.Generic;
using System.Linq;

namespace Pruebas1.Controllers
{
    [RoutePrefix("api/update")]
    public class UpdateController : ApiController
    {
        [HttpGet]
        public IEnumerable<Update> GetAllUpdate()
        {
            List<Update> updates = Update.GetAll();   
            return updates;
        }

        [HttpGet]
        public IHttpActionResult GetUpdate(int id)
        {
            List<Update> updates = Update.GetAll();
            var update = updates.FirstOrDefault((p) => p.ID == id);
            if (update == null)
            {
                return NotFound();
            }
            return Ok(update);
        }

        [HttpPost]
        public IHttpActionResult PostUpdate(Update update)
        {

            Update.Insertar(update);
            return Ok(update);
        }

        [HttpPut]
        public IHttpActionResult PutUpdate(int id,Update update)
        {
            Update.Actualizar(update, id);
            update.ID = id;
            return Ok(update);
        }

        [HttpDelete]
        public IHttpActionResult DeleteUpdate(int id)
        {
            Update.Eliminar(id);
            return Ok();
        }
    }
}
