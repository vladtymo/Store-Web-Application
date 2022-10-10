using DataAccess.Entities;

namespace DataAccess.Interfaces
{
    public interface IPhoneRepository : IDisposable
    {
        IEnumerable<Phone> GetAll();
        Phone? GetById(int phoneId);
        void Insert(Phone phone);
        void Update(Phone phone);
        void Delete(int phoneId);
        void Delete(Phone phone);
        void Save();
    }
}
