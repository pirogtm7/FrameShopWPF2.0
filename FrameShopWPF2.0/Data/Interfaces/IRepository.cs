using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameShopWPF
{
    public interface IRepository<TEntity> where TEntity : IBaseEntity
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        TEntity GetById(int entityId);
        void DeleteById(int entityId);
        IEnumerable<TEntity> GetAll();
    }
}
