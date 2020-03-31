using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace FrameShopWPF
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DbSet<TEntity> _dbSet;

        public Repository(FrameShopDbContext context)
        {
            _dbSet = context.Set<TEntity>();
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public TEntity GetById(int entityId)
        {
            return _dbSet.Find(entityId);
        }

        public void DeleteById(int entityId)
        {
            var tEntity = _dbSet.Find(entityId);

            if (tEntity != null)
            {
                _dbSet.Remove(tEntity);
            }
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }
    }
}
