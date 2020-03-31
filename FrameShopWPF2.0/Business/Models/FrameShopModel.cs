using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameShopWPF
{
    public class FrameShopModel
    {
        private List<MaterialModel> materials = new List<MaterialModel>();

        public List<MaterialModel> Materials { get { return materials; } set { materials = value; } }

    }
}