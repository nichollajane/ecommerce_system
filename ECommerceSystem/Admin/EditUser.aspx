<%@ Page Title="User List" Language="C#" MasterPageFile="~/Administration.Master" AutoEventWireup="true" CodeBehind="EditUser.aspx.cs" Inherits="ECommerceSystem.Admin.EditUser" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="mb-4">Edit User</h2>
    <div class="text-end">
     <asp:LinkButton CssClass="btn btn-primary" PostBackUrl="~/Admin/User/EditUser.aspx"  runat="server">
     <i class="bi bi-plus-circle"></i>Back</asp:LinkButton></div>
    <div class="card mb-4">
        <div class="card-body">  
            <table class="w-100">
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="Label2" runat="server" Text="Fullname:"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="Fullname" runat="server" Width="200px"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="Fullname is Required!" ForeColor="Red" ControlToValidate="Fullname"></asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style6">
                        <asp:Label ID="Label16" runat="server" Text="User Type:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:DropDownList ID="User_Type" runat="server" Width="200px">
                            <asp:ListItem>Select User Type</asp:ListItem>
                            <asp:ListItem>Admin</asp:ListItem>
                            <asp:ListItem>Customer</asp:ListItem>
                        </asp:DropDownList>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="User Type is Required!" ForeColor="Red" ControlToValidate="User_Type"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style4">
                        <asp:Label ID="Label17" runat="server" Text="Email:"></asp:Label>
                    </td>
                    <td class="auto-style5">
                        <asp:TextBox ID="Email" runat="server" Width="200px"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="Email is Required!" ForeColor="Red" ControlToValidate="Email"></asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style6">
                        <asp:Label ID="Label18" runat="server" Text="Password:"></asp:Label>
                    </td>
                    <td class="auto-style7">
                        <asp:TextBox ID="Password" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="Password is Required!" ForeColor="Red" ControlToValidate="Password"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label19" runat="server" Text="Contact No:"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="Contact_No" runat="server" Width="200px" TextMode="Number"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="Contact Number isRequired!" ForeColor="Red" ControlToValidate="Contact_No"></asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style3">
                        <asp:Label ID="Label30" runat="server" Text="Gender:"></asp:Label>
                    </td>
                    <td class="text-start">
                        <asp:TextBox ID="Gender" runat="server" Width="200px"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ErrorMessage="User Gender is Required!" ForeColor="Red" ControlToValidate="Gender"></asp:RequiredFieldValidator>
                        <br />
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style8">
                        <asp:Label ID="Label21" runat="server" Text="Address"></asp:Label>
                    </td>
                    <td class="auto-style9">
                        <br />
                    </td>
                    <td class="auto-style10">
                        </td>
                    <td class="auto-style11"></td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label22" runat="server" Text="Street:"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="Street" runat="server" Width="200px"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ErrorMessage="Street is Required!" ForeColor="Red" ControlToValidate="Street"></asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style3">
                        <asp:Label ID="Label23" runat="server" Text="Home No:"></asp:Label>
                    </td>
                    <td class="text-start">
                        <asp:TextBox ID="Home_No" runat="server" Width="200px"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ErrorMessage="Home No is Required!" ForeColor="Red" ControlToValidate="Home_No"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label24" runat="server" Text="Barangay:"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="User_Barangay" runat="server" Width="200px"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ErrorMessage="Barangay is Required!" ForeColor="Red" ControlToValidate="User_Barangay"></asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style3">
                        <asp:Label ID="Label25" runat="server" Text="City:"></asp:Label>
                    </td>
                    <td class="text-start">
                        <asp:TextBox ID="City" runat="server" Width="200px"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator25" runat="server" ErrorMessage="City is Required!" ForeColor="Red" ControlToValidate="City"></asp:RequiredFieldValidator>
                        <br />
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label26" runat="server" Text="Municipality:"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="Municipality" runat="server" Width="200px"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator26" runat="server" ErrorMessage="Municipality is Required!" ForeColor="Red" ControlToValidate="Municipality"></asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style3">
                        <asp:Label ID="Label27" runat="server" Text="Region:"></asp:Label>
                    </td>
                    <td class="text-start">
                        <asp:TextBox ID="Region" runat="server" Width="200px"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator27" runat="server" ErrorMessage="Region is Required!" ForeColor="Red" ControlToValidate="Region"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Label ID="Label28" runat="server" Text="Country:"></asp:Label>
                    </td>
                    <td class="auto-style2">
                        <asp:TextBox ID="Country" runat="server" Width="200px"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator28" runat="server" ErrorMessage="Country is Required!" ForeColor="Red" ControlToValidate="Country"></asp:RequiredFieldValidator>
                    </td>
                    <td class="auto-style3">
                        <asp:Label ID="Label29" runat="server" Text="Zipcode:"></asp:Label>
                    </td>
                    <td class="text-start">
                        <asp:TextBox ID="Zipcode" runat="server" Width="200px" TextMode="Number"></asp:TextBox>
                        <br />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator29" runat="server" ErrorMessage="Zipcode is Required!" ForeColor="Red" ControlToValidate="Zipcode"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1">
                        <asp:Button ID="SaveChangesButton" runat="server" Text="Save Changes" OnClick="SaveChangesButton_Click" />
                    </td>
                    </tr>
            </table>     
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content1" runat="server" contentplaceholderid="head">
    <style type="text/css">
        .auto-style1 {
            width: 306px;
            text-align: right;
        }
        .auto-style2 {
            width: 272px;
            text-align: left;
        }
        .auto-style3 {
            width: 185px;
            text-align: right;
        }
        .auto-style4 {
            width: 306px;
            text-align: right;
            height: 46px;
        }
        .auto-style5 {
            width: 272px;
            text-align: left;
            height: 46px;
        }
        .auto-style6 {
            width: 185px;
            text-align: right;
            height: 46px;
        }
        .auto-style7 {
            height: 46px;
            text-align: left;
        }
        .auto-style8 {
            width: 306px;
            text-align: left;
            height: 21px;
        }
        .auto-style9 {
            width: 272px;
            text-align: left;
            height: 21px;
        }
        .auto-style10 {
            width: 185px;
            text-align: right;
            height: 21px;
        }
        .auto-style11 {
            text-align: center;
            height: 21px;
        }
    </style>
</asp:Content>
