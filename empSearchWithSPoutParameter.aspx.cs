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
    public partial class empSearchWithSPoutParameter : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnfind_Click(object sender, EventArgs e)
        {
            string scn = ConfigurationManager.ConnectionStrings["dbconnect"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(scn) )
            {
                using (SqlCommand cmd = new SqlCommand("SeaechEmployee", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlParameter emp_eid = cmd.Parameters.Add("@eid", SqlDbType.Int);
                    emp_eid.Value = Convert.ToInt32(tbeid.Text);

                    SqlParameter emp_fname = cmd.Parameters.Add("@fname", SqlDbType.VarChar, 40);

                    emp_fname.Direction = ParameterDirection.Output;

                    SqlParameter emp_lname = cmd.Parameters.Add("@lname", SqlDbType.VarChar, 40);
                    emp_lname.Direction = ParameterDirection.Output; 

                    SqlParameter emp_doj = cmd.Parameters.Add("@doj", SqlDbType.VarChar, 40);
                    emp_doj.Direction = ParameterDirection.Output;

                    SqlParameter emp_salary = cmd.Parameters.Add("@salary", SqlDbType.Int);
                    emp_salary.Direction = ParameterDirection.Output;
                    try
                    {
                        conn.Open();
                        cmd.ExecuteReader();
                        tbfname.Text = emp_fname.Value.ToString();
                        tblname.Text = emp_lname.Value.ToString();
                        tbdoj.Text = emp_doj.Value.ToString();
                        tbsal.Text = emp_salary.Value.ToString();

                    }
                    catch (SqlException ex)
                    {

                        Console.WriteLine(ex.Message);
                    }
                    finally
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }
                    }
                }
            }
        }
    }
}