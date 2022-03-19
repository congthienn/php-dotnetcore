using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using BookStoreDesktop.Interfaces;
using BookStoreDesktop.Services;
using BookStoreDesktop.Repository;
using AutoMapper;
using BookStoreDesktop.Interfaces.Services;
using BookStoreDesktop.Interfaces.Repository;

namespace BookStoreDesktop.Autofac
{
    public class AutofacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Services
            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<RoleService>().As<IRoleService>();
            builder.RegisterType<BookService>().As<IBookService>();



            //Repository
            builder.RegisterType<CategoryRepository>().As<ICategoryRepository>();
            builder.RegisterType<RoleRepository>().As<IRoleRepository>();
            builder.RegisterType<BookRepository>().As<IBookRepository>();
        }
    }
}
