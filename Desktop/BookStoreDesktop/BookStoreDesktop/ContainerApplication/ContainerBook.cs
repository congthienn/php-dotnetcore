using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BookStoreDesktop.Models;
using BookStoreDesktop.Interfaces;
using BookStoreDesktop.Autofac;
namespace BookStoreDesktop.ContainerApplication
{
    public partial class ContainerBook : Form
    {
        private readonly ICategoryService _categoryService;
        public ContainerBook()
        {
            this._categoryService = AutofacInstance.GetInstance<ICategoryService>();
            InitializeComponent();
        }
        public void SelectCategory()
        {
            List<Category> listCategory = this._categoryService.GetAllCategory();
            Category fakeCategory = new Category { Name = "---Chon the loai sach---" };
            listCategory.Insert(0, fakeCategory);
            selectCategory.DataSource = listCategory;
            selectCategory.ValueMember = "Id";
            selectCategory.DisplayMember = "Name";
        }
        private void ContainerBook_Load(object sender, EventArgs e)
        {
            SelectCategory();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ContainerAddBook addBook = new ContainerAddBook();
            addBook.ShowDialog();
        }
    }
}
