using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace StudentProjectManagement
{
    public partial class Student : System.Web.UI.Page
    {
        readonly SqlConnection conn = new SqlConnection(@"Data Source=HP-G3I5;Initial Catalog=ProjectDB;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            int StudentID = 2;
            string Sname = name.Text;
            string SregNum = regNum.Text;
            string Scontact = contact.Text;
            string Sdegree = degree.Text;
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Person(pname,contact,degree,regNum,CatId) values ('" + Sname + "','" + Scontact + "','" + Sdegree + "','" + SregNum + "','" + StudentID + "')";
            cmd.ExecuteNonQuery();
            Reset();
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            bool key1 = false, key2 = false, key3 = false;
            string Sname = name.Text;
            string SregNum = regNum.Text;
            string Scontact = contact.Text;
            string Sdegree = degree.Text;
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            if (SregNum != "") key1 = true;
            if (Scontact != "") key2 = true;
            if (Sdegree != "") key3 = true;

            if (key1 && key2 && key3)
            {
                //key1 key2 key3
                cmd.CommandText = "update Person set contact='" + Scontact + "',degree='" + Sdegree + "',regNum='" + SregNum + "' where pname='" + Sname + "' ";

            }
            else
            {
                if (key1)
                {
                    if (key2)
                    {
                        //key1 key2
                        cmd.CommandText = "update Person set contact='" + Scontact + "',regNum='" + SregNum + "' where pname='" + Sname + "' ";
                    }
                    else if (key3)
                    {
                        //key1 key3
                        cmd.CommandText = "update Person set degree='" + Sdegree + "',regNum='" + SregNum + "' where pname='" + Sname + "' ";
                    }
                    else
                    {
                        //key1 
                        cmd.CommandText = "update Person set regNum='" + SregNum + "' where pname='" + Sname + "' ";

                    }
                }
                else if (key2)
                {
                    if (key3)
                    {
                        //key2 key3
                        cmd.CommandText = "update Person set contact='" + Scontact + "',degree='" + Sdegree + "' where pname='" + Sname + "' ";
                    }
                    else
                    {
                        //key2 
                        cmd.CommandText = "update Person set contact='" + Scontact + "' where pname='" + Sname + "' ";
                    }
                }
                else if (key3)
                {
                    //key3
                    cmd.CommandText = "update Person set degree='" + Sdegree + "' where pname='" + Sname + "' ";
                }

            }


            cmd.ExecuteNonQuery();
           Reset();
        }

        protected void Delete_Click(object sender, EventArgs e)
        {

        }
        protected void Reset()
        {
            name.Text = "";
            regNum.Text = "";
            degree.Text = "";
            contact.Text = "";
        }
    }
}