﻿using System;
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
        readonly SqlConnection conn = new SqlConnection(@"Data Source=HP-G3I5;Initial Catalog=ProjectDB;Integrated Security=True");
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
                cmd.CommandText = "Select pid,pname from Person where CatId=1";
                advisor.DataSource = cmd.ExecuteReader();
                advisor.DataTextField = "pname";
                advisor.DataValueField = "pid";
                advisor.DataBind();
                advisor.Items.Insert(0, new ListItem("--Select--", ""));
                advisor.Items[0].Selected = true;
                advisor.Items[0].Attributes["disabled"] = "disabled";
               
                conn.Close();
            }
            conn.Open();
            DisplayData();
        } 
        protected void Add_Click(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            string projectName = name.Text;
            string projectDescription = description.Text;
            string projectAdvisorID = advisor.SelectedItem.Value;
            cmd.CommandText = "insert into Project(name,description,pid) values ('" + projectName + "','" + projectDescription + "','" + projectAdvisorID + "')";
            cmd.ExecuteNonQuery();
            conn.Close();
            Reset();
            conn.Open();
            DisplayData();

        }
        protected void Reset()
        {
            name.Text = "";
            description.Text = "";
           // advisor.Items[0].Selected=true;
        }

        protected void Delete_Click(object sender, EventArgs e)
        {
            string projectName = name.Text;
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Project where name='" + projectName + "'";
            conn.Open();
            cmd.ExecuteNonQuery();
            DisplayData();
            conn.Close();
            Reset();
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            bool key1 = false, key2 = false;
            string projectName = name.Text;
            string projectDescrption = description.Text;
            string projectAdvisorID = advisor.Text;
            if (projectDescrption != "") { key1 = true; }
            if (projectAdvisorID != "") { key2 = true; }
            if(key1 && key2)
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                //string projectAdvisorID = advisor.SelectedItem.Value;
                cmd.CommandText = "update Project set pid= '" + projectAdvisorID + "',description= '" + projectDescrption + "' where name='" + projectName + "' ";
                cmd.ExecuteNonQuery();
                conn.Close();
                Reset();
            }
            else if (key1)
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Project set description= '" + projectDescrption + "' where name='" + projectName + "' ";
                cmd.ExecuteNonQuery();
                conn.Close();
                Reset();

            }
            else if (key2)
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "update Project set pid= '" + projectAdvisorID + "' where name='" + projectName + "' ";
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
            cmd.CommandText = "select* from Project";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            conn.Close();
        }

    }
}