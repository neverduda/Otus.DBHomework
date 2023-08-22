using Domain.Entities;

namespace Infrastructure.Repositories
{
    public interface IUserRepository : IRepository<User>
    {

        void AddUser(User item);
    }
}