using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class bul : System.Web.UI.Page
{
    OleDbConnection bag = new OleDbConnection("Provider=Microsoft.jet.oledb.4.0;Data Source=" + HttpContext.Current.Server.MapPath("~/App_Data/veri.mdb"));
    protected void Page_Load(object sender, EventArgs e)
    {
        GridView1.DataSource = Session["bulunanlar"];
        GridView1.DataBind();
    }

    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        GridView1.SelectedIndex = e.NewSelectedIndex;
        Session["secilenyazi"] = GridView1.DataKeys[e.NewSelectedIndex].Value;
        Response.Redirect("makaleac.aspx");
        //OleDbDataAdapter ddar = new OleDbDataAdapter("select * from Makaleler where MakId=" + Session["secilenyazi"], bag);
        //DataTable dt = new DataTable();
        //ddar.Fill(dt);
        //Session["secilenmakale"] = dt;
    }
}