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

        protected void Page_Load(object sender, EventArgs e)
        {
            Button1_Click(sender, e);

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
            //valor = Regex.Replace(valor, "'", "§");

            // recebe o nome do codigo para poder chamar a função mais tarde
            //string nomearquivo = nomeArquivo.Value;
            //conexão 
            string stringConexaoSQLServer = String.Format("DATA SOURCE={0}; INITIAL CATALOG={1}; USER ID={2}; Password={3}; Pooling=false;",
                                                  "192.168.254.193", "IntraNet", "sa", "fxm@sterb1");

            conexaoSQLServer = new SqlConnection(stringConexaoSQLServer);
            conexaoSQLServer.Open();

            if (valor == "")
            {
            }
            else
            {
                // insere no banco
                string sqlPost = "insert into dbo.Posts (Posting_UserID, Posting_Text, Posting_DateTime) values ('2', '" + valor + "', getDate())";
                SqlCommand cmdVerifcPost = new SqlCommand(sqlPost, conexaoSQLServer);
                cmdVerifcPost.ExecuteNonQuery();
                ID_Campo_De_Postagem.Value = "";
            }
        }
    }
}