using MongoDB.Driver;
using BookStoreApi.Models;
using BookStoreApi.RepositoryPattern;
using BookStoreApi.Interfaces;
namespace BookStoreApi.Services
{
    public class RolesService : IRoleService
    {
        private readonly UnitOfWorkSQL _unitOfWork;
        public RolesService()   
        {
          this._unitOfWork = new UnitOfWorkSQL();
        }
        public async Task<IEnumerable<Role>> GetRoles() => await this._unitOfWork.RoleRepository.Get(orderBy:x=>x.OrderByDescending(x=>x.TimeCreate));
        public async Task<Role?> GetRoleById(string id) => await this._unitOfWork.RoleRepository.GetByID(id);
        public async Task CreateRole(Role newRole) => await this._unitOfWork.RoleRepository.Insert(newRole);
        public async Task UpdateRoleById(string id, Role updateRole) => await this._unitOfWork.RoleRepository.Update(updateRole);

        public async Task DeleteRoleById(string id) => await this._unitOfWork.RoleRepository.Delete(id);
        public async Task<IEnumerable<Role?>> ValidateRoleName(string id, string name) => await this._unitOfWork.RoleRepository.Get(x=>x.Id != id && x.Name == name);
    }
}