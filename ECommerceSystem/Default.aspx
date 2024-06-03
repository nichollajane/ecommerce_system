<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Customer.Master" CodeBehind="Default.aspx.cs" Inherits="ECommerceSystem.Default" %>

<asp:Content ID="Content" ContentPlaceHolderID="MainContent" runat="server">
     
<div class="container my-5">
	<div class="row p-4 pb-0 pe-lg-0 pt-lg-5 align-items-center rounded-3">
		<div class="col-lg-7 p-3 p-lg-5 pt-lg-3">
			<div class="lc-block mb-3">
				<div>
					<h2 class="fw-bold display-4">Your One-Stop Online Shop.&nbsp;<p></p>
						<p></p>
					</h2>
				</div>
			</div>

			<div class="lc-block mb-3">
				<div>
					<p class="lead">
                       Discover a world of variety and convenience. From trendy finds to everyday essentials, we have it all. Enjoy seamless shopping and fast delivery. Shop now and simplify your life!
					</p>
				</div>
			</div>

			<div class="lc-block d-grid gap-2 d-md-flex justify-content-md-start"><a class="btn btn-primary px-4 me-md-2" href="/ProductList.aspx" role="button">Show Now!</a>
			</div>
		</div>
		<div class="col-lg-4 offset-lg-1 p-0 overflow-hidden">
			<div class="lc-block"><img class="rounded-start w-100" src="/img/hero.svg"></div>
		</div>
	</div>
</div>
 
 
  
</asp:Content>