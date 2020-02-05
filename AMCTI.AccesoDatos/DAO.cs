using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AMCTI.AccesoDatos
{
    public class DAO
    {
        #region Atributos

        private SqlConnection _conexion;
        private string _strCadenaDeConexion;
        private Exception _exErrores = null;
        private SqlTransaction _transaccionSql;
        private List<SqlParameter> _parametros;
        private bool _esProcedimiento = true;
        private string _procedimiento;



        #endregion

        #region Propiedades

        public bool EsProcedimiento
        {
            get { return _esProcedimiento; }
            set { _esProcedimiento = value; }
        }

        public string Procedimiento
        {
            get { return _procedimiento; }
            set { _procedimiento = value; }
        }


        public List<SqlParameter> ListaDeParametros
        {
            get { return _parametros; }
            set { _parametros = value; }
        }


        public Exception ErroresEnElProceso
        {
            get { return _exErrores; }
            set { _exErrores = value; }
        }


        #endregion

        #region Constructor

        public DAO(string cadenaConexion)
        {
            _strCadenaDeConexion = cadenaConexion;
        }

        #endregion

        #region Metodos Privados

        private void Conectar()
        {
            try
            {
                _conexion = new SqlConnection(_strCadenaDeConexion);
                _conexion.ConnectionString = _strCadenaDeConexion;
                _conexion.Open();
                _transaccionSql = _conexion.BeginTransaction();

            }
            catch (Exception error)
            {
                _exErrores = error;
            }
        }

        private void Desconectar()
        {
            try
            {
                if (_conexion.State == ConnectionState.Open)
                {
                    _conexion.Close();
                }
            }
            catch (Exception error)
            {
                _exErrores = error;
            }
        }

        private SqlCommand ObtenerComando()
        {
            SqlCommand comando = new SqlCommand(Procedimiento, _conexion);
            comando.CommandType = EsProcedimiento ? CommandType.StoredProcedure : CommandType.Text;
            comando.Transaction = _transaccionSql;
            comando.CommandTimeout = 300;

            try
            {
                if (_parametros != null && _parametros.Count > 0)
                {
                    foreach (SqlParameter prmt in _parametros)
                    {
                        comando.Parameters.Add(prmt);
                    }
                }
            }
            catch (Exception error)
            {

                _exErrores = error; ;
            }
            return comando;
        }

        #endregion

        #region Metodos Publicos

        public DataSet ObtenerDataSet()
        {
            bool Fallo = false;
            DataSet SetDeDatos = new DataSet();
            try
            {
                Conectar();
                SqlDataAdapter sda = new SqlDataAdapter(ObtenerComando());
                sda.Fill(SetDeDatos);
                sda.Dispose();
            }
            catch (Exception error)
            {
                Fallo = true;
                _exErrores = error; ;
            }
            finally
            {
                if (Fallo)
                {
                    _transaccionSql.Rollback();
                }
                else
                {
                    _transaccionSql.Commit();
                }
                Desconectar();
            }
            return SetDeDatos;
        }


        public DataTable ObtenerDataTable()
        {
            bool Fallo = false;
            DataSet SetDeDatos = new DataSet();
            try
            {
                Conectar();
                SqlDataAdapter sda = new SqlDataAdapter(ObtenerComando());
                sda.Fill(SetDeDatos);
                sda.Dispose();
            }
            catch (Exception error)
            {
                Fallo = true;
                _exErrores = error; ;
            }
            finally
            {
                if (Fallo)
                {
                    _transaccionSql.Rollback();
                }
                else
                {
                    _transaccionSql.Commit();
                }
                Desconectar();
            }
            return SetDeDatos.Tables[0];
        }


        public object ObtenerEscalar()
        {
            bool Fallo = false;
            object ObjetoDevoler = null;

            try
            {
                Conectar();
                ObjetoDevoler = ObtenerComando().ExecuteScalar();
            }
            catch (Exception error)
            {
                Fallo = true;
                _exErrores = error; ;
            }
            finally
            {
                if (Fallo)
                {
                    _transaccionSql.Rollback();
                }
                else
                {
                    _transaccionSql.Commit();
                }

                Desconectar();
            }
            return ObjetoDevoler;
        }


        public int EjecutarSentencia()
        {
            bool Fallo = false;
            int FilasAfectadas = 0;

            try
            {
                Conectar();
                FilasAfectadas = ObtenerComando().ExecuteNonQuery();
            }
            catch (Exception error)
            {
                Fallo = true;
                _exErrores = error; ;
            }
            finally
            {
                if (Fallo)
                {
                    _transaccionSql.Rollback();
                }
                else
                {
                    _transaccionSql.Commit();
                }
                Desconectar();
            }

            return FilasAfectadas;
        }


        public SqlDataReader ObtenerDataReader()
        {
            bool Fallo = false;
            SqlDataReader sdr = null;
            try
            {
                Conectar();
                sdr = ObtenerComando().ExecuteReader();
            }
            catch (Exception error)
            {
                Fallo = true;
                _exErrores = error; ;
            }
            finally
            {
                if (Fallo)
                {
                    _transaccionSql.Rollback();
                }
                else
                {
                    _transaccionSql.Commit();
                }
            }
            return sdr;
        }
        #endregion  
    }
}
