<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="/Parametreler/Login.aspx.cs" Inherits="yemek.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Yemek Siparis</title>
    <link href="/css/style.css" rel="stylesheet" />
    <link href="/css/bootstrap.css" rel="stylesheet" />
</head>
<body style="background-image:url('/css/Ett.jpg')">

    <style type="text/css">
        .ortalama {
            margin-bottom: auto;
            margin-left: auto;
            margin-right: auto;
            margin-top: auto;
            top: 50%;
            left: 50%;
            margin-bottom: auto;
            margin-left: auto;
        }

        </style>

    <form id="form1" runat="server" >

        
    <div>
        <table width:400px; height:300px; top:150px; left:250; font-size:100%"; style="margin-left:auto; margin-right:auto; margin-top:150px" class="radiusTable">
            <tr>
                <td> <asp:Label ID="lblEMail" runat="server" Text="Email  Giris:" Font-Italic="true" CssClass="VeriAlTitle"></asp:Label> </td>
                <td> <asp:TextBox ID="txtEMail" runat="server" BackColor="#cccccc" CssClass="VeriAltxt"></asp:TextBox> </td>
               
            </tr>

            <tr>
                <td> <asp:Label ID="lblSifre" runat="server" Text="Sifre" Font-Italic="true" CssClass="VeriAlTitle" ></asp:Label> </td>
                <td> <asp:TextBox ID="txtSifre" runat="server" BackColor="#cccccc" BorderStyle="Inset" CssClass="VeriAltxt" AutoCompleteType="Disabled" TextMode="Password" ></asp:TextBox > </td>
            </tr>

            <tr>
                <td> <asp:Button ID="LoginBtn" runat="server" Text="Giris" OnClick="LoginBtn_Click" style="height: 26px; margin-left:auto; margin-right:auto" Font-Italic="true" CssClass="ButtonStyle;" /> </td>
                <td>
                    <asp:Label ID="lblHata" runat="server" Text="" Visible="false"></asp:Label></td>
            </tr>

        </table>
    
            
                <asp:Label runat="server" ID="lblHataMesaj" ForeColor="#434242"></asp:Label>

    </div>

    </form>
</body>
</html>
