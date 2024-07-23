using ADO.net_Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ADO.net_Application
{
    public partial class StudentForm : System.Web.UI.Page
    {
        StudentDAL dal=new StudentDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AllStudent();
            }

        }

        public void AllStudent()
        {
            List<Student> student = dal.Getstudent();
            gdview.DataSource = student;
            gdview.DataBind();

        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
           Student student=new Student()
           {
               Name=txtName.Text,
               Age= Convert.ToInt32( txtAge.Text),
               Email=txtEmail.Text,
           };
          bool ststus=  dal.InsertStudent(student);
            if (ststus)
            {
                lbltext.Text = "student inserted successfully";
            }
            else
            {
                lbltext.Text = "Student Inserted Failed";
            }
            AllStudent();
            clearmethod();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            Student s=new Student()
            {
                Rollnumber=Convert.ToInt32(txtRollnumber.Text),
                Name = txtName.Text,
                Age = Convert.ToInt32(txtAge.Text),
                Email = txtEmail.Text
            };
           
            bool status = dal.UpdateStudent(s);
            if (status)
            {
                lbltext.Text = "student Update Sucessfully";
            }
            else
            {
                lbltext.Text = "student Update Failed";
            }
            AllStudent();
            clearmethod();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            /* int employeeId = Convert.ToInt32(GridView1.DataKeys[e.RowIndex].Values[0]);
             employeeDAL.DeleteEmployee(employeeId);
             BindGrid();*/
           /* Student st = new Student()
            {
                Rollnumber = Convert.ToInt32(txtRollnumber.Text)

            };
            dal.DeleteStudent();*/

            AllStudent();
            Button btn = (Button)sender;
            int Rollnumber = Convert.ToInt32(btn.CommandArgument);
            dal.DeleteStudent(Rollnumber);
            AllStudent();



        }

        protected void cleartext_Click(object sender, EventArgs e)
        {
            clearmethod();
        }
        public void clearmethod()
        {
            txtRollnumber.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtName.Text = string.Empty;
            txtAge.Text = string.Empty;
            lbltext.Text = string.Empty;
        }
    }
}