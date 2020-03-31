using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace FrameShopWPF
{
    public class FrameShopDbContext : DbContext
    {
        public DbSet<Frame> Frames { get; set; }
        public DbSet<FrameShop> FrameShops { get; set; }
        public DbSet<Material> Materials { get; set; }

        public FrameShopDbContext(DbContextOptions<FrameShopDbContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
            Materials.Add(new Material() { Name = "Wood", QuanInStock = 213, QuanPerUnit = 5 });
            Materials.Add(new Material() { Name = "Metal", QuanInStock = 100, QuanPerUnit = 2 });
            Materials.Add(new Material() { Name = "Plastic", QuanInStock = 43, QuanPerUnit = 3 });
            Materials.Add(new Material() { Name = "Paint", QuanInStock = 300, QuanPerUnit = 6 });
            Materials.Add(new Material() { Name = "Varnish", QuanInStock = 200, QuanPerUnit = 5 });
            SaveChanges();
        }
    }
}
