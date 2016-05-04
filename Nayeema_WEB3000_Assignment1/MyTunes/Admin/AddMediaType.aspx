<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddMediaType.aspx.cs" Inherits="MyTunes.Admin.AddMediaType" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<h1>Administration</h1>
    <hr />
    <table>
        <tr><td>
            <h3><a href="AdminPage.aspx"></a>
       <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin/AddMediaType.aspx">Add MediaType</asp:HyperLink></h3>
            </td>
            <td>
               
            <h3><a href="AdminPage.aspx"></a>
       <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Admin/AddArtist.aspx">Add Artist</asp:HyperLink></h3>
            </td>
            <td>
            <h3><a href="AdminPage.aspx"></a>
       <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Admin/AddGenre.aspx">Add Genre</asp:HyperLink></h3>
            </td>
            <td>
            <h3><a href="AdminPage.aspx"></a>
       <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/AddMediaType.aspx">Add MediaType</asp:HyperLink></h3>
            </td>
            <td>
               
            <h3><a href="AdminPage.aspx"></a>
       <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Admin/AdminPage.aspx">Add Track</asp:HyperLink></h3>
            </td>
        </tr>
    </table>
    <h3>Add MediaType:</h3>
    <table>
        <tr>
           <td><asp:Label ID="LabelAddName" runat="server">Name:</asp:Label></td>
            <td>
                <asp:TextBox ID="AddMediaTypeName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Text="* MediaType name required." ControlToValidate="AddMediaTypeName" SetFocusOnError="true" Display="Dynamic"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="LabelAddMediaCategory" runat="server">MediaCategory:</asp:Label></td>
            <td>
                <asp:DropDownList ID="DropDownMediaCategory" runat="server" 
                    ItemType="MyTunes.Models.MediaCategory" 
                    SelectMethod="GetMediaCategories" DataTextField="Name" 
                    DataValueField="MediaCategoryId" >
                </asp:DropDownList>
            </td>
        </tr>
        
    </table>
    <p></p>
    <p></p>
    <asp:Button ID="AddMediaTypeButton" runat="server" Text="Add MediaType" OnClick="AddMediaTypeButton_Click"  CausesValidation="true"/>
    <asp:Label ID="LabelAddStatus" runat="server" Text=""></asp:Label>

   
   
</asp:Content>


