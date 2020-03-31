using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameShopWPF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly FrameShopDbContext _context;
        public IRepository<Frame> FrameRepository { get; }
        public IRepository<FrameShop> FrameShopRepository { get; }
        public IRepository<Material> MaterialRepository { get; }

        public UnitOfWork(FrameShopDbContext context, IRepository<Frame> frames,
            IRepository<FrameShop> frameShops, IRepository<Material> materials)
        {
            _context = context;
            FrameRepository = frames;
            FrameShopRepository = frameShops;
            MaterialRepository = materials;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
