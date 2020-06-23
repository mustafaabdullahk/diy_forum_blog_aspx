<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <p>
    <asp:DataList ID="DataList1" runat="server">
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
                        Yazar:<%#Eval("KisiAdi") %>&nbsp&nbsp &nbsp <%#Eval("KisiSoyAdi") %></td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td bgcolor="#CCD7D9" colspan="2">
                        Başlık: <%#Eval("MakBaslik") %>&nbsp &nbsp Tarih: <%#Eval("MakTarih") %>
                    </td>
                </tr>
                <tr bgcolor="#EAEBEC">
                    <td>
                        <%#Eval("MakIcerik") %>&nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:DataList>
        </p>

</asp:Content>

