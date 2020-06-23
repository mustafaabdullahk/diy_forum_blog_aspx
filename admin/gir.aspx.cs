using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class admin_gir : System.Web.UI.Page
{
    OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + HttpContext.Current.Server.MapPath("~/App_Data/veri.mdb"));
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["admn"] = "";
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {

            DataTable dt = new DataTable();
            OleDbCommand cmd = new OleDbCommand("SELECT AdmnId FROM Admin WHERE ((AdmnAd =@1) AND (AdmnSifre = @2))");
            cmd.Parameters.Add("@1", TextBox1.Text);
            cmd.Parameters.Add("@2", TextBox2.Text);
            //cmd.ExecuteNonQuery();
            //OleDbDataReader drd;
            //drd = cmd.ExecuteReader();
            //while (drd.Read())
            //{
            //   Session["admn"] = drd[0];
            //}
            OleDbDataAdapter adp = new OleDbDataAdapter(cmd);
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                Session["admn"] = dt.Rows[0]["AdmnId"].ToString();
            }
            Response.Redirect("Default.aspx");
        }
        catch
        {
            Session["admn"] = "";
            Response.Redirect("Default.aspx");
        }
    }
}