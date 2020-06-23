using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

public partial class MasterPage : System.Web.UI.MasterPage
{
    OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + HttpContext.Current.Server.MapPath("~/App_Data/veri.mdb"));
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            DropDownList1.Items.Add("20");        
            DropDownList1.Items.Add("50");
            DropDownList1.Items.Add("100");
            DropDownList1.Items.Add("200");
            DropDownList1.Items.Add("500");
            DropDownList1.Items.Add("999");
            listecek();
            yukle();
        }
        Panel1.Visible = false;
        Panel2.Visible = false;
    }

    public void yukle()
    {
        OleDbDataAdapter adp = new OleDbDataAdapter("select * from Konular where KonuOnay=1 order by KonuId desc", baglan);
        DataTable dt = new DataTable();
        adp.Fill(dt);
        DataList1.DataSource = dt;
        DataList1.DataBind();
    }
    public void listecek()
    {
        OleDbDataAdapter adp = new OleDbDataAdapter("select * from Statuler", baglan);
        DataTable dt = new DataTable();
        adp.Fill(dt);
        DropDownList2.DataSource = dt;
        DropDownList2.DataBind();
        DropDownList2.Items.Insert(0, "seciniz");
        DropDownList2.DataTextField = "SttAd";
    }
    public void ara()
    {
        baglan.Close();
        baglan.Open();
        OleDbCommand cmd = new OleDbCommand("Select TOP " + DropDownList1.Text + " * From Makaleler Where MakBaslik like '%" + başlık.Text + "%' and MakIcerik like '%" + konu.Text + "%' and MakOnay=1 order by MakTarih DESC", baglan);
        OleDbDataAdapter adp2 = new OleDbDataAdapter(cmd);
        DataTable dtt = new DataTable();
        adp2.Fill(dtt);
        baglan.Close();
        Session["bulunanlar"] = dtt;
        Response.Redirect("bul.aspx");
    }
    protected void ButtonBul_Click(object sender, EventArgs e)
    {
        ara();
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        ara();
    }
    protected void Buttongir_Click(object sender, EventArgs e)
    {
        Session["qqq"]=null;

        try
        {
            baglan.Close();
            baglan.Open();
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM Kisiler WHERE (KisiHesapAdi = @1 AND KisiHesapSifre = @2)", baglan);
            cmd.Parameters.Add("@1", TextBox1.Text);
            cmd.Parameters.Add("@2", sifre.Text);
            OleDbDataReader drd;
            drd = cmd.ExecuteReader();
            while (drd.Read())
            {
                Session["qqq"] = drd["KisiId"];
                Panel1.Visible = false;
                ImageButton4.ImageUrl = "~/img/uyecigisi.gif";
                if (Session["qqq"] == null)
                {

                    ImageButton4.ImageUrl = "~/img/uyegirisi.gif"; 
                    Session["qqq"] = null;
                }
            }
            baglan.Close();
            Label1.Text = Session["qqq"].ToString();
        }
        catch
        {
            Label1.Text = "hata yeniden deneyin";
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (!(TextBoxAdi.Text != "" && TextBoxSoyadi.Text != "" && DropDownList1.Text != "seciniz" && TextBoxKadi.Text != "" && TextBoxSifre.Text != TextBoxSifretekrar.Text))
        {
            baglan.Close();
            baglan.Open();
            string sorgu = "insert into Kisiler(KisiAdi,KisiSoyAdi,KisiKullStatu,KisiResYol,KisiHesapAdi,KisiHesapSifre) values (@1,@2,@3,@4,@5,@6)";
            OleDbCommand kaydet = new OleDbCommand(sorgu, baglan);
            kaydet.Parameters.Add("@1", TextBoxAdi.Text);
            kaydet.Parameters.Add("@2", TextBoxSoyadi.Text);
            kaydet.Parameters.Add("@3", DropDownList1.SelectedIndex);
            kaydet.Parameters.Add("@4", FileUpload1.FileName);
            FileUpload1.SaveAs(Server.MapPath("foto/") + FileUpload1.FileName);
            kaydet.Parameters.Add("@5", TextBoxKadi.Text);
            kaydet.Parameters.Add("@6", TextBoxSifre.Text);
            kaydet.ExecuteNonQuery();
            baglan.Close();
            Label1.Text = ("kayıt başarıyla gerçekleşti");
        }
        else
            Label1.Text = ("lütfen formu eksiksiz doldurun");
        Panel2.Visible = false;
    }

    protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
    {
        if (!Panel2.Visible)
            Panel2.Visible = true;
        else
            Panel2.Visible = false;
        Panel1.Visible = false;
    }
    protected void ImageButton4_Click(object sender, ImageClickEventArgs e)
    {
        if (!Panel1.Visible)
            Panel1.Visible = true;
        else
            Panel1.Visible = false;
        Panel2.Visible = false;
    }
} 