using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ArmasAPI.Data.Repository;
using ArmasWebAplication.Model;

namespace ArmasWebAplication.Controllers
{
    [Route("api/[controller]")]
    public class ArmasController : ControllerBase
    {
        private IArmasRepository repository;
        public ArmasController(IArmasRepository repository)
        {
            this.repository = repository;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Arma>> Get()
        {
            return Ok(repository.getArmas());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Arma> Get(int id)
        {
            try
            {
                return Ok(repository.getArma(id));
            }
            catch
            {
                return NotFound();
            }
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody] Arma m)
        {
            repository.addArma(m);
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Arma m)
        {
            try
            {
                repository.updateArma(id, m);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/values/5
        [HttpDelete("{Arma}")]
        public ActionResult<bool> Delete(string Arma)
        {
            try
            {
                return Ok(repository.deleteArma(Arma));
            }
            catch
            {
                return BadRequest();
            }

        }

        // GET api/values/5
        [HttpGet("dealer/{id}")]
        public ActionResult<Arma> GetByDealer(int id)
        {
            try
            {
                return Ok(repository.GetByDealer(id));
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpGet("calibre/{cali}")]
        public ActionResult<Arma> GetByCalibre(int cali)
        {
            try
            {
                return Ok(repository.GetByCalibre(cali));
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
