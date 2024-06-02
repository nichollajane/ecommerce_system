<%@ Page Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="ECommerceSystem.Categories" %>


<asp:Content ID="Head" runat="server" ContentPlaceHolderID="Head">
    <style type="text/css">
        .auto-style3 {
            overflow-x: auto;
            -webkit-overflow-scrolling: touch;
            text-align: center;
        }
    </style>
</asp:Content>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-between align-items-center mb-2">
        <h2>Categories</h2>

        <asp:LinkButton CssClass="btn btn-primary" PostBackUrl="~/Admin/Category/CreateCategory.aspx"  runat="server">
            <i class="bi bi-plus-circle mr-2"></i>
            Add Category
        </asp:LinkButton>
    </div>
    <div class="card fs-6">
        <div class="card-body">
            <div class="auto-style3">
                <asp:GridView ID="CategoriesGridView" runat="server" 
                    CellPadding="5" CellSpacing="5" 
                    CssClass="table" AutoGenerateColumns="False" 
                    OnRowCommand="CategoriesGridView_RowCommand"
                    OnRowDataBound="CategoriesGridView_RowDataBound"
                >
                    <Columns>
                        <asp:TemplateField HeaderText="">
                            <ItemTemplate>
                                <asp:Image 
                                    ID="Category_Image" 
                                    runat="server" 
                                    Width="100px"
                                >
                                </asp:Image>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Category_ID" HeaderText="ID" />
                        <asp:BoundField DataField="Category_Name" HeaderText="Name" />
                        <asp:BoundField DataField="Category_Description" HeaderText="Description" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <div class="d-flex align-items-center gap-2">
                                    <asp:Button 
                                        ID="EditButton" 
                                        runat="server" 
                                        Text="Edit" 
                                        CssClass="btn btn-sm btn-secondary"
                                        CommandArgument='<%# Eval("Category_ID") %>' 
                                        CommandName="EditCategory" 
                                    />
                                    <asp:Button 
                                        ID="DeleteButton" 
                                        runat="server" 
                                        Text="Delete" 
                                        CssClass="btn btn-sm btn-danger"
                                        OnClick='<%# "return confirm(\"Are you sure you want to delete this category?\")" %>'
                                        CommandArgument='<%# Eval("Category_ID") %>' 
                                        CommandName="DeleteCategory" 
                                    />
                                </div>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
