<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EventSummary.ascx.cs" Inherits="UserControl_EventSummary" %>
<div class="event_summary">
    <div class="event_img">
        <asp:ImageButton ID="ImageButton1" runat="server" 
            onclick="ImageButton1_Click" />
    </div>
    <div class="event_info">
    
<asp:LinqDataSource ID="LinqDataSource1" runat="server" ContextTypeName="WebshopDataContext" 
    Select="new (ID, Name, StsrtDateTime, EndDateTime, NOfInterested, NOfPaid, Location, Price, EventImages, EventOrganizers)" 
    TableName="Events" Where="ID == @ID">
            <WhereParameters>
                <asp:Parameter DefaultValue="0" Name="ID" Type="Int64" />
            </WhereParameters>
</asp:LinqDataSource>

<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:ASPNETDBConnectionString %>" 
            SelectCommand="SELECT * FROM [Events] WHERE ([ID] = @ID)">
    <SelectParameters>
        <asp:Parameter DefaultValue="7" Name="ID" Type="Int64" />
    </SelectParameters>
        </asp:SqlDataSource>

<asp:DataList ID="DataList1" runat="server" DataSourceID="LinqDataSource1">
    <ItemTemplate>
        Name:
        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
        <br />
        Start:
        <asp:Label ID="StsrtDateTimeLabel" runat="server"
            Text='<%# Eval("StsrtDateTime") %>' />
        <br />
        End:
        <asp:Label ID="EndDateTimeLabel" runat="server" 
            Text='<%# Eval("EndDateTime") %>' />
        <br />
        Location:
        <asp:Label ID="LocationLabel" runat="server" Text='<%# Eval("Location") %>' />
        <br />
        Price:
        <asp:Label ID="PriceLabel" runat="server" Text='<%# Eval("Price") %>' />
        <br />
    </ItemTemplate>
</asp:DataList>
    </div>
</div>

