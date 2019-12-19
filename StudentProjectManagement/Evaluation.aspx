<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Evaluation.aspx.cs" Inherits="StudentProjectManagement.Evaluation" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>University of Engineering and Technology,Lahore</title>
     <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no" />
    <link href="Style.css" rel="stylesheet"/>
     <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css" />
</head>
<body>
    <nav class="navbar navbar-expand-sm fixed-top" id="customColor">
  <div class="container">
    <a class="navbar-brand" href="/">Student Project Management</a>
    <div class="navbar-collapse collapse">
      <ul class="nav navbar-nav mr-auto">
        <li class="nav-item"><a href="Student.aspx" class="nav-link">Student</a></li>
        <li class="nav-item"><a href="Advisor.aspx" class="nav-link">Advisor</a></li>
        <li class="nav-item"><a href="Project.aspx" class="nav-link">Project</a></li>
          <li class="nav-item"><a href="Group.aspx" class="nav-link">Group</a></li>
         <li class="nav-item"><a href="Evaluation.aspx" class="nav-link">Evaluation</a></li>
      </ul>

     </div>
      </div>
    </nav>
    <div class="container-fluid">
        <div class="row">
                <div class="col-md-3"></div>
                <div class="col-md-6">
                    <div class="form-outer">
                          <h1 class="text-center">Evaluation</h1>
         <form id="form1" runat="server">
              <div class="input-container">
        <div>
            <table class="table-responsive">
                <tr>
                    <td>
                        Total Marks:
                    </td>
                     
                    <td>
                        <asp:TextBox ID="Tmarks" runat="server"  Width="300px" Height="50px"></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>
                        Obtained Marks:
                    </td>
                     
                    <td>
                        <asp:TextBox ID="Omarks" runat="server" Width="300px" Height="50px" ></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Group Number:
                    </td>
                    <td>
                        <asp:DropDownList ID="groupNum" runat="server"></asp:DropDownList>
                    </td>
                </tr> 
                <tr>
                  
                     <td>
                     
                    </td>
                    <td>
                        <asp:Button ID="Add" runat="server" Text="Add" ForeColor="White" Height="40" Width="90px" BackColor="#009999" OnClick="Add_Click" />
                        <asp:Button ID="Update" runat="server" Text="Update" BackColor="#009999" ForeColor="White" Height="40" Width="90px" />
                        <asp:Button ID="Delete" runat="server" Text="Delete" BackColor="#009999" ForeColor="White" Height="40" Width="90px" />
                    </td>
                    <td>
                       
                   </td>
                  
                </tr>
            </table>
        </div>
       </div>
    </form>
    </div>
   </div>
        </div>
        </div>
</body>
</html>
