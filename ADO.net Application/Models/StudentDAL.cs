using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace ADO.net_Application.Models
{
    public class StudentDAL
    {

        string connectingString = ConfigurationManager.ConnectionStrings["StudentContext"].ConnectionString;

        public List<Student> Getstudent()
        {
            List<Student> students = new List<Student>();
            using (SqlConnection sc = new SqlConnection(connectingString))
            {
                SqlCommand cmd = new SqlCommand("select * from student", sc);
                sc.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    Student s = new Student()
                    {
                        Rollnumber = (int)dr["Rollnumber"],
                        Name = dr["Name"].ToString(),
                        Age = (int)dr["Age"],
                        Email = dr["Email"].ToString()
                    };
                    students.Add(s);
                }
                return students;
            }
        }
        public bool InsertStudent(Student student)
        {
            try
            {
             
                using (SqlConnection sc = new SqlConnection(connectingString))
                {
                    SqlCommand cmd = new SqlCommand("Sp_INsertData", sc);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Name", student.Name);
                    cmd.Parameters.AddWithValue("@Age", student.Age);
                    cmd.Parameters.AddWithValue("@Email", student.Email);
                    sc.Open();
                    cmd.ExecuteNonQuery();
                    return true;


                }
            }
            catch
            {
                return false;
            }



        }
        public bool UpdateStudent( Student s)
        {
            using (SqlConnection sc=new SqlConnection(connectingString))
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateStudent", sc);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Rollnumber", s.Rollnumber);
                cmd.Parameters.AddWithValue("@Name", s.Name);
                cmd.Parameters.AddWithValue("@Age", s.Age);
                cmd.Parameters.AddWithValue("@Email", s.Email);
                sc.Open();
                cmd.ExecuteNonQuery();

                return true;



            }
        }
        public void DeleteStudent(int Rollnumber)
        {
            using (SqlConnection sc = new SqlConnection(connectingString))
            {
                SqlCommand cmd = new SqlCommand("Sp_DeleteStudent", sc);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Rollnumber", Rollnumber);
                sc.Open();
                cmd.ExecuteNonQuery();


            }
        }
    }
}
