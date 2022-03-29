using BookStoreApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using BookStoreApi.Settings;
using BookStoreApi.Interfaces;
using BookStoreApi.RepositoryPattern;
namespace BookStoreApi.Services
{
    public class UsersService : IUserService
    {
        private readonly UnitOfWorkSQL _unitOfWork;
        public UsersService(IOptions<BookStoreDatabaseSetting> bookStoreDataBaseSetting)
        {
            this._unitOfWork = new UnitOfWorkSQL();
        }
        public async Task<IEnumerable<User>> GetUserAsync() => await this._unitOfWork.UserRepository.Get();
        public async Task<User?> GetUserAsync(string id) => await this._unitOfWork.UserRepository.GetByID(id);
        public async Task CreateUserAsync(User newUser) => await this._unitOfWork.UserRepository.Insert(newUser);
        public async Task UpdateUserAsync(string id,User updateUser) => await this._unitOfWork.UserRepository.Update(updateUser);
        public async Task DeleteUserAsync(string id) => await this._unitOfWork.UserRepository.Delete(id);
        public async Task<IEnumerable<User?>> ValidateEmailUser(string id, string email) => await this._unitOfWork.UserRepository.Get(x=>x.Id != id && x.Email == email); 
        public async Task<IEnumerable<User?>> ValidatePhoneUser(string id, string phone) => await this._unitOfWork.UserRepository.Get(x=>x.Id != id && x.Phone == phone);
        public async Task<IEnumerable<User>> GetListUserByRoleId(string roleId) => await this._unitOfWork.UserRepository.Get(x=>x.RoleId == roleId);
    }
}