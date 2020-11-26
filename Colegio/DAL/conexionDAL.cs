using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Colegio.DAL
{
    class conexionDAL
    {
        private string CadenaConexion = "Data Source=DESKTOP-TTDTQAO\\SQLPLATZI; Initial Catalog=db_colegio; Integrated Security = True";
        SqlConnection Conexion;

        public SqlConnection EstablecerConexion(){
 
            this.Conexion = new SqlConnection(this.CadenaConexion);
            return this.Conexion;
        }
        /*INSERT, DELETE, UPDATE*/
        public bool execSinRetornoDatos(string strComando) {

            try {
               
                SqlCommand Comando = new SqlCommand();

                Comando.CommandText = strComando;
                Comando.Connection = this.EstablecerConexion();
                Conexion.Open();
                Comando.ExecuteNonQuery();
                Conexion.Close();

                return true;
            } catch {
                return false;
            }
        }

        /* SELECT retorno de datos*/
        public DataSet EjecutarSentecia(SqlCommand sqlComando)
        {
            DataSet DS = new DataSet();
            SqlDataAdapter Adaptador = new SqlDataAdapter();

            try {
                SqlCommand Comando = new SqlCommand();
                Comando = sqlComando;
                Comando.Connection = this.EstablecerConexion();
                Adaptador.SelectCommand = Comando;
                Conexion.Open();
                Adaptador.Fill(DS);
                Conexion.Close();
                return DS;

            }
            catch {
                return DS;
            }
        }
    }

}
