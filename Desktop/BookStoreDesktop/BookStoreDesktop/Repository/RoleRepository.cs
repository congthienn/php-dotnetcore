using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStoreDesktop.Interfaces.Repository;
using BookStoreDesktop.Models;
using BookStoreDesktop.BookStoreDatabase;
using Microsoft.EntityFrameworkCore;

namespace BookStoreDesktop.Repository
{
    public class RoleRepository : IRoleRepository
    {
        public void CreateRole(Role role)
        {
            using(var _context = new BookStoreContext())
            {
                _context.Roles.Add(role);
                _context.SaveChanges();
            }
        }
        public void DeleteRole(Role role)
        {
            using(var _context = new BookStoreContext())
            {
                _context.Roles.Remove(role);
                _context.SaveChanges();
            }
        }
        public List<Role> GetAllRole()
        {
            using(var _context = new BookStoreContext())
            {
                return _context.Roles.AsNoTracking().ToList();
            }
        }

        public Role GetRoleById(int id)
        {
            using(var _context = new BookStoreContext())
            {
                return _context.Roles.Find(id);
            }
        }

        public List<Role> GetRoleByName(string name)
        {
            using(var _context = new BookStoreContext())
            {
                return _context.Roles.Where(x => x.Name.Contains(name)).ToList();
            }
        }

        public void UpdateRole(Role role)
        {
            using(var _context = new BookStoreContext())
            {
                _context.Roles.Update(role);
                _context.SaveChanges();
            }
        }

        public Role ValidateName(int id, string name)
        {
            using(var _context = new BookStoreContext())
            {
                return _context.Roles.Where(x=>x.Id != id && x.Name == name).FirstOrDefault();
            }
        }
    }
}
