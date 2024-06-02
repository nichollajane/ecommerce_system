<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Navbar.ascx.cs" Inherits="ECommerceSystem.Views.Admin.Navbar" %>


<nav class="navbar navbar-expand-lg navbar-light bg-light">
  <div class="container-fluid">
    <a class="navbar-brand" href="#">ECommerce System</a>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarSupportedContent">
      <ul class="navbar-nav me-auto mb-2 mb-lg-0">
        <li class="nav-item">
          <a class="nav-link" href="~/Admin/Products.aspx">
              Products
          </a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="#">
              Categories
          </a>
        </li>
          <li class="nav-item">
          <a class="nav-link" href="#">
              Orders
          </a>
        </li>
        <li class="nav-item">
          <a class="nav-link active" href="/Users.aspx">
              Users
          </a>
        </li>
      </ul>
    </div>
  </div>
</nav>