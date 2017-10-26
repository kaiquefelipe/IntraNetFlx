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
        public SqlConnection conexaoSQLServer;     
        static string connectionString = null;
        //1-definição das informações para montar a string de conexão
        static string Server = "192.168.254.193";
        static string Username = "sa";
        static string Password = "fxm@sterb1";
        static string Database = "IntraNet";
        //public int count = 1;


        public static int getValueMaxID()
        {
            //2-montagem da string de conexão
            connectionString = "Data Source=" + Server + ";";
            connectionString += "User ID=" + Username + ";";
            connectionString += "Password=" + Password + ";";
            connectionString += "Initial Catalog=" + Database;

            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataReader sqlDataReader;
            connection.Open();
            int max = 0;
            string sSQL = @"
                SELECT 
	                [LastPostID] = MAX(t0.Posting_ID)
                FROM 
	                [dbo].[Posts] t0 
            ";

            SqlCommand command = new SqlCommand(sSQL, connection);
            sqlDataReader = command.ExecuteReader();
           
            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    string teste = sqlDataReader["LastPostID"].ToString();
                    if (string.IsNullOrEmpty(teste)) {
                        
                    }else
                    {
                        max = Convert.ToInt32(sqlDataReader["LastPostID"].ToString());
                    }
                    
                }
            }

            sqlDataReader.Close();
            connection.Close();

            return max;
        }

        public static void buildPost(int idPost, HtmlGenericControl elementGrandfather)
        {

            System.Web.UI.HtmlControls.HtmlGenericControl element = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
            element.InnerHtml = "";





            //2-montagem da string de conexão
            connectionString = "Data Source=" + Server + ";";
            connectionString += "User ID=" + Username + ";";
            connectionString += "Password=" + Password + ";";
            connectionString += "Initial Catalog=" + Database;

            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataReader sqlDataReader;
            connection.Open();
            

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
	                [NameUser] = t3.User_Nome,
                    [Caminho_Img] = t3.Caminho_Img,
                    [INTERACT_ID] = t2.Interact_ID
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
                        System.Web.UI.HtmlControls.HtmlGenericControl create_Div_Inter_Content = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        System.Web.UI.HtmlControls.HtmlGenericControl create_Img_Inter = new System.Web.UI.HtmlControls.HtmlGenericControl("IMG");

                        
                        System.Web.UI.HtmlControls.HtmlGenericControl create_row_Post_Container = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");

                        System.Web.UI.HtmlControls.HtmlGenericControl create_P = new System.Web.UI.HtmlControls.HtmlGenericControl("P");
                        System.Web.UI.HtmlControls.HtmlGenericControl create_action_Post = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        System.Web.UI.HtmlControls.HtmlGenericControl create_Div_Like_And_Interact = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        System.Web.UI.HtmlControls.HtmlGenericControl create_Div_Like = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        System.Web.UI.HtmlControls.HtmlGenericControl create_Div_Interact = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");

                        // --------------------------------------------------------- ADD 24/10/2017 --------------------------------------------------------- //

                        System.Web.UI.HtmlControls.HtmlGenericControl create_Div_Share = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");                        
                        System.Web.UI.HtmlControls.HtmlGenericControl create_A_Like = new System.Web.UI.HtmlControls.HtmlGenericControl("A");
                        System.Web.UI.HtmlControls.HtmlGenericControl create_A_Interact = new System.Web.UI.HtmlControls.HtmlGenericControl("A");
                        System.Web.UI.HtmlControls.HtmlGenericControl create_A_Share = new System.Web.UI.HtmlControls.HtmlGenericControl("A");
                        System.Web.UI.HtmlControls.HtmlGenericControl create_P_Like = new System.Web.UI.HtmlControls.HtmlGenericControl("P");
                        System.Web.UI.HtmlControls.HtmlGenericControl create_P_Interact = new System.Web.UI.HtmlControls.HtmlGenericControl("P");
                        System.Web.UI.HtmlControls.HtmlGenericControl create_P_Share = new System.Web.UI.HtmlControls.HtmlGenericControl("P");
                        System.Web.UI.HtmlControls.HtmlGenericControl create_Div_Border_Like = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        System.Web.UI.HtmlControls.HtmlGenericControl create_Div_Border_Interact = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        System.Web.UI.HtmlControls.HtmlGenericControl create_Div_Border_Share = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        System.Web.UI.HtmlControls.HtmlGenericControl create_Div_Likes = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        System.Web.UI.HtmlControls.HtmlGenericControl create_Resul_Post = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");

                        // --------------------------------------------------------- START HEADER --------------------------------------------------------- //
                        System.Web.UI.HtmlControls.HtmlGenericControl create_header_Post = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");

                        System.Web.UI.HtmlControls.HtmlGenericControl create_involves_Header_Post = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        System.Web.UI.HtmlControls.HtmlGenericControl create_div_Img_Current_Perfil_Post = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        System.Web.UI.HtmlControls.HtmlGenericControl create_involves_Data_User_Posted = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        System.Web.UI.HtmlControls.HtmlGenericControl create_img_Current_Perfil = new System.Web.UI.HtmlControls.HtmlGenericControl("IMG");
                        System.Web.UI.HtmlControls.HtmlGenericControl create_Name_User_Current = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        System.Web.UI.HtmlControls.HtmlGenericControl create_Publishing_Schedule = new System.Web.UI.HtmlControls.HtmlGenericControl("SPAN");
                        // --------------------------------------------------------- END HEADER --------------------------------------------------------- //



                        // --------------------------------------------------------- ADD 25/10/2017 --------------------------------------------------------- //

                        System.Web.UI.HtmlControls.HtmlGenericControl create_Div_User_Interact = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        System.Web.UI.HtmlControls.HtmlGenericControl create_Div_Img_User_Interact = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        System.Web.UI.HtmlControls.HtmlGenericControl create_Img_User_Interact = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                        System.Web.UI.HtmlControls.HtmlGenericControl create_Div_Text_Area_Interact = new System.Web.UI.HtmlControls.HtmlGenericControl("TEXTAREA");
                        System.Web.UI.HtmlControls.HtmlGenericControl create_Text_Area_Interact = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");



                        // ---------------------------------------------------------------------------////--------------------------------------------------------------------//
                        // ID
                        // ---------------------------------------------------------------------------////--------------------------------------------------------------------//

                        createDiv.ID = "ID_Div_PostagemRow" + idPost;
                        //createDivInter.ID = "ID_Div_";
                        //create_Div_Inter_Content.ID = "ID_Div_";
                        //create_Img_Inter.ID = "";
                        create_P.ID = "ID_P_Text_Post" + idPost;
                        create_Div_Like_And_Interact.ID = "ID_Div_Like_And_Interact" + idPost;
                        create_Div_Like.ID = "ID_Div_Like" + idPost;
                        create_Div_Interact.ID = "ID_Div_Interact" + idPost;
                        element.ID = "totalPost" + idPost;


                        // --------------------------------------------------------- ADD 24/10/2017 --------------------------------------------------------- //

                        create_Div_Share.ID = "ID_Div_Share" + idPost;
                        create_A_Like.ID = "ID_A_Like" + idPost;
                        create_A_Interact.ID = "ID_A_Interact" + idPost;
                        create_A_Share.ID = "ID_A_Share" + idPost;
                        create_P_Like.ID = "ID_P_Like" + idPost;
                        create_P_Interact.ID = "ID_P_Interact" + idPost;
                        create_P_Share.ID = "ID_P_Share" + idPost;
                        create_Div_Border_Like.ID = "ID_Div_Border_Like" + idPost;
                        create_Div_Border_Interact.ID = "ID_Div_Border_Interact" + idPost;
                        create_Div_Border_Share.ID = "ID_Div_Border_Share" + idPost;
                        create_Div_Likes.ID = "ID_Div_Likes" + idPost;
                        create_Resul_Post.ID = "ID_Div_ResulPost" + idPost;
                        create_action_Post.ID = "ID_Div_ActionPost" + idPost; 



                        // ---------------------------------------------------------------------------////--------------------------------------------------------------------//
                        // Class
                        // ---------------------------------------------------------------------------////--------------------------------------------------------------------//

                        createDiv.Attributes["class"] = "CL_Div_PostagemRow";
                        //createDivInter.Attributes["class"] = "postagemRowImage";// ADICIONAR QUANDO TIVER SUPORTE PARA IMAGEM
                        create_Div_Inter_Content.Attributes["class"] = "CL_Div_PostagemRowContent w3-content";
                        create_Img_Inter.Attributes["class"] = "postagemImgImage";
                        create_P.Attributes["class"] = "CL_text";
                        create_Div_Like_And_Interact.Attributes["class"] = "w3-row CL_Like_And_Interact";
                        create_Div_Like.Attributes["class"] = "CL_Div_Like col-md-3";
                        create_Div_Interact.Attributes["class"] = "CL_Div_Interact col-md-4";
                        create_row_Post_Container.Attributes["class"] = "rowPostContainer";
                        create_header_Post.Attributes["class"] = "headerPost";
                        element.Attributes["class"] = "totalPost";



                        // --------------------------------------------------------- ADD 24/10/2017 --------------------------------------------------------- //

                        create_Div_Share.Attributes["class"] = "CL_Div_Share col-md-5";
                        create_A_Like.Attributes["class"] = "CL_A_Like";
                        create_A_Interact.Attributes["class"] = "CL_A_Interact";
                        create_A_Share.Attributes["class"] = "CL_A_Share";
                        create_P_Like.Attributes["class"] = "CL_P_Like";
                        create_P_Interact.Attributes["class"] = "CL_P_Interact";
                        create_P_Share.Attributes["class"] = "CL_P_Share";
                        create_Div_Border_Like.Attributes["class"] = "CL_Div_Border_Like";
                        create_Div_Border_Interact.Attributes["class"] = "CL_Div_Border_Interact";
                        create_Div_Border_Share.Attributes["class"] = "CL_Div_Border_Share";
                        create_Div_Likes.Attributes["class"] = "CL_Div_Likes";
                        create_Resul_Post.Attributes["class"] = "CL_Div_ResulPost";
                        create_action_Post.Attributes["class"] = "CL_Div_ActionPost"; 


                        create_involves_Header_Post.Attributes["class"] = "involvesHeaderPost";
                        create_div_Img_Current_Perfil_Post.Attributes["class"] = "divImgCurrentPerfilPost";
                        create_involves_Data_User_Posted.Attributes["class"] = "involvesDataUserPosted";
                        create_img_Current_Perfil.Attributes["class"] = "imgCurrentPerfil";
                        create_Name_User_Current.Attributes["class"] = "NameUserCurrent";
                        create_Publishing_Schedule.Attributes["class"] = "PublishingSchedule";


                        //createDivInter.Controls.Add(create_Img_Inter); // ADICIONAR QUANDO TIVER SUPORTE PARA IMAGEM
                        //createDiv.Controls.Add(createDivInter); // ADICIONAR QUANDO TIVER SUPORTE PARA IMAGEM



                        // ---------------------------------------------------------------------------////--------------------------------------------------------------------//
                        // InnerHtml
                        // ---------------------------------------------------------------------------////--------------------------------------------------------------------//


                        create_P.InnerHtml = sqlDataReader["Posting_Text"].ToString();
                        //createDivInter.Controls.Add(create_Img_Inter); // ADICIONAR QUANDO TIVER SUPORTE PARA IMAGEM
                        //createDiv.Controls.Add(createDivInter); // ADICIONAR QUANDO TIVER SUPORTE PARA IMAGEM
                        //create_Div_Like.InnerHtml = ((Convert.ToInt32(sqlDataReader["TotalLike"].ToString()) > 0) ? sqlDataReader["TotalLike"].ToString() + "Curtida(s)" : "");

                        create_P_Like.InnerHtml = "Curtir";
                        create_P_Interact.InnerHtml = "Comentar";
                        create_P_Share.InnerHtml = "Compartilhar";

                        create_Div_Likes.InnerHtml = ((Convert.ToInt32(sqlDataReader["TotalLike"].ToString()) > 0) ? sqlDataReader["TotalLike"].ToString() + " Curtida(s)" : "");



                        // ---------------------------------------------------------------------------////--------------------------------------------------------------------//
                        // resto
                        // ---------------------------------------------------------------------------////--------------------------------------------------------------------//
                        //create_img_Current_Perfil.InnerHtml = @"C:\Users\DESENV5\Documents\Visual Studio 2015\Projects\IntraNetBack\IntraNetBack\Imagens\perfilRoni.jpg";

                        create_img_Current_Perfil.Attributes["src"] = sqlDataReader["Caminho_Img"].ToString();

                        create_div_Img_Current_Perfil_Post.Controls.Add(create_img_Current_Perfil);

                        create_involves_Header_Post.Controls.Add(create_div_Img_Current_Perfil_Post);

                        create_Name_User_Current.InnerHtml = sqlDataReader["NameUser"].ToString();

                        create_involves_Data_User_Posted.Controls.Add(create_Name_User_Current);

                        create_Publishing_Schedule.InnerHtml = sqlDataReader["Schedule"].ToString();

                        create_involves_Data_User_Posted.Controls.Add(create_Publishing_Schedule);

                        create_involves_Header_Post.Controls.Add(create_involves_Data_User_Posted);

                        create_header_Post.Controls.Add(create_involves_Header_Post);

                        element.Controls.Add(create_header_Post);


                        create_Div_Inter_Content.Controls.Add(create_P);
                        createDiv.Controls.Add(create_Div_Inter_Content);
                        //createDiv.Style.Add(HtmlTextWriterStyle.BackgroundColor, "#333");
                        create_row_Post_Container.Controls.Add(createDiv);
                        element.Controls.Add(create_row_Post_Container);

                        //Div Action
                        create_Div_Like_And_Interact.Controls.Add(create_Div_Like);
                        create_Div_Like_And_Interact.Controls.Add(create_Div_Interact);
                        //createDivAction.Controls.Add(create_Div_Like_And_Interact)



                    // Like

                        create_A_Like.Controls.Add(create_P_Like);
                        create_Div_Like.Controls.Add(create_A_Like);
                        create_Div_Like.Controls.Add(create_Div_Border_Like);
                        create_Div_Like_And_Interact.Controls.Add(create_Div_Like);


                    // Interact
                        
                        create_A_Interact.Controls.Add(create_P_Interact);
                        create_Div_Interact.Controls.Add(create_A_Interact);
                        create_Div_Interact.Controls.Add(create_Div_Border_Interact);
                        create_Div_Like_And_Interact.Controls.Add(create_Div_Interact);


                    // Share

                        create_A_Share.Controls.Add(create_P_Share);
                        create_Div_Share.Controls.Add(create_A_Share);
                        create_Div_Share.Controls.Add(create_Div_Border_Share);
                        create_Div_Like_And_Interact.Controls.Add(create_Div_Share);  


                        create_action_Post.Controls.Add(create_Div_Like_And_Interact);
                        element.Controls.Add(create_action_Post);



                        create_Resul_Post.Controls.Add(create_Div_Likes);

                        element.Controls.Add(create_Resul_Post);
                    }

                    System.Web.UI.HtmlControls.HtmlGenericControl createDivComment = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                    System.Web.UI.HtmlControls.HtmlGenericControl createDivCommentText = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");

                    System.Web.UI.HtmlControls.HtmlGenericControl rowPostComment = new System.Web.UI.HtmlControls.HtmlGenericControl("DIV");
                    rowPostComment.Attributes["class"] = "rowPostComment";

                    createDivComment.ID = "ID_Div_PostagemCommentRow" + sqlDataReader["INTERACT_ID"].ToString() + idPost;
                    createDivComment.Attributes["class"] = "CL_Div_PostagemCommentRow";
                    createDivCommentText.Attributes["class"] = "CL_Div_ContentCommentRow";
                    createDivCommentText.InnerHtml = sqlDataReader["Interact_Text"].ToString();

                    createDivComment.Controls.Add(createDivCommentText);
                    rowPostComment.Controls.Add(createDivComment);

                    element.Controls.Add(rowPostComment);
                    //count++;
                }
                elementGrandfather.Controls.Add(element);
            }

            sqlDataReader.Close();
            connection.Close();


        }
        

    }
}