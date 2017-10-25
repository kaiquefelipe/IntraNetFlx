<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Postagens.aspx.cs" Inherits="IntraNetBack.Postagens" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" href="https://www.w3schools.com/w3css/4/w3.css" />
    <title></title>
    <link href="~/Components/bootstrap.css" rel="stylesheet" />
    <link href="StyleSheet1.css" rel="stylesheet" />
    <link rel="stylesheet" type="text/css" href="http://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.css" />

</head>
<body>
        
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="container-fluid">
                <div class="row" style="height: 100%;">
                    <div class="" style="height: 100%;">
                        <div id="ID_Div_Campo_De_Postagem" class="CL_Div_Campo_De_Postagem w3-content">
                            <div id="ID_Div_Campo_De_Postagem_Posting" class="CL_Div_Campo_De_Postagem_Posting w3-content">
                                <div class="CL_Div_Criar_Publicacao">
                                    <!-- <img src="imagens/698651-icon-135-pen-angled-16.png" class="CL_Imagem_lapis"> -->
                                    <i class="fa fa-pencil" aria-hidden="true"></i> <p class="CL_Criar_Publicacao">Criar publicação</p>
                                </div>
                                <div class="CL_Div_Album">
                                    <!-- <img src="imagens/camera-2-20.png" class="CL_Imagem_cam"> -->
                                    <i class="fa fa-camera" aria-hidden="true"></i><p class="CL_Album">Álbum de fotos/videos</p>
                                </div>
                                <div class="CL_Div_Sentimento_Atividade">
                                    <!-- <img src="imagens/misc-_smile_-16.png" class="CL_Imagem_Smile_Emoji"> --><i class="fa fa-smile-o" aria-hidden="true"></i><p class="CL_Sentimento_Atividade">Sentimento/Atividade</p>
                                </div>
                            
                                    <textarea name="" id="ID_Campo_De_Postagem" class="CL_Campo_De_Postagem" placeholder="No que você está pensando?" rows="4" runat="server" ></textarea>
                                    <!-- <input type="button" /> -->
                                    <!-- <button name="Publicar" value="Publicar" id="ID_Buton_Publicar" class onclick="FunctionPost" runat="server"></button>-->

                                <asp:Button ID="Button1" CssClass="CL_Buton_Publicar" runat="server" Text="Publicar" OnClick="Button1_Click" />

                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div id="timeLine" runat="server">
                                        <div id="totalPost" runat="server">
                                            <div id="headerPost" class="headerPost" runat="server"></div>
                                            <div id="rowPostContainer" class="rowPostContainer" runat="server"></div>
                                            <div id="actionPost" class="actionPost" runat="server"></div>
                                            <div id="resultPost" class="resultPost" runat="server"></div>
                                            <div id="rowPostComment" runat="server"></div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>  
                    </div>
                    
                    <!--  <div class="col-md-4 w3-red" style="height: 100%;overflow-y: scroll;"> -->
                        <!-- <form method="post" action="Teste.php">
                            <input type="text" name="teste">
                            <input type="submit" name="enviar" value="enviar">
                        </form> -->

                    <!-- </div>
                    <div class="col-md-3 w3-blue" style="height: 100%;overflow-y: scroll;">
                        <h2>Web Hosting</h2>
                        <p>
                            You can easily find a web hosting company that offers the right mix of features and price for your applications.
                        </p>
                        <p>
                            <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
                        </p>
                    </div>-->

                </div>
            </div> 
            <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
            <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.2.0/js/bootstrap.min.js"></script>
            <!--script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0-beta.2/js/bootstrap.min.js" integrity="sha384-alpBpkh1PFOepccYVYDB4do5UnbKysX5WZXm3XxPqe5iKTfUKjNkCk9SaVuEZflJ" crossorigin="anonymous"></script-->
          </ContentTemplate>
     </asp:UpdatePanel>
    </form>
</body>
</html>
