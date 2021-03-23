using System.Threading.Tasks;
using PatientRecords.DataLayer.Data.Entities;
using PatientRecords.DataLayer.DataBasics.Abstractions;
using PatientRecords.DataLayer.DataBasics.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System;
using PatientRecords.DataLayer.Data.Repositries.Interfaces;

namespace PatientRecords.DataLayer.Data.Repositries
{
    public class UserRepositry  :  EntityRepository<User> , IUserRepositry
    {
        private readonly UserManager<User> _userManager;


        public UserRepositry(MainContext context , UserManager<User> userManager) :base(context)
        {
            _userManager =  userManager;
        }

        public override IQueryable<User> GetAll()
        {
            return _userManager.Users;
        }

        public override async void Add(User entity)
        {
          await _userManager.CreateAsync(entity);
        }

        public override async void Update(User entity)
        {
            await _userManager.UpdateAsync(entity);
        }

        public override async void Remove(User entity)
        {
            await _userManager.DeleteAsync(entity);
        }

        public override async Task<User> FindAsync(params object[] keyValues)
        {
          return await  _userManager.FindByIdAsync((string)keyValues.First());
        }
 
        public override  Task<int> SubmitChanges()
        {
            return null;
        }

    }
}
