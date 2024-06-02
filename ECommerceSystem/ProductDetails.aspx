<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Customer.Master" CodeBehind="ProductDetails.aspx.cs" Inherits="ECommerceSystem.ProductDetails" %>

<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
    <link href="css/products.css" rel="stylesheet" />

    <style>
        .product-image {
            aspect-ratio: 1/1;
            width: 100%;
            height: 500px;
        }

        .input-group {
            width: 200px;
        }
    </style>
</asp:Content>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row g-0 border rounded overflow-hidden flex-md-row mb-4 shadow-sm h-md-250 position-relative">
        <div class="col-auto d-none d-lg-block">
            <asp:Image ID="Product_Image" CssClass="product-image" runat="server" />
        </div>
        <div class="col p-4 d-flex flex-column position-static">
            <strong class="d-inline-block mb-2 text-primary-emphasis">
                 <asp:Label ID="Product_Category" runat="server" Text="Product Category"></asp:Label>
            </strong>
            <h3 class="mb-0">
                <asp:Label ID="Product_Name" runat="server" Text="Product Name"></asp:Label>
            </h3>
            <div class="mb-1 text-body-secondary flex gap-2">
                <strong>
                    <asp:Label ID="Product_Price" runat="server" Text="Product Price"></asp:Label>
                </strong>
                |
                <asp:Label ID="Product_Availability" runat="server" Text="Product Availability"></asp:Label>
                |
                <asp:Label ID="Product_Quantity" runat="server" Text="Product Quantity"></asp:Label>
            </div>
            <asp:Label ID="Product_Description" runat="server" Text="Product Description" CssClass="card-text mb-4"></asp:Label>

            <div class="row gap-4">
                <div class="col-md-4">
                    <div class="input-group mb-3">
                        <button class="btn btn-primary" type="button" onclick="decrementValue()">-</button>
                        <asp:TextBox ID="Quantity" runat="server" TextMode="Number" AutoPostBack="false" CssClass="form-control text-center" Value="1"></asp:TextBox>
                        <button class="btn btn-primary" type="button" onclick="incrementValue()" dir="ltr">+</button>
                    </div>
                </div>
                <div class="col-md-4">
                    <asp:Button ID="AddToCartButton" runat="server" Text="Add to Cart" CssClass="btn btn-primary w-100" OnClick="AddToCartButton_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
               
<asp:Content ID="Scripts" ContentPlaceHolderID="Scripts" runat="server">
    <script>
       function decrementValue() {
           let textbox = document.getElementById('MainContent_Quantity');
           let value = parseInt(textbox.value);
           if (value > 1) {
               value--;
           }
           textbox.value = value;
       }

       function incrementValue() {
           let textbox = document.getElementById('MainContent_Quantity');
           let value = parseInt(textbox.value);
           value++;
           textbox.value = value;
       }
   </script>
</asp:Content>