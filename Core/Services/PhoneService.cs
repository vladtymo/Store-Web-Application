using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Entities;
using BusinessLogic.Entities.Specifications;
using BusinessLogic.Interfaces;

namespace BusinessLogic.Services
{
    public class PhoneService : IPhoneService
    {
        private readonly IMapper mapper;
        private readonly IRepository<Phone> phoneRepository;
        private readonly IRepository<Color> colorRepository;

        public PhoneService(IMapper mapper,
                            IRepository<Phone> phoneRepository,
                            IRepository<Color> colorRepository)
        {
            this.mapper = mapper;
            this.phoneRepository = phoneRepository;
            this.colorRepository = colorRepository;
        }

        public void CreatePhone(PhoneDTO phoneDTO)
        {
            var phone = mapper.Map<Phone>(phoneDTO);
            phoneRepository.Insert(phone);
            phoneRepository.Save();
        }

        public void DeletePhone(int phoneId)
        {
            phoneRepository.Delete(phoneId);
            phoneRepository.Save();
        }

        public PhoneDTO? GetPhone(int phoneId)
        {
            var phone = phoneRepository.GetFirstBySpec(new Phones.ById(phoneId));
            return mapper.Map<PhoneDTO>(phone);
        }

        public List<PhoneDTO> GetAllPhones()
        {
            var result = phoneRepository.GetListBySpec(new Phones.All());
            return mapper.Map<List<PhoneDTO>>(result);
        }

        public List<ColorDTO> GetAllColors()
        {
            var result = colorRepository.GetAll();
            return mapper.Map<List<ColorDTO>>(result);
        }

        public void UpdatePhone(PhoneDTO phoneDTO)
        {
            var phone = mapper.Map<Phone>(phoneDTO);
            phoneRepository.Update(phone);
            phoneRepository.Save();
        }

        public List<PhoneDTO> GetPhones(int[] phoneIds)
        {
            var result = phoneRepository.GetListBySpec(new Phones.ByIds(phoneIds));
            return mapper.Map<List<PhoneDTO>>(result);
        }
    }
}
