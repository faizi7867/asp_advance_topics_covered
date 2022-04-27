using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EmployeeMgmt
{
    public partial class ListEmpUsingSP : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string scn = ConfigurationManager.ConnectionStrings["dbconnect"].ConnectionString;
            using (SqlConnection cn = new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("ListEmployees", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    SqlDataReader dr =  cmd.ExecuteReader();
                    List<Employee> EmployeeFactory = new List<Employee>();
                    while (dr.Read())
                    {
                        Employee e1 = new Employee();
                        e1.Eid = Convert.ToInt32(dr["eid"]);
                        e1.Fname = dr["fname"].ToString();
                        e1.Lname = dr["lname"].ToString();
                        e1.Doj = dr["dob"].ToString();
                        e1.Salary = Convert.ToInt32(dr["salary"]);
                        EmployeeFactory.Add(e1);
                    }
                    dr.Close();
                    listemps.DataSource = EmployeeFactory;
                    listemps.DataBind();

                    cn.Close();
                }
            }

        }
    }
}