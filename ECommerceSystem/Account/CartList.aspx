<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Customer.Master" CodeBehind="CartList.aspx.cs" Inherits="ECommerceSystem.Account.CartList" enableEventValidation="false" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-between align-items-center mb-2">
        <h2>Your Cart</h2>
    </div>

    <div class="mt-6 grid grid-cols-1 gap-x-6 gap-y-10 sm:grid-cols-2 lg:grid-cols-4 xl:gap-x-8">
        <asp:Repeater ID="CartsRepeater" runat="server" OnItemCommand="CartsRepeater_ItemCommand">
            <ItemTemplate>
                <div class="group relative">
                    <div 
                        onclick='<%# "viewProduct(" + Eval("Product_Id") + ")" %>'
                        class="aspect-h-1 aspect-w-1 w-full overflow-hidden rounded-md bg-gray-200 lg:aspect-none group-hover:opacity-75 lg:h-80"
                    >
                        <img src='<%# Eval("Product_Image_Url") %>' alt='<%# Eval("Product_Name") %>' class="h-full w-full object-cover object-center lg:h-full lg:w-full">
                    </div>

                    <div class="mt-4 flex justify-between">
                        <div>
                        <p class="text-gray-700">
                            <strong><%# Eval("Product_Name") %></strong>
                        </p>
                        </div>
                        <p class="text-sm font-medium text-gray-900">
                            <%# Convert.ToDecimal(Eval("Product_Price")).ToString("₱#,##0.00") %>
                        </p>
                    </div>

                    <div class="input-group mb-3">
                        <asp:Button 
                            ID="DecrementQuantityButton" 
                            runat="server" 
                            Text="-" 
                            CssClass="btn btn-primary" 
                            CommandArgument='<%# Eval("Cart_ID") %>'
                            OnClick="DecrementQuantityButton_Click"
                        />
                        <asp:TextBox ID="Quantity" runat="server" TextMode="Number" ReadOnly="true" AutoPostBack="false" CssClass="form-control text-center" Value='<%# Eval("Quantity") %>'></asp:TextBox>
                        <asp:Button 
                            ID="IncrementQuantityButton" 
                            runat="server" 
                            Text="+" 
                            CssClass="btn btn-primary" 
                            CommandArgument='<%# Eval("Cart_ID") %>'
                            OnClick="IncrementQuantityButton_Click"
                        />
                    </div>

                    <div class="d-flex justify-content-between">
                        <a href='/Account/CheckOut.aspx?Cart_ID=<%# Eval("Cart_ID") %>' class="btn btn-sm btn-success">
                            Check Out
                        </a>

                        <asp:Button 
                            ID="RemoveCartButton" 
                            runat="server" 
                            Text="Remove" 
                            CssClass="btn btn-sm btn-outline-danger" 
                            OnClick="RemoveCartButton_Click"
                            CommandArgument='<%# Eval("Cart_ID") %>'
                        />
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>