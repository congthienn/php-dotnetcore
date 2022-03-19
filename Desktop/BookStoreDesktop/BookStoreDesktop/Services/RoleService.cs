using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreDesktop.Interfaces.Services;
using BookStoreDesktop.Interfaces.Repository;
using BookStoreDesktop.Models;
using BookStoreDesktop.Automapper;
using BookStoreDesktop.Autofac;
namespace BookStoreDesktop.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService()
        {
            this._roleRepository = AutofacInstance.GetInstance<IRoleRepository>();
        }
        public bool CreateRole(RoleDTO roleDTO)
        {
            Role newRole = new Role();
            ConfigMapper.configMapper().Map(roleDTO,newRole);
            Role validateName = this._roleRepository.ValidateName(newRole.Id, newRole.Name);
            if(validateName != null)
            {
                MessageBox.Show("Tên chức vụ đã có, vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            this._roleRepository.CreateRole(newRole);
            return true;
        }

        public bool DeleteRole(int id)
        {
           Role role = this._roleRepository.GetRoleById(id);
            if(role is null)
            {
                MessageBox.Show("Không tìm thấy chức vụ phù hợp, vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            this._roleRepository.DeleteRole(role);
            return true;
        }

        public List<Role> GetAllRole()
        {
            return this._roleRepository.GetAllRole();
        }

        public List<Role> GetRoleByName(string name)
        {
            return this._roleRepository.GetRoleByName(name);
        }

        public bool UpdateRole(RoleDTO roleDTO, int id)
        {
            Role role = this._roleRepository.GetRoleById(id);
            if(role is null)
            {
                MessageBox.Show("Không tìm thấy chức vụ phù hợp, vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            ConfigMapper.configMapper().Map(roleDTO, role);
            Role validateName = this._roleRepository.ValidateName(role.Id, role.Name);
            if(validateName != null)
            {
                MessageBox.Show("Tên chức vụ đã có, vui lòng kiểm tra lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            this._roleRepository.UpdateRole(role);
            return true;
        }
    }
}
