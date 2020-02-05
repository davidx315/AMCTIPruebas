using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PruebaWebForms1
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGenerarResultado_Click(object sender, EventArgs e)
        {
            lblResultado.Text = (int.Parse(txtPrimerNumero.Text) + int.Parse(txtSegundoNumero.Text)).ToString();
        }

        protected void txtPrimerNumero_TextChanged(object sender, EventArgs e)
        {
            lblText1.Text = txtPrimerNumero.Text;
        }
    }
}