<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Customer.Master" CodeBehind="CheckOut.aspx.cs" Inherits="ECommerceSystem.Account.CheckOut" enableEventValidation="false" %>


<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
    <style>
        .product-image {
            width: 100%;
            height: 100px;
            aspect-ratio: 1 / 3;
            border: 1px solid #ced4da;
            border-radius: 10px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-between align-items-center mb-2">
        <h2>Check Out</h2>
    </div>

    <div class="card mb-4">
        <div class="card-header">
            <h5>Order Summary</h5>
        </div>
        <div class="table-responsive">
            <asp:GridView 
                ID="CartItemsGridView" 
                runat="server" 
                CellPadding="5" 
                CellSpacing="5" 
                CssClass="table" 
                AutoGenerateColumns="False" 
            >
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                             <img src='<%# Eval("Product_Image_Url") %>' alt='<%# Eval("Product_Name") %>' class="product-image" />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField>
                        <ItemTemplate>
                            <p>
                                <strong><%# Eval("Product_Name") %></strong>
                            </p>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Price">
                        <ItemTemplate>
                            <asp:Label ID="priceLabel" runat="server" Text='<%# Convert.ToDecimal(Eval("Product_Price")).ToString("₱#,##0.00") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
   
                   <asp:TemplateField HeaderText="Total Price">
                        <ItemTemplate>
                            <asp:Label ID="totalPriceLabel" runat="server" Text='<%# Convert.ToDecimal(Eval("Total_Price")).ToString("₱#,##0.00") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>

    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header">
                    <h5>Order Information</h5>
                </div>
                
                <div class="card-body">
                    <!-- Add form -->
                    <div class="card mb-4">
                    <div class="card-body"> 
                        <table class="w-100 table table-borderless">
                            <tr>
                                <td class="auto-style4 fw-semibold">Order No:</td>
                                <td class="auto-style5">
                                    <asp:TextBox ID="Order_No" runat="server" CssClass="form-control w-100" Width="200px" ReadOnly="true" OnTextChanged="Order_No_TextChanged"></asp:TextBox>
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
                        </table>

                        <div class="d-flex justify-content-end">
                            <asp:Button 
                                ID="ConfirmOrderButton" 
                                runat="server" 
                                CssClass="btn btn-primary" Text="Confirm Order" 
                                OnClick="ConfirmOrderButton_Click"
                            />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>