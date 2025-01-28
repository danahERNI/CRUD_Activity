using ItemList.Data;
using ItemList.Model.Entities;
using ItemList.Repositories.Interfaces;
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

        public async Task<Owner> AddOwner(Owner owner)
        {
            _context.OwnerModels.Add(owner);
            await _context.SaveChangesAsync();
            return owner;
        }

        public Task<Owner?> DeleteOwner(int id)
        {
            throw new NotImplementedException();
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
