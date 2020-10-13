using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL.EF;
using BLL.Models;
using BLL.Repos;

namespace LibrarySystem
{
    public partial class Form1 : Form
    {

        public static int currUserId { get; set; }
        private UserRepo _userRepo = new UserRepo();
        public static User _user = new User();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //User _user = _userRepo.GetUser(txtUsername.Text);
            using (UserRepo repo = new UserRepo())
            {
                _user = repo.GetUser(txtUsername.Text);
            }
            if (_user!= null)
            {
                if (txtPassword.Text == _user.Password)
                {
                    currUserId = _user.UserId;
                    Dashboard._curr.UserId = _user.UserId;
                    Dashboard._curr.Username = _user.Username;
                    Dashboard._curr.Password = _user.Password;
                    Dashboard._curr.UserType = _user.UserType;
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    lbStatus.Text = "Invalid Login: "+$"{--Program.count} tries remaining...";
                    this.DialogResult = DialogResult.None;
                }

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Program.count = 0;
            this.DialogResult = DialogResult.Abort;
        }
    }
}
