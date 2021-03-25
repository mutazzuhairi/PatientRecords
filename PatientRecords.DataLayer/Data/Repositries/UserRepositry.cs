using System.Threading.Tasks;
using PatientRecords.DataLayer.Data.Entities;
using PatientRecords.DataLayer.DataUtilities.Abstractions;
using PatientRecords.DataLayer.DataUtilities.DBContext;
using PatientRecords.DataLayer.Data.Repositries.Interfaces;
using Microsoft.AspNetCore.Identity;
using System.Linq;

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

        public async Task CreateAsync(User entity,string password)
        {
            await _userManager.CreateAsync(entity, password);
        }

        public override async void Update(User entity)
        {
            await _userManager.UpdateAsync(entity);
        }

        public  async Task UpdateAsync(User entity)
        {
            await _userManager.UpdateAsync(entity);
        }

        public async Task UpdatePasswordAsync(User entity,string currentPassword,string newPassword)
        {
            await _userManager.ChangePasswordAsync(entity, currentPassword, newPassword);
        }

        public async Task RemoveFromRoleAsync(User entity, string role)
        {
            await _userManager.RemoveFromRoleAsync(entity, role);
        }

        public async Task SetLockoutEnabledAsync(User entity,bool enabled)
        {
            await _userManager.SetLockoutEnabledAsync(entity, enabled);
        }

        public async Task AddToRoleAsync(User entity,string role)
        {
            await _userManager.AddToRoleAsync(entity, role);
        }

        public override async void Remove(User entity)
        {
            await _userManager.DeleteAsync(entity);
        }

        public override async Task<User> FindAsync(params object[] keyValues)
        {
          return await  _userManager.FindByIdAsync((string)keyValues.First());
        }

        public async Task<User> FindByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<bool> CheckPasswordAsync(User user , string password)
        {
            return await _userManager.CheckPasswordAsync(user , password);
        }

        public override  Task<int> SubmitChanges()
        {
            return Task.FromResult<int>(0);
        }

    }
}
