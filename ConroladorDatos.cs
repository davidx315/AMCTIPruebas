using AMCTI.AccesoDatos;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMCTIPrueba.Productos.Core
{
    public class ControladorDatos
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["ContextAMCTI"].ConnectionString;

        public DataTable ObtenerProductos(int idProducto)
        {
            DataTable dtResultado = null;
            var conexion = new DAO(connectionString); /*Instansiar un Objeto*/
            conexion.Procedimiento = "SP_S_Producto";
            dtResultado = conexion.ObtenerDataTable();

            if (conexion.ErroresEnElProceso != null)
            {
                throw conexion.ErroresEnElProceso;
            }

            return dtResultado;
        }



        //Para alimentar el DropDown//
        public DataSet ObtenerProducto2()
        {
            //Conectar con la base de datos//
            DataSet dtResultado = null;
            var conexion = new DAO(connectionString);
            conexion.Procedimiento = "SP_S_Producto";
            dtResultado = conexion.ObtenerDataSet();

            if (conexion.ErroresEnElProceso != null)
            {
                throw conexion.ErroresEnElProceso;
            }

            return dtResultado;


        }


    }
}
