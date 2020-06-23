<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="makaleac.aspx.cs" Inherits="makaleac" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style8
        {
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
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
                <asp:Label ID="Labelbslk" runat="server"></asp:Label>
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
</asp:Content>

