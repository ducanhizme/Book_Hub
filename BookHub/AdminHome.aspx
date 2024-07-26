<%@ Page Language="C#" CodeBehind="AdminHome.aspx.cs" Inherits="BookHub.AdminHome" MasterPageFile="~/Layout/_AdminLayout.master"%>

<asp:Content ID="AdminHome" ContentPlaceHolderID="MainContent" runat="server">
    <section class="content">
        <div class="filter-container">
           <form action="AdminHome.aspx?action=search" runat="server">
                <input type="text" id="searchBar" placeholder="Search by Book Name" name="search-key">
           </form>
            <div class="dropdown" id="entitySelectDropdown">
                <button class="dropbtn">All Entities</button>
                <div class="dropdown-content">
                    <a href="#" data-value="all">All Entities</a>
                    <a href="#" data-value="books">Books</a>
                </div>
            </div>
            
            <div class="dropdown" >
                <button class="dropbtn">All Categories</button>
                <div class="dropdown-content" id="categoryFilter" runat="server">
                    <a href="/AdminHome.aspx?action=filter&orderBy=category&categoryId=all" data-value="all">All Categories</a>
                </div>
            </div>
            
            <div class="dropdown" id="priceSortDropdown">
                <button class="dropbtn">Sort by Price</button>
                <div class="dropdown-content">
                    <a href="#" data-value="none">Sort by Price</a>
                    <a href="#" data-value="asc">Low to High</a>
                    <a href="#" data-value="desc">High to Low</a>
                </div>
            </div>
            
            <div class="dropdown" id="dateSortDropdown">
                <button class="dropbtn">Sort by Publication Date</button>
                <div class="dropdown-content">
                    <a href="#" data-value="none">Sort by Publication Date</a>
                    <a href="#" data-value="asc">Oldest to Newest</a>
                    <a href="#" data-value="desc">Newest to Oldest</a>
                </div>
            </div>
        </div>
        <div class="table-container">
            <table class="book-table">
                <thead>
                    <tr>
                        <th>Book ID</th>
                        <th>Book Name</th>
                        <th>Author</th>
                        <th>Price</th>
                        <th>Language</th>
                        <th>Publication Date</th>
                        <th>Image</th>
                        <th>Edit</th>
                        <th>Delete</th>
                    </tr>
                </thead>
                <tbody id="bookTableBody" runat="server">
                    <tr>
                        <td class="book-id">1</td>
                        <td>Sample Book</td>
                        <td>John Doe</td>
                        <td class="price">$19.99</td>
                        <td class="language">English</td>
                        <td class="publication-date">2023-10-01</td>
                        <td><img src="https://images-na.ssl-images-amazon.com/images/S/compressed.photo.goodreads.com/books/1531891848i/11.jpg" alt="Book Image" class="book-image"></td>
                        <td><button class="edit-button">Edit</button></td>
                        <td><button class="delete-button">Delete</button></td>
                    </tr>
                   
                </tbody>
            </table>
        </div>
    </section>
</asp:Content>

<asp:Content ID="AdminStyle" ContentPlaceHolderID="Head" runat="server">
    <link rel="stylesheet" href="css/admin.css" >
</asp:Content>