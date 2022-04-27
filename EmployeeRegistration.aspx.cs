using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeMgmt
{
    public partial class EmployeeRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void tbregister_Click(object sender, EventArgs e)
        {
            string connstring = ConfigurationManager.ConnectionStrings["dbconnect"].ConnectionString;
            string insertQuery = $"insert into employees values({Convert.ToInt32( tbeid.Text)},'{tbfname.Text.ToString()}'" +
                $",'{tblname.Text.ToString()}','{tbdoj.Text.ToString()}',{Convert.ToInt32(tbsal.Text)} )";
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                using(SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    conn.Open();
                    int cnt = cmd.ExecuteNonQuery();
                    if (cnt > 0)
                    {
                        Response.Output.Write("Data inserted successfully");
                    }
                }
            }
        }
    }
}