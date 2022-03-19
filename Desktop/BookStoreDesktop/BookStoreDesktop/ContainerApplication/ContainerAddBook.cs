using BookStoreDesktop.Interfaces;
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
using BookStoreDesktop.Autofac;
namespace BookStoreDesktop.ContainerApplication
{
    public partial class ContainerAddBook : Form
    {
        private readonly ICategoryService _categoryService;
        public string pathFile=null;
        public ContainerAddBook()
        {
            InitializeComponent();
            this._categoryService = AutofacInstance.GetInstance<ICategoryService>();
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
        public bool CheckData()
        {
            if (String.IsNullOrWhiteSpace(txtName.Text))
            {
                MessageBox.Show("Tên sách không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if(txtPrice.Value == 0)
            {
                MessageBox.Show("Giá bán không phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if(txtQuantity.Value == 0)
            {
                MessageBox.Show("Số lượng sản phẩm không phù hợp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (String.IsNullOrWhiteSpace(txtAuthor.Text))
            {
                MessageBox.Show("Tên tác giả không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (selectCategory.SelectedValue.ToString() == "0")
            {
                MessageBox.Show("Thể loại sách không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (String.IsNullOrWhiteSpace(this.pathFile))
            {
                MessageBox.Show("Hình ảnh sản phẩm không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                string[] f = open.FileName.Split('\\');
                this.pathFile = f[f.Length - 1];
                pictureBox1.Image = new Bitmap(open.FileName);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ContainerAddBook_Load(object sender, EventArgs e)
        {
            SelectCategory();
            txtName.Focus();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void ContainerAddBook_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void txtPrice_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Folder = Path.Combine(Directory.GetCurrentDirectory(), "Images");
            MessageBox.Show(Folder);
            bool checkData = CheckData();
            if (checkData)
            {
                BookDTO newBook = new BookDTO
                {
                    Name = txtName.Text,
                    Author = txtAuthor.Text,
                    CategoryId = Convert.ToInt32(selectCategory.SelectedValue.ToString()),
                    ImgPath = this.pathFile,
                    Price = (int)txtPrice.Value,
                    Quantity = (int)txtQuantity.Value,
                };
            }
        }
    }
}