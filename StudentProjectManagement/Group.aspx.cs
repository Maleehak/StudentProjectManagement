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
    public partial class Group : System.Web.UI.Page
    {
        readonly SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-82ANPR0U;Initial Catalog=ProjectDB;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                conn.Open();
                //adding Projects
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select ProjectId,name from Project";
                Projects.DataSource = cmd.ExecuteReader();
                Projects.DataTextField = "name";
                Projects.DataValueField = "ProjectId";
                Projects.DataBind();
                Projects.Items.Insert(0, new ListItem("--Select--", ""));
                Projects.Items[0].Selected = true;
                Projects.Items[0].Attributes["disabled"] = "disabled";
                conn.Close();

                //adding students
                conn.Open();
                SqlCommand cmd2 = conn.CreateCommand();
                cmd2.CommandType = CommandType.Text;
                cmd2.CommandText = "Select pid,pname from Person where CatId=2";
                Students.DataSource = cmd2.ExecuteReader();
                Students.DataTextField = "pname";
                Students.DataValueField = "pid";
                Students.DataBind();
                conn.Close();
                

            }


        }

        protected void Add_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            string groupNumber = GroupNum.Text;
            string projectID = Projects.SelectedItem.Value;
            //string of 4 students
            string[] studentsArray = new String[4];
            int index = 0;
            foreach (ListItem listItem in Students.Items)
            {
                if (listItem.Selected)
                {
                    var val = listItem.Text;
                    studentsArray[index] = val;
                    index++;
                }
            }
            cmd.CommandText = "insert into ProjectGroup(GNum,ProjectId,s1,s2,s3,s4) values ('" + groupNumber + "','" + projectID+ "','" + studentsArray[0]+ "','" + studentsArray[1] + "','" + studentsArray[2] + "','" + studentsArray[3] + "')";
            cmd.ExecuteNonQuery();
            conn.Close();


        }

        protected void Update_Click(object sender, EventArgs e)
        {
            string groupNumber = GroupNum.Text;
            string projectID = Projects.SelectedItem.Value;
            bool key1 = false, key2 = false;
            if (projectID != "") { key1 = true; }
            if (Students.SelectedIndex != -1) { key2 = true; }
            if (key1 && key2)
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                //string of 4 students
                string[] studentsArray = new String[4];
                int index = 0;
                foreach (ListItem listItem in Students.Items)
                {
                    if (listItem.Selected)
                    {
                        var val = listItem.Text;
                        studentsArray[index] = val;
                        index++;
                    }
                }
                cmd.CommandText = "update ProjectGroup set projectId= '" + projectID + "',s1='" + studentsArray[0] + "',s2='" + studentsArray[1] + "',s3='" + studentsArray[2] + "',s4='" + studentsArray[3] + "' where GNum='" + groupNumber + "' ";
                cmd.ExecuteNonQuery();
                conn.Close();


            }
            else if (key1)
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update ProjectGroup set projectId= '" + projectID + "' where GNum='" + groupNumber + "' ";
                cmd.ExecuteNonQuery();
                conn.Close();

            }
            else if (key2)
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                //string of 4 students
                string[] studentsArray = new String[4];
                int index = 0;
                foreach (ListItem listItem in Students.Items)
                {
                    if (listItem.Selected)
                    {
                        var val = listItem.Text;
                        studentsArray[index] = val;
                        index++;
                    }
                }
                cmd.CommandText = "update ProjectGroup set s1='" + studentsArray[0] + "',s2='" + studentsArray[1] + "',s3='" + studentsArray[2] + "',s4='" + studentsArray[3] + "' where GNum='" + groupNumber + "' ";
                cmd.ExecuteNonQuery();
                conn.Close();

            }

        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            string groupNumber = GroupNum.Text;
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from ProjectGroup where GNum='" +groupNumber + "'";
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            

        }
    }
}