<%@ Control Language="C#" AutoEventWireup="true" CodeFile="EventBackEnd.ascx.cs" Inherits="UserControl_EventBackEnd" %>
<%--<asp:GridView ID="BasicEvents" runat="server" 
              OnSelectedIndexChanged="BasicEvents_SelectedIndexChanged" >
</asp:GridView>--%>
<%--<asp:GridView ID="Participants" runat="server">
</asp:GridView>--%>
<div class="Events">
    <div class="EventsList">
        <span class="events_list_title">Events</span>
        <br />
        <asp:ListBox ID="events_list" runat="server"></asp:ListBox>
    </div>
    <div class="EventsProgram">
        <span class="events_list_title">Event Program</span>
        <br />
        <asp:ListBox ID="events_program" runat="server"></asp:ListBox>
    </div>
    <div class="EventsButtons">
        <asp:Button ID="Add" runat="server" Text="Add Event" />
        <asp:Button ID="Delete" runat="server" Text="Delete Event" />
    </div>
    <div class="AddEvent">
        <asp:Label ID="lblName" runat="server" Text="Event Name"></asp:Label>
        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
        
        <br />
            
            
        <asp:Label ID="lblStartDateTime" runat="server" Text="Start Date"></asp:Label>
        <asp:TextBox ID="txtStartDateTime"  runat="server"></asp:TextBox>
        
        <br />
        
        <asp:Label ID="lblEndDateTime" runat="server" Text="End Date"></asp:Label>
        <asp:TextBox ID="txtEndDateTime" runat="server"></asp:TextBox>
        
        <br />
        
        <asp:Label ID="lblNoOfMin" runat="server" Text="Minimum Participants"></asp:Label>
        <asp:TextBox ID="txtNoOfMin" runat="server"></asp:TextBox>
        
        <br />
        
        <asp:Label ID="lblNoOfMax" runat="server" Text="Maximum Participants"></asp:Label>
        <asp:TextBox ID="txtNoOfMax" runat="server"></asp:TextBox>
        
        <br />
        
        <asp:Label ID="lblConditions" runat="server" Text="Condtitions"></asp:Label>
        <asp:TextBox ID="txtConditions" runat="server"></asp:TextBox>
        
        <br />
        
        <%--<asp:Label ID="lblStatus" runat="server" Text="Status"></asp:Label>
        <asp:TextBox ID="txtStatus" runat="server"></asp:TextBox>--%>
        
        <br />
        
        <asp:Label ID="lblLocation" runat="server" Text="Location"></asp:Label>
        <asp:TextBox ID="txtLocation" runat="server"></asp:TextBox>
        
        <br />
        
        <%--<asp:Label ID="lblType" runat="server" Text="Type"></asp:Label>
        <asp:TextBox ID="txtType" runat="server"></asp:TextBox>--%>
        
        <br />
        
        <asp:Label ID="lblPrice" runat="server" Text="Price"></asp:Label>
        <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox>
            
        <br />
            
        <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
        <asp:TextBox ID="txtDescription" runat="server"></asp:TextBox>
        <asp:Label ID="Label1" runat="server" Text=" euro"></asp:Label>
            
        <br />
            
        <asp:Label ID="lblIsMainEvent" runat="server" Text="Main Event?"></asp:Label>
        <asp:CheckBox ID="btnIsMainEvent" runat="server" />
        
        <br />
            
        <%--<asp:Label ID="Label13" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="TextBox13" runat="server"></asp:TextBox>
            
        <br />
            
        <asp:Label ID="Label14" runat="server" Text="Label"></asp:Label>
        <asp:TextBox ID="TextBox14" runat="server"></asp:TextBox>
        
        <br />--%>
    </div>
</div>