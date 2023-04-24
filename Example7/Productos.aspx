<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Example7.Productos" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:DropDownList ID="cmbCategoria" runat="server" AutoPostBack="true" OnSelectedIndexChanged="cmbCategoria_SelectedIndexChanged"></asp:DropDownList>

            <br />

            <asp:GridView ID="gvProductos" runat="server"></asp:GridView>
        </div>
    </form>
</body>
</html>
