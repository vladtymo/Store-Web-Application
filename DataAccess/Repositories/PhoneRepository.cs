using DataAccess.Data;
using DataAccess.Entities;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class PhoneRepository : IPhoneRepository
    {
        private readonly StoreDbContext context;

        public PhoneRepository(StoreDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Phone> GetAll()
        {
            return context.Phones.Include(x => x.Color).ToList();
        }
        public Phone? GetById(int phoneId)
        {
            return context.Phones.Include(x => x.Color)
                                 .FirstOrDefault(x => x.Id == phoneId);
        }
        public void Insert(Phone phone)
        {
            context.Phones.Add(phone);
        }
        public void Update(Phone phone)
        {
            context.Entry(phone).State = EntityState.Modified;
        }
        public void Delete(int phoneId)
        {
            Phone? phone = context.Phones.Find(phoneId);
            if (phone != null) context.Phones.Remove(phone);
        }
        public void Delete(Phone phone)
        {
            context.Phones.Remove(phone);
        }
        public void Save()
        {
            context.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }
    }
}
