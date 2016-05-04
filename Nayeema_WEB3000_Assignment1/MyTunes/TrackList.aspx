
<%@ Page Title="Tracks" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
         CodeBehind="TrackList.aspx.cs" Inherits="MyTunes.TrackList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div>
            <hgroup>
                <h2><%: Page.Title %></h2>
            </hgroup>

            <asp:ListView ID="trackList" runat="server" 
                DataKeyNames="TrackId" GroupItemCount="4"
                ItemType="MyTunes.Models.Track" SelectMethod="GetTracks">
                <EmptyDataTemplate>
                    <table >
                        <tr>
                            <td>No data was returned.</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
                    <td/>
                </EmptyItemTemplate>
                <GroupTemplate>
                    <tr id="itemPlaceholderContainer" runat="server">
                        <td id="itemPlaceholder" runat="server"></td>
                    </tr>
                </GroupTemplate>
                <ItemTemplate>
                    <td runat="server">
                        <table>
                            <tr>
                                <td>
                                    <a href="TrackDetails.aspx?TrackId=<%#:Item.TrackId%>"></a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="TrackDetails.aspx?TrackId=<%#:Item.TrackId%>">
                                        <span>
                                            <%#:Item.Name%>
                                        </span>
                                    </a>
                                    <br />
                                    <span>
                                        <b>Price: </b><%#:String.Format("{0:c}", Item.UnitPrice)%>
                                    </span>
                                    <br />

                                    <a href="/AddToCart.aspx?trackID=<%#:Item.TrackId %>">               
                                        <span class="TrackListItem">
                                            <b>Add To Cart<b>
                                        </span>           
                                    </a>

                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                        </p>
                    </td>
                </ItemTemplate>
                <LayoutTemplate>
                    <table style="width:100%;">
                        <tbody>
                            <tr>
                                <td>
                                    <table id="groupPlaceholderContainer" runat="server" style="width:100%">
                                        <tr id="groupPlaceholder"></tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                            <tr></tr>
                        </tbody>
                    </table>
                </LayoutTemplate>
            </asp:ListView>
        </div>
        <asp:DataPager ID="TrackListPager" runat="server"
            PagedControlID="trackList" PageSize="30">
            <Fields>
                <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False" />
                <asp:NumericPagerField></asp:NumericPagerField>
                <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" ShowNextPageButton="False" ShowPreviousPageButton="False"></asp:NextPreviousPagerField>
            </Fields>
        </asp:DataPager> 
    </section>
</asp:Content>