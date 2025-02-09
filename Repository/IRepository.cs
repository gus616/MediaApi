namespace MediaApi.Repository
{
    public interface IRepository<TEntity>
    {

        Task<IEnumerable<TEntity>> GetAll();

        Task<IEnumerable<TEntity>> GetAllByUserId(int id);   

        Task<TEntity> GetById(int id);

        Task Add(TEntity entity);    
        
        void Update(TEntity entity);

        void Delete(TEntity entity);

        Task Save();

        IEnumerable<TEntity> Search(Func<TEntity, bool> filter);
    }
}
