using E_Commerce.DAL.Data.Context;
using E_Commerce.DAL.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.DAL.Repositories.Generic
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        /*------------------------------------------------------------------------*/
        protected readonly E_CommerceContext _context;
        /*------------------------------------------------------------------------*/
        public GenericRepository(E_CommerceContext context)
        {
            _context = context;
        }
        /*------------------------------------------------------------------------*/
        // Get All
        public IEnumerable<TEntity> GetAll()
        {
            return _context.Set<TEntity>().AsNoTracking();
        }
        /*------------------------------------------------------------------------*/
        // Get One By Id
        public TEntity? GetById(int id)
        {
            return _context.Set<TEntity>().Find(id);
        }
        /*------------------------------------------------------------------------*/
        // Create One
        public void Create(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }
        /*------------------------------------------------------------------------*/
        // Update One
        public void Update(TEntity entity)
        {
        }
        /*------------------------------------------------------------------------*/
        // Delete One
        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }
        /*------------------------------------------------------------------------*/
    }
}
