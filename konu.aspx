<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="konu.aspx.cs" Inherits="konu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style8
        {
            width: 13px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:DataList ID="DataList1" runat="server" 
        onselectedindexchanged="DataList1_SelectedIndexChanged">
        <ItemTemplate>
            <table cellpadding="0" cellspacing="0" class="style1">
                <tr>
                    <td>
                        <img alt=""  src="foto/<%#Eval("KisiResYol")%>" style="height: 42px; width: 74px" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        Yazar:<%#Eval("KisiAdi") %><%#Eval("KisiSoyAdi") %></td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td bgcolor="#CCD7D9" colspan="2">
                        <%#Eval("MakBaslik") %>Tarih: <%#Eval("MakTarih") %>
                    </td>
                </tr>
                <tr>
                    <td>
                        <%#Eval("MakIcerik") %>&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
    <asp:Panel ID="Panel3" runat="server" Visible="False">
        <table class="style1">
            <tr>
                <td>
                    eklenmesini istediğiniz yorum :</td>
                <td class="style8">
                    <asp:TextBox ID="TextBox2" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    başlık</td>
                <td class="style8">
                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="gönder" />
                </td>
                <td class="style8">
                    &nbsp;</td>
            </tr>
        </table>
    </asp:Panel>
</asp:Content>

