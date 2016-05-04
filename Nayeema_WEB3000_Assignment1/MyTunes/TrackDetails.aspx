<%@ Page Title="Track Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
         CodeBehind="TrackDetails.aspx.cs" Inherits="MyTunes.TrackDetails" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="trackDetail" runat="server" ItemType="MyTunes.Models.Track" SelectMethod="GetTrack" RenderOuterTable="false">
        <ItemTemplate>
            <div>
                <h1><%#:Item.Name %></h1>
            </div>
            <br />
            <table>
                <tr>
                    <td>&nbsp;</td>
                    <td style="vertical-align: top; text-align: left;">
                        <b>Album:</b><br />
                        <%#:Item.Album.Title %>
                        <br />
                         <b>Artist:</b><br />
                        <%#:Item.Album.Artist.Name %>
                        <br />
                        <b>Genre:</b><br />
                        <%#:Item.Genre.Name %>
                        <br />
                        <b>MediaCategory:</b><br />
                        <%#:Item.MediaType.MediaCategory.Name %>
                        <br />
                        <b>MediaType:</b><br />
                        <%#:Item.MediaType.Name %>
                        <br />
                        <b>Composer:</b><br />
                        <%#:Item.Composer %>
                        <br />
                        <b>Milliseconds:</b><br />
                        <%#:Item.Milliseconds %>
                        <br />
                        <b>Bytes:</b><br />
                        <%#:Item.Bytes %>
                        <br />
                        <span><b>Price:</b>&nbsp;<%#: String.Format("{0:c}", Item.UnitPrice) %></span>
                        <br />
                        <span><b>Product Number:</b>&nbsp;<%#:Item.TrackId %></span>
                        <br />
                        <a href="/AddToCart.aspx?trackID=<%#:Item.TrackId %>">               
                                        <span class="TrackListItem">
                                            <b>Add To Cart<b>
                                        </span>           
                                    </a>

                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>


