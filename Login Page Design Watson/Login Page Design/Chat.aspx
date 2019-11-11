
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Chat.aspx.cs" Inherits="Login_Page_Design.Chat" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Chat_bot Design</title>
    <link rel="stylesheet" type="text/css" href="Chat_style.css" />
    <link href="bootstrap.min.css" rel="stylesheet" />
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"></script>

</head>
<body>
    <form id="form1" runat="server">
        <div class="chatbox">
            <div id="Parent" class="chatlog">
            </div>
            <div class="chat-form">
                <asp:TextBox ID="Input" runat="server" CssClass="input-text" placeholder="Say something to Wall-e" ClientIDMode="Static"></asp:TextBox>
                <asp:Button ID="Send_btn" runat="server" CssClass="send-button" OnClick="Send_btn_Click" iskeypressed="Enter" Text="Send" />
            </div>
            <script type="text/javascript">
                var myResponse =
                    {
                        input: {
                            text: null
                        },
                        context: null,
                        alternate_intents: false
                    };
                $(function () {
                    $('#Send_btn').click(function () {
                        myResponse.input.text = $("#Input").val();

                            $("#Parent").append("<div class='chat self'><div class='user-photo'><img src='Stock/you.jpg' /></div><p class='chat-message'>" + $('#Input').val() + "</p></div>");
                        $.ajax({
                            type: "POST",
                            url: "http://localhost:44329/api/values",
                            contentType: "application/json",
                            data: JSON.stringify(myResponse),
                            success: function (response) {
                                myResponse.context = response.context;
                                var message = response.output.text;
                                $("#Parent").append("<div class='chat friend'><div class='user-photo'><img src='Stock/robot-walle.jpg' /></div><p class='chat-message'>" + message + "</p></div>");
                            },
                            error: function (response) {
                                console.log(response);
                            }
                        })
                        $('#Input').val("");
                        return false;
                    })
                })
            </script>
        </div>
    </form>
</body>
</html>
