<%@ Page Title="User List" Language="C#" MasterPageFile="~/Administration.Master" AutoEventWireup="true" CodeBehind="~/Admin/Users.aspx.cs" Inherits="ECommerceSystem.Admin.Users" EnableEventValidation="false" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <div class="d-flex justify-content-between align-items-center mb-2">
        <h2>Users</h2>
        <asp:LinkButton CssClass="btn btn-primary" PostBackUrl="~/Admin/CreateUser.aspx"  runat="server">
            <i class="bi bi-plus-circle"></i>
            Add User
        </asp:LinkButton>
    </div>

    <div class="card fs-6">
        <div class="card-body">
            <div class="table-responsive">
                <asp:GridView ID="AdminUsersGridView" runat="server" CellPadding="5" CellSpacing="5" CssClass="table" AutoGenerateColumns="False" OnRowCommand="AdminUsersGridView_RowCommand">
                    <Columns>
                        <asp:BoundField DataField="User_ID" HeaderText="ID" />
                        <asp:BoundField DataField="User_Fullname" HeaderText="Full Name" />
                        <asp:BoundField DataField="User_Type" HeaderText="Type" />
                        <asp:BoundField DataField="User_Email" HeaderText="Email" />
                        <asp:BoundField DataField="User_Contact_No" HeaderText="Contact No" />
                        <asp:BoundField DataField="User_Gender" HeaderText="Gender" />
                        <asp:BoundField DataField="User_Home_No" HeaderText="Home No" />
                        <asp:BoundField DataField="User_Street" HeaderText="Street" />
                        <asp:BoundField DataField="User_Barangay" HeaderText="Barangay" />
                        <asp:BoundField DataField="User_City" HeaderText="City" />
                        <asp:BoundField DataField="User_Municipality" HeaderText="Municipality" />
                        <asp:BoundField DataField="User_Region" HeaderText="Region" />
                        <asp:BoundField DataField="User_Country" HeaderText="Country" />
                        <asp:BoundField DataField="User_Zipcode" HeaderText="Zipcode" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <div class="d-flex align-items-center gap-2">
                                     <asp:Button 
                                        ID="EditButton" 
                                        runat="server" 
                                        Text="Edit" 
                                        CssClass="btn btn-sm btn-secondary"
                                        CommandArgument='<%# Eval("User_ID") %>' 
                                        CommandName="Edit" 
                                    />
                                    <asp:Button 
                                        ID="DeleteButton" 
                                        runat="server" 
                                        Text="Delete" 
                                        CssClass="btn btn-sm btn-danger"
                                        OnClick='<%# "return confirm(\"Are you sure you want to delete this user?\")" %>'
                                        CommandArgument='<%# Eval("User_ID") %>' 
                                        CommandName="Delete" 
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
