using WeatherAPI.Data;

namespace WeatherAPI.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly WeatherAPIContext _context;
        public UnitOfWork(WeatherAPIContext context)
        {
            this._context = context;
        }
        public void CreateTransaction()
        {
            _context.Database.BeginTransactionAsync();
        }
        public void Commit()
        {
            _context.Database.CommitTransactionAsync();
        }
        public void Rollback()
        {
            _context.Database.RollbackTransactionAsync();
        }
        public void Save()
        {
            _context.SaveChanges();
        }
    }

}
