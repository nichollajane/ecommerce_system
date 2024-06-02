<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master" CodeBehind="Signin.aspx.cs" Inherits="ECommerceSystem.Signin" %>

<asp:Content runat="server" ID="Head" ContentPlaceHolderID="Head">
    <link href="css/signin.css" rel="stylesheet" />
</asp:Content>

<asp:Content runat="server" ID="MainContent" ContentPlaceHolderID="MainContent">
    <div class="container sign-container d-flex justify-content-center align-items-center">
        <div class="card signin-form">
            <div class="card-body">
                <h5 class="card-title text-center">Sign In</h5>

                <div class="mb-3">
                    <label for="email" class="form-label">Email address</label>
                    <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                </div>

                <div class="mb-3">
                    <label for="password" class="form-label">Password</label>
                   <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                </div>

                <asp:Label 
                    ID="InvalidSignin"
                    runat="server"
                    CssClass="d-inline-block mb-3"
                    ForeColor="Red"
                    Text="Invalid email or password!"
                    Visible="false"
                >
                </asp:Label>

                <asp:Button ID="SigninButton" runat="server" Text="Login" CssClass="btn btn-primary w-100" OnClick="SigninButton_Click" />
            </div>
        </div>
    </div>
</asp:Content>
