<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page7.aspx.cs" Inherits="Sys_Prog_lab5.Page7" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="background-image: url('http://localhost:61476/Properties/11.jpg'); background-repeat: repeat">
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="Label1" runat="server" Font-Size="X-Large" ForeColor="White" Text="Label"></asp:Label>
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" OnClientClick="HB()"  Text="Повернутися на головну сторінку" Width="270px" />
        </div>
    </form>
    <script type="text/javascript">
        function HB() {
            document.getElementById('Button1').style.visibility = 'hidden';
        }
    </script>
</body>
</html>
