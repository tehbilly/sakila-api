using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace REST.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ActorsController : ControllerBase
    {
        private readonly Repository _repository;

        public ActorsController(Repository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public Task<List<ActorDTO>> ListActors() => _repository
            .GetActors(a => ActorDTO.FromActor(a));

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetActor(int id)
        {
            var actor = await _repository.GetActor(id);
            if (actor == null) return NotFound();
            return Ok(ActorDTO.FromActor(actor));
        }
    }

    public class ActorDTO
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime LastUpdate { get; set; }

        public static ActorDTO FromActor(Actor actor)
        {
            return new ActorDTO
            {
                ID = actor.ActorId,
                FirstName = actor.FirstName,
                LastName = actor.LastName,
                LastUpdate = actor.LastUpdate,
            };
        }
    }
}