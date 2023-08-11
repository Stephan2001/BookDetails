<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="frmBook.aspx.cs" Inherits="BookDetails.frmBook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Manage Books</h3>
    <asp:Label ID="lbl" runat="server" Text="Title:"></asp:Label><br />
    <asp:TextBox ID="txtTitle" runat="server" CssClass="form-Control"></asp:TextBox><br /><br />
    <asp:Label runat="server" Text="Edition:"></asp:Label><br />
    <asp:TextBox ID="txtEdition" runat="server" CssClass="form-Control"></asp:TextBox><br /><br />
    <asp:Label runat="server" Text="Publisher"></asp:Label><br />
    <asp:TextBox ID="txtPublisher" runat="server" CssClass="form-Control"></asp:TextBox><br /><br />
    <asp:Label  runat="server" Text="Author:"></asp:Label><br />
    <asp:DropDownList ID="ddlAuthor" runat="server"></asp:DropDownList><br /><br />
    <asp:Label  runat="server" Text="Price:"></asp:Label><br />
    <asp:TextBox ID="txtPrice" runat="server" CssClass="form-Control"></asp:TextBox><br /><br />
    <asp:Label  runat="server" Text="Status:"></asp:Label><br />
    <asp:DropDownList ID="ddlStatus" runat="server"></asp:DropDownList><br /><br />
    <asp:Button ID="btnAdd" runat="server" Text="Add student" CssClass="btn btn-danger" OnClick="btnAdd_Click" />
    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnDisplay" runat="server" Text="Display student" CssClass="btn btn-danger" OnClick="btnDisplay_Click" />
    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnUpdate" runat="server" Text="Update Book" CssClass="btn btn-danger" OnClick="btnUpdate_Click" /><br /><br />
    <asp:GridView ID="dgvDisplay" runat="server" >
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnID" runat="server" Text="Action" OnClick="btnID_Click" CommandArgument='<%# Eval("StudentID") %>' />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
