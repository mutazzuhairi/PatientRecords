using PatientRecords.DataLayer.Data.Entities;
using PatientRecords.DataLayer.DataUtilities.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatientRecords.DataLayer.Data.Repositries.Interfaces
{
    public  interface IUserRepositry : IRepository<User>
    {
        public Task<User> FindByEmailAsync(string email);
        public Task<bool> CheckPasswordAsync(User user, string password);
    }
}
