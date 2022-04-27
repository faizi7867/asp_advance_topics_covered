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
    public partial class TransactionsComplete : System.Web.UI.Page
    {
        string scn = ConfigurationManager.ConnectionStrings["dbconnect"].ConnectionString;
        private class Account
        {
            public int AcNo { get; set; }
            public string Name { get; set; }
            public int Bal { get; set; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Account> acs = new List<Account>();
            using (SqlConnection cn = new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("GetAllAccounts", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Account a = new Account();
                        a.Name = dr["acname"].ToString();
                        a.AcNo = Convert.ToInt32(dr["acno"]);
                        a.Bal = Convert.ToInt32(dr["bal"]);
                        acs.Add(a);

                    }
                    dr.Close();
                }
                Session["acs"] = acs;
                gvaccounts.DataSource = acs;
                gvaccounts.DataBind();
                Response.Output.Write(gvaccounts.Rows[0].Cells[1].Text.ToString());
                Response.Output.Write(gvaccounts.Rows[1].Cells[1].Text.ToString());
                Response.Output.Write(gvaccounts.Rows[2].Cells[1].Text.ToString());
            }
        }

        protected void btntransfer_Click(object sender, EventArgs e)
        {
            int from = Convert.ToInt32(tbfrom.Text);
            int to = Convert.ToInt32(tbto.Text);
            int amount = Convert.ToInt32(tbamount.Text);
            SqlTransaction tr = null;
            string qry1 = $"update accounts set bal = bal + {amount} where acno = {to} ";
            string qry2 = $"update accounts set bal = bal - {amount} where acno = {from} ";
            using(SqlConnection cn = new SqlConnection(scn))
            {
                try
                {
                    cn.Open();
                    tr = cn.BeginTransaction();
                    SqlCommand cmd = new SqlCommand(qry1, cn);
                    cmd.Transaction = tr;
                    SqlCommand cmd2 = new SqlCommand(qry2, cn);
                    cmd2.Transaction = tr;
                    cmd.ExecuteNonQuery();
                    cmd.ExecuteNonQuery();
                    tr.Commit();
                }
                catch (SqlException ex)
                {
                    tr.Rollback();
                }

            }
            

         }
    }
}