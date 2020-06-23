using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;

/// <summary>
/// Summary description for Class1
/// </summary>
public class ForumAracı
{

    OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + HttpContext.Current.Server.MapPath("~/App_Data/veri.mdb"));
    public DataTable MakAl(int MakSayısı, int StatuNo)
    {
        OleDbDataAdapter adp = new OleDbDataAdapter("SELECT top " + MakSayısı + " Makaleler.* FROM Statuler INNER JOIN (Kisiler INNER JOIN Makaleler ON Kisiler.KisiId = Makaleler.MakYazar) ON Statuler.SttId = Kisiler.KisiKullStatu WHERE (((Statuler.SttId)=" + StatuNo + ")) ORDER BY Makaleler.MakTarih DESC", baglan);
        DataTable dtt = new DataTable();
        adp.Fill(dtt);
        return dtt;
    }
    //
    // TODO: Add constructor logic here
    //

}