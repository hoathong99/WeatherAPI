namespace WeatherAPI.DAL
{
    public interface IGenericRepos<T> where T : class
    {
        Task<IEnumerable<T>> getAll();
        Task<T> getById(int id);
        Task<Boolean> insert(T entity);
        Task<Boolean> update(T entity);
        Task<Boolean> delete(int id);
    }
}
