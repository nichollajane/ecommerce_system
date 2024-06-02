<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Customer.Master" CodeBehind="ProductList.aspx.cs" Inherits="ECommerceSystem.ProductList" %>

<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
    <link href="css/products.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-between align-items-center mb-2">
        <h2>Products</h2>
    </div>

    <div class="mt-6 grid grid-cols-1 gap-x-6 gap-y-10 sm:grid-cols-2 lg:grid-cols-4 xl:gap-x-8">
        <asp:Repeater ID="ProductsRepeater" runat="server">
            <ItemTemplate>
                <div onclick='<%# "viewProduct(" + Eval("Product_Id") + ")" %>' class="group relative">
                    <div class="aspect-h-1 aspect-w-1 w-full overflow-hidden rounded-md bg-gray-200 lg:aspect-none group-hover:opacity-75 lg:h-80">
                        <img src='<%# Eval("Product_Image_Url") %>' alt='<%# Eval("Product_Name") %>' class="h-full w-full object-cover object-center lg:h-full lg:w-full">
                    </div>
                    <div class="mt-4 flex justify-between">
                        <div>
                        <h3 class="text-sm text-gray-700">
                            <a href="#">
                            <span aria-hidden="true" class="absolute inset-0"></span>
                            <%# Eval("Product_Name") %>
                            </a>
                        </h3>
                        </div>
                        <p class="text-sm font-medium text-gray-900">
                            <%# Convert.ToDecimal(Eval("Product_Price")).ToString("₱#,##0.00") %>
                        </p>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

<asp:Content ID="Scripts" ContentPlaceHolderID="Scripts" runat="server">
    <script>
        function viewProduct(productId) {
            window.location.href = "ProductDetails.aspx?Product_Id=" + productId;
        }
    </script>
</asp:Content>
               