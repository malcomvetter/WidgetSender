<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="XSS1.aspx.cs" Inherits="WebApplication1.XSS1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1><asp:Literal ID="literal1" runat="server"></asp:Literal></h1>    
    </div>
    </form>
</body>
</html>
