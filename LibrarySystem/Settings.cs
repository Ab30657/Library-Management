using BLL.Models;
using BLL.Repos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LibrarySystem
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == Dashboard._curr.Password)
            {
                if (txtNew.Text == txtconfirm.Text)
                {
                    Dashboard._curr.Password = txtNew.Text; 
                    using(UserRepo rep= new UserRepo())
                    {
                        rep.Update(Dashboard._curr);
                    }
                    MessageBox.Show("Password changed successfully!");
                    textBox1.Text = "";
                    txtconfirm.Text = "";
                    txtNew.Text = "";
                }
            }
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
