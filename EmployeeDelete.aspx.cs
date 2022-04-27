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
    public partial class EmployeeDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            string connstring = ConfigurationManager.ConnectionStrings["dbconnect"].ConnectionString;
            string querydelete = $"delete from employees where eid = {Convert.ToInt32(tbeid.Text)}";
            using (SqlConnection conn = new SqlConnection(connstring))
            {
                using (SqlCommand cmd = new SqlCommand(querydelete,conn))
                {
                    try
                    {
                        conn.Open();
                        int cnt = cmd.ExecuteNonQuery();
                        if (cnt > 0)
                        {
                            Response.Output.Write("Data deleted sucessfully");
                        }
                        else
                        {
                            Response.Output.Write($"No such data with Id {tbeid.Text}");
                        }
                    }
                    catch (SqlException ex)
                    {

                        Response.Output.Write(ex.Message);
                    }
                    finally
                    {
                        if (conn.State == System.Data.ConnectionState.Open)
                        {
                            conn.Close();
                        }
                    }
                }
            }
        }
    }
}