using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameShopWPF
{
    public class Material : BaseEntity
    {
        private string name;
        private int quanPerUnit, quanInStock;
        [Key]
        public Guid MaterialId { get; set; }
        public string Name { get { return name; } set { name = value; } }
        public int QuanPerUnit { get { return quanPerUnit; } set { quanPerUnit = value; } }
        public int QuanInStock { get { return quanInStock; } set { quanInStock = value; } }

    }
}
