<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page4.aspx.cs" Inherits="Sys_Prog_lab5.Page4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="background-image: url('Properties/2.jpg'); background-repeat: repeat">
    <form id="form1" runat="server">
    <div>
    
    </div>
        <br />
        <asp:Table ID="Table1" runat="server" ForeColor="White">
        </asp:Table>
        <br />
        <asp:Label ID="Label1" runat="server" Font-Size="X-Large" ForeColor="White"></asp:Label>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button5_Click" OnClientClick="HB()" Text="Повернутися на головну сторінку" Width="295px" />
    </form>
    <script type="text/javascript">
        function HB() {
            document.getElementById('Button1').style.visibility = 'hidden';
        }
    </script>
</body>
</html>
