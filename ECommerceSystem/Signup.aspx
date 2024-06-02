<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="Signup.aspx.cs" Inherits="ECommerceSystem.Signup" %>

<asp:Content runat="server" ID="MainContent" ContentPlaceHolderID="MainContent">
    <div class="container mt-4 mb-4">
        <div class="row justify-content-center">
            <div class="col-md-8">
                <h2 class="text-center mb-4">Signup</h2>
                <p class="mt-2 text-center">Already have an account? <a href="/Login.aspx" class="link-primary">Login</a></p>
                <div class="mb-3">
                    <label for="FullName" class="form-label">Full Name</label>
                    <asp:TextBox ID="FullName" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="UserType" class="form-label">User Type</label>
                    <asp:TextBox ID="UserType" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="Email" class="form-label">Email</label>
                    <asp:TextBox ID="Email" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:Label ID="EmailExists" runat="server" ForeColor="Red" Visible="false">
                        Email already exists!
                    </asp:Label>
                </div>
                <div class="mb-3">
                    <label for="Password" class="form-label">Password</label>
                    <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="ConfirmPassword" class="form-label">Confirm Password</label>
                    <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                    <asp:Label ID="ConfirmPasswordError" runat="server" ForeColor="Red" Visible="false">
                        Confirm password didn't match!
                    </asp:Label>
                </div>
                <div class="mb-3">
                    <label for="ContactNo" class="form-label">Contact No</label>
                    <asp:TextBox ID="ContactNo" runat="server" CssClass="form-control"  TextMode="Number"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="Gender" class="form-label">Gender</label>
                    <asp:TextBox ID="Gender" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="HomeNo" class="form-label">Home No</label>
                    <asp:TextBox ID="HomeNo" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="Street" class="form-label">Street</label>
                    <asp:TextBox ID="Street" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="Barangay" class="form-label">Barangay</label>
                    <asp:TextBox ID="Barangay" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="City" class="form-label">City</label>
                    <asp:TextBox ID="City" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="Municipality" class="form-label">Municipality</label>
                    <asp:TextBox ID="Municipality" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="Region" class="form-label">Region</label>
                    <asp:TextBox ID="Region" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="Country" class="form-label">Country</label>
                    <asp:TextBox ID="Country" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="mb-3">
                    <label for="Zipcode" class="form-label">Zipcode</label>
                    <asp:TextBox ID="Zipcode" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>
                <div class="text-center">
                    <asp:Button ID="SignupButton" runat="server" Text="Signup" CssClass="btn btn-primary" OnClick="SignupButton_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>