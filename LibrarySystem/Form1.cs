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
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //User _user = _userRepo.GetUser(txtUsername.Text);
            User _user = new User();
            _user.UserId = 1;
            _user.Username = "Ab30657";            
            if (_user!= null)
            {
                Program.login = true;
                currUserId = _user.UserId;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
