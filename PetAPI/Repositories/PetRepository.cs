using PetAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace PetAPI.Repositories
{
    public class PetRepository : IPetRepository
    {

        private readonly PetContext _context;

        public PetRepository(PetContext context)
        {
            _context = context;
        }
        public async Task<Pet> Create(Pet pet)
        {
            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();
            return pet;
        }

        public async Task Delete(int id)
        {
            var petToDelete = await _context.Pets.FindAsync(id);
            _context.Pets.Remove(petToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Pet>> Get()
        {
            return await _context.Pets.ToListAsync();
           
        }

        public async Task<Pet> Get(int id)
        {
            return await _context.Pets.FindAsync(id);
        }

        public async Task Update(Pet pet)
        {
            _context.Entry(pet).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }
    }
}
