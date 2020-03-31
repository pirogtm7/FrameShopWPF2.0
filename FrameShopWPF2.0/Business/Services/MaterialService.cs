using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameShopWPF
{
	public class MaterialService : IMaterialService
	{
        private readonly IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public MaterialService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public IEnumerable<MaterialModel> GetMaterials()
        {
            var materials = _unitOfWork.MaterialRepository.GetAll();
            var materialModels = _mapper.Map<IEnumerable<MaterialModel>>(materials);
            return materialModels;
        }
    }
}
