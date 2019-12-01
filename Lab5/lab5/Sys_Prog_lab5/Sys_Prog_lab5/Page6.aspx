<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page6.aspx.cs" Inherits="Sys_Prog_lab5.Page6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="background-image: url('http://localhost:61476/Properties/10.jpg'); background-repeat: repeat">
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" OnClientClick="HB()"  Text="Вилучити замовлення " Width="217px" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" OnClientClick="HB()"  Text="Назад" Width="217px" />
        <br />
        <asp:Label ID="Label1" runat="server" Font-Size="X-Large" ForeColor="White"></asp:Label>
    </form>
    <script type="text/javascript">
        function HB() {
            document.getElementById('Button1').style.visibility = 'hidden';
            document.getElementById('Button2').style.visibility = 'hidden';
        }
    </script>
</body>
</html>
