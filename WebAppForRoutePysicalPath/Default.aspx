<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebAppForRoutePysicalPath.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
        <table class="table table-striped">
            <thead>
                <tr>
                    <th>RouteCollection.RouteExistingFiles</th>
                    <th colspan="2">TRUE</th>
                    <th colspan="2">FALSE</th>
                </tr>
                <tr>
                    <th>Route.RouteExistingFiles</th>
                    <th>True</th>
                    <th>False</th>
                    <th>True</th>
                    <th>False</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>Route.GetRouteData()</td>
                    <td><%=GetRouteData(RouteOrRouteCollection.Route,true,true)==null?"null":"RouteData" %></td>
                    <td><%=GetRouteData(RouteOrRouteCollection.Route,true,false)==null?"null":"RouteData" %></td>
                    <td><%=GetRouteData(RouteOrRouteCollection.Route,false,true)==null?"null":"RouteData" %></td>
                    <td><%=GetRouteData(RouteOrRouteCollection.Route,false,false)==null?"null":"RouteData" %></td>
                </tr>
                <tr>
                    <td>RouteCollection.GetRouteData()</td>
                    <td><%=GetRouteData(RouteOrRouteCollection.RouteCollection,true,true)==null?"null":"RouteData" %></td>
                    <td><%=GetRouteData(RouteOrRouteCollection.RouteCollection,true,false)==null?"null":"RouteData" %></td>
                    <td><%=GetRouteData(RouteOrRouteCollection.RouteCollection,false,true)==null?"null":"RouteData" %></td>
                    <td><%=GetRouteData(RouteOrRouteCollection.RouteCollection,false,false)==null?"null":"RouteData" %></td>
                </tr>
            </tbody>
        </table>
    </form>
    <script src="scripts/jquery-1.10.2.min.js"></script>
    <script src="scripts/bootstrap.js"></script>
    <script src="scripts/bootstrap.min.js"></script>
</body>
</html>
