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
    public class Patients
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Bg { get; set; }
    }
    public partial class PatientWithBloodgroups : System.Web.UI.Page
    {
        string scn = ConfigurationManager.ConnectionStrings["dbconnect"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                List<int> ages = new List<int>();
                for (int i = 1; i < 111; i++)
                {
                    ages.Add(i);
                }
                ddlage.DataSource = ages;
                ddlage.DataBind();
                List<string> bgs = new List<string>();
                using (SqlConnection conn = new SqlConnection(scn))
                {
                    using (SqlCommand cmd = new SqlCommand("getallbgs", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        try
                        {
                            conn.Open();
                            SqlDataReader dr = cmd.ExecuteReader();
                            while (dr.Read())
                            {
                                bgs.Add(dr["name"].ToString());
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
                ddlbg.DataSource = bgs;
                ddlbg.DataBind();

            }
        }

        protected void btnfind_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("getpatientbyid", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter p_id = cmd.Parameters.Add("@patid", SqlDbType.Int);
                    p_id.Value = Convert.ToInt32(tbpatid.Text);

                    try
                    {
                        conn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        if (!dr.HasRows)
                        {
                            Response.Output.Write("no such date found");
                            tbpatname.Text = " ";
                            ddlage.SelectedValue = "1";
                            ddlbg.SelectedValue = "O+ve";
                        }
                        while (dr.Read())
                        {
                            tbpatname.Text = dr["name"].ToString();
                            ddlage.SelectedValue = dr["age"].ToString();
                            ddlbg.SelectedValue = dr["bgname"].ToString();
                        }

                        dr.Close();
                    }
                    catch (SqlException ex)
                    {
                        Response.Output.Write(ex.Message);
                    }
                }
            }
        }

        protected void btnadd_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("InsertPatient", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter p_id = cmd.Parameters.Add("@pid", SqlDbType.Int);
                    p_id.Value = Convert.ToInt32(tbpatid.Text);

                    SqlParameter p_name = cmd.Parameters.Add("@name", SqlDbType.VarChar, 50);
                    p_name.Value = tbpatname.Text.ToString();

                    SqlParameter p_age = cmd.Parameters.Add("@age", SqlDbType.Int);
                    p_age.Value = Convert.ToInt32(ddlage.SelectedValue);

                    SqlParameter p_bg = cmd.Parameters.Add("@bg", SqlDbType.VarChar, 20);
                    p_bg.Value = ddlbg.SelectedValue.ToString();


                    try
                    {
                        conn.Open();
                        int cnt = cmd.ExecuteNonQuery();
                        if (cnt > 0)
                        {
                            Response.Output.Write("Data inserted sucessfully");
                        }
                        else
                        {
                            Response.Output.Write("please check your code once");
                        }

                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
        }

        protected void btnupdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("UpdatePatient", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter p_id = cmd.Parameters.Add("@pid", SqlDbType.Int);
                    p_id.Value = Convert.ToInt32(tbpatid.Text);

                    SqlParameter p_name = cmd.Parameters.Add("@name", SqlDbType.VarChar, 50);
                    p_name.Value = tbpatname.Text.ToString();

                    SqlParameter p_age = cmd.Parameters.Add("@age", SqlDbType.Int);
                    p_age.Value = Convert.ToInt32(ddlage.SelectedValue);

                    SqlParameter p_bg = cmd.Parameters.Add("@bg", SqlDbType.VarChar, 20);
                    p_bg.Value = ddlbg.SelectedValue.ToString();


                    try
                    {
                        conn.Open();
                        int cnt = cmd.ExecuteNonQuery();
                        if (cnt > 0)
                        {
                            Response.Output.Write("Data update sucessfully");
                        }
                        else
                        {
                            Response.Output.Write("please check your code once");
                        }

                    }
                    catch (SqlException ex)
                    {

                        Response.Output.Write(ex.Message);
                    }
                }
            }

        }

        protected void btndelete_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("DeletePatient", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter p_id = cmd.Parameters.Add("@patind", SqlDbType.Int);
                    p_id.Value = Convert.ToInt32(tbpatid.Text);
                    try
                    {
                        conn.Open();
                        int cnt = cmd.ExecuteNonQuery();
                        if (cnt > 0)
                        {
                            Response.Output.Write("data deleted sucessfuly!");
                        }

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

        protected void btnlistallpatients_Click(object sender, EventArgs e)
        {
            gridpatients.Visible = true;
            List<Patients> PatientFactory = new List<Patients>();
            using (SqlConnection conn = new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("ListPatients", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        conn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            Patients p = new Patients();
                            p.Id = Convert.ToInt32(dr["id"]);
                            p.Name = dr["name"].ToString();
                            p.Age = Convert.ToInt32(dr["age"]);
                            p.Bg = dr["bname"].ToString();
                            PatientFactory.Add(p);
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
            gridpatients.DataSource = PatientFactory;gridpatients.DataBind();
        }
    }
}