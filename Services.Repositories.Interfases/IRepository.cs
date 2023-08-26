namespace Services.Repositories.Interfases
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetAllItems();
    }
}