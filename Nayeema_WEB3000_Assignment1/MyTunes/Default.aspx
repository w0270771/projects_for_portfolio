<%@ Page Title="Welcome" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MyTunes._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
        <h1><%: Title %>.</h1>
        <h2>MyTunes Store can help you find the perfect tunes to buy.</h2>
        <p class="lead">MyTunes, is a modified version of the popular Chinook
             database which contains data regarding the sale of audio and video 
            files. The modified database has been built with this website 
            construction in mind so some of the original Chinook tables 
            have been removed and replaced with other tables relevant to
             the construction of this website.</p>
</asp:Content>
