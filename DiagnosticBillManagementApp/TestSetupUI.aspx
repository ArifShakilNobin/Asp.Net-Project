<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestSetupUI.aspx.cs" Inherits="DiagnosticBillManagementApp.TestSetupUi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 138px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Panel runat="server" GroupingText="Test SetUp">
        <table>
            <tr>
                <td class="auto-style1">
                    <asp:Label ID="Label1" runat="server" Text="Test Name"></asp:Label></td>
                <td>
                    <asp:TextBox ID="testTextBox" runat="server" Width="209px"></asp:TextBox></td>
            </tr>
            <tr>
                <td class="auto-style1"><asp:Label ID="Label2" runat="server" Text="Fee"></asp:Label></td>
                <td><asp:TextBox ID="feeTextBox" runat="server" Width="213px"></asp:TextBox>
                    <asp:Label ID="Label4" runat="server" Text="BDT" style="text-align: center"></asp:Label>
                </td>
                
            </tr>
            
            <tr>
                <td><asp:Label ID="Label3" runat="server" Text="Test Type"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="TestTypeDropDownList" runat="server" ></asp:DropDownList></td>
            </tr>
            
            <tr>
                <td>
                    <asp:Button ID="saveButton" runat="server" Text="Save" OnClick="saveButton_Click" />
                    <br />
                    <asp:Label ID="msgLabel" runat="server" Text=""></asp:Label>
                </td>
            </tr>
    </table>
            
            </asp:Panel>
        <asp:GridView ID="testSetupGridView" runat="server" AutoGenerateColumns="False">
            <Columns>
                <asp:TemplateField HeaderText="Sl">
                    <ItemTemplate><%#Eval("ID") %></ItemTemplate>
                </asp:TemplateField>
            </Columns>
            
             <Columns>
                <asp:TemplateField HeaderText="Test Name">
                    <ItemTemplate><%#Eval("TestName") %></ItemTemplate>
                </asp:TemplateField>
            </Columns>
            
            <Columns>
                <asp:TemplateField HeaderText="Fee">
                    <ItemTemplate><%#Eval("Fee") %></ItemTemplate>
                </asp:TemplateField>
            </Columns>
            
             <Columns>
                <asp:TemplateField HeaderText="Type">
                    <ItemTemplate><%#Eval("TestType") %></ItemTemplate>
                </asp:TemplateField>
            </Columns>

        </asp:GridView>
        
    </div>
    </form>
</body>
</html>
