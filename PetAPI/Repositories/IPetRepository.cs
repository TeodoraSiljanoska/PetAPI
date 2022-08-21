using PetAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetAPI.Repositories
{
    public interface IPetRepository
    {
        Task<IEnumerable<Pet>> Get();
        Task<Pet> Get(int id);
        Task<Pet> Create(Pet pet);
        Task Update(Pet pet);
        Task Delete(int id);


    }
}
