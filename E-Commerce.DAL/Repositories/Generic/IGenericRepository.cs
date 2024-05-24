namespace E_Commerce.DAL.Repositories.Generic
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        /*------------------------------------------------------------------------*/
        // Get All
        IEnumerable<TEntity> GetAll();
        /*------------------------------------------------------------------------*/
        // Get One By Id
        TEntity? GetById(int id);
        /*------------------------------------------------------------------------*/
        // Create One
        void Create(TEntity entity);
        /*------------------------------------------------------------------------*/
        // Update One
        void Update(TEntity entity);
        /*------------------------------------------------------------------------*/
        // Delete One
        void Delete(TEntity entity);
        /*------------------------------------------------------------------------*/
    }
}
