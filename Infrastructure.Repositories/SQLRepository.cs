using Domain.Entities;
using Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Services.Repositories.Interfases;

namespace Infrastructure.Repositories
{
    public class SQLRepository : IUserRepository, IRepository<Product>, IRepository<Advertisement>
    {
        private bool disposed = false;

        private DBContext dbContext;

        public SQLRepository(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void AddUser(User item)
        {
            dbContext.Users.Add(item);
            dbContext.SaveChanges();
        }

        public IEnumerable<User> GetAllItems()
        {
            return dbContext.Users.ToList();
        }

        IEnumerable<Product> IRepository<Product>.GetAllItems()
        {
            return dbContext.Products.ToList();
        }

        IEnumerable<Advertisement> IRepository<Advertisement>.GetAllItems()
        {
            return dbContext.Advertisements
                .Include(x => x.Seller)
                .Include(x => x.Buyer)
                .Include(x => x.Product)
                .ToList();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
