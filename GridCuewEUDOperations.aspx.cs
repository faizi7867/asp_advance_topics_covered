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
    public partial class GridCuewEUDOperations : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        string scn = ConfigurationManager.ConnectionStrings["dbconnect"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getData();
            }

        }

        public void getData()
        {
            using (SqlConnection cn = new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("select * from students", cn))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                        DataTable dt = ds.Tables[0];
                        gvstudents.DataSource = dt;
                        gvstudents.DataBind();
                        Session["ds"] = ds;
                    }

                }
            }
        }

        protected void gvstudents_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvstudents.EditIndex = e.NewEditIndex;
            DataSet ds = Session["ds"] as DataSet;
            DataTable dt = ds.Tables[0];
            gvstudents.DataSource = dt;
            gvstudents.DataBind();
        }

        protected void gvstudents_RowDeleted(object sender, GridViewDeletedEventArgs e)
        {

        }

        protected void gvstudents_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvstudents.EditIndex = -1;
            e.Cancel = true;
            DataSet ds = Session["ds"] as DataSet;
            DataTable dt = ds.Tables[0];
            gvstudents.DataSource = dt;
            gvstudents.DataBind();
        }

        protected void gvstudents_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow gvr = gvstudents.Rows[e.RowIndex];
            Label sid = gvr.FindControl("lblsid") as Label;
            TextBox fname = gvr.FindControl("txtfname") as TextBox;
            string fn = fname.Text;
            TextBox lname = gvr.FindControl("txtlname") as TextBox;
            string ln = lname.Text;

            TextBox sclass = gvr.FindControl("txtclass") as TextBox;
            string sc = sclass.Text;
            using (SqlConnection cn = new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("UpdateStudent", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter s_sid = cmd.Parameters.Add("@sid", SqlDbType.Int);
                    s_sid.Value = sid.Text;
                    SqlParameter s_fname = cmd.Parameters.Add("fname", SqlDbType.VarChar);
                    s_fname.Value = fn;
                    SqlParameter s_lnanme = cmd.Parameters.Add("lname", SqlDbType.VarChar);
                    s_lnanme.Value = ln;
                    SqlParameter s_class = cmd.Parameters.Add("class", SqlDbType.VarChar);
                    s_class.Value = sc;
                    cn.Open();
                    int cnt = cmd.ExecuteNonQuery();
                    cn.Close();
                    gvstudents.EditIndex = -1;
                    getData();
                }
            }


        }

        protected void gvstudents_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow gvr = gvstudents.Rows[e.RowIndex];
            Label sid = gvr.FindControl("lblsid") as Label;
            using (SqlConnection cn = new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteStudent", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter s_sid = cmd.Parameters.Add("@sid", SqlDbType.Int);
                    s_sid.Value = sid.Text;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                    cn.Close();
                    getData();

                }
            }
        }

        protected void gvstudents_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}