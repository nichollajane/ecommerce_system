<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Customer.Master" CodeBehind="OrderList.aspx.cs" enableEventValidation="false" Inherits="ECommerceSystem.Account.OrderList" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-between align-items-center mb-2">
        <h2>Orders</h2>
    </div>
    <div class="card">
        <div class="card-header">
            <h5>Order Summary</h5>
        </div>
        <div class="card-body">
            <div class="table-responsive">
                <asp:GridView 
                    ID="OrdersGridView" 
                    runat="server" 
                    CellPadding="5" 
                    CellSpacing="5" 
                    CssClass="table" 
                    AutoGenerateColumns="False" 
                >
                    <Columns>
                        <asp:BoundField DataField="Order_No" HeaderText="Order No" />
                        <asp:BoundField DataField="Order_Date" HeaderText="Date placed" />
                        <asp:BoundField DataField="Order_Quantity" HeaderText="Total # of Items" />
                        <asp:TemplateField HeaderText="Total">
                            <ItemTemplate>
                                <asp:Label ID="totalPrice" runat="server" Text='<%# Convert.ToDecimal(Eval("Order_Price")).ToString("₱#,##0.00") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Order_Status" HeaderText="Status" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <a href='/Account/OrderDetail.aspx?Order_ID=<%# Eval("Order_ID") %>' class="btn btn-sm btn-primary">
                                    View
                                </a>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>