﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;

namespace mini_project.user
{
    public partial class pnr1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["name"] == null)
            {
                Response.Redirect("../login.aspx");

            }
            Label1.Text = "";
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string cs = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            SqlConnection con = new SqlConnection(cs);
            string user = TextBox1.Text;

            con.Open();
            string query = "select PNR from TICKETBOOKING where PNR='" + user + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            try
            {
                SqlDataReader sdr = cmd.ExecuteReader();



                if (sdr.Read())
                {
                    GridView1.Visible = true;

                }
                else
                {
                    Label1.Text = "sorrry enter PNR is not matched please try again";
                }
                con.Close();
            }
            catch (SqlException ex)
            {

                Label1.Text = "sorrry enter PNR is not matched please try again";
            }

        }
    }
}