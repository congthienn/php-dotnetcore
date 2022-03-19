using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreDesktop.Models;
namespace BookStoreDesktop.Interfaces.Repository
{
    public interface IRoleRepository
    {
        List<Role> GetAllRole();
        Role GetRoleById(int id);
        void CreateRole(Role role);
        void UpdateRole(Role role);
        void DeleteRole(Role role);
        Role ValidateName(int id,string name);
        List<Role> GetRoleByName(string name);
    }
}