using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InscricaoCongresso.View
{
    public partial class Principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void btnGerar_Click(object sender, EventArgs e)
        {
            //chama a renderização do código de barras a partir da string, exclusivamente numérica, passada como parametro
            Session["boleto"] = TextBox1.Text;
            Response.Redirect("boleto.aspx");
        }
    }
}