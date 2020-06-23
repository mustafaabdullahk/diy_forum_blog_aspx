using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class admin_Default : System.Web.UI.Page
{
    ForumAracı fa = new ForumAracı();
    OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + HttpContext.Current.Server.MapPath("~/App_Data/veri.mdb"));
    protected void Page_Load(object sender, EventArgs e)
    {
        G_doldur();
        G_doldur2();
        G_doldur3();
        G_doldur4();

        if (!Page.IsPostBack)
        {
            DataTable dt = fa.MakAl(3, 1);           
            Panel1.Visible = false;
            Panel2.Visible = false;
            PanelMakAc.Visible = false;
            PanelKisiOnay.Visible = false;
            PanelKonu.Visible = false;
        }
        if (Session["admn"] != "")
        {
            Response.Redirect("gir.aspx");
        }
    }
    public void makac(string str)
    {
        baglan.Close();
        baglan.Open();
        OleDbCommand Kayit = new OleDbCommand("SELECT Makaleler.*, Kisiler.* FROM Statuler INNER JOIN (Kisiler INNER JOIN Makaleler ON Kisiler.KisiId = Makaleler.MakYazar) ON Statuler.SttId = Kisiler.KisiKullStatu WHERE (((Makaleler.MakId)=" +str+ ") AND ((Makaleler.MakYazar)=(select MakYazar from Makaleler where(MakId=" +str+"))))", baglan);
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
        baglan.Close();
    }
    public void G_doldur4()
    {
        OleDbDataAdapter adp = new OleDbDataAdapter("SELECT * FROM Konular", baglan);
        DataTable dt = new DataTable();
        adp.Fill(dt);
        GridViewKonu.DataSource = dt;
        GridViewKonu.DataBind();
        if (dt.Rows.Count == 0)
        {
            MakHata.Text = "Onaylı Herhangi bir kayıt yok";
        }
    }
    public void G_doldur3()
    {
        OleDbDataAdapter adp = new OleDbDataAdapter("SELECT * FROM Kisiler where KisiOnay = 0", baglan);
        DataTable dt = new DataTable();
        adp.Fill(dt);
        GridView3.DataSource = dt;
        GridView3.DataBind();
        if (dt.Rows.Count == 0)
        {
            MakHata.Text = "Onaylı Herhangi bir kayıt yok";
        }
    }
    public void G_doldur2()
    {
        OleDbDataAdapter adp2 = new OleDbDataAdapter("Select * From Makaleler Where MakOnay=1", baglan);
        DataTable dtt = new DataTable();
        adp2.Fill(dtt);
        GridView2.DataSource = dtt;
        GridView2.DataBind();
        if (dtt.Rows.Count == 0)
        {
            MakHata.Text = "Onaylı Herhangi bir kayıt yok";
        }
    }
    public void G_doldur()
    {
        baglan.Close();
        baglan.Open();
        OleDbCommand cmd = new OleDbCommand("Select * From Makaleler Where MakOnay = 0", baglan);
        OleDbDataAdapter adp2 = new OleDbDataAdapter(cmd);
        DataTable dtt = new DataTable();
        adp2.Fill(dtt);
        baglan.Close();
        GridView1.DataSource = dtt;
        GridView1.DataBind();
        if (dtt.Rows.Count == 0)
        {
            MakHata.Text = "onay bekleyen kayıt yok";
        }
    }
    protected void GridView2_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        GridView2.SelectedIndex = e.NewSelectedIndex;
        string i = GridView2.DataKeys[e.NewSelectedIndex].Value.ToString();
        Session["okunanmakale"] = i;
        makac(i);
    }
    protected void GridView1_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        GridView1.SelectedIndex = e.NewSelectedIndex;
        object i = GridView1.DataKeys[e.NewSelectedIndex].Value;
        baglan.Close();
        baglan.Open();
        OleDbCommand cmd = new OleDbCommand("UPDATE Makaleler set MakOnay =1 WHERE MakId ="+i, baglan);
        cmd.ExecuteNonQuery();
        baglan.Close();
        G_doldur();
        G_doldur2();
    }
    protected void ButtonOnayK_Click(object sender, EventArgs e)
    {
        baglan.Close();
        baglan.Open();
        OleDbCommand cmd = new OleDbCommand("UPDATE Makaleler set MakOnay =0 WHERE MakId =" + (Session["okunanmakale"]), baglan);
        cmd.ExecuteNonQuery();
        baglan.Close();
        G_doldur();
        G_doldur2();
        MakHata.Text = "bir kayıtdı onayı kaldırıldı";
    }
    protected void Düzenle_Click(object sender, EventArgs e)
    {
        baglan.Close();
        baglan.Open();
        OleDbCommand cmd = new OleDbCommand("UPDATE Makaleler set MakBaslik='" + Labelbslk.Text + "',MakIcerik='" + TextBox1.Text + "' WHERE MakId =" + Session["okunanmakale"], baglan);
        cmd.ExecuteNonQuery();
        baglan.Close();
        G_doldur();
        G_doldur2();
        MakHata.Text = "bir kayıt güncellendi";
    }
    protected void Kaldır_Click(object sender, EventArgs e)
    {
        baglan.Close();
        baglan.Open();
        OleDbCommand cmd = new OleDbCommand("DELETE from Makaleler  WHERE MakId = " + Session["okunanmakale"], baglan);
        cmd.ExecuteNonQuery();
        baglan.Close();
        G_doldur();
        G_doldur2();
        MakHata.Text = "bir kayıt slindi";
    }
    protected void g_onaysız_Click(object sender, EventArgs e)
    {
        if (!Panel1.Visible)
        {
            Panel1.Visible = true;
            g_onaysız.Text = "onay bekleyen makaleleri gizle";
        }
        else
        {
            Panel1.Visible = false;
            g_onaysız.Text = "onay bekleyen makaleleri göster";
        }
    }
    protected void g_onaylı_Click(object sender, EventArgs e)
    {
        if (!Panel2.Visible)
        {
            Panel2.Visible = true;
            g_onaylı.Text = "onaylanan makaleleri gizle";
        }
        else
        {
            Panel2.Visible = false;
            g_onaylı.Text = "onaylanan makaleleri göster";
        }
    }
    protected void g_düzenleyici_Click(object sender, EventArgs e)
    {
        if (!PanelMakAc.Visible)
        {
            PanelMakAc.Visible = true;
            g_düzenleyici.Text = "düzenleyiciyi gizle";
        }
        else
        {
            PanelMakAc.Visible = false;
            g_düzenleyici.Text = "düzenleyiciyi göster";
        }
    }
    public void kisiac()
    {
        baglan.Close();
        baglan.Open();
        OleDbCommand cmd = new OleDbCommand("SELECT * FROM Kisiler where KisiId = "+Session["incelenenkisi"], baglan);
        
        OleDbDataReader oku;
        oku = cmd.ExecuteReader();
        while (oku.Read())
        {
            Kisibilgileri.Text = oku["KisiAdi"].ToString();
            Kisibilgileri0.Text = oku["KisiSoyAdi"].ToString();
            Kisibilgileri2.Text = oku["KisiHesapAdi"].ToString();
        }
        baglan.Close();
    }
    protected void Kisionayla_Click(object sender, EventArgs e)
    {
        baglan.Close();
        baglan.Open();
        OleDbCommand cmd = new OleDbCommand("UPDATE Kisiler set KisiOnay =1 WHERE KisiId =" + (Session["incelenenkisi"]), baglan);
        cmd.ExecuteNonQuery();
        baglan.Close();
        MakHata.Text = "bir kisi kaydı onaylandı";
        G_doldur3();
    }
    protected void GridView3_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {

        GridView3.SelectedIndex = e.NewSelectedIndex;
        string i = GridView3.DataKeys[e.NewSelectedIndex].Value.ToString();
        Session["incelenenkisi"] = i;
        kisiac();

    }
    protected void Kisisil_Click(object sender, EventArgs e)
    {
        baglan.Close();
        baglan.Open();
        OleDbCommand cmd = new OleDbCommand("DELETE from Kisiler WHERE KisiId =" + (Session["incelenenkisi"]), baglan);
        cmd.ExecuteNonQuery();
        baglan.Close();
        MakHata.Text = "bir kisi kaydı silindi";
    }
    protected void onaybekleyenüyeler_Click(object sender, EventArgs e)
    {
        if (!PanelKisiOnay.Visible)
        {
            PanelKisiOnay.Visible = true;
            onaybekleyenüyeler.Text = "onay bekleyen üyeler gizle";
        }
        else
        {
            PanelKisiOnay.Visible = false;
            onaybekleyenüyeler.Text = "onay bekleyen üyeleri göster";
        }
    }
    public void konuac()
    {
        baglan.Close();
        baglan.Open();
        OleDbCommand cmd = new OleDbCommand("SELECT * FROM Konular where KonuId = " + Session["incelenenkonu"], baglan);

        OleDbDataReader oku;
        oku = cmd.ExecuteReader();
        while (oku.Read())
        {
            TextBoxKonuAdi.Text = oku["KonuBaslik"].ToString();
        }
        baglan.Close();
    }
    protected void GridViewKonu_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        
        GridViewKonu.SelectedIndex = e.NewSelectedIndex;
        string i = GridViewKonu.DataKeys[e.NewSelectedIndex].Value.ToString();
        Session["incelenenkonu"] = i;
        konuac();
    }
    protected void ButtonKonuEkle_Click(object sender, EventArgs e)
    {
        baglan.Close();
        baglan.Open();
        OleDbCommand cmd = new OleDbCommand("INSERT INTO Konular (KonuOnay,KonuBaslik) values (1,'"+ TextBoxKonuAdi.Text +"')", baglan);
        cmd.ExecuteNonQuery();
        baglan.Close();
        MakHata.Text = "bir konu kaydı daha eklendi";
        G_doldur4();
    }
    protected void ButtonKonuduzenle_Click(object sender, EventArgs e)
    {
        baglan.Close();
        baglan.Open();
        OleDbCommand cmd = new OleDbCommand("UPDATE Konular set KonuOnay =1,KonuBaslik ='"+TextBoxKonuAdi.Text+"' WHERE KonuId = " + Session["incelenenkonu"], baglan);
        cmd.ExecuteNonQuery();
        baglan.Close();
        MakHata.Text = "bir konu kaydı düzenlendi";
        G_doldur4();
    }
    protected void ButtonKonuSil_Click(object sender, EventArgs e)
    {
        baglan.Close();
        baglan.Open();
        OleDbCommand cmd = new OleDbCommand("DELETE from Konular  WHERE KonuId = " + Session["incelenenkonu"], baglan);
        cmd.ExecuteNonQuery();
        baglan.Close();
        G_doldur();
        G_doldur2();
        MakHata.Text = "bir konu kayıdı slindi";
    }
    protected void ButtonKonuOnay_Click(object sender, EventArgs e)
    {
        baglan.Close();
        baglan.Open();
        OleDbCommand cmd = new OleDbCommand("UPDATE Konular set KonuOnay =1 WHERE KonuId = " + Session["incelenenkonu"], baglan);
        cmd.ExecuteNonQuery();
        baglan.Close();
        MakHata.Text = "bir konu kaydı onaylandı";
    }
    protected void k_düzenleyici_Click(object sender, EventArgs e)
    {
        if (!PanelKonu.Visible)
        {
            PanelKonu.Visible = true;
            k_düzenleyici.Text = "konu düzenleyiciyi gizle";
        }
        else
        {
            PanelMakAc.Visible = false;
            k_düzenleyici.Text = "konu düzenleyiciyi göster";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["admn"] = null;
    }
}