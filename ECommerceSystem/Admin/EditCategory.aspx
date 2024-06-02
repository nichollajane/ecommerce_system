<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="EditCategory.aspx.cs" Inherits="ECommerceSystem.EditCategory" %>


<asp:Content ID="Head" runat="server" ContentPlaceHolderID="Head">
    <style type="text/css">
        .auto-style1 {
            height: 44px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="mb-4">Edit Category</h2>
    <div>
    <div class="card mb-4">
        <div class="card-body"> 
                <table class="w-100 table">
                    <tr>
                        <td class="auto-style4 fw-semibold">
                            <asp:Label ID="Label1" runat="server" Text="Category Name:"></asp:Label>
                        </td>
                        <td class="auto-style5">
                            <asp:TextBox ID="Category_Name" runat="server" CssClass="form-control w-100" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Category_Name" Display="Dynamic" ErrorMessage="Category Name is Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1 fw-semibold">
                            <asp:Label ID="Label2" runat="server" Text="Category Description:"></asp:Label>
                        </td>
                        <td class="auto-style1">
                            <asp:TextBox ID="Category_Description" runat="server" CssClass="form-control w-100" Width="200px" OnTextChanged="Category_Description_TextChanged"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Category_Description" Display="Dynamic" ErrorMessage="Category Description is Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                     <tr>
                        <td class="auto-style1 fw-semibold">
                            <asp:Label ID="Label3" runat="server" Text="Category Image:"></asp:Label>
                        </td>
                        <td class="auto-style1">
                            <asp:FileUpload ID="FileUpload" runat="server" Width="200px" />
                            <br />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="FileUpload" ErrorMessage="Image is Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
                <div class="card-footer d-flex justify-content-end">
                    <asp:Button ID="SaveButton" runat="server" CssClass="btn btn-primary" OnClick="SaveButton_Click" Text="Save Changes" />
                </div>
            </div>
            </div>
    </div> 
</asp:Content>

