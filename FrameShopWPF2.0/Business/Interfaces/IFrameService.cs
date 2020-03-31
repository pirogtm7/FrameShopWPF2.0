using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameShopWPF
{
    public interface IFrameService
    {
        void CreateFrame(FrameShopModel frameShop, MainViewModel mv, FrameModel frame);
        void FinalAmount(MaterialModel material, FrameModel frame, MainViewModel mv);
        void Save(FrameModel frame);
        List<MaterialModel> GetMaterials(FrameModel frame);
    }
}
