using BLL.Migrations;
using BLL.Models;
using BLL.Repos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace LibrarySystem
{
    public partial class NewMember : Form
    {
        List<Student> students = new List<Student>();
        List<Card> cards = new List<Card>();
        Student student = new Student();
        public NewMember()
        {
            InitializeComponent();
            
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {

            Card card = new Card();
            using (StudentRepo rep = new StudentRepo())
            {

                student.HasCard = true;
                rep.Update(student);
            }
            student.FullName = cboStudent.SelectedItem.ToString();
            card.CardNum = txtCardNum.Text;
            card.IssueDate = DateTime.Parse(txtIssue.Text);
            card.ExpireDate = DateTime.Parse(txtExpire.Text);
            card.StudentId = (int)cboStudent.SelectedValue;
            using(CardRepo rep= new CardRepo())
            {
                rep.Add(card);
            }
            student.HasCard = true;
            using(StudentRepo rep= new StudentRepo())
            {
                rep.Update(student);
            }
            MessageBox.Show("Card Added Successfully!");
            LoadStudentData();
        }

        private void btnIssue_Leave(object sender, EventArgs e)
        {
            btnIssue.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void NewMember_Load(object sender, EventArgs e)
        {
            LoadStudentData();
        }

        private void LoadStudentData()
        {
            using (StudentRepo rep = new StudentRepo())
            {
                students = rep.GetAll();

            }
            using (CardRepo rep = new CardRepo())
            {
                cards = rep.GetAll();
            }

            cboStudent.DisplayMember = "FullName";
            cboStudent.ValueMember = "StudentId";
            cboStudent.DataSource = students;
            student.FullName = ((Student)cboStudent.SelectedItem).FullName ;
            student.Gender = ((Student)cboStudent.SelectedItem).Gender;
            student.StudentId = (int)cboStudent.SelectedValue;
            //
            txtIssue.ReadOnly = true;
            txtIssue.Text = DateTime.Now.ToShortDateString();
            txtExpire.ReadOnly = true;
            txtExpire.Text = DateTime.Now.AddYears(1).ToShortDateString();
            string code;
            if (cards.Count == 0)
            {
                code = "0";
            }
            else
            {
                code = cards.Last().CardNum.Substring(4);
            }
            txtCardNum.Text = "LIB-" + (int.Parse(code) + 1).ToString();
        }

        private void cboStudent_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
