using Microsoft.AspNetCore.Http;        
using Microsoft.AspNetCore.Mvc;
using PetAPI.Models;
using PetAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace PetAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        private readonly IPetRepository _petRepository;
        public PetsController(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Pet>> GetPets()
        {
            return await _petRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pet>> GetPets(int id)
        {
            return await _petRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Pet>> PostPets([FromBody] Pet pet)
        {
            var newPet = await _petRepository.Create(pet);
            return CreatedAtAction(nameof(GetPets), new { id = newPet.Id }, newPet);
        }

        [HttpPut]
        public async Task<ActionResult> PutPets(int id,[FromBody] Pet pet)
        {
            if(id!=pet.Id)
            {
                return BadRequest();
            }

            await _petRepository.Update(pet);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var petToDelete = await _petRepository.Get(id);
            if (petToDelete == null)
                return NotFound();
            await _petRepository.Delete(petToDelete.Id);
            return NoContent();
        }


    }
}
