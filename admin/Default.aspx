<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="admin_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .style3
        {
            width: 10%;
        }
        .style4
        {
            width: 80%;
        }
        .style7
        {
            width: 80%;
            }
        .style1
        {
            width: 100%;
        }
        .style6
        {
            width: 25%;
        }
         .style5
        {
            width 100%;
            height 10px;
        }
         .styleoo
        {
            height 70%;
            width: 55%;
        }
        .style8
        {
            width 100%;
            height: 26px;
        }
        .style9
        {
            height: 26px;
        }
        .style10
        {
            height: 23px;
        }
        .style11
        {
            width 100%;
            height: 19px;
        }
        .style12
        {
            width: 100%;
            border: 1px solid #808080;
        }
    </style>
</head>
<body bgcolor="#eeeff0">
    <form id="form1" runat="server">
    <div>
        <table cellpadding="0" cellspacing="0" class="style1">
            <tr>
                <td class="style3" rowspan="10">
                    &nbsp;</td>
                <td colspan="2" class="style7">
                    <table cellpadding="0" cellspacing="0" class="style1">
                        <tr>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                    </td>
                <td class="style3" rowspan="10">
                    &nbsp;</td>
            </tr>
            <tr align="center">
                <td rowspan="8" class="style6" align="left">
                    <table cellpadding="0" cellspacing="0" class="style1">
                        <tr>
                            <td>
                                <asp:Button ID="g_onaysız" runat="server" onclick="g_onaysız_Click" 
                                    Text="onay bekleyen makaleleri göster" />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="g_onaylı" runat="server" onclick="g_onaylı_Click" 
                                    Text="onaylanan makaleleri göster" />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style9">
                                <asp:Button ID="g_düzenleyici" runat="server" onclick="g_düzenleyici_Click" 
                                    Text="düzenleyiciyi göster" />
                            </td>
                            <td class="style9">
                                </td>
                        </tr>
                        <tr>
                            <td class="style9">
                                <asp:Button ID="onaybekleyenüyeler" runat="server" 
                                    onclick="onaybekleyenüyeler_Click" Text="onay bekleyen üyeler" />
                            </td>
                            <td class="style9">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style9">
                                <asp:Button ID="k_düzenleyici" runat="server" onclick="k_düzenleyici_Click" 
                                    Text="konu düzenleyiciyi göster" />
                            </td>
                            <td class="style9">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="style9">
                                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                                    Text="güvenlecıkış" />
                            </td>
                            <td class="style9">
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td class="style5" align="center">
            
                    <asp:Panel ID="Panel1" runat="server">
                        <table cellpadding="0" cellspacing="0" class="style1">
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
                                        BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
                                        CellPadding="3" DataKeyNames="MakId" GridLines="Vertical" 
                                        onselectedindexchanging="GridView1_SelectedIndexChanging">
                                        <AlternatingRowStyle BackColor="Gainsboro" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Başlık">
                                                <ItemTemplate>
                                                    <%#Eval("MakBaslik") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="İçerik">
                                                <ItemTemplate>
                                                    <%#Eval("MakIcerik") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Tarih">
                                                <ItemTemplate>
                                                    <%#Eval("MakTarih") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:CommandField ButtonType="Button" HeaderText="onayla" 
                                                SelectImageUrl="~/img/Oku.png" SelectText="onayla" ShowSelectButton="True" />
                                        </Columns>
                                        <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                        <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                                        <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                        <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                        <SortedAscendingHeaderStyle BackColor="#0000A9" />
                                        <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                        <SortedDescendingHeaderStyle BackColor="#000065" />
                                    </asp:GridView>
                                    <br />
                                    
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;</td>
                                <td>
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
               <asp:Label ID="MakHata" runat="server" ForeColor="#FF3300"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style5" align="center">
            
                    <asp:Panel ID="Panel2" runat="server">
                        <table cellpadding="0" cellspacing="0" class="style1">
                            <tr>
                                <td>
                                    <table cellpadding="0" cellspacing="0" class="style1">
                                        <tr>
                                            <td align="center">
                                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" 
                                                    BackColor="White" BorderColor="#999999" BorderStyle="None" BorderWidth="1px" 
                                                    CellPadding="3" DataKeyNames="MakId" GridLines="Vertical" 
                                                    onselectedindexchanging="GridView2_SelectedIndexChanging">
                                                    <AlternatingRowStyle BackColor="Gainsboro" />
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Başlık">
                                                            <ItemTemplate>
                                                                <%#Eval("MakBaslik") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="İçerik">
                                                            <ItemTemplate>
                                                                <%#Eval("MakIcerik") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Tarih">
                                                            <ItemTemplate>
                                                                <%#Eval("MakTarih") %>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:CommandField ButtonType="Button" HeaderText="Düzele" 
                                                            SelectImageUrl="~/img/Oku.png" SelectText="Aç" ShowSelectButton="True" />
                                                    </Columns>
                                                    <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                                                    <HeaderStyle BackColor="#000084" Font-Bold="True" ForeColor="White" />
                                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                                    <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                                                    <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" ForeColor="White" />
                                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                    <SortedAscendingHeaderStyle BackColor="#0000A9" />
                                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                    <SortedDescendingHeaderStyle BackColor="#000065" />
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center">
                                                <asp:Panel ID="PanelMakAc" runat="server">
                                                    <table class="style1">
                                                        <tr>
                                                            <td>
                                                                <asp:Image ID="Image1" runat="server" Height="100px" Width="120px" />
                                                            </td>
                                                            <td>
                                                                &nbsp;</td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                makaleyi yazan :</td>
                                                            <td>
                                                                <asp:Label ID="Labelyazar" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                kullanıcı statüsü :</td>
                                                            <td>
                                                                <asp:Label ID="Labelstatu" runat="server"></asp:Label>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                makale başlık :</td>
                                                            <td>
                                                                <asp:TextBox ID="Labelbslk" runat="server"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                makale :</td>
                                                            <td>
                                                                <asp:TextBox ID="TextBox1" runat="server" TextMode="MultiLine" Width="231px"></asp:TextBox>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </asp:Panel>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <table class="style1">
                                                    <tr>
                                                        <td>
                                                            <asp:Button ID="ButtonOnayK" runat="server" onclick="ButtonOnayK_Click" 
                                                                Text="Onay kaldır" />
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="Düzenle" runat="server" onclick="Düzenle_Click" 
                                                                Text="Düzenle" />
                                                        </td>
                                                        <td>
                                                            <asp:Button ID="Kaldır" runat="server" onclick="Kaldır_Click" Text="Kaldır" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
               
                </td>
            </tr>
            <tr>
                <td class="style8" align="center" style="background-color: #FFA6A8">
            
                    <asp:Label ID="Label1" runat="server"></asp:Label>
               
                </td>
            </tr>
            <tr>
                <td class="style8" align="center">
            
                    <asp:Panel ID="PanelKisiOnay" runat="server">
                        <asp:GridView ID="GridView3" runat="server" 
    AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
    BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" 
    Width="100%" DataKeyNames="KisiId" onselectedindexchanging="GridView3_SelectedIndexChanging">
                            <AlternatingRowStyle BackColor="#DCDCDC" />
                            <Columns>
                                <asp:CommandField ButtonType="Button" 
            ShowSelectButton="True" />
                                <asp:TemplateField HeaderText="Adı">
                                    <ItemTemplate>
                                        <%#Eval("KisiAdi") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Soyadı">
                                    <ItemTemplate>
                                        <%#Eval("KisiSoyAdi") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <HeaderStyle BackColor="#000084" Font-Bold="True" 
        ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" 
        HorizontalAlign="Center" />
                            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" 
        ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#0000A9" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#000065" />
                        </asp:GridView>
                        <table class="style1">
                            <tr>
                                <td>
                                    adı :</td>
                                <td>
                                    <asp:Label ID="Kisibilgileri" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    soyadı :</td>
                                <td>
                                    <asp:Label ID="Kisibilgileri0" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    kullanıcı adı :</td>
                                <td>
                                    <asp:Label ID="Kisibilgileri2" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <table class="style1">
                                        <tr>
                                            <td class="style10">
                                                <asp:Button ID="Kisionayla" runat="server" onclick="Kisionayla_Click" 
                                                    Text="onayla" />
                                            </td>
                                            <td class="style10">
                                                <asp:Button ID="Kisisil" runat="server" onclick="Kisisil_Click" Text="sil" />
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td class="style5" align="center">
            
                    <asp:Panel ID="PanelKonu" runat="server">
                        <asp:GridView ID="GridViewKonu" runat="server" 
    AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" 
    BorderStyle="None" BorderWidth="1px" CellPadding="3" GridLines="Vertical" 
    Width="100%" DataKeyNames="KonuId" onselectedindexchanging="GridViewKonu_SelectedIndexChanging">
                            <AlternatingRowStyle BackColor="#DCDCDC" />
                            <Columns>
                                <asp:CommandField ButtonType="Button" 
            ShowSelectButton="True" />
                                <asp:TemplateField HeaderText="Adı">
                                    <ItemTemplate>
                                        <%#Eval("KonuBaslik") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="onay">
                                    <ItemTemplate>
                                        <%#Eval("KonuOnay") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" ForeColor="Black" />
                            <HeaderStyle BackColor="#000084" Font-Bold="True" 
        ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" 
        HorizontalAlign="Center" />
                            <RowStyle BackColor="#EEEEEE" ForeColor="Black" />
                            <SelectedRowStyle BackColor="#008A8C" Font-Bold="True" 
        ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#0000A9" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#000065" />
                        </asp:GridView>
                        <table cellpadding="0" cellspacing="0" class="style12">
                            <tr>
                                <td>
                                    konu adi :</td>
                                <td colspan="3">
                                    <asp:TextBox ID="TextBoxKonuAdi" runat="server" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="ButtonKonuEkle" runat="server" Text="ekle" 
                                        onclick="ButtonKonuEkle_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="ButtonKonuduzenle" runat="server" Text="düzenle" 
                                        onclick="ButtonKonuduzenle_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="ButtonKonuSil" runat="server" Text="sil" 
                                        onclick="ButtonKonuSil_Click" />
                                </td>
                                <td>
                                    <asp:Button ID="ButtonKonuOnay" runat="server" Text="Onayla" 
                                        onclick="ButtonKonuOnay_Click" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td class="style5" align="center">
            
                    &nbsp;</td>
            </tr>
            <tr>
                <td class="style11" align="center">
            
                    </td>
            </tr>
            <tr>
                <td class="styleoo">
                        <p>
                            &nbsp;</p>
                </td>
            </tr>
            <tr>
                <td class="style4" colspan="2" align="center">
                    &nbsp;</td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
