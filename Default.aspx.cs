using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + HttpContext.Current.Server.MapPath("~/App_Data/veri.mdb"));
        Session["id"] = Request.QueryString["id"];
        string sorgu = "SELECT TOP 15 Makaleler.MakBaslik, Makaleler.MakIcerik, Makaleler.MakTarih, Kisiler.KisiAdi, Kisiler.KisiSoyAdi, Kisiler.KisiResYol FROM Konular INNER JOIN (Kisiler INNER JOIN Makaleler ON Kisiler.KisiId = Makaleler.MakYazar) ON Konular.KonuId = Makaleler.MakKonu WHERE (((Konular.KonuOnay)=1) AND ((Makaleler.MakOnay)=1)) order by MakTarih DESC";
        OleDbDataAdapter adp = new OleDbDataAdapter(sorgu,baglan);
        DataTable dttt = new DataTable();
        adp.Fill(dttt);
        DataList1.DataSource = (dttt);
        DataList1.DataBind();
    }
}