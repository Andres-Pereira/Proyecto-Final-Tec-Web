using ArmasAPI.Data.Repository;
using Microsoft.AspNetCore.Mvc;
using MoviesAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesAPI.Controllers
{
    [Route("api/[controller]")]

    public class DealersController:ControllerBase
    {
       
       
            private IArmasRepository repository;
            public DealersController(IArmasRepository repository)
            {
                this.repository = repository;
            }
            // GET api/values
            [HttpGet]
            public ActionResult<IEnumerable<Dealer>> Get()
            {
                return Ok(repository.getDealers(true));
            }

            // GET api/values/5
            [HttpGet("{id}")]
            public ActionResult<Dealer> Get(int id)
            {
                try
                {
                    return Ok(repository.GetDealer(id,true));
                }
                catch
                {
                    return NotFound();
                }
            }

            // POST api/values
            [HttpPost]
            public ActionResult Post([FromBody] Dealer m)
            {
                repository.addDealer(m);
                return Ok();
            }

            // PUT api/values/5
            [HttpPut("{id}")]
            public ActionResult Put(int id, [FromBody] Dealer m)
            {
                try
                {
                    repository.updateDealer(id, m);
                    return Ok();
                }
                catch
                {
                    return BadRequest();
                }
            }

            // DELETE api/values/5
            [HttpDelete("{Arma}")]
            public ActionResult<bool> Delete(string Dealer)
            {
                try
                {
                    return Ok(repository.deleteDealer(Dealer));
                }
                catch
                {
                    return BadRequest();
                }

            }
        
    }
}
