using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFCoreWebApp.Core.Abstractions.Repositories;
using EFCoreWebApp.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFCoreWebApp.DaraAccess.Repositories
{
    public class UserRepository
    :IRepository<User>
    {
        private DataContext dataContext;

        public UserRepository()
        {
            dataContext = new DataContext();
        }
        public IEnumerable<User> GetAll()
        {
            return dataContext.Users.ToList();
        }
        public User Get(int id)
        {
            return dataContext.Users.Find(id);
        }
        public void Create(User item)
        {
            dataContext.Users.Add(item);
        }
        public void Update(User item)
        {
            dataContext.Entry(item).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            User user = dataContext.Users.Find(id);
            if (user != null)
                dataContext.Users.Remove(user);
        }
        public void Save()
        {
            dataContext.SaveChanges();
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dataContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
