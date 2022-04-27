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
    public partial class EmpUpdateusingSp : System.Web.UI.Page
    {
        string scn = ConfigurationManager.ConnectionStrings["dbconnect"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnfind_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("selectOnId", cn))
                {
                    cn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter emp_eid = cmd.Parameters.Add("@eid", SqlDbType.Int);
                    emp_eid.Value = Convert.ToInt32( tbeid.Text);
                    SqlDataReader dr =  cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        tbfname.Text = dr["fname"].ToString();
                        tblname.Text = dr["lname"].ToString();
                        tbdoj.Text = dr["dob"].ToString();
                        tbsal.Text = dr["salary"].ToString();
                    }
                    dr.Close();
                }
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("UpdateEmployees", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();

                    SqlParameter emp_id = cmd.Parameters.Add("@eid", SqlDbType.Int);
                    emp_id.Value = Convert.ToInt32(tbeid.Text);

                    SqlParameter emp_fname = cmd.Parameters.Add("@fname", SqlDbType.VarChar);
                    emp_fname.Value = tbfname.Text.ToString();

                    SqlParameter emp_lname = cmd.Parameters.Add("@lname", SqlDbType.VarChar);
                    emp_lname.Value = tblname.Text.ToString();

                    SqlParameter emp_doj = cmd.Parameters.Add("@doj", SqlDbType.VarChar);
                    emp_doj.Value = tbdoj.Text.ToString(); ;

                    SqlParameter emp_salary = cmd.Parameters.Add("@salary", SqlDbType.Int);
                    emp_salary.Value = Convert.ToInt32(tbsal.Text);

                    int cnt = cmd.ExecuteNonQuery();
                    if (cnt > 0)
                    {
                        Response.Output.Write($"{Convert.ToInt32(tbeid.Text)} updated");
                    }
                    else
                    {
                        Response.Output.Write($"details with empid {Convert.ToInt32(tbeid.Text)} not found ");
                    }


                }
            }
        }
    }
}