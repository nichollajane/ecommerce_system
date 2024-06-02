<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Customer.Master" CodeBehind="OrderDetail.aspx.cs" Inherits="ECommerceSystem.Account.OrderDetail" EnableEventValidation="false"  %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-between align-items-center mb-2">
        <h2>Order Details</h2>
    </div>

    <div class="card mb-4">
        <div class="card-header">
            <h5>Order Summary</h5>
        </div>
        <div class="table-responsive">
            <asp:GridView 
                ID="OrderItemsGridView" 
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
</asp:Content>