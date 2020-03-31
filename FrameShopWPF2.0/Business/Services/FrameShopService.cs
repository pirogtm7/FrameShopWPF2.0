using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameShopWPF
{
    public class FrameShopService : IFrameShopService
    {
        private readonly IUnitOfWork _unitOfWork;
        IMapper _mapper;
        public FrameShopService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public void FrameShopFill(MaterialModel material, FrameShopModel frameShop)
        {
            if (material != null)
            {
                frameShop.Materials.Add(material);
            }
            var newFrameShop = _mapper.Map<FrameShop>(frameShop);
            _unitOfWork.FrameShopRepository.Add(newFrameShop);
            _unitOfWork.Save();
        }

        public List<string> NamesOfMaterials(FrameShopModel frameShop)
        {
            var NamesOfMaterials = new List<string>();
            foreach (MaterialModel material in frameShop.Materials)
            {
                NamesOfMaterials.Add(material.Name);
            }
            return NamesOfMaterials;
        }

        public List<MaterialModel> GetMaterials(FrameShopModel frameShop)
        {
            return frameShop.Materials;
        }
    }
}
