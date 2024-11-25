using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using WAD.CODEBASE._00016668.Data;
using WAD.CODEBASE._00016668.Models;

namespace WAD.CODEBASE._00016668.Repositories
{
    public class GroupRepository : IRepository<Groups>
    {
        // private entity of db context initiation
        private readonly ContactDbContext _contactDbContext;

        // constructor
        public GroupRepository(ContactDbContext contactDbContext)
        {
            _contactDbContext = contactDbContext;
        }

        // adding or creating new entity
        public async Task AddAsync(Groups entity)
        {
            await _contactDbContext.GroupsDbSet.AddAsync(entity);
            await _contactDbContext.SaveChangesAsync();
        }

        // deleting an entity from the database
        public async Task DeleteAsync(int id)
        {
            var removeGroup = await _contactDbContext.GroupsDbSet.FindAsync(id);
            if (removeGroup != null)
            {
                _contactDbContext.GroupsDbSet.Remove(removeGroup);
                await _contactDbContext.SaveChangesAsync();
            }
        }

        // getting all entities from the database
        public async Task<IEnumerable<Groups>> GetAllAsync()
        {
            return await _contactDbContext.GroupsDbSet.ToListAsync();
        }

        // retrieving the enetity using its id
        public async Task<Groups> GetByIdAsync(int id)
        {
            return await _contactDbContext.GroupsDbSet.FindAsync(id);
        }

        // updating the entity in the database
        public async Task UpdateAsync(Groups entity)
        {
            _contactDbContext.GroupsDbSet.Update(entity);
            await _contactDbContext.SaveChangesAsync();
        }
    }
}
