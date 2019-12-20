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
    public partial class Advisor : System.Web.UI.Page
    {
        readonly SqlConnection conn = new SqlConnection(@"Data Source=HP-G3I5;Initial Catalog=ProjectDB;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn.Open();
            DisplayData();

        }

        protected void Add_Click(object sender, EventArgs e)
        {
            conn.Open();
            int AdvisorID = 1;
            string Aname = name.Text;
            string Arank = rank.Text;
            string Acontact = contact.Text;
            string Adesignation = designation.Text;
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Person(pname,contact,designation,rank,CatId) values ('" + Aname + "','" + Acontact + "','" + Adesignation + "','" + Arank + "','" + AdvisorID + "')";
            cmd.ExecuteNonQuery();
            Reset();
            DisplayData();

        }

        protected void Update_Click(object sender, EventArgs e)
        {
            conn.Open();
            bool key1 = false, key2 = false, key3 = false;
            string Aname = name.Text;
            string Arank = rank.Text;
            string Acontact = contact.Text;
            string Adesignation = designation.Text;
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            if (Arank != "") key1 = true;
            if (Acontact != "") key2 = true;
            if (Adesignation != "") key3 = true;

            if (key1 && key2 && key3)
            {
                //key1 key2 key3
                cmd.CommandText = "update Person set contact='" + Acontact + "',designation='" + Adesignation + "',rank='" + Arank + "' where pname='" + Aname + "' ";

            }
            else
            {
                if (key1)
                {
                    if (key2)
                    {
                        //key1 key2
                        cmd.CommandText = "update Person set contact='" + Acontact + "',rank='" + Arank + "' where pname='" + Aname + "' ";
                    }
                    else if (key3)
                    {
                        //key1 key3
                        cmd.CommandText = "update Person set designation='" + Adesignation + "',rank='" + Arank + "' where pname='" + Aname + "' ";
                    }
                    else
                    {
                        //key1 
                        cmd.CommandText = "update Person set rank='" + Arank + "' where pname='" + Aname + "' ";

                    }
                }
                else if (key2)
                {
                    if (key3)
                    {
                        //key2 key3
                        cmd.CommandText = "update Person set contact='" + Acontact + "',designation='" + Adesignation + "' where pname='" + Aname + "' ";
                    }
                    else
                    {
                        //key2 
                        cmd.CommandText = "update Person set contact='" + Acontact + "' where pname='" + Aname + "' ";
                    }
                }
                else if (key3)
                {
                    //key3
                    cmd.CommandText = "update Person set designation='" + Adesignation + "' where pname='" + Aname + "' ";
                }

            }


            cmd.ExecuteNonQuery();
            Reset();
            DisplayData();
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            conn.Open();
            string Aname = name.Text;
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Person where pname='" + Aname + "'";
            cmd.ExecuteNonQuery();
            Reset();
            DisplayData();
           
        }
        protected void Reset()
        {
            name.Text = "";
            rank.Text = "";
            designation.Text = "";
            contact.Text = "";
        }
        public void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
        public void DisplayData()
        {
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select pname,contact,designation,rank from Person where CatId=1";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            GridView2.DataSource = dt;
            GridView2.DataBind();
            conn.Close();
        }
        }
    }