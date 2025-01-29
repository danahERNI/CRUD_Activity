using ItemList.Data;
using ItemList.Model.Entities;
using ItemList.Repositories.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace ItemList.Repositories
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly AppDbContext _context;

        public OwnerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Owner?> AddOwner(Owner owner)
        {
            var create = await _context.OwnerModels.AddAsync(owner);
            await _context.SaveChangesAsync();
            return owner;
        }

        public async Task<Owner?> DeleteOwner(int id)
        {
            var findId = await _context.OwnerModels.Where(i => i.OwnerId == id).FirstOrDefaultAsync();
            if (findId == null)
            {
                return null;
            }
            _context.OwnerModels.Remove(findId);
            await _context.SaveChangesAsync();
            return findId;

        }

        public async Task<IEnumerable<Owner>> GetAllUsers()
        {
            var ownerList = await _context.OwnerModels.ToListAsync();
            return ownerList;
        }

        public async Task<Owner?> GetOwnerId(int id)
        {
            var getOwnerId = await _context.OwnerModels.FindAsync(id);
            return getOwnerId;
        }

        public async Task<Owner?> UpdateOwner(int id, Owner owner)
        {
            var currentDetails = await _context.OwnerModels.FindAsync(id);
            if (currentDetails == null) 
            {
                throw new KeyNotFoundException("No id found");
            }
            currentDetails.OwnerName = owner.OwnerName;
            currentDetails.ContactNumber = owner.ContactNumber;
            currentDetails.Email = owner.Email;

            await _context.SaveChangesAsync();
            return currentDetails;
        }
    }
}
