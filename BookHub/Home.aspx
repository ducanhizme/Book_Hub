<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="BookHub.Home"  MasterPageFile="~/Layout/_General.Master" %>

<asp:Content ID="HomeContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="banner padding-inline-l">
        <div class="banner-content">
            <button class="outline-button">Author of August</button>
            <h1>Eric-Emanuel Schmitt</h1>
            <p>Eric-Emmanuel Schmitt has been awarded more than 20 literary prizes and distinctions, and in 2001 he received the title of Chevalier des Arts et des Lettres. His books have been translated into over 40 languages.</p>
            <button class="filled-button">View his books</button>
        </div>
        <div class="discount-tag">
            <p>Autographed books + 30% discount</p>
        </div>
        <img src="Resource/book_banner.png" alt="a book">
    </div>
<div class="benefits padding-inline-l">
    <div class="benefits-group">
        <svg xmlns="http://www.w3.org/2000/svg" width="49" height="49" viewBox="0 0 49 49" fill="none">
            <path d="M19.3995 39.8668C19.3995 41.8578 17.7855 43.4718 15.7945 43.4718C13.8035 43.4718 12.1895 41.8578 12.1895 39.8668C12.1895 37.8758 13.8035 36.2618 15.7945 36.2618C17.7855 36.2618 19.3995 37.8758 19.3995 39.8668Z"
                  fill="#382C2C"/>
            <path d="M36.2228 39.8668C36.2228 41.8578 34.6088 43.4718 32.6178 43.4718C30.6268 43.4718 29.0128 41.8578 29.0128 39.8668C29.0128 37.8758 30.6268 36.2618 32.6178 36.2618C34.6088 36.2618 36.2228 37.8758 36.2228 39.8668Z"
                  fill="#382C2C"/>
            <path d="M7.38282 9.82513C6.0555 9.82513 4.97949 10.9011 4.97949 12.2285V36.2618C4.97949 37.5891 6.0555 38.6651 7.38282 38.6651H9.90634C10.463 35.9226 12.8877 33.8585 15.7945 33.8585C18.7013 33.8585 21.1259 35.9226 21.6826 38.6651H24.2061C25.5335 38.6651 26.6095 37.5891 26.6095 36.2618V12.2285C26.6095 10.9011 25.5335 9.82513 24.2061 9.82513H7.38282Z"
                  fill="#382C2C"/>
            <path d="M33.8195 17.0351C32.4921 17.0351 31.4161 18.1111 31.4161 19.4385V33.9786C31.8044 33.8998 32.2063 33.8585 32.6178 33.8585C35.5246 33.8585 37.9492 35.9226 38.5059 38.6651H41.0295C42.3568 38.6651 43.4328 37.5891 43.4328 36.2618V24.2451C43.4328 23.6077 43.1796 22.9964 42.7289 22.5457L37.9222 17.739C37.4715 17.2883 36.8602 17.0351 36.2228 17.0351H33.8195Z"
                  fill="#382C2C"/>
        </svg>
        <p>Free shiping over 50$ </p>
    </div>
    <div class="benefits-group">
        <svg xmlns="http://www.w3.org/2000/svg" width="49" height="49" viewBox="0 0 49 49" fill="none">
            <g clip-path="url(#clip0_2_179)">
                <path d="M23.8739 3.14571C24.1737 2.22312 25.4789 2.22313 25.7787 3.14572L29.9973 16.1293C30.1314 16.5419 30.5158 16.8212 30.9497 16.8212H44.6014C45.5715 16.8212 45.9748 18.0626 45.19 18.6328L34.1455 26.657C33.7945 26.912 33.6477 27.364 33.7817 27.7766L38.0004 40.7602C38.3001 41.6828 37.2442 42.45 36.4594 41.8798L25.4149 33.8555C25.0639 33.6005 24.5887 33.6005 24.2377 33.8555L13.1932 41.8798C12.4084 42.45 11.3525 41.6828 11.6522 40.7602L15.8709 27.7766C16.0049 27.364 15.8581 26.912 15.5071 26.657L4.4626 18.6328C3.6778 18.0626 4.08113 16.8212 5.0512 16.8212H18.7029C19.1368 16.8212 19.5212 16.5419 19.6553 16.1293L23.8739 3.14571Z"
                      fill="#382C2C"/>
            </g>
            <defs>
                <clipPath id="clip0_2_179">
                    <rect width="48.0667" height="48.0667" fill="white" transform="translate(0.792969 0.2146)"/>
                </clipPath>
            </defs>
        </svg>
        <p>Save with loyalty points</p>
    </div>
    <div class="benefits-group">
        <svg xmlns="http://www.w3.org/2000/svg" width="49" height="49" viewBox="0 0 49 49" fill="none">
            <path d="M22.0744 11.7607C19.5336 10.5226 16.6793 9.82788 13.6628 9.82788C10.6462 9.82788 7.79189 10.5226 5.2511 11.7607V35.7941C7.79189 34.5559 10.6462 33.8612 13.6628 33.8612C17.673 33.8612 21.3964 35.089 24.4778 37.1891C27.5591 35.089 31.2826 33.8612 35.2928 33.8612C38.3093 33.8612 41.1636 34.5559 43.7044 35.7941V11.7607C41.1636 10.5226 38.3093 9.82788 35.2928 9.82788C32.2762 9.82788 29.4219 10.5226 26.8811 11.7607V29.0545C26.8811 30.3819 25.8051 31.4579 24.4778 31.4579C23.1504 31.4579 22.0744 30.3819 22.0744 29.0545V11.7607Z"
                  fill="#382C2C"/>
        </svg>
        <p>Read a few pages </p>
    </div>
</div>
<div class="product-container padding-inline-l">
    <h2>New releases</h2>
    <div class="slider-wrapper swiper">
        <div id="bookContainer" class="product-list swiper-wrapper" runat="server">

        </div>
    </div>
</div>
    <div id="catgory_section" runat="server">
        <div class="product-container padding-inline-l">
            <h2>New releases</h2>
            <div class="slider-wrapper swiper">
                <div id="Div1" class="product-list swiper-wrapper" runat="server">
        </div>
    </div>
</div>
    </div>
<div class="subscribe">
    <h2>Subscribe to our newsletter</h2>
    <div class="input-subscribe">
        <p>Sed eu feugiat amet, libero ipsum enim pharetra hac dolor sit amet, consectetur. Elit adipiscing enim pharetra hac.</p>
        <div class="input-subscribe-group">
            <input type="email" placeholder="Enter your email" />
            <button>Send <svg class="svg-icon" viewBox="0 0 20 20">
				<path d="M17.218,2.268L2.477,8.388C2.13,8.535,2.164,9.05,2.542,9.134L9.33,10.67l1.535,6.787c0.083,0.377,0.602,0.415,0.745,0.065l6.123-14.74C17.866,2.46,17.539,2.134,17.218,2.268 M3.92,8.641l11.772-4.89L9.535,9.909L3.92,8.641z M11.358,16.078l-1.268-5.613l6.157-6.157L11.358,16.078z"></path>
			</svg></button>
        </div>
    </div>
</div>
</asp:Content>
<asp:Content ID="Head" ContentPlaceHolderID="Head" runat="server">
    <link
        rel="stylesheet"
        href="https://cdn.jsdelivr.net/npm/swiper@11/swiper-bundle.min.css"
/>
<link href="css/home.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Scripts" ContentPlaceHolderID="Scripts" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/swiper@11/swiper-bundle.min.js"></script>
    <script src="js/home.js"></script>
</asp:Content>

    
    