using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameShopWPF
{
    public class Frame : BaseEntity
    {
        private List<MaterialModel> materials = new List<MaterialModel>();
        private int width, length, quantity;

        public Guid FrameId { get; set; }
        public List<MaterialModel> Materials { get { return materials; } set { materials = value; } }
        public int Width { get { return width; } set { width = value; } }
        public int Length { get { return length; } set { length = value; } }
        public int Quantity { get { return quantity; } set { quantity = value; } }

    }
}
