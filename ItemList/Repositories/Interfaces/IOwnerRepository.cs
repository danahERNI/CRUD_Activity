using ItemList.Model.Entities;

namespace ItemList.Repositories.Interfaces
{
    public interface IOwnerRepository
    {
        public Task<IEnumerable<Owner>> GetAllUsers();
        public Task<Owner?> GetOwnerId(int id);
        public Task<Owner> AddOwner(Owner owner);
        public Task<Owner?> UpdateOwner(int id, Owner owner);
        public Task<Owner?> DeleteOwner(int id);
    }
}
