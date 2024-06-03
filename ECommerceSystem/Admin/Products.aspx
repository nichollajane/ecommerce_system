<%@ Page Language="C#"  MasterPageFile="~/Administration.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="ECommerceSystem.Admin.Products" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-between align-items-center mb-2">
        <h2>Products</h2>
        <asp:LinkButton CssClass="btn btn-primary" PostBackUrl="~/Admin/CreateProduct.aspx"  runat="server">
            <i class="bi bi-plus-circle"></i>
            Add Product
        </asp:LinkButton>
    </div>
    <div class="card">
        <div class="table-responsive">
            <asp:GridView 
                ID="ProductsGridView" 
                runat="server" 
                CellPadding="5" 
                CellSpacing="5" 
                CssClass="table" 
                AutoGenerateColumns="False" 
                OnRowCommand="ProductsGridView_RowCommand"
                OnRowDataBound="ProductsGridView_RowDataBound"
            >
                <Columns>
                    <asp:BoundField DataField="Product_Id" HeaderText="ID" />
                    <asp:TemplateField HeaderText="">
                        <ItemTemplate>
                            <asp:Image 
                                ID="Product_Image" 
                                runat="server" 
                                Width="100px"
                            >
                            </asp:Image>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="Product_SKU" HeaderText="SKU" />
                    <asp:BoundField DataField="Product_Name" HeaderText="Name" />
                    <asp:BoundField DataField="Product_Description" HeaderText="Description" />
                    <asp:TemplateField HeaderText="The Price">
                        <ItemTemplate>
                            <asp:Label ID="priceLabel" runat="server" Text='<%# Convert.ToDecimal(Eval("Product_Price")).ToString("₱#,##0.00") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
   
                    <asp:BoundField DataField="Product_Brand" HeaderText="Brand" />
                    <asp:BoundField DataField="Product_Availability" HeaderText="Availability" />
                    <asp:BoundField DataField="Product_Quantity" HeaderText="Quantity" />
                    <asp:BoundField DataField="Product_Color" HeaderText="Color" />
                    <asp:BoundField DataField="Product_Size" HeaderText="Size" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="d-flex align-items-center gap-2">
                                <asp:Button 
                                    ID="EditButton" 
                                    runat="server" 
                                    Text="Edit" 
                                    CssClass="btn btn-sm btn-secondary"
                                    CommandArgument='<%# Eval("Product_Id") %>' 
                                    CommandName="EditProduct" 
                                />
                                <asp:Button 
                                    ID="DeleteButton" 
                                    runat="server" 
                                    Text="Delete" 
                                    CssClass="btn btn-sm btn-danger"
                                    OnClick='<%# "return confirm(\"Are you sure you want to delete this product?\")" %>'
                                    CommandArgument='<%# Eval("Product_Id") %>' 
                                    CommandName="DeleteProduct" 
                                />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </div>
</asp:Content>