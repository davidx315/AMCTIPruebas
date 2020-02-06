using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMCTIPrueba.Productos.Core
{
    using System.Data;
    using System.Linq;
    using System.Web.UI.WebControls;

     public class ControladorListasProducto
    {
        public ControladorDatos objDatosProducto = new ControladorDatos();

        public DropDownList ListadoTitulo(DropDownList lista)
        {
            return LlenarLista(lista, objDatosProducto.ObtenerProducto2(), "titulo", "idProd");
        }

        protected DropDownList LlenarLista(DropDownList lista, object dataSource, string texto, string valor)
        {
            lista.DataSource = dataSource;
            lista.DataTextField = texto;
            lista.DataValueField = valor;
            lista.DataBind();
            return lista;
        }
    }
}
