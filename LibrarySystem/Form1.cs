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
using BLL.Repos;

namespace LibrarySystem
{
    public partial class Form1 : Form
    {
        private UserRepo _user = new UserRepo(new LibraryContext()); 
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_user.GetOne(txtUsername.Text)==null)
            {
                //Create an alert that login failed
            }
        }
    }
}
