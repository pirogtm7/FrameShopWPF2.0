using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameShopWPF
{
    public class FrameShop : BaseEntity
    {
        private List<MaterialModel> materials = new List<MaterialModel>();

        public Guid FrameShopId { get; set; }
        public List<MaterialModel> Materials { get { return materials; } set { materials = value; } }

    }
}
