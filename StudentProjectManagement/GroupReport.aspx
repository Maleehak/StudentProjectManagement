<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="GroupReport.aspx.cs" Inherits="StudentProjectManagement.GroupReport" %>

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
  
  
          <form id="form1" runat="server">
              <div>
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
      </ul>

     </div>
      </div>
    </nav>
     </div>
              <div id="heading">
                  <h1 >Final Report</h1>
              </div>
        <div>
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" BackColor="White" PageIndex="20">
                 <Columns>  
                <asp:BoundField DataField="pname" HeaderText="Advisor" HeaderStyle-BackColor="#a5cfd3"   />  
                <asp:BoundField DataField="rank" HeaderText="Rank" HeaderStyle-BackColor="#a5cfd3" />  
                <asp:BoundField DataField="contact" HeaderText="Contact" HeaderStyle-BackColor="#a5cfd3" />  
                <asp:BoundField DataField="designation" HeaderText="Designation" HeaderStyle-BackColor="#a5cfd3" />  
                <asp:BoundField DataField="name" HeaderText="Project Name" HeaderStyle-BackColor="#a5cfd3" />  
                <asp:BoundField DataField="description" HeaderText="Description" HeaderStyle-BackColor="#a5cfd3" />  
                 <asp:BoundField DataField="GNum" HeaderText="Group Number" HeaderStyle-BackColor="#a5cfd3" /> 
                <asp:BoundField DataField="s1" HeaderText="Student 1" HeaderStyle-BackColor="#a5cfd3" /> 
                 <asp:BoundField DataField="s2" HeaderText="Student 2" HeaderStyle-BackColor="#a5cfd3" /> 
                 <asp:BoundField DataField="s3" HeaderText="Student 3" HeaderStyle-BackColor="#a5cfd3" /> 
                 <asp:BoundField DataField="s4" HeaderText="Student 4" HeaderStyle-BackColor="#a5cfd3"  /> 

                </Columns>
            </asp:GridView>
            
           
        </div>
    </form>

     
      
  
    
</body>
</html>
