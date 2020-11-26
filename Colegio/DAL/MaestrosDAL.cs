using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Colegio.BLL;



namespace Colegio.DAL
{
    class MaestrosDAL
    {
        conexionDAL conexion;

        public MaestrosDAL()
        {
            conexion = new conexionDAL();
        }
        
        public bool Agregar(MaestrosBLL oMaestrosBLL)
        {

            SqlCommand  SQLComando = new SqlCommand("INSERT INTo tb_maestros VALUES(@apellido, @nombre)");

            SQLComando.Parameters.Add("@Apellido",SqlDbType.VarChar).Value= oMaestrosBLL.apellido;
            SQLComando.Parameters.Add("@nombre", SqlDbType.VarChar).Value = oMaestrosBLL.nombre;


            return conexion.execSinRetornoDatos(SQLComando);
            //   return conexion.execSinRetornoDatos("INSERT INTO tb_maestros (apellido, nombre) VALUES ('"+oMaestrosBLL.apellido+"','" + oMaestrosBLL.nombre + "')");
        }

        public int Eliminar(MaestrosBLL oMaestrosBLL) {
            conexion.execSinRetornoDatos("DELETE FROM  tb_maestros WHERE id = "+oMaestrosBLL.ID);

            return 1;
        }

        public int Modificar(MaestrosBLL oMaestrosBLL)
        {
            conexion.execSinRetornoDatos("UPDATE tb_maestros SET apellido = '"+oMaestrosBLL.apellido+"',nombre = '"+oMaestrosBLL.nombre+"' WHERE id = " + oMaestrosBLL.ID);

            return 1;
        }

        public DataSet MostrarMaestros(){

            SqlCommand sentencia = new SqlCommand("SELECT * FROM tb_maestros");
            return conexion.EjecutarSentecia(sentencia);
        }

    }
}
