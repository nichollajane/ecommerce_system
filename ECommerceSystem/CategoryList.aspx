<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Customer.Master" CodeBehind="CategoryList.aspx.cs" Inherits="ECommerceSystem.CategoryList" %>

<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
    <link href="css/products.css" rel="stylesheet" />
</asp:Content>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-between align-items-center mb-2">
        <h2>Categories</h2>
    </div>

    <div class="mt-6 grid grid-cols-1 gap-x-6 gap-y-10 sm:grid-cols-2 lg:grid-cols-4 xl:gap-x-8">
        <asp:Repeater ID="CategoriesRepeater" runat="server">
            <ItemTemplate>
                <div onclick='<%# "viewCategory(" + Eval("Category_ID") + ")" %>' class="group relative">
                    <div class="aspect-h-1 aspect-w-1 w-full overflow-hidden rounded-md bg-gray-200 lg:aspect-none group-hover:opacity-75 lg:h-80">
                        <img src='<%# Eval("Category_Image_Url") %>' alt='<%# Eval("Category_Name") %>' class="h-full w-full object-cover object-center lg:h-full lg:w-full">
                    </div>
                    <div class="mt-4">
                        <div>
                        <p class="text-primary font-medium">
                            <span aria-hidden="true" class="absolute inset-0"></span>
                            <%# Eval("Category_Name") %>
                        </p>
                        </div>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

<asp:Content ID="Scripts" ContentPlaceHolderID="Scripts" runat="server">
    <script>
        function viewCategory(categoryID) {
            window.location.href = "/ProductList.aspx?Category_ID=" + categoryID;
        }
    </script>
</asp:Content>
               