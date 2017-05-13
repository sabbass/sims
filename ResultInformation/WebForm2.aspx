<%@ Page Title="" Language="C#" MasterPageFile="~/Dashboard.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="ResultInformation.WebForm2" %>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    
        <div class="col-lg-10" style="background-color:white;height:424px; float:left; top: 0px; left: 5px;">
            <asp:ImageButton  class="img-thumbnail" ID="ImageButton2" OnClick="ImageButton2_Click" runat="server" ImageUrl="~/img/reg.png" Height="180px" Width="180px"/>&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:ImageButton class="img-thumbnail" ID="ImageButton7" runat="server" height="180px" ImageUrl="~/img/examrules2.png" Width="180px" />&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:ImageButton class="img-thumbnail" ID="ImageButton3" runat="server" ImageUrl="~/img/result.png" Height="180px" Width="180px" /> &nbsp;&nbsp;&nbsp;&nbsp;         
            <asp:ImageButton class="img-thumbnail" ID="ImageButton4" runat="server" ImageUrl="~/img/images3.png" Height="180px" Width="180px" />&nbsp;&nbsp;&nbsp;&nbsp;
            <br /><br />
             <asp:ImageButton class="img-thumbnail" ID="ImageButton5" runat="server" Height="180px" ImageUrl="~/img/fees.png" Width="180px" />&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:ImageButton class="img-thumbnail" ID="ImageButton6" runat="server" height="180px" ImageUrl="~/img/fyp6.jpg" Width="180px" />&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:ImageButton class="img-thumbnail" ID="ImageButton1" runat="server"  ImageUrl="~/img/admin.png" Height="180px" Width="180px"/>&nbsp;&nbsp;&nbsp;&nbsp;  
            <asp:ImageButton class="img-thumbnail" ID="ImageButton8" runat="server" ImageUrl="~/img/images5.png" Height="180px" Width="180px" />
        </div>  
    <asp:Label ID="Label1" Width="1350px" BackColor="Black" ForeColor="White" runat="server" Text="National University of Modern Languages H-9 Islamabad ,Pakistan info@numl.edu.pk "></asp:Label>
       <asp:Label  width="1350px" ID="Label2" BackColor="Black" ForeColor="White" runat="server" Text="© 2017 NUML All Rights Reserved"></asp:Label>   


</asp:Content>