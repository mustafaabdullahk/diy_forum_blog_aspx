using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class konu : System.Web.UI.Page
{
    OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + HttpContext.Current.Server.MapPath("~/App_Data/veri.mdb"));
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["id"] = Request.QueryString["id"];

        if (Session["qqq"] != null)
        {
            Panel3.Visible = true;
        }
        if (Session["id"] != null)
        {
            
            string sorgu = "SELECT Makaleler.MakBaslik, Makaleler.MakIcerik, Makaleler.MakTarih, Kisiler.KisiAdi, Kisiler.KisiSoyAdi, Kisiler.KisiResYol FROM Konular INNER JOIN (Kisiler INNER JOIN Makaleler ON Kisiler.KisiId = Makaleler.MakYazar) ON Konular.KonuId = Makaleler.MakKonu WHERE (((Konular.KonuOnay)=1) AND ((Konular.KonuId)=" + Session["id"].ToString() + ") AND ((Makaleler.MakOnay)=1))";
            OleDbDataAdapter adp = new OleDbDataAdapter(sorgu, baglan);
            DataTable dttt = new DataTable();
            adp.Fill(dttt);
            DataList1.DataSource = (dttt);
            DataList1.DataBind();
        }
        else
            Response.Redirect("default.aspx");
    }
    protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        baglan.Close();
        baglan.Open();
        OleDbCommand cmd = new OleDbCommand("INSERT INTO Makaleler (MakIcerik,Makbaslik,MakYazar,MakKonu,MakOnay) values ('"+TextBox2.Text+"','" + TextBox3.Text + "',"+Session["qqq"]+","+Session["id"]+",0)", baglan);
        cmd.ExecuteNonQuery();
        baglan.Close();
    }
}