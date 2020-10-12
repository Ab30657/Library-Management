using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;
using BLL.Models;
using BLL.Repos;

namespace LibrarySystem
{
    public partial class ManageBook : Form
    {
        public string browsePath { get; set; }
        public ManageBook()
        {
            InitializeComponent();
            browsePath = Application.StartupPath + "\\Noimage.png";
        }

        private void ManageBook_Load(object sender, EventArgs e)
        {
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            pboxImage.Image = Image.FromFile(Application.StartupPath + "\\Noimage.png");
        }

        private void ClickAnim(Button sender)
        {
            sender.BackColor = Color.FromArgb(156, 176, 242);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            
            Book book = new Book();
            book.Title = txtName.Text;
            book.ISBN = txtISBN.Text;
            book.Author = txtAuthor.Text;

            MemoryStream ms = new MemoryStream();
            pboxImage.Image.Save(ms, ImageFormat.Jpeg);
            byte[] arr = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(arr, 0, arr.Length);

            book.Image = arr;
            book.IsRef = cbIsRef.Checked;
            book.AddedDate = DateTime.Today;
            book.AdminId = Dashboard._curr.UserId;
            using (BookRepo repo = new BookRepo())
            {
                repo.Add(book);
            }
            
            MessageBox.Show("Book Added Successfully!");
        }

        private void btnAdd_Leave(object sender, EventArgs e)
        {
            ClickAnim(sender as Button);


        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "All Images *.jpg|*.jpg";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                browsePath = openFileDialog1.FileName;
                pboxImage.ImageLocation = browsePath;
            }
        }

        private void btnBrowse_Leave(object sender, EventArgs e)
        {
            ClickAnim(sender as Button);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            btnAdd.Enabled = false;
            btnDelete.Enabled = true;
            btnDelete.ForeColor = Color.FromArgb(255, 255, 255);
            btnUpdate.Enabled = true;
            Book book = new Book();
            using (BookRepo repo = new BookRepo())
            {
                 book = repo.GetOne(int.Parse(txtID.Text));
            }
            txtAuthor.Text = book.Author;
            txtID.Text = book.BookId.ToString();
            txtID.ReadOnly = true;
            txtISBN.Text = book.ISBN;
            txtName.Text = book.Title;
            cbIsRef.Checked = book.IsRef;

            MemoryStream ms = new MemoryStream(book.Image,0,book.Image.Length);
            pboxImage.Image = Image.FromStream(ms);
            
        }

        private void ClearControls()
        {
            foreach (var item in this.Controls)
            {
                
                if(item is TextBox)
                {
                    ((TextBox)item).Text = "";
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Book book = new Book();
            book.Title = txtName.Text;
            book.ISBN = txtISBN.Text;
            book.Author = txtAuthor.Text;

            MemoryStream ms = new MemoryStream();
            pboxImage.Image.Save(ms, ImageFormat.Jpeg);
            byte[] arr = new byte[ms.Length];
            ms.Position = 0;
            ms.Read(arr, 0, arr.Length);
            book.BookId = int.Parse(txtID.Text);
            book.Image = arr;
            book.IsRef = cbIsRef.Checked;
            book.AddedDate = DateTime.Today;
            book.AdminId = Dashboard._curr.UserId;
            using (BookRepo repos = new BookRepo())
            {
                repos.Update(book);
            }
            MessageBox.Show("Book Updated Successfully!");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtAuthor.Text = "";
            txtName.Text = "";
            txtISBN.Text = "";
            cbIsRef.Checked = false;
            pboxImage.Image = Image.FromFile(Application.StartupPath + "\\Noimage.png");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

            using (BookRepo repos = new BookRepo())
            {
                repos.Delete(int.Parse(txtID.Text));
            }
            ClearControls();
            btnAdd.Enabled = true;
            btnUpdate.Enabled = false;
            btnDelete.Enabled = false;
            MessageBox.Show("Deleted!");
           
        }
    }
}
