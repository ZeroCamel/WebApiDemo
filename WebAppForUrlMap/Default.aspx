<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebAppForUrlMap.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>

    <form id="form1" runat="server">
        <div id="page">
            <asp:GridView ID="GridViewEmployees" runat="server" AutoGenerateColumns="false" Width="100%">
                <Columns>
                    <asp:HyperLinkField HeaderText="姓名" DataTextField="Name" DataNavigateUrlFields="Name,Id"
                        DataNavigateUrlFormatString="~/employees/{0}/{1}" />
                    <asp:BoundField DataField="Gender" HeaderText="性别" />
                    <asp:BoundField DataField="BirthDate" HeaderText="出身年月" />
                    <asp:BoundField DataField="DepartMent" HeaderText="部门" />
                </Columns>
            </asp:GridView>
            <asp:DetailsView ID="DetailViewEmployee" runat="server" AutoGenerateRows="false" Width="100%">
                <Fields>
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="Name" HeaderText="Name"/>
                    <asp:BoundField DataField="Gender" HeaderText="Gender"/>
                    <asp:BoundField DataField="BirthDate" HeaderText="BirthDate"/>
                    <asp:BoundField DataField="DepartMent" HeaderText="DepartMent"/>
                </Fields>
            </asp:DetailsView>
        </div>
    </form>

    <script src="scripts/jquery-1.10.2.min.js"></script>
    <script src="scripts/bootstrap.js"></script>
    <script src="scripts/bootstrap.min.js"></script>
    <script src="scripts/knockout-3.4.2.js"></script>
    <script src="scripts/viewmodel.js"></script>

</body>
</html>
