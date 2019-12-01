<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page2.aspx.cs" Inherits="Sys_Prog_lab5.Page2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <style type="text/css">
        #form1 {
            margin-left: 68px;
        }
    </style>
</head>
<body style="background-image: url('Properties/5.jpg')";>
    <form id="form1" runat="server">
        <br />
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" ForeColor="White" Text="НОВЕ ЗАМОВЛЕННЯ — КРОК 1"></asp:Label>
        <br />
        <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="White" Text="Прізвище/Ім’я латиницею:"></asp:Label>
        <p>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label3" runat="server" Text="ФОТОГРАФІЯ (JPEG/PNG, min 100x150, max 200x300):" ForeColor="White"></asp:Label>
        </p>
        <p>
            <asp:FileUpload ID="PhotoUpload" runat="server" Width="260px" ForeColor="Black" />
        </p>
        <p>
            <asp:Label ID="Label4" runat="server" Text="ЗВІДКИ:" ForeColor="White"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:Label ID="Label5" runat="server" Text="КУДИ:" ForeColor="White"></asp:Label>
        </p>
        <p>
            <asp:DropDownList ID="From" runat="server" AutoPostBack="True" OnTextChanged="From_TextChanged" Height="19px" Width="175px">
            </asp:DropDownList>
            <asp:DropDownList ID="To" runat="server" AutoPostBack="True" OnTextChanged="To_TextChanged" Height="19px" Width="175px">
            </asp:DropDownList>
        </p>
        <p>
            <asp:RadioButtonList ID="RadioButtonList1" runat="server" AutoPostBack="True" ForeColor="White" OnSelectedIndexChanged="RadioButtonList1_SelectedIndexChanged">
                <asp:ListItem Selected="True">ТУДІ І НАЗАД</asp:ListItem>
                <asp:ListItem>В ОДИН КІНЕЦЬ</asp:ListItem>
            </asp:RadioButtonList>
        </p>
        <p>
            <asp:Label ID="Label6" runat="server" Font-Size="Large" ForeColor="White" Text="Дата прямого рейсу:"></asp:Label>
        </p>
        <p>
            <asp:Label ID="Label7" runat="server" ForeColor="White" Text="Число"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label8" runat="server" ForeColor="White" Text="Місяць"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label9" runat="server" ForeColor="White" Text="Рік"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="TextBox3" runat="server" Width="60px"></asp:TextBox>
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextBox5" runat="server" Width="80px"></asp:TextBox>
        </p>
        <p>
            <asp:Label ID="Label10" runat="server" Font-Size="Large" ForeColor="White" Text="Дата зворотнього рейсу:"></asp:Label>
        </p>
        <p>
            <asp:Label ID="Label11" runat="server" ForeColor="White" Text="Число"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;
            <asp:Label ID="Label12" runat="server" ForeColor="White" Text="Місяць"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="Label13" runat="server" ForeColor="White" Text="Рік"></asp:Label>
        </p>
        <p>
            <asp:TextBox ID="TextBox6" runat="server" Width="60px"></asp:TextBox>
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            <asp:TextBox ID="TextBox8" runat="server" Width="80px"></asp:TextBox>
        </p>
        <p>
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" OnClientClick="HB()" Text="Далі" style="margin-left: 0px" Width="150px" />
    &nbsp;<asp:Button ID="Button2" runat="server" OnClick="Button1_Click" OnClientClick="HB()" Text="Назад" Width="150px" />
        </p>
    </form>
    <script type="text/javascript">
        function HB() {
            document.getElementById('Button3').style.visibility = 'hidden';
            document.getElementById('Button2').style.visibility = 'hidden';
        }
    </script>
    </body>
</html>
