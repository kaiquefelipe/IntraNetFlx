using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;

namespace IntraNetBack
{
    public partial class Postagens : System.Web.UI.Page
    {
        private SqlConnection conexaoSQLServer;
        SqlDataReader sqlDataReader;
        public int user;
        string stringConexaoSQLServer = String.Format("DATA SOURCE={0}; INITIAL CATALOG={1}; USER ID={2}; Password={3}; Pooling=false;",
                                                  "192.168.254.193", "IntraNet", "sa", "fxm@sterb1");

        protected void Page_Load(object sender, EventArgs e)
        {
            Button1_Click(sender, e);
            //string User_Selected = DropDownList1.SelectedValue;

            int k = Utils.getValueMaxID();
            int pois = k - 10;
            for (int i = k; i > pois; i--)
            {
                Utils.buildPost(i, timeLine);
            }
           
        }

        protected void FunctionPost(object sender, EventArgs e)
        {
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            // recebe o valor do textArea e troca os '' por § para não dar erro no banco
            string valor = ID_Campo_De_Postagem.Value;
            string User_Selected = DropDownList1.SelectedValue;
            //valor = Regex.Replace(valor, "'", "§");

            // recebe o nome do codigo para poder chamar a função mais tarde
            //string nomearquivo = nomeArquivo.Value;
            //conexão 

            conexaoSQLServer = new SqlConnection(stringConexaoSQLServer);
            conexaoSQLServer.Open();

            string sql_User = "SELECT t3.UserID from [dbo].[Users] t3 WHERE t3.User_Nome = '" + User_Selected + @"'";


            SqlCommand command = new SqlCommand(sql_User, conexaoSQLServer);
            sqlDataReader = command.ExecuteReader();

            while (sqlDataReader.Read())
            {
                if (string.IsNullOrEmpty(User_Selected))
                {
                }
                else
                {
                    user = Convert.ToInt32(sqlDataReader["UserID"].ToString());
                }
            }

            sqlDataReader.Close();
            conexaoSQLServer.Close();


            conexaoSQLServer = new SqlConnection(stringConexaoSQLServer);
            conexaoSQLServer.Open();

            if (string.IsNullOrEmpty(valor))
            {
            }
            else
            {
                // insere no banco
                string sqlPost = "insert into dbo.Posts (Posting_UserID, Posting_Text, Posting_DateTime) values (" + user + ", '" + valor + "', getDate())";

                SqlCommand cmdVerifcPost = new SqlCommand(sqlPost, conexaoSQLServer);
                cmdVerifcPost.ExecuteNonQuery();
                ID_Campo_De_Postagem.Value = "";
                DropDownList1.SelectedValue = null;
            }

            sqlDataReader.Close();
            conexaoSQLServer.Close();

        }
    }
}