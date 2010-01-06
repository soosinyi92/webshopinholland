<%@ Control Language="C#" AutoEventWireup="true" EnableViewState="true" CodeFile="EventBackEnd.ascx.cs" Inherits="UserControl_EventBackEnd" %>
<%--<asp:GridView ID="BasicEvents" runat="server" 
              OnSelectedIndexChanged="BasicEvents_SelectedIndexChanged" >
</asp:GridView>--%>
<%--<asp:GridView ID="Participants" runat="server">
</asp:GridView>--%>
<div class="Events">
    <div class="EventsList">
        <span class="events_list_title">Events</span>
        <br />
        <asp:ListBox ID="events_list" runat="server" 
            onselectedindexchanged="events_list_SelectedIndexChanged" AutoPostBack="true" ></asp:ListBox>
    </div>
    <div class="EventsProgram">
        <span class="events_list_title">Event Program</span>
        <br />
        <asp:ListBox ID="events_program" runat="server"></asp:ListBox>
    </div>
    <div class="clear"></div>
    <div class="EventsButtons">
        <asp:Button ID="Delete" runat="server" Text="Delete Event" 
            onclick="Delete_Click" />
    </div>
    <table class="AddEvent">
        <tr>
            <th><asp:Label ID="lblName" runat="server" Text="Event Name"></asp:Label></th>
            <td><asp:TextBox ID="txtName" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <th><asp:Label ID="lblStartDateTime" runat="server" Text="Start Date"></asp:Label></th>
            <td><asp:TextBox ID="txtStartDateTime"  runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <th><asp:Label ID="lblEndDateTime" runat="server" Text="End Date"></asp:Label></th>
            <td><asp:TextBox ID="txtEndDateTime" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <th><asp:Label ID="lblNoOfMin" runat="server" Text="Minimum Participants"></asp:Label></th>
            <td><asp:TextBox ID="txtNoOfMin" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <th><asp:Label ID="lblNoOfMax" runat="server" Text="Maximum Participants"></asp:Label></th>
            <td><asp:TextBox ID="txtNoOfMax" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <th><asp:Label ID="lblConditions" runat="server" Text="Condtitions"></asp:Label></th>
            <td><asp:TextBox ID="txtConditions" runat="server"></asp:TextBox></td>
        </tr>
        
        <%--<asp:Label ID="lblStatus" runat="server" Text="Status"></asp:Label>
        <asp:TextBox ID="txtStatus" runat="server"></asp:TextBox>--%>
        <tr>
            <th><asp:Label ID="lblLocation" runat="server" Text="Location"></asp:Label></th>
            <td><asp:TextBox ID="txtLocation" runat="server"></asp:TextBox></th>
        </tr>
        <%--<asp:Label ID="lblType" runat="server" Text="Type"></asp:Label>
        <asp:TextBox ID="txtType" runat="server"></asp:TextBox>--%>
        <tr>
            <th><asp:Label ID="lblPrice" runat="server" Text="Price"></asp:Label></th>
            <td><asp:TextBox ID="txtPrice" runat="server"></asp:TextBox></td>
            <td><asp:Label ID="Label1" runat="server" Text=" euro"></asp:Label></td>
        </tr>
        <tr>
            <th><asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label></th>
            <td>
                <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <th><asp:Label ID="lblIsMainEvent" runat="server" Text="Main Event?"></asp:Label></th>
            <%--<td><asp:CheckBox ID="btnIsMainEvent" runat="server" /></td>--%>
            <td>
                <asp:DropDownList ID="ddltIsMainEvent" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
        <%--<asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
            
        <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
        
        <br />--%>
    </table>
    <asp:Button ID="Add" runat="server" Text="Add Event" onclick="Add_Click" />
    <asp:Button ID="Update" runat="server" Text="Update Event" 
        onclick="Update_Click" />
        
</div>