<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestTypeUI.aspx.cs" Inherits="DiagnosticBillManagementApp.TestTypeUi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form runat="server">
    <div>
    
        
        <asp:Panel runat="server" GroupingText="Test Type Setup">
            <table>
           
             <tr>
                <td><asp:Label ID="Label1" runat="server" Text="Test Type"></asp:Label></td>
            
                <td><asp:TextBox ID="testTypeTextBox" runat="server"></asp:TextBox></td>

             </tr>
            
            <tr>
                <td> <asp:Button ID="saveButton" runat="server" Text="Save" Width="106px" OnClick="saveButton_Click"  /></td>
            </tr>
               
           
        </table>
        
        </asp:Panel>
        
        
        

         <asp:GridView ID="testTypeGridView" runat="server" AutoGenerateColumns="False">
             <Columns>
                 <asp:TemplateField HeaderText="Sl">
                     <ItemTemplate><%#Eval("ID") %></ItemTemplate>
                 </asp:TemplateField>
             </Columns>
             
             <Columns>
                 <asp:TemplateField HeaderText="Type Name">
                     <ItemTemplate><%#Eval("TypeName") %></ItemTemplate>
                 </asp:TemplateField>
             </Columns>

         </asp:GridView>
               

    </div>
    </form>
</body>
</html>
