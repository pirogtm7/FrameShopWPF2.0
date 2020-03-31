using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameShopWPF
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Frame, FrameModel>().ReverseMap();
            CreateMap<FrameShop, FrameShopModel>().ReverseMap();
            CreateMap<Material, MaterialModel>().ReverseMap();
        }
    }
}
