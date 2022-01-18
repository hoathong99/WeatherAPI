namespace WeatherAPI.DAL
{
    public interface IUnitOfWork
    {
        void CreateTransaction();
        void Commit();
        void Rollback();
        void Save();
    }
}
