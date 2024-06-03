<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Administration.Master" CodeBehind="OrderDetail.aspx.cs" Inherits="ECommerceSystem.Admin.OrderDetail" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-between align-items-center mb-2">
        <h2>Order</h2>
    </div>

    <div class="card mb-4">
        <div class="card-header">
            <h5>Order Details</h5>
        </div>
        
        <div class="card-body">
           <table class="w-100 table table-borderless">
                <tr>
                    <td class="auto-style4 fw-semibold">Order No:</td>
                    <td class="auto-style5">
                        <asp:TextBox ID="Order_No" runat="server" CssClass="form-control w-100" Width="200px" ReadOnly="true"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Order_No" Display="Dynamic" ErrorMessage="Order No is Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2 fw-semibold">Order Quantity:</td>
                    <td class="auto-style3">
                        <asp:TextBox ID="Order_Quantity" runat="server" CssClass="form-control w-100" TextMode="Number" Width="200px" ReadOnly="true"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Order_Quantity" Display="Dynamic" ErrorMessage="Order Quantity is Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1 fw-semibold">Order Price:</td>
                    <td>
                        <asp:TextBox ID="Order_Price" runat="server" CssClass="form-control w-100" Width="200px" ReadOnly="true"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Order_Price" Display="Dynamic" ErrorMessage="Order Price is Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style2 fw-semibold">Payment Method:</td>
                    <td class="auto-style3">
                        <div class="d-flex align-items-center">
                            <asp:RadioButton ID="Payment_Method" runat="server" Text="COD" />
                        </div>
                    </td>
                </tr>
                <tr>
                    <td class="auto-style1 fw-semibold">Shipping Address:</td>
                    <td>
                        <div class="input-group mb-3">
                        <asp:TextBox ID="Shipping_Address" runat="server" CssClass="form-control w-100" Width="200px"></asp:TextBox>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredValidator7" runat="server" ControlToValidate="Shipping_Address" Display="Dynamic" ErrorMessage="Shipping Address is Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
               <tr>
                    <td class="auto-style1 fw-semibold">Order Status:</td>
                    <td>
                        <div class="input-group mb-3">
                            <asp:DropDownList ID="Order_Status" runat="server" CssClass="form-control">
                                <asp:ListItem>Order Placed</asp:ListItem>
                                <asp:ListItem>Preparing to ship</asp:ListItem>
                                <asp:ListItem>Ready to ship</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Shipping_Address" Display="Dynamic" ErrorMessage="Shipping Address is Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
        </div>
        <div class="card-footer">
            <div class="d-flex justify-content-end">
                <asp:Button 
                    ID="UpdateOrderButton" 
                    runat="server" 
                    CssClass="btn btn-primary" Text="Confirm Order" 
                    OnClick="UpdateOrderButton_Click"
                />
            </div>
        </div>
    </div>
</asp:Content>