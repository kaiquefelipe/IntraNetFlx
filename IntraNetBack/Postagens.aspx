<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Postagens.aspx.cs" Inherits="IntraNetBack.Postagens" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="~/Components/bootstrap.css" rel="stylesheet" />
    <link href="StyleSheet1.css" rel="stylesheet" />
</head>
<body>
    <div class="container">
        <div class="row">
            <div class="col-md-4">
                <form id="form1" runat="server">
                    <div id="timeLine" runat="server">
                        <div id="totalPost" runat="server">
                            <div id="headerPost" class="headerPost" runat="server"></div>
                            <div id="rowPostContainer" class="rowPostContainer" runat="server"></div>
                            <div id="actionPost" class="actionPost" runat="server"></div>
                            <div id="resultPost" class="resultPost" runat="server"></div>
                            <div id="rowPostComment" runat="server"></div>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>
    <!--script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/js/bootstrap.min.js" integrity="sha384-alpBpkh1PFOepccYVYDB4do5UnbKysX5WZXm3XxPqe5iKTfUKjNkCk9SaVuEZflJ" crossorigin="anonymous"></script-->
</body>
</html>
