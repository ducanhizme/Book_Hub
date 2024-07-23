<%@ Page Language="C#" CodeBehind="BookDetails.aspx.cs" Inherits="BookHub.BookDetails" MasterPageFile="~/Layout/_General.Master"%>

<asp:Content ID="BookDetailContent" runat="server" ContentPlaceHolderID="MainContent">
    <section class="detail-product-container">
        <form class="detail-product" id="BookDetailContainer" runat="server">
        </form>
    </section>
    <div class="product-container padding-inline-l">
        <h2>Related Books</h2>
        <div class="slider-wrapper swiper">
            <div id="relatedBook" class="product-list swiper-wrapper" runat="server">

            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Head" runat="server" ContentPlaceHolderID="Head">
    <link
        rel="stylesheet"
        href="https://cdn.jsdelivr.net/npm/swiper@11/swiper-bundle.min.css"/>
    <link rel="stylesheet" href="css/style.css">
    <link rel="stylesheet" href="css/detail.css">

</asp:Content>

<asp:Content ID="Scripts" ContentPlaceHolderID="Scripts" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/swiper@11/swiper-bundle.min.js"></script>
    <script src="js/detail.js"></script>
</asp:Content>