using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.HtmlControls;

namespace IntraNetBack
{
    public class Utils
    {        
        static string connectionString = null;
        //1-definição das informações para montar a string de conexão
        static string Server = "192.168.254.193";
        static string Username = "sa";
        static string Password = "fxm@sterb1";
        static string Database = "IntraNet";

        public static void buildPost(int idPost, HtmlGenericControl elementGrandfather)
        {
            //2-montagem da string de conexão
            connectionString = "Data Source=" + Server + ";";
            connectionString += "User ID=" + Username + ";";
            connectionString += "Password=" + Password + ";";
            connectionString += "Initial Catalog=" + Database;

            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataReader sqlDataReader;
            connection.Open();
            int count = 1;

            string sSQL = @"
                SELECT 
	                [Posting_Text] = t0.Posting_Text, 
	                [TotalLike] = (SELECT COUNT(t1.Like_TypeID) FROM [dbo].[Post_Likes] t1 WHERE t1.Like_PostingID = '" + idPost + @"'),
	                [Interact_Text] = t2.Interact_Text,
	                [Schedule] = (CASE
					                WHEN (DATEDIFF(DAY, t0.Posting_DateTime, GETDATE())) >= 1 THEN CONVERT(VARCHAR(10), t0.Posting_DateTime, 103)
					                WHEN (DATEDIFF(SECOND, t0.Posting_DateTime, GETDATE()) / 60) < 1 THEN ' Agora mesmo'
					                WHEN (DATEDIFF(MINUTE, t0.Posting_DateTime, GETDATE()) / 60) < 1 THEN CAST((DATEDIFF(MINUTE, t0.Posting_DateTime, GETDATE())) AS VARCHAR(100)) + ' Minuto(s)'
					                WHEN (DATEDIFF(HOUR, t0.Posting_DateTime, GETDATE()) / 60) < 1 THEN CAST((DATEDIFF(HOUR, t0.Posting_DateTime, GETDATE())) AS VARCHAR(100)) + ' Hora(s)'
				                END),
	                [NameUser] = t3.User_Nome
                FROM 
	                [dbo].[Posts] t0 
	                LEFT JOIN [dbo].[Posts_Interact] t2 ON t2.Interact_PostingID = '" + idPost + @"'
                    LEFT JOIN [dbo].[Users] t3 ON t3.UserID = t0.Posting_UserID
                WHERE t0.Posting_ID = '" + idPost + @"'
            ";

            SqlCommand command = new SqlCommand(sSQL, connection);
            sqlDataReader = command.ExecuteReader();

            bool firstLine = true;
            if (sqlDataReader.HasRows)
            {
                System.Web.UI.HtmlControls.HtmlGenericControl element = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                while (sqlDataReader.Read())
                {
                    if (firstLine)
                    {
                        firstLine = false;
                        // ---------------------------------------------------------------------------////--------------------------------------------------------------------//
                        // Create
                        // ---------------------------------------------------------------------------////--------------------------------------------------------------------//

                        System.Web.UI.HtmlControls.HtmlGenericControl createDiv = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        System.Web.UI.HtmlControls.HtmlGenericControl createDivInter = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        System.Web.UI.HtmlControls.HtmlGenericControl createDivInterContent = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        System.Web.UI.HtmlControls.HtmlGenericControl createImgInter = new System.Web.UI.HtmlControls.HtmlGenericControl("IMG");

                        
                        System.Web.UI.HtmlControls.HtmlGenericControl rowPostContainer = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");

                        System.Web.UI.HtmlControls.HtmlGenericControl createP = new System.Web.UI.HtmlControls.HtmlGenericControl("P");
                        System.Web.UI.HtmlControls.HtmlGenericControl actionPost = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        System.Web.UI.HtmlControls.HtmlGenericControl createDivLikeAndInteract = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        System.Web.UI.HtmlControls.HtmlGenericControl createDivLike = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        System.Web.UI.HtmlControls.HtmlGenericControl createDivInteract = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        System.Web.UI.HtmlControls.HtmlGenericControl createButtonLike = new System.Web.UI.HtmlControls.HtmlGenericControl("BUTTON");
                        System.Web.UI.HtmlControls.HtmlGenericControl createButtonInteract = new System.Web.UI.HtmlControls.HtmlGenericControl("BUTTON");
                        // --------------------------------------------------------- START HEADER --------------------------------------------------------- //
                        System.Web.UI.HtmlControls.HtmlGenericControl headerPost = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");

                        System.Web.UI.HtmlControls.HtmlGenericControl involvesHeaderPost = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        System.Web.UI.HtmlControls.HtmlGenericControl divImgCurrentPerfilPost = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        System.Web.UI.HtmlControls.HtmlGenericControl involvesDataUserPosted = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        System.Web.UI.HtmlControls.HtmlGenericControl imgCurrentPerfil = new System.Web.UI.HtmlControls.HtmlGenericControl("IMG");
                        System.Web.UI.HtmlControls.HtmlGenericControl NameUserCurrent = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        System.Web.UI.HtmlControls.HtmlGenericControl PublishingSchedule = new System.Web.UI.HtmlControls.HtmlGenericControl("SPAN");
                        // --------------------------------------------------------- END HEADER --------------------------------------------------------- //


                        // ---------------------------------------------------------------------------////--------------------------------------------------------------------//
                        // ID
                        // ---------------------------------------------------------------------------////--------------------------------------------------------------------//

                        createDiv.ID = "ID_Div_PostagemRow" + count;
                        //createDivInter.ID = "ID_Div_";
                        //createDivInterContent.ID = "ID_Div_";
                        //createImgInter.ID = "";
                        createP.ID = "ID_P_Text_Post";
                        createDivLikeAndInteract.ID = "ID_Div_Like_And_Interact";
                        createDivLike.ID = "ID_Div_Like";
                        createDivInteract.ID = "ID_Div_Interact";
                        createButtonLike.ID = "ID_Button_Like";
                        createButtonInteract.ID = "ID_Button_Like";
                        element.ID = "totalPost" + count;




                        // ---------------------------------------------------------------------------////--------------------------------------------------------------------//
                        // Class
                        // ---------------------------------------------------------------------------////--------------------------------------------------------------------//



                        createDiv.Attributes["class"] = "CL_Div_PostagemRow";
                        //createDivInter.Attributes["class"] = "postagemRowImage";// ADICIONAR QUANDO TIVER SUPORTE PARA IMAGEM
                        createDivInterContent.Attributes["class"] = "CL_Div_PostagemRowContent w3-content";
                        createImgInter.Attributes["class"] = "postagemImgImage";
                        createP.Attributes["class"] = "CL_text";
                        createDivLikeAndInteract.Attributes["class"] = "w3-row CL_Like_And_Interact";
                        createDivLike.Attributes["class"] = "CL_Like";
                        createDivInteract.Attributes["class"] = "CL_Interact";
                        createButtonLike.Attributes["class"] = "CL_Button_Like";
                        createButtonInteract.Attributes["class"] = "CL_Button_Interact";
                        rowPostContainer.Attributes["class"] = "rowPostContainer";
                        headerPost.Attributes["class"] = "headerPost";
                        element.Attributes["class"] = "totalPost";


                        involvesHeaderPost.Attributes["class"] = "involvesHeaderPost";
                        divImgCurrentPerfilPost.Attributes["class"] = "divImgCurrentPerfilPost";
                        involvesDataUserPosted.Attributes["class"] = "involvesDataUserPosted";
                        imgCurrentPerfil.Attributes["class"] = "imgCurrentPerfil";
                        NameUserCurrent.Attributes["class"] = "NameUserCurrent";
                        PublishingSchedule.Attributes["class"] = "PublishingSchedule";


                        //createDivInter.Controls.Add(createImgInter); // ADICIONAR QUANDO TIVER SUPORTE PARA IMAGEM
                        //createDiv.Controls.Add(createDivInter); // ADICIONAR QUANDO TIVER SUPORTE PARA IMAGEM



                        // ---------------------------------------------------------------------------////--------------------------------------------------------------------//
                        // InnerHtml
                        // ---------------------------------------------------------------------------////--------------------------------------------------------------------//


                        createP.InnerHtml = sqlDataReader["Posting_Text"].ToString();
                        //createDivInter.Controls.Add(createImgInter); // ADICIONAR QUANDO TIVER SUPORTE PARA IMAGEM
                        //createDiv.Controls.Add(createDivInter); // ADICIONAR QUANDO TIVER SUPORTE PARA IMAGEM
                        createDivLike.InnerHtml = ((Convert.ToInt32(sqlDataReader["TotalLike"].ToString()) > 0) ? sqlDataReader["TotalLike"].ToString() + "Curtida(s)" : "");


                        // ---------------------------------------------------------------------------////--------------------------------------------------------------------//
                        // resto
                        // ---------------------------------------------------------------------------////--------------------------------------------------------------------//
                        //imgCurrentPerfil.InnerHtml = @"C:\Users\DESENV5\Documents\Visual Studio 2015\Projects\IntraNetBack\IntraNetBack\Imagens\perfilRoni.jpg";
                        imgCurrentPerfil.Attributes["src"] = "https://uploaddeimagens.com.br/images/001/145/888/full/perfilRoni.jpg";
                        divImgCurrentPerfilPost.Controls.Add(imgCurrentPerfil);
                        involvesHeaderPost.Controls.Add(divImgCurrentPerfilPost);
                        NameUserCurrent.InnerHtml = sqlDataReader["NameUser"].ToString();
                        involvesDataUserPosted.Controls.Add(NameUserCurrent);
                        PublishingSchedule.InnerHtml = sqlDataReader["Schedule"].ToString();
                        involvesDataUserPosted.Controls.Add(PublishingSchedule);
                        involvesHeaderPost.Controls.Add(involvesDataUserPosted);
                        headerPost.Controls.Add(involvesHeaderPost);
                        element.Controls.Add(headerPost);


                        createDivInterContent.Controls.Add(createP);
                        createDiv.Controls.Add(createDivInterContent);
                        //createDiv.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#333");
                        rowPostContainer.Controls.Add(createDiv);
                        element.Controls.Add(rowPostContainer);

                        //Div Action
                        createDivLikeAndInteract.Controls.Add(createDivLike);
                        createDivLikeAndInteract.Controls.Add(createDivInteract);
                        //createDivAction.Controls.Add(createDivLikeAndInteract)
                        actionPost.Controls.Add(createDivLikeAndInteract);
                        element.Controls.Add(actionPost);
                    }

                    System.Web.UI.HtmlControls.HtmlGenericControl createDivComment = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                    System.Web.UI.HtmlControls.HtmlGenericControl createDivCommentText = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");

                    System.Web.UI.HtmlControls.HtmlGenericControl rowPostComment = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                    rowPostComment.Attributes["class"] = "rowPostComment";

                    createDivComment.ID = "ID_Div_PostagemCommentRow" + count;
                    createDivComment.Attributes["class"] = "CL_Div_PostagemCommentRow";
                    createDivCommentText.Attributes["class"] = "CL_Div_ContentCommentRow";
                    createDivCommentText.InnerHtml = sqlDataReader["Interact_Text"].ToString();

                    createDivComment.Controls.Add(createDivCommentText);
                    rowPostComment.Controls.Add(createDivComment);

                    element.Controls.Add(rowPostComment);
                    count++;
                }
                elementGrandfather.Controls.Add(element);
            }

            sqlDataReader.Close();
            connection.Close();


        }

    }
}