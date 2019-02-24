using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestTask.Server.LibServer;

namespace TestTask.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public List<Phone> Get()
        {
            return ProcesDataApi.GET_DataObjects();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Phone Get(int id)
        {
            return ProcesDataApi.GET_DataObject(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] Phone data)
        {
            ProcesDataApi.POST_DataObject(data);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Phone  data)
        {
            ProcesDataApi.PUT_DataObject(id, data);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ProcesDataApi.DELETE_DataObject(id);
        }
    }
}
