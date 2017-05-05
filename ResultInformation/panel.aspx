<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="panel.aspx.cs" Inherits="ResultInformation.panel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <ul>
        <li>@Html.ActionLink("Student", "Index", "Student")</li>
<li>@Html.ActionLink("Shift", "Index", "Shift")</li>
<li>@Html.ActionLink("Institute", "Index", "Institute")</li>
<li>@Html.ActionLink("Semester", "Index", "Semester")</li>
<li>@Html.ActionLink("Course", "Index", "Course")</li>
        </ul>
    </form>
    

</body>
</html>
