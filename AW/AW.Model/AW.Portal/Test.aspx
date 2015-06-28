<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="AW.Portal.Test" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.7.2/jquery.min.js"></script>
<script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/jquery-ui.js" type="text/javascript"></script>
<link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.8.9/themes/start/jquery-ui.css"
    rel="stylesheet" type="text/css" />
<script type="text/javascript">
    function ShowPopup(message) {
        $(function () {
            $("#dialog").html(message);
            $("#dialog").dialog({
                title: "jQuery Dialog Popup",
                buttons: {
                    Close: function () {
                        $(this).dialog('close');
                    }
                },
                modal: true
            });
        });
    };
</script>

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div id="dialog" style="display: none">
</div>
<asp:Button ID="btnShowPopup" runat="server" Text="Show Popup" OnClick="btnShowPopup_Click" />
    <div>
        <asp:GridView ID="GridView1" runat="server"></asp:GridView>
    </div>
    </form>
</body>
</html>
