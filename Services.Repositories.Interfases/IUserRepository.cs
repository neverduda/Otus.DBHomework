using Domain.Entities;

namespace Services.Repositories.Interfases
{
    public interface IUserRepository : IRepository<User>
    {

        void AddUser(User item);
    }
}