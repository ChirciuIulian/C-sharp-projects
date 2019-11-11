<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Login_Page_Design.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <link href="Style.css" rel="stylesheet" />
    <link href="bootstrap.min.css" rel="stylesheet" />
    <link href="https://fonts.googleapis.com/css?family=Poor+Story" rel="stylesheet"/>

     <style>
        @import url('https://fonts.googleapis.com/css?family=Leckerli+One|Oleo+Script+Swash+Caps');
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <section class="cover">
            <div>
                <div class="elements">
                    <div class="intro">
                        <asp:Label ID="Label1" runat="server" Text="login"></asp:Label>
                        <asp:TextBox ID="TextBox1" CssClass="txt1 txtstyle" placeholder="username" runat="server" Text="1b7b6021-5621-4085-857c-c86cc1c5ad77"></asp:TextBox>
                        <asp:TextBox ID="TextBox2" CssClass="txt2 txtstyle" placeholder="password"  runat="server" Text="5doIPZZQxEei"></asp:TextBox>
                        <asp:TextBox ID="TextBox3" CssClass="txt3 txtstyle" placeholder="workspace" runat="server" Text="a36c2c60-aacd-4e33-967b-c9f93c32ab49"></asp:TextBox>
                        <asp:Button ID="Button1" CssClass="btn1 btnstyle" runat="server" Text="Log In" OnClick="Button1_Click"/>
                        <asp:Button ID="Button2" CssClass="btn2 btnstyle" runat="server" Text="Clear Tabs" OnClick="Button2_Click"/>
                    </div>
                </div>
            </div>
        </section>
    </form>
</body>
</html>
