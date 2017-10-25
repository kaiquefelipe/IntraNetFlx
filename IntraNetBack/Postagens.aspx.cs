using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntraNetBack
{
    public partial class Postagens : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int x = Utils.getRows();
            for (int i = 1; i <= 10; i++)
            {
                Utils.buildPost(i, timeLine);
            }
           
        }
    }
}