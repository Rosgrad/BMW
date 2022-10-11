using BMW.Dal.Interfaces;
using BMW.Domain.Entity;

namespace BMW.Dal.Repositories
{
    public class BMWRepository : IBaseRepository<Cars>
    {
        private readonly BMWDbContext _db;

        public BMWRepository(BMWDbContext db)
        {
            _db = db;
        }

        public async Task Create(Cars entity)
        {
            await _db.Cars.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task Delete(Cars entity)
        {
            _db.Cars.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public IQueryable<Cars> GetAll()
        {
            return _db.Cars;
        }

        public async Task<Cars> Update(Cars entity)
        {
            _db.Cars.Update(entity);
            await _db.SaveChangesAsync();
            return entity;
        }
    }
}
