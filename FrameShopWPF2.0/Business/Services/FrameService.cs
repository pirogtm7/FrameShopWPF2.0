using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using static FrameShopWPF.ConfigAccess;

namespace FrameShopWPF
{
	public class FrameService : IFrameService
	{
        private readonly IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public FrameService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void CreateFrame(FrameShopModel frameShop, MainViewModel mv, FrameModel frame)
        {
            foreach (MaterialModel material in frameShop.Materials)
            {
                foreach (MainViewModel.CheckedListItem<string> item in mv.CustomCheckBox)
                {
                    if (material.Name == item.Item & item.IsChecked == true)
                    {
                        frame.Materials.Add(material);
                        FinalAmount(material, frame, mv);
                    }
                }
            }
            var newFrame = _mapper.Map<Frame>(frame);
            _unitOfWork.FrameRepository.Add(newFrame);
            _unitOfWork.Save();
        }

        public void FinalAmount(MaterialModel material, FrameModel frame, MainViewModel mv)
        {
            mv.CheckLabel = "";

            int finalAmount = material.QuanPerUnit * frame.Width * frame.Length * frame.Quantity;

            if (material.QuanInStock >= finalAmount)
            {
                mv.CheckLabel += enoughString + material.Name + ".\n" + youNeedString +
                    finalAmount + youHaveString + material.QuanInStock + ".\n\n";
            }

            else if (material.QuanInStock < finalAmount)
            {
                mv.CheckLabel += notEnoughString + material.Name + ".\n" + youNeedString +
                    finalAmount + youHaveString + material.QuanInStock + ".\n\n";
            }
        }
        public void Save(FrameModel frame)
        {
            Serializer.XMLSerializator serialization =
                new Serializer.XMLSerializator(typeof(FrameModel));

            serialization.Serialization(frame, pathXML);
        }

        public List<MaterialModel> GetMaterials(FrameModel frame)
        {
            return frame.Materials;
        }
    }
}
