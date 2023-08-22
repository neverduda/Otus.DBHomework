namespace Infrastructure.Repositories
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetAllItems();
    }
}