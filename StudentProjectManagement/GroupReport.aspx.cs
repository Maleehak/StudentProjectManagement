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
    public partial class GroupReport : System.Web.UI.Page
    {
        readonly SqlConnection conn = new SqlConnection(@"Data Source=HP-G3I5;Initial Catalog=ProjectDB;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT p.pname,p.rank,p.contact,p.designation,pro.name,pro.description,g.GNum,g.s1,g.s2,g.s3,g.s4 from Person p LEFT JOIN Project pro ON p.pid=pro.pid LEFT JOIN ProjectGroup g ON pro.ProjectId=g.ProjectId WHERE p.CatId=1";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            GridView1.DataSource = dt;


            GridView1.DataBind();

        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
        }
    }
}