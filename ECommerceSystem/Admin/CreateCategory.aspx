<%@ Page Language="C#" MasterPageFile="~/Administration.Master" AutoEventWireup="true" CodeBehind="CreateCategory.aspx.cs" Inherits="ECommerceSystem.Admin.CreateCategory" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-between align-items-center mb-2">
        <h2>Create Category</h2>
    </div>

    <div>
        <div class="card mb-4">
            <div class="card-body">
                <table class="w-100 table table-borderless">
                    <tr>
                        <td>
                            <asp:Label ID="Label1" runat="server" Text="Category Name:"></asp:Label>
                        </td>
                        <td class="auto-style5">
                            <asp:TextBox ID="Category_Name" runat="server" CssClass="form-control w-100" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Category_Name" Display="Dynamic" ErrorMessage="Category Name is Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label2" runat="server" Text="Category Description:"></asp:Label>
                        </td>
                        <td class="auto-style1">
                            <asp:TextBox ID="Category_Description" runat="server" CssClass="form-control w-100" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Category_Description" Display="Dynamic" ErrorMessage="Category Description is Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label3" runat="server" Text="Category Image:"></asp:Label>
                        </td>
                        <td class="auto-style1">
                            <asp:FileUpload ID="FileUpload" runat="server" CssClass="form-control" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="FileUpload" ErrorMessage="Image is Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </div>
            <div class="card-footer d-flex justify-content-end">
                <asp:Button ID="SaveButton" runat="server" CssClass="btn btn-primary" OnClick="SaveButton_Click" Text="Add &amp; Save" />
            </div>
        </div>
    </div> 
   </asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            height: 44px;
        }
    </style>
</asp:Content>

