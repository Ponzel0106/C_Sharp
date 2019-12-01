<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page3.aspx.cs" Inherits="Sys_Prog_lab5.Page3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body style="background-image: url('Properties/7.jpg'); background-repeat: repeat; background-color: #99450F">
    <form id="form1" runat="server">
    <div style="margin-left: 143px">
    
        <asp:Label ID="Label1" runat="server" Font-Size="X-Large" ForeColor="White" Text="НОВЕ ЗАМОВЛЕННЯ — КРОК 2"></asp:Label>
        <br />
        <asp:Image ID="Image" runat="server" Height="300px" Width="200px" AlternateText="Can`t upload a photo!" />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Font-Size="X-Large" ForeColor="White" Text="Label"></asp:Label>
        <br />
        <br />
        <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" ForeColor="White" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
            <asp:ListItem Selected="True">ЕКОНОМ-КЛАС</asp:ListItem>
            <asp:ListItem>БІЗНЕС-КЛАС</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:Label ID="Label3" runat="server" ForeColor="White" Text="Вік пасажира:"></asp:Label>
        <br />
        <asp:RadioButtonList ID="RadioButtonList2" runat="server" AutoPostBack="True" ForeColor="White">
            <asp:ListItem>від 2 до 7 років (дитина)</asp:ListItem>
            <asp:ListItem Selected="True">від 7 років    (дорослий)</asp:ListItem>
        </asp:RadioButtonList>
        <br />
        <asp:CheckBox ID="CheckBox1" runat="server" ForeColor="White" Text="Наявність багажу " OnCheckedChanged="CheckBox1_CheckedChanged" />
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" ForeColor="White" Text="Кількість супроводжувальних осіб віком від 2 до 7 років:"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox1" runat="server" Height="19px" ReadOnly="True" Width="60px"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" ForeColor="Black" OnClick="Button1_Click" Text="ЗБІЛЬШИТИ" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="ЗМЕНШИТИ" />
        <br />
        <asp:Label ID="Label5" runat="server" ForeColor="White" Text="Кількість супроводжувальних осіб віком від 7 років:"></asp:Label>
        <br />
        <asp:TextBox ID="TextBox2" runat="server" Height="19px" ReadOnly="True" Width="60px"></asp:TextBox>
        <asp:Button ID="Button3" runat="server" ForeColor="Black" OnClick="Button3_Click1" Text="ЗБІЛЬШИТИ" />
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="ЗМЕНШИТИ" />
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Font-Size="X-Large" ForeColor="White" Text="Label"></asp:Label>
        <br />
        <br />
        <asp:Button ID="Button5" runat="server" Text="Далі" style="margin-left: 0px" Width="150px" OnClick="Button5_Click" OnClientClick="HB()" />
    &nbsp;<asp:Button ID="Button6" runat="server" OnClick="Button3_Click" OnClientClick="HB()" Text="Назад" Width="150px" />
    
    </div>
    </form>
    <script type="text/javascript">
        function HB() {
            document.getElementById('Button5').style.visibility = 'hidden';
            document.getElementById('Button6').style.visibility = 'hidden';
        }
    </script>
</body>
</html>
