using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameShopWPF
{
    public class FrameShop
    {
        private List<Material> materials = new List<Material>();

        public List<Material> Materials { get { return materials; } set { materials = value; } }

    }
}
