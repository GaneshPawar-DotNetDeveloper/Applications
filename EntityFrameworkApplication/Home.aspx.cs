using EntityFrameworkApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EntityFrameworkApplication
{
    public partial class Home : System.Web.UI.Page
    {
        ABCD db=new ABCD();
        protected void Page_Load(object sender, EventArgs e)
        {
            pageLoad();
           clearMethod();
        }

        public void pageLoad()
        {
            List<student> student= db.students.ToList();
            gdview.DataSource = student;
            gdview.DataBind();
        }
      private void clearMethod()
        {
            
            txtRollnumber.Text = string.Empty;
            txtName.Text = string.Empty;
            txtAge.Text = string.Empty;
            txtEmail.Text = string.Empty;
               
        }
       

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
               /*int age;
                if(int.TryParse(txtAge.Text, out age))
                {
                    lbltext.Text = age.ToString();
                }
                else
                {
                    lbltext.Text = "Invalid input";
                }*/

                student sc = new student()
                {
                    Name = txtName.Text,
                   Age = int.Parse(string.IsNullOrEmpty(txtAge.Text.ToString()) ? "0" : txtAge.Text.ToString()) ,

                  // Age = age,
                    Email = txtEmail.Text
                };
                try
                {
                
                    db.students.Add(sc);
                    db.SaveChanges();
                    pageLoad();
                    clearMethod();
                    lbltext.Text = "Student ctrated successfully";
                }
                catch
                {
                    lbltext.Text = "student creation Failed";
                }
                
            }
            else
            {
                lbltext.Text = "please correct your Input";
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            student sc = new student()
            {
                Rollnumber = Convert.ToInt32(txtRollnumber.Text),
                Name = txtName.Text,
                Age = Convert.ToInt32(txtAge.Text),
                Email = txtEmail.Text
            };
            try
            {
               var ExistingSting=  db.students.FirstOrDefault(s => s.Rollnumber == sc.Rollnumber);
                ExistingSting.Name = sc.Name;
                ExistingSting.Age = sc.Age;
                ExistingSting.Email = sc.Email;
                db.SaveChanges();
                pageLoad();
                clearMethod();
                lbltext.Text = "Student Update Successfully";

            }
            catch
            {
                lbltext.Text = "Student update Failed";
            }

           
        }
       

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            int rollnumber = Convert.ToInt32(txtRollnumber.Text);

            try
            {
                var student = db.students.FirstOrDefault(s => s.Rollnumber == rollnumber);
                db.students.Remove(student);
                pageLoad();
                lbltext.Text = "student deleted successfully";

            }
            catch
            {
                lbltext.Text = "student delete Failed";

            }

        }
      


        protected void cleartext_Click(object sender, EventArgs e)
        {
            clearMethod();
        }

        protected void btnLoads_Click(object sender, EventArgs e)
        {
            int rollnumber = Convert.ToInt32(txtRollnumber.Text);
            student sc = db.students.FirstOrDefault(s => s.Rollnumber == rollnumber);

            if (sc != null)
            {
                txtName.Text = sc.Name;
                txtAge.Text = sc.Age.ToString();
                txtEmail.Text = sc.Email;
                lbltext.Text = "Student Load Successully";

            }
            else
            {
                lbltext.Text = "Student Load faild";
            }
        }
    }
}