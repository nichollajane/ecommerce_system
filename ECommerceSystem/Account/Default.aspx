<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Customer.Master" CodeBehind="Default.aspx.cs" Inherits="ECommerceSystem.Account.Default" %>

<asp:Content runat="server" ID="MainContent" ContentPlaceHolderID="MainContent">
    <div class="container mt-4 mb-4">
        <div class="row justify-content-center">
            <div class="col-md-8">
                <h2 class="text-center mb-4">Profile</h2>
                <div class="mb-3">
                    <asp:Label ID="Label1" runat="server" Text="Full Name"></asp:Label>
                    <asp:TextBox ID="FullName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <asp:Label ID="Label3" runat="server" Text="Email"></asp:Label>
                    <asp:TextBox ID="Email" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:Label ID="EmailExists" runat="server" ForeColor="Red" Visible="false">
                        Email already exists!
                    </asp:Label>
                </div>

                <div class="mb-3">
                    <asp:Label ID="Label4" runat="server" Text="Password"></asp:Label>
                    <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <asp:Label ID="Label2" runat="server" Text="Confirm Password"></asp:Label>
                    <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                    <asp:CompareValidator ID="ConfirmPasswordError" runat="server" ErrorMessage="Confirm Password didn't match!" ControlToCompare="Password" ControlToValidate="ConfirmPassword" ForeColor="Red"></asp:CompareValidator>
                </div>

                <div class="mb-3">
                    <asp:Label ID="Label6" runat="server" Text="Contact No"></asp:Label>
                    <asp:TextBox ID="ContactNo" runat="server" CssClass="form-control"  TextMode="Number"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <asp:Label ID="Label7" runat="server" Text="Gender"></asp:Label>
                    <asp:TextBox ID="Gender" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <asp:Label ID="Label8" runat="server" Text="Home No"></asp:Label>
                    <asp:TextBox ID="HomeNo" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <asp:Label ID="Label9" runat="server" Text="Street"></asp:Label>
                    <asp:TextBox ID="Street" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <asp:Label ID="Label10" runat="server" Text="Street"></asp:Label>
                    <asp:TextBox ID="Barangay" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <asp:Label ID="Label11" runat="server" Text="City"></asp:Label>
                    <asp:TextBox ID="City" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <asp:Label ID="Label12" runat="server" Text="Municipality"></asp:Label>
                    <asp:TextBox ID="Municipality" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <asp:Label ID="Label13" runat="server" Text="Region"></asp:Label>
                    <asp:TextBox ID="Region" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <asp:Label ID="Label14" runat="server" Text="Country"></asp:Label>
                    <asp:TextBox ID="Country" runat="server" CssClass="form-control"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <asp:Label ID="Label15" runat="server" Text="Zipcode"></asp:Label>
                    <asp:TextBox ID="Zipcode" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>

                <div class="text-center">
                    <asp:Button ID="SaveButton" runat="server" Text="Update Profile" CssClass="btn btn-primary" OnClick="SaveButton_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>