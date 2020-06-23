using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class makaleac : System.Web.UI.Page
{
OleDbConnection bag = new OleDbConnection("Provider=Microsoft.jet.oledb.4.0;Data Source=" + HttpContext.Current.Server.MapPath("~/App_Data/veri.mdb"));
    protected void Page_Load(object sender, EventArgs e)
    {
        makac();

    }
    public void makac()
    {
        bag.Close();
        bag.Open();
        OleDbCommand Kayit = new OleDbCommand("SELECT Makaleler.*, Kisiler.* FROM Statuler INNER JOIN (Kisiler INNER JOIN Makaleler ON Kisiler.KisiId = Makaleler.MakYazar) ON Statuler.SttId = Kisiler.KisiKullStatu WHERE (((Makaleler.MakId)=" + Session["secilenyazi"] + ") AND ((Makaleler.MakYazar)=(select MakYazar from Makaleler where(MakId=" + Session["secilenyazi"] + "))))", bag);
        OleDbDataReader oku;
        oku = Kayit.ExecuteReader();
        while (oku.Read())
        {
            Labelyazar.Text = oku["KisiAdi"].ToString();
            Labelyazar.Text += oku["KisiSoyAdi"].ToString();
            Labelbslk.Text = oku["MakBaslik"].ToString();
            TextBox1.Text = oku["MakIcerik"].ToString();
            Image1.ImageUrl = "foto/" + oku["KisiResYol"].ToString();
        }
        bag.Close();
    }
}