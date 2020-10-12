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
    public partial class Dashboard : Form
    {
        public static User _curr = new User();
        DateTime sessionStart = DateTime.Now;
        public Dashboard()
        {
            //_curr = GetUser(Form1.currUserId);       
            InitializeComponent();
            _curr.Username = "Ab30657";
            _curr.UserId = 1;
        }

        private User GetUser(int i)
        {
            UserRepo repo = new UserRepo();
            return repo.GetOne(i);
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lbUserName_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {            
            SetNavLine(sender as Button);
            pnlContainer.Controls.Clear();
        }

        private void SetNavLine(Button btn)
        {
            pnlNav.Height = btn.Height;
            pnlNav.Top = btn.Top;
            pnlNav.Left = btn.Left;
            btn.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void btnDashboard_Leave(object sender, EventArgs e)
        {
            btnDashboard.BackColor = Color.FromArgb(24, 30, 54);
        }

        private Form activeForm = null;

        private void openChildForm(Form childform)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childform;
            childform.TopLevel = false;
            childform.FormBorderStyle = FormBorderStyle.None;
            childform.Dock = DockStyle.Fill;
            pnlContainer.Controls.Add(childform);
            childform.BringToFront();
            childform.Show();
        }

        private void btnManageBook_Click(object sender, EventArgs e)
        {
            SetNavLine(sender as Button);
            openChildForm(new ManageBook());
        }

        private void btnManageBook_Leave(object sender, EventArgs e)
        {
            btnManageBook.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void pnlContainer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            _unameTop.Text = _curr.Username;
            timer1.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbLoginTime.Text = DateTime.Now.Subtract(sessionStart).ToString(@"mm\:ss");
        }
    }
}
