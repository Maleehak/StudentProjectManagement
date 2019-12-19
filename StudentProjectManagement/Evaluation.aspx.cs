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
    public partial class Evaluation : System.Web.UI.Page
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
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select GNum from ProjectGroup";
                groupNum.DataSource = cmd.ExecuteReader();
                groupNum.DataTextField = "GNum";
                //advisor.DataValueField = "pid";
                groupNum.DataBind();
                groupNum.Items.Insert(0, new ListItem("--Select--", ""));
                groupNum.Items[0].Selected = true;
                groupNum.Items[0].Attributes["disabled"] = "disabled";
                conn.Close();
            }
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            string TotalMarks = Tmarks.Text;
            string ObtainedMarks = Omarks.Text;
            string GroupNumber = groupNum.SelectedItem.Value;
            cmd.CommandText = "insert into Evaluation(totalMarks,obtainedMarks,groupNum) values ('" + TotalMarks + "','" + ObtainedMarks + "','" + GroupNumber + "')";
            cmd.ExecuteNonQuery();
            conn.Close();
            Reset();
        }
        protected void Reset()
        {
            Tmarks.Text = "";
            Omarks.Text = "";
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            string GroupNumber = groupNum.SelectedItem.Value;
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Evaluation where groupNum='" + GroupNumber + "'";
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            Reset();
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            bool key1 = false, key2 = false;
            string TotalMarks = Tmarks.Text;
            string ObtainedMarks = Omarks.Text;
            string GroupNumber = groupNum.SelectedItem.Value;
            if (TotalMarks != "") { key1 = true; }
            if (ObtainedMarks != "") { key2 = true; }
            if (key1 && key2)
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                //string projectAdvisorID = advisor.SelectedItem.Value;
                cmd.CommandText = "update Evaluation set totalMarks= '" + TotalMarks + "',obtainedMarks= '" + ObtainedMarks + "' where groupNum='" + GroupNumber + "' ";
                cmd.ExecuteNonQuery();
                conn.Close();
                Reset();
            }
            else if (key1)
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Evaluation set totalMarks= '" + TotalMarks + "' where groupNum='" + GroupNumber + "' ";
                cmd.ExecuteNonQuery();
                conn.Close();
                Reset();

            }
            else if (key2)
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Evaluation set obtainedMarks= '" + ObtainedMarks + "' where groupNum='" + GroupNumber + "' ";
                cmd.ExecuteNonQuery();
                conn.Close();
                Reset();
            }
        }
    }
}