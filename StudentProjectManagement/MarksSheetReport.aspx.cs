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
    public partial class MarksSheetReport : System.Web.UI.Page
    {
        readonly SqlConnection conn = new SqlConnection(@"Data Source=LAPTOP-82ANPR0U;Initial Catalog=ProjectDB;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT pro.name,g.s1,g.s2,g.s3,g.s4 ,e.totalMarks,e.obtainedMarks from Project pro LEFT JOIN ProjectGroup g ON pro.ProjectId=g.ProjectId LEFT JOIN Evaluation e ON g.GId=e.GId";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            GridView1.DataSource = dt;


            GridView1.DataBind();
        }
    }
}