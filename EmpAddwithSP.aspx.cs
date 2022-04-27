using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeMgmt
{
    public partial class EmpAddwithSP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            string cns = ConfigurationManager.ConnectionStrings["dbconnect"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(cns))
            {
                using (SqlCommand cmd = new SqlCommand("InsertEmployees", conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter emp_id = cmd.Parameters.Add("@eid",SqlDbType.Int);
                    emp_id.Value =Convert.ToInt32( tbeid.Text);

                    SqlParameter emp_fname = cmd.Parameters.Add("@fname",SqlDbType.VarChar);
                    emp_fname.Value = tbfname.Text.ToString();

                    SqlParameter emp_lname = cmd.Parameters.Add("@lname",SqlDbType.VarChar);
                    emp_lname.Value = tblname.Text.ToString();

                    SqlParameter emp_doj = cmd.Parameters.Add("@doj",SqlDbType.VarChar);
                    emp_doj.Value = tbdoj.Text.ToString(); ;

                    SqlParameter emp_salary = cmd.Parameters.Add("@salary",SqlDbType.Int);
                    emp_salary.Value = Convert.ToInt32(tbsal.Text);

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