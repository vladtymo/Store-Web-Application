using BusinessLogic.DTOs;

namespace BusinessLogic.Interfaces
{
    public interface IPhoneService
    {
        void CreatePhone(PhoneDTO phoneDTO);
        List<PhoneDTO> GetAllPhones();
        List<PhoneDTO> GetPhones(int[] phoneIds);
        PhoneDTO? GetPhone(int phoneId);
        List<ColorDTO> GetAllColors();
        void DeletePhone(int phoneId);
        void UpdatePhone(PhoneDTO phoneDTO);
    }
}
