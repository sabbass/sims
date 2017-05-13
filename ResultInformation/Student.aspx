<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="WebApplication1.Student" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Css/bootstrap.css" rel="stylesheet" />
    <link href="Css/bootstrap-grid.css" rel="stylesheet" />
</head>
<body style="background-color:lightskyblue">
    <br /><br />
    <div class="col-lg-6 offset-3" style="border-right:4px ;border-left: 4px;border-bottom: 4px; border-top: 4px;border-color: #e0e0e0; border-radius:4px;align-content:center;text-align:center;">
    <form id="form1" runat="server">
        <br />
        <asp:Label ID="Label1" runat="server"  Text="LOGIN HERE" Font-Bold="true" Font-Underline="true" ForeColor="Yellow"></asp:Label>
             <br /><br />
            <div class="col-lg-6 offset-3 ">
            <div class="form-group">
                 <input type="text" class="form-control" id="inputcnic" placeholder="CNIC/PASSPORT#"/>
            </div>
           <div class="form-group">
                  <input type="text" class="form-control" id="inputpassword" placeholder="PASSWORD"/>
            </div> 
                       
          <asp:Button ID="Button1" OnClick="Button1_Click" runat="server"  Font-Bold="true"  Text="Log in" CssClass="btn btn-lg btn-warning"  />             
            </div>
    </form>
    </div>
</body>
</html>
