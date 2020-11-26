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
            return conexion.execSinRetornoDatos("INSERT INTO tb_maestros (apellido, nombre) VALUES ('"+oMaestrosBLL.apellido+"','" + oMaestrosBLL.nombre + "')");
        }

        public int Eliminar(MaestrosBLL oMaestrosBLL) {

            conexion.execSinRetornoDatos("DELETE FROM  tb_maestros WHERE id = "+oMaestrosBLL.ID);

            return 1;
        }

        public DataSet MostrarMaestros(){

            SqlCommand sentencia = new SqlCommand("SELECT * FROM tb_maestros");
            return conexion.EjecutarSentecia(sentencia);
        }

    }
}
