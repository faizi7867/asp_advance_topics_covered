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
    public partial class DataSetComplete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string scn = ConfigurationManager.ConnectionStrings["dbconnect"].ConnectionString;
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            SqlConnection conn = new SqlConnection(scn);
            SqlCommand cmd = new SqlCommand("ListPatients", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            da.SelectCommand = cmd;
            da.Fill(ds);

            DataTable dt1 = ds.Tables[0];
            DataRow dr1 = dt1.Rows[0];
            Response.Output.WriteLine(dr1[0]);
            Response.Output.WriteLine(dr1[1]);
            Response.Output.WriteLine(dr1[2]);
            Response.Output.WriteLine(dr1[3]);
            Response.Output.WriteLine(dr1[4]);
        }
    }
}