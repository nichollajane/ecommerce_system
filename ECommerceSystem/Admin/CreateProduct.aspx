<%@ Page Language="C#" MasterPageFile="~/Administration.Master" AutoEventWireup="true"  CodeBehind="CreateProduct.aspx.cs" Inherits="ECommerceSystem.CreateProduct" %>


<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
    <h2 class="mb-4">Create Product</h2>
    <div>
        <div class="card mb-4">
            <div class="card-body"> 
                <table class="w-100 table table-borderless">
                    <tr>
                        <td class="auto-style4 fw-semibold">Product Stock Keeping Unit:</td>
                        <td class="auto-style5">
                            <asp:TextBox ID="Product_SKU" runat="server" CssClass="form-control w-100" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Product_SKU" Display="Dynamic" ErrorMessage="Product Stock Keeping Unit is Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1 fw-semibold">Product Name:</td>
                        <td>
                            <asp:TextBox ID="Product_Name" runat="server" CssClass="form-control w-100" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Product_Name" Display="Dynamic" ErrorMessage="Product Name is Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1 fw-semibold">Product Description:</td>
                        <td>
                            <asp:TextBox ID="Product_Description" runat="server" CssClass="form-control w-100" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="Product_Description" Display="Dynamic" ErrorMessage="Product Description is Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2 fw-semibold">Product Price:</td>
                        <td class="auto-style3">
                            <asp:TextBox ID="Product_Price" runat="server" CssClass="form-control w-100" TextMode="Number" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="Product_Price" Display="Dynamic" ErrorMessage="Product Price is Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1 fw-semibold">Product Brand:</td>
                        <td>
                            <asp:TextBox ID="Product_Brand" runat="server" CssClass="form-control w-100" Width="200px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="Product_Brand" Display="Dynamic" ErrorMessage="Product Brand is Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2 fw-semibold">Product Availability:</td>
                        <td class="auto-style3">
                            <div class="d-flex align-items-center">
                                <asp:RadioButtonList ID="Product_Availability" runat="server">
                                    <asp:ListItem>Available</asp:ListItem>
                                    <asp:ListItem>Not Available</asp:ListItem>
                                </asp:RadioButtonList>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1 fw-semibold">Product Quantity:</td>
                        <td>
                            <div class="input-group mb-3">
                                <button class="btn btn-primary" onclick="decrementValue()" type="button">
                                    -
                                </button>
                                <asp:TextBox ID="Product_Quantity" runat="server" AutoPostBack="false" CssClass="form-control text-center" TextMode="Number" Value="1"></asp:TextBox>
                                <button class="btn btn-primary" dir="ltr" onclick="incrementValue()" type="button">
                                    +
                                </button>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredValidator7" runat="server" ControlToValidate="Product_Quantity" Display="Dynamic" ErrorMessage="Product Quantity is Required" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1 fw-semibold">Product Images</td>
                        <td>
                            <asp:FileUpload ID="FileUpload" runat="server" CssClass="form-control" />
                            <asp:Label ID="ImageErrorMessage" runat="server" ForeColor="Red" Text="" Visible="false"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredValidator8" runat="server" ControlToValidate="FileUpload" Display="Dynamic" ErrorMessage="Product Image is Required!" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1 fw-semibold">Product Color</td>
                        <td>
                            <asp:TextBox ID="Product_Color" runat="server" CssClass="form-control w-full" placeholder="(Optional)"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1 fw-semibold">Product Size</td>
                        <td>
                            <asp:TextBox ID="Product_Size" runat="server" CssClass="form-control w-full" placeholder="(Optional)"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style1 fw-semibold">Category</td>
                        <td>
                            <asp:DropDownList ID="Category_ID" runat="server"  CssClass="form-control w-full"></asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="Category_ID" Display="Dynamic" ErrorMessage="Category is required!" ForeColor="Red"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </div>

            <div class="card-footer d-flex justify-content-end">
                <asp:Button ID="AddSaveButton" runat="server" CssClass="btn btn-primary" OnClick="AddSaveButton_Click" Text="Add & Save" />
            </div>
        </div>
    </div> 
</asp:Content>
