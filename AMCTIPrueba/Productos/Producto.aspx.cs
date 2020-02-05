using AMCTIPrueba.Productos.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AMCTIPrueba.Productos
{
    public partial class Producto : System.Web.UI.Page
    {
        ControladorDatos objDatosProducto = new ControladorDatos();
        ControladorListasProducto objListaProducto = new ControladorListasProducto();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                DataTable dtResultado = null;
                dtResultado = objDatosProducto.ObtenerProductos(1);
                gridProductos.DataSource = dtResultado; /*Este es el DataSource*/
                gridProductos.DataBind(); /*Este es el que llena la tabla*/

                LlenarProducto();
            }
        }

        protected void LlenarProducto()
        {
            ListaTitulo.DataSource = objDatosProducto.ObtenerProducto2();
            ListaTitulo.DataTextField = "titulo";
            ListaTitulo.DataValueField = "idProd";
            ListaTitulo.DataBind();
            ListaTitulo.Items.Insert(0, new ListItem("Todos", "0"));
        }

        protected void ListaTitulo_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarProducto();
        }




    }
}