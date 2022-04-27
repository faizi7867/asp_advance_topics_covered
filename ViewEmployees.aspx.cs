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
    public class Employee
    {
        public int Eid { get; set; }
        public string Fname { get; set; }
        public string Lname{ get; set; }
        public string Doj{ get; set; }
        public int Salary { get; set; }

    }
    public partial class ViewEmployees : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connstring = ConfigurationManager.ConnectionStrings["dbconnect"].ConnectionString;
            string queryListAllEmployees = $"select * from employees";
            using (SqlConnection conn =  new SqlConnection(connstring))
            {
                using (SqlCommand cmd = new SqlCommand(queryListAllEmployees,conn))
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    List<Employee> el = new List<Employee>();
                    while (dr.Read())
                    {
                        Employee e1 = new Employee();
                        e1.Eid =Convert.ToInt32( dr["eid"]);
                        e1.Fname = dr["fname"].ToString();
                        e1.Lname = dr["lname"].ToString();
                        e1.Doj = dr["dob"].ToString();
                        e1.Salary =Convert.ToInt32( dr["salary"]);
                        el.Add(e1);

                    }
                    dr.Close();
                    gridemployees.DataSource = el;
                    gridemployees.DataBind();
                }
            } 
        }
    }
}
