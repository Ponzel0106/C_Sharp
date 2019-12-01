<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page5.aspx.cs" Inherits="Sys_Prog_lab5.Page5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="background-image: url('Properties/4.jpg'); background-repeat: repeat">
    <form id="form1" runat="server">
    <div>
    
        <asp:Table ID="Table1" runat="server" Font-Size="Medium" ForeColor="White">
        </asp:Table>
        <br />
        <asp:Label ID="Label1" runat="server" Font-Size="X-Large" ForeColor="White"></asp:Label>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" OnClientClick="HB()" Text="Назад" Width="200px" />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Font-Size="Large" ForeColor="White" Text="Видалити запис за ID"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" OnClientClick="HB()" Text="Delete" Width="147px" />
    
    </div>
    </form>
    <script type="text/javascript">
        function HB() {
            document.getElementById('Button1').style.visibility = 'hidden';
            document.getElementById('Button2').style.visibility = 'hidden';
        }
    </script>
</body>
</html>
