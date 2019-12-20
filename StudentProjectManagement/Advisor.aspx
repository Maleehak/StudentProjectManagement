<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Advisor.aspx.cs" Inherits="StudentProjectManagement.Advisor" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>
         University of Engineering and Techlogy ,Lahore
    </title>
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
           <li class="nav-item"><a href="GroupReport.aspx" class="nav-link">Group Report</a></li>
           <li class="nav-item"><a href="MarksSheetReport.aspx" class="nav-link">Marks Sheet</a></li>
          
      </ul>

     </div>
      </div>
    </nav>
    <div class="container-fluid">
        <div class="row">
                <div class="col-md-3"></div>
                <div class="col-md-6">
                    <div class="form-outer">
                          <h1 class="text-center">Advisor</h1>
         <form id="form1" runat="server">
              <div class="input-container">
        <div>
            <table class="table-responsive">
                <tr>
                    <td>
                        Name:
                    </td>
                     
                    <td>
                        <asp:TextBox ID="name" runat="server" Width="300px" Height="50px" ></asp:TextBox>
                    </td>
                </tr>
                 <tr>
                    <td>
                        Rank:
                    </td>
                     
                    <td>
                        <asp:TextBox ID="rank" runat="server" Width="300px" Height="50px" ></asp:TextBox>
                    </td>
                </tr>
                  <tr>
                    <td>
                        Contact:
                    </td>
                       
                    <td>
                        <asp:TextBox ID="contact" runat="server" Width="300px" Height="50px"></asp:TextBox>  
                    </td>
            
                </tr>  
                 
                  <tr>
                    <td>
                        Designation:
                    </td>
                     
                    <td>
                        <asp:TextBox ID="designation" runat="server" Width="300px" Height="50px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                  
                     <td>
                     
                    </td>
                    <td>  
                        <asp:Button ID="Add" runat="server" Text="Add" BackColor="#009999" Height="40" Width="90px" ForeColor="White" OnClick="Add_Click" />
                          <asp:Button ID="Update" runat="server" Text="Update" BackColor="#009999" Height="40" Width="90px" ForeColor="White" OnClick="Update_Click" />
                         <asp:Button ID="Delete" runat="server" Text="Delete"  BackColor="#009999" Height="40" Width="90px" ForeColor="White" OnClick="Delete_Click" />
                    </td>
                    <td>
                       
                   </td>
                  
                </tr>
                <tr>
                     <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView2_RowDataBound" BackColor="White" PageIndex="20">
                 <Columns>  
                <asp:BoundField DataField="pname" HeaderText="Advisor Name" HeaderStyle-BackColor="#a5cfd3"   />  
                <asp:BoundField DataField="contact" HeaderText="Contact" HeaderStyle-BackColor="#a5cfd3" />   
                <asp:BoundField DataField="designation" HeaderText="Degree" HeaderStyle-BackColor="#a5cfd3" />  
                 <asp:BoundField DataField="rank" HeaderText="Rank" HeaderStyle-BackColor="#a5cfd3" /> 
                </Columns>
            </asp:GridView>
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

