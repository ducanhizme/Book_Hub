﻿<%@ Page Language="C#" CodeBehind="AdminHome.aspx.cs" Inherits="BookHub.AdminHome" MasterPageFile="~/Layout/_AdminLayout.master"%>

<asp:Content ID="AdminHome" ContentPlaceHolderID="MainContent" runat="server">
    <form class="content" action="AdminHome.aspx" runat="server" method="post">
        <div class="filter-container">
            <input type="text" id="searchBar" placeholder="Search by Book Name" name="search-key">
            <%-- <div class="dropdown" id="entitySelectDropdown"> --%>
            <%--     <button class="dropbtn">All Entities</button> --%>
            <%--     <div class="dropdown-content"> --%>
            <%--         <a href="#" data-value="all">All Entities</a> --%>
            <%--         <a href="#" data-value="books">Books</a> --%>
            <%--     </div> --%>
            <%-- </div> --%>
            <div class="dropdown">
                <button class="dropbtn">All Categories</button>
                <div class="dropdown-content" id="categoryFilter" runat="server">
                    <a href="/AdminHome.aspx?action=filter&orderBy=category&categoryId=all" data-value="all">All Categories</a>
                </div>
            </div>

            <div class="dropdown" id="priceSortDropdown">
                <button class="dropbtn">Sort by Price</button>
                <div class="dropdown-content">
                    <a href="AdminHome.aspx?action=filter&orderBy=price&type=all" >Sort by Price</a>
                    <a href="AdminHome.aspx?action=filter&orderBy=price&type=asc" >Low to High</a>
                    <a href="AdminHome.aspx?action=filter&orderBy=price&type=desc" >High to Low</a>
                </div>
            </div>

            <div class="dropdown" id="dateSortDropdown">
                <button class="dropbtn">Sort by Publication Date</button>
                <div class="dropdown-content">
                    <a href="AdminHome.aspx?action=filter&orderBy=date&type=all" >Sort by Publication Date</a>
                    <a href="AdminHome.aspx?action=filter&orderBy=date&type=asc" >Oldest to Newest</a>
                    <a href="AdminHome.aspx?action=filter&orderBy=date&type=desc" >Newest to Oldest</a>
                </div>
            </div>
            <a href="#popup1" class="edit-button">Create Book</a>
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
                </tbody>
            </table>
        </div>
        <div id="popup1" class="overlay">
            <div class="popup">
                <a class="close" href="#">&times;</a>
                <div class="form-container">
                    <h2>Create Book</h2>
                    <div class="form">
                        <div class="form-group">
                            <label for="bookName">Book Name</label>
                            <input type="text" id="bookName" name="bookName">
                        </div>
                        <div class="form-group">
                            <label for="author">Author</label>
                            <input type="text" id="author" name="author">
                        </div>
                        <div class="form-group">
                            <label for="publisherId">Publisher</label>
                            <select id="publisherId" name="publisherId" runat="server">
                            </select>
                        </div>
                        <div class="form-group">
                            <label for="price">Price</label>
                            <input type="number" id="price" name="price" value="0" step="0.01">
                        </div>
                        <div class="form-group">
                            <label for="description">Description</label>
                            <textarea id="description" name="description" rows="4" ></textarea>
                        </div>
                        <div class="form-group">
                            <label for="language">Language</label>
                            <input type="text" id="language" name="language">
                        </div>
                        <div class="form-group">
                            <label for="publicationDate">Publication Date</label>
                            <input type="date" id="publicationDate" name="publicationDate" value="2024-07-22">
                        </div>
                        <div class="form-group">
                            <label for="readingAge">Reading Age</label>
                            <input type="number" id="readingAge" name="readingAge" value="0">
                        </div>
                        <div class="form-group">
                            <label for="printLength">Print Length</label>
                            <input type="number" id="printLength" value="0" name="printLength">
                        </div>
                        <div class="form-group">
                            <label for="dimensions">Dimensions</label>
                            <input type="text" id="dimensions" name="dimensions">
                        </div>
                        <div class="form-group">
                            <label for="image">Image URL</label>
                            <input type="url" id="image" name="image">
                        </div>
                    </div>
                    <button type="submit" name="action" value="Create">Submit</button>
                </div>
            </div>
        </div>
    </form>

</asp:Content>

<asp:Content ID="AdminStyle" ContentPlaceHolderID="Head" runat="server">
    <link rel="stylesheet" href="css/admin.css">
</asp:Content>