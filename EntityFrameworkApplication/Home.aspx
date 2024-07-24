<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="EntityFrameworkApplication.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
     <div>
     <asp:Label ID="Label0" runat="server" Text="Rollnumber"></asp:Label> 
     <asp:TextBox ID="txtRollnumber" runat="server"></asp:TextBox>
         </div>
     <div>
     <asp:Label ID="Label1" runat="server" Text="Name"></asp:Label> 
     <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
         </div>
      <div>
     <asp:Label ID="Label2" runat="server" Text="Age"></asp:Label> 
     <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
         </div>
      <div>
     <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label> 
     <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
         </div>
     <asp:Button ID="btnInsert" runat="server" Text="Insert" OnClick="btnInsert_Click" />
        <asp:Button ID="btnLoads" runat="server" Text="Load" OnClick="btnLoads_Click" />
     <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
     <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
     <asp:Button ID="cleartext" runat="server" Text="Clear" OnClick="cleartext_Click" />
     <br />
     <asp:Label ID="lbltext" runat="server" ></asp:Label>





     <div>
         <asp:GridView ID="gdview" runat="server"></asp:GridView>
     </div>


 </form>

</body>
</html>
