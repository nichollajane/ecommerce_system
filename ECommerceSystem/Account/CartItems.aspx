<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="CartItems.aspx.cs" Inherits="ECommerceSystem.Account.Cart.CartItems" %>


<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
     <div class="d-flex justify-content-between align-items-center mb-2">
        <h2>CartItems</h2>
    </div>


    <asp:GridView ID="CartItemsGridView" runat="server" Height="542px" Width="1446px">
        <Columns>
            <asp:TemplateField>




            </asp:TemplateField>
        </Columns>
    </asp:GridView>


</asp:Content>