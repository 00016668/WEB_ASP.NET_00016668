using Microsoft.EntityFrameworkCore;
using WAD.CODEBASE._00016668.Data;
using WAD.CODEBASE._00016668.Models;

namespace WAD.CODEBASE._00016668.Repositories
{
    public class ContactRepository : IRepository<Contacts>
    {
        private readonly ContactDbContext _dbContext;

        // constructor
        public ContactRepository(ContactDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Add or create a new entity
        public async Task AddAsync(Contacts entity)
        {
            _dbContext.Contacts.Add(entity);
            await _dbContext.SaveChangesAsync();
        }

        // delete an entity
        public async Task DeleteAsync(int id)
        {
            var entity = await _dbContext.Contacts.FindAsync(id);
            if (entity != null)
            {
                _dbContext.Contacts.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        // Retrieve all entity from the database
        public async Task<IEnumerable<Contacts>> GetAllAsync()
        {
            var allItems = await _dbContext.Contacts.Include(t => t.Groups).ToListAsync();
            return allItems;
        }

        // Retreive the entity from the database using only an id
        public async Task<Contacts> GetByIdAsync(int id)
        {
            var item = await _dbContext.Contacts.Include(c => c.Groups).FirstOrDefaultAsync(c => c.Id == id);
            return item;
        }

        // update the entity
        public async Task UpdateAsync(Contacts entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
