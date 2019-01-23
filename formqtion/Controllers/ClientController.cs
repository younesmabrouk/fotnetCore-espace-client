using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EspaceClient.Data.Context;
using EspaceClient.Entities;
using EspaceClient.Data.Repositories;

namespace formqtion.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private IClientRepository clientRepository;

        public ClientController(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var clients = clientRepository.GetAll();
            return Ok(clients);
        }

        [HttpGet("getByName")]
        public ActionResult Get(string name)
        {
            var clients = clientRepository.GetByName(name);
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var client = clientRepository.GetById(id);
            return Ok(client);
        }

        [HttpPost]
        public ActionResult Post([FromBody]Client client)
        {
            clientRepository.Insert(client);
            return Created("/api/client/" + client.Id, client);
        }

        [HttpPut]
        public ActionResult Put([FromBody]Client client)
        {
            clientRepository.Update(client);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
      
            int rows = clientRepository.Delete(id);
            if (rows > 0)
            {
                return Ok("deleted");
            }
            return Ok("no row affected");
        }

    }
}
