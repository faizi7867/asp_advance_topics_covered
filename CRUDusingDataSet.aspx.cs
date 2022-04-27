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
    public partial class WebForm1 : System.Web.UI.Page
    {
        string scn = ConfigurationManager.ConnectionStrings["dbconnect"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetDataIntoDataSet();
            }
        }
        private void GetDataIntoDataSet()
        {
            using (SqlConnection conn = new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("ListStudents", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    DataSet ds = new DataSet();
                    using (SqlDataAdapter da = new SqlDataAdapter())
                    {
                        da.SelectCommand = cmd;
                        da.Fill(ds);
                        gvstudents.DataSource = ds;
                        gvstudents.DataBind();
                        Session["ds"] = ds;
                    }
                }
            }
        }

        protected void btnaddinds_Click(object sender, EventArgs e)
        {
            DataSet ds = Session["ds"] as DataSet;
            DataTable dt = ds.Tables[0];

            DataRow dr =   dt.NewRow();
            dr["sid"] = Convert.ToInt32(tbsid.Text);
            dr["fname"] = tbfname.Text.ToString();
            dr["lname"] = tblname.Text.ToString();
            dr["class"] = tbclass.Text.ToString();
            dt.Rows.Add(dr);

            Session["ds"] = ds;
            gvstudents.DataSource = ds;
            gvstudents.DataBind();

        }

        protected void btnupdateinds_Click(object sender, EventArgs e)
        {
            DataSet ds = Session["ds"] as DataSet;
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                if (dr.RowState != DataRowState.Deleted)
                {
                    int sid = Convert.ToInt32(tbsid.Text);
                    if (sid == (int)dr["sid"])
                    {
                        dr["fname"] = tbfname.Text.ToString();
                        dr["lname"] = tblname.Text.ToString();
                        dr["class"] = tbclass.Text.ToString();

                        gvstudents.DataSource = ds;
                        gvstudents.DataBind();
                        Session["ds"] = ds;
                        break;
                    }
                    else
                    {
                        tbfname.Text = "Data update failed";
                        tblname.Text = " ";
                        tbclass.Text = " ";
                    }
                }
            }
        }

        protected void btnfind_Click(object sender, EventArgs e)
        {
            DataSet ds = Session["ds"] as DataSet;
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                if (dr.RowState != DataRowState.Deleted)
                {
                    int sid = Convert.ToInt32(tbsid.Text);
                    if (sid == (int)dr["sid"])
                    {
                        tbfname.Text = dr["fname"].ToString();
                        tblname.Text = dr["lname"].ToString();
                        tbclass.Text = dr["class"].ToString()
                            ;
                        break;
                    }
                    else
                    {
                        tbfname.Text = "No record found";
                        tblname.Text = " ";
                        tbclass.Text = " ";
                    }
                }
            }
        }

        protected void btndeleteinds_Click(object sender, EventArgs e)
        {
            DataSet ds = Session["ds"] as DataSet;
            DataTable dt = ds.Tables[0];
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                if (dr.RowState != DataRowState.Deleted)
                {
                    int sid = Convert.ToInt32(tbsid.Text);
                    if (sid == (int)dr["sid"])
                    {
                        dr.Delete();
                        Session["ds"] = ds;
                        gvstudents.DataSource = ds;
                        gvstudents.DataBind();
                        break;
                    }
                    else
                    {
                        tbfname.Text = "No data found to delete";
                        tblname.Text = " ";
                        tbclass.Text = " ";
                    }
                }
            }
        }

        protected void AddinDB_Click(object sender, EventArgs e)
        {

            using (SqlConnection cn = new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("InsertStudent", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter s_sid = cmd.Parameters.Add("@sid", SqlDbType.Int);
                    SqlParameter s_fname = cmd.Parameters.Add("@fname", SqlDbType.VarChar, 50);
                    SqlParameter s_lname = cmd.Parameters.Add("@lname", SqlDbType.VarChar, 50);
                    SqlParameter s_class = cmd.Parameters.Add("@class", SqlDbType.VarChar, 20);
                    s_sid.SourceColumn = "sid";
                    s_fname.SourceColumn = "fname";
                    s_lname.SourceColumn = "lname";
                    s_class.SourceColumn = "class";
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = Session["ds"] as DataSet;
                    DataTable dt = ds.Tables[0];
                    da.InsertCommand = cmd;

                    int cnt = da.Update(dt);
                    if (cnt != 0)
                    {
                        tbsid.Text = "Data Updated In DataBase";
                    }

                }
            }
        }

        protected void updateinDB_Click(object sender, EventArgs e)
        {
            
            using (SqlConnection cn  =new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("UpdateStudent", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter s_sid = cmd.Parameters.Add("@sid", SqlDbType.Int);
                    SqlParameter s_fname = cmd.Parameters.Add("@fname", SqlDbType.VarChar,50);
                    SqlParameter s_lname = cmd.Parameters.Add("@lname", SqlDbType.VarChar,50);
                    SqlParameter s_class = cmd.Parameters.Add("@class", SqlDbType.VarChar,20);
                    s_sid.SourceColumn = "sid";
                    s_fname.SourceColumn = "fname";
                    s_lname.SourceColumn = "lname";
                    s_class.SourceColumn = "class";
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = Session["ds"] as DataSet;
                    DataTable dt = ds.Tables[0];
                    da.UpdateCommand = cmd;
                    int cnt = da.Update(dt);
                    if (cnt!=0)
                    {
                        tbsid.Text = "Data Updated In DataBase";
                    }

                }
            }
        }

        protected void deleteinBD_Click(object sender, EventArgs e)
        {
            using (SqlConnection cn = new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("DeleteStudent", cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter s_sid = cmd.Parameters.Add("@sid", SqlDbType.Int);
                    s_sid.SourceColumn = "sid";
                    SqlDataAdapter da = new SqlDataAdapter();
                    DataSet ds = Session["ds"] as DataSet;
                    DataTable dt = ds.Tables[0];
                    da.DeleteCommand = cmd;
                    int cnt = da.Update(dt);
                    if (cnt != 0)
                    {
                        tbsid.Text = "Data Updated In DataBase";
                    }

                }
            }
        }
    }
}