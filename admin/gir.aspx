<%@ Page Language="C#" AutoEventWireup="true" CodeFile="gir.aspx.cs" Inherits="admin_gir" %>

<%@ Register namespace="WebControlCaptcha" tagprefix="WebControlCaptcha" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

        .style1
        {
            width: 100%;
            height: 329px;
        }
        .style7
        {
            width: 30%;
            height: 85px;
        }
        .style8
        {
            height: 138px;
        }
        .style9
        {
            width: 35%;
            height: 138px;
        }
        .style12
        {
            width: 100%;
        }
        .style10
        {
            height: 138px;
        }
        .style2
        {
            width: 30%;
            height: 138px;
        }
        .style11
        {
            height: 78px;
        }
        .style13
        {
            height: 9px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td class="style7">
                </td>
                <td class="style7">
                </td>
                <td class="style8">
                </td>
            </tr>
            <tr>
                <td class="style9">
                </td>
                <td class="style9">
                    <table class="style12">
                        <tr>
                            <td>
                                kullanıcıadı</td>
                            <td>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                sifre</td>
                            <td>
                                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" class="style13">
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
                            </td>
                            <td>
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
                <td class="style10">
                </td>
            </tr>
            <tr>
                <td class="style2">
                </td>
                <td class="style2">
                </td>
                <td class="style11">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
