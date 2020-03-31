using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameShopWPF
{
    public interface IUnitOfWork
    {
        IRepository<Frame> FrameRepository { get; }
        IRepository<FrameShop> FrameShopRepository { get; }
        IRepository<Material> MaterialRepository { get; }
        void Save();
    }
}
