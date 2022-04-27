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
    public partial class MARS : System.Web.UI.Page
    {
        string connstring = ConfigurationManager.ConnectionStrings["dbconnect"].ConnectionString;
        int stid = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnadd_Click1(object sender, EventArgs e)
        {

            using (SqlConnection cn = new SqlConnection(connstring))
            {
                using (SqlCommand cmd = new SqlCommand($"select country_id from states where name = '{tbstate.Text.ToString()}'", cn))
                {
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        stid = Convert.ToInt32(dr["country_id"]);
                    }
                    using (SqlCommand cmd1 = new SqlCommand($"select name from countries where id = {stid}", cn))
                    {
                        SqlDataReader dr2 = cmd1.ExecuteReader();
                        if (!dr2.HasRows)
                        {
                            tbcountry.Text = " ";
                        }
                        while (dr2.Read())
                        {
                            tbcountry.Text = dr2["name"].ToString();
                        }
                    }

                }
            }
            
        }
    }
}