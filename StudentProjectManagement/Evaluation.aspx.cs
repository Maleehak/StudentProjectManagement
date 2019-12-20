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
                cmd.CommandText = "Select GId,GNum from ProjectGroup";
                groupNum.DataSource = cmd.ExecuteReader();
                groupNum.DataTextField = "GNum";
                groupNum.DataValueField = "GId";
                groupNum.DataBind();
                groupNum.Items.Insert(0, new ListItem("--Select--", ""));
                groupNum.Items[0].Selected = true;
                groupNum.Items[0].Attributes["disabled"] = "disabled";
                conn.Close();
            }
            conn.Open();
            DisplayData();
        }

        protected void Add_Click(object sender, EventArgs e)
        {
            //conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            string TotalMarks = Tmarks.Text;
            string ObtainedMarks = Omarks.Text;
            string GroupID = groupNum.SelectedItem.Value;
            cmd.CommandText = "insert into Evaluation(totalMarks,obtainedMarks,GId) values ('" + TotalMarks + "','" + ObtainedMarks + "','" + GroupID + "')";
            cmd.ExecuteNonQuery();
            DisplayData();
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
            string GroupID = groupNum.SelectedItem.Value;
            cmd.CommandText = "delete from Evaluation where GId='" + GroupID + "'";
            conn.Open();
            cmd.ExecuteNonQuery();
            DisplayData();
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
                string GroupID = groupNum.SelectedItem.Value;
                cmd.CommandText = "update Evaluation set totalMarks= '" + TotalMarks + "',obtainedMarks= '" + ObtainedMarks + "' where GId='" + GroupID + "' ";
                cmd.ExecuteNonQuery();
                conn.Close();
                Reset();
            }
            else if (key1)
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                string GroupID = groupNum.SelectedItem.Value;
                cmd.CommandText = "update Evaluation set totalMarks= '" + TotalMarks + "' where GId='" + GroupID + "' ";
                cmd.ExecuteNonQuery();
                conn.Close();
                Reset();

            }
            else if (key2)
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                string GroupID = groupNum.SelectedItem.Value;
                cmd.CommandText = "update Evaluation set obtainedMarks= '" + ObtainedMarks + "' where GId='" + GroupID + "' ";
                cmd.ExecuteNonQuery();
                conn.Close();
                Reset();
            }
            conn.Open();
            DisplayData();
        }
        public void DisplayData()
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Evaluation";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }
    }
}