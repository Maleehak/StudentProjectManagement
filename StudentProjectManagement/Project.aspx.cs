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
    public partial class Project : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-82ANPR0U;Initial Catalog=ProjectDB;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select pid,pname from Person where CatId=1";
            advisor.DataSource = cmd.ExecuteReader();
            advisor.DataTextField = "pname";
            advisor.DataValueField = "pid";
            advisor.DataBind();
            conn.Close();

        }

        protected void Add_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            string projectName = name.Text;
            string projectDescription = description.Text;
            string projectAdvisorID = advisor.SelectedItem.Value;
            cmd.CommandText = "insert into Project(name,description,pid) values ('" + projectName + "','" + projectDescription + "','" + projectAdvisorID + "')";
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            reset();

        }
        protected void reset()
        {
            name.Text = "";
            description.Text = "";
            //advisor.SelectedValue = "";
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            string projectName = name.Text;
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Project where name='" + projectName + "'";
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            reset();
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            //bool key1 = false, key2 = false;
            //string projectName = name.Text;
        }

    }
}