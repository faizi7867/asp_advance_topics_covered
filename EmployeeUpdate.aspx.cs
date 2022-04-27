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
    public partial class EmployeeUpdate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnfetch_Click(object sender, EventArgs e)
        {
            string constring = ConfigurationManager.ConnectionStrings["dbconnect"].ConnectionString;
            string queryfind = $"select fname, lname,dob,salary from employees where eid = {Convert.ToInt32(tbeid.Text)}";
            using (SqlConnection conn = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand(queryfind, conn))
                {
                    try
                    {
                        conn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            tbfname.Text = dr["fname"].ToString();
                            tblname.Text = dr["lname"].ToString();
                            tbdoj.Text = dr["dob"].ToString();
                            tbsal.Text = dr["salary"].ToString();
                        }
                        dr.Close();

                    }
                    catch (SqlException ex)
                    {
                        Response.Output.Write(ex.Message);
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

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            string constring = ConfigurationManager.ConnectionStrings["dbconnect"].ConnectionString;
            string queryupdate = $"update employees set fname = '{tbfname.Text.ToString()}', " +
                $"lname = '{tblname.Text.ToString()}', dob = '{tbdoj.Text.ToString()}',salary = {Convert.ToInt32(tbsal.Text)} where eid ={Convert.ToInt32(tbeid.Text)}";
            using (SqlConnection conn = new SqlConnection(constring))
            {
                using (SqlCommand cmd = new SqlCommand(queryupdate, conn))
                {
                    try
                    {
                        conn.Open();
                        int cnt = cmd.ExecuteNonQuery();
                        if (cnt>0)
                        {
                            Response.Output.Write("data updated sucessfully");
                        }
                    }
                    finally
                    {
                        if (conn.State== ConnectionState.Open)
                        {
                            conn.Close();
                        }
                    }
                }
            }
        }
                    
    }
}