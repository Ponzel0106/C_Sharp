<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page1.aspx.cs" Inherits="Sys_Prog_lab5.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        #form1 {
            margin-left: 161px;
        }
    </style>
</head>
<body style="background-image:url('Properties/1.jpg'); background-attachment: fixed";>
    <form id="form1" runat="server">
        <p>
            <asp:Label ID="header" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="White" Text="Літай з авіакомпанією “КРУТИЙ ШТОПОР”!" Font-Italic="True" Font-Overline="False" Font-Strikeout="False"></asp:Label>
            <br />
        </p>
        <asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="White" Text="Прізвище/Ім’я латиницею:"></asp:Label>
        <p>
            <asp:TextBox ID="name" runat="server" Width="251px"></asp:TextBox>
        </p>
        <asp:Label ID="Label3" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="White" Text="Емейл-адреса:"></asp:Label>
        <p>
            <asp:TextBox ID="email" runat="server" Width="250px"></asp:TextBox>
        </p>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" OnClientClick="HB()" Text="Існуючі Замовлення " Width="261px" />
        <p>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" OnClientClick="HB()" Text="Нове Замовлення " Width="261px" />
        </p>
    </form>
    <script type="text/javascript">
        function HB() {
            document.getElementById('Button1').style.visibility = 'hidden';
            document.getElementById('Button2').style.visibility = 'hidden';
        }
    </script>
</body>
</html>
