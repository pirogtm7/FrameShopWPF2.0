using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameShopWPF
{
    public interface IFrameShopService
    {
        void FrameShopFill(MaterialModel material, FrameShopModel frameShop);
        List<string> NamesOfMaterials(FrameShopModel frameShop);
        List<MaterialModel> GetMaterials(FrameShopModel frameShop);
    }
}
