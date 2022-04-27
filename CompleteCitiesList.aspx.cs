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
    public partial class CompleteCitiesList : System.Web.UI.Page
    {
        string scn = ConfigurationManager.ConnectionStrings["dbconnect"].ConnectionString; 
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                List<string> countries = new List<string>();

                using (SqlConnection cn = new SqlConnection(scn))
                {
                    using (SqlCommand cmd = new SqlCommand("GetCtryList", cn))
                    {
                        cn.Open();
                        SqlDataReader dr = cmd.ExecuteReader();
                        while (dr.Read())
                        {
                            string country = dr["name"].ToString();
                            countries.Add(country);
                        }
                        dr.Close();

                    }
                }

                ddlcountries.DataSource = countries;
                ddlcountries.DataBind();
            }

        }
        public List<string> getStates(string name)
        {
            List<string> states = new List<string>();
            using (SqlConnection conn = new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("GetStatesList", conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter p1 = cmd.Parameters.Add("@cntryname", SqlDbType.VarChar,50);
                    p1.Value = name;
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        states.Add(dr["name"].ToString());
                    }

                    conn.Close();

                }
            }
            return states;

        }
        public List<string> getcities(string name)
        {
            List<string> states = new List<string>();
            using (SqlConnection conn = new SqlConnection(scn))
            {
                using (SqlCommand cmd = new SqlCommand("GetCitiesList", conn))
                {
                    conn.Open();
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter p1 = cmd.Parameters.Add("@state_name", SqlDbType.VarChar, 50);
                    p1.Value = name;
                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        states.Add(dr["name"].ToString());
                    }

                    conn.Close();

                }
            }
            return states;

        }

        protected void btnstates_Click(object sender, EventArgs e)
        {
            string countryname = ddlcountries.SelectedValue ?? "--select--";
            ddlstates.DataSource = getStates(countryname);
            ddlstates.DataBind();
        }

        protected void btncities_Click(object sender, EventArgs e)
        {
            string statename = ddlstates.SelectedValue ?? "--select--";
            ddlcities.DataSource = getcities(statename);
            ddlcities.DataBind();
        }
    }
}