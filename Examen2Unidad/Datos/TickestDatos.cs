using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class TickestDatos
    {
        MySqlConnection conn;
        MySqlCommand cmd;

        public DataTable ListarPedidos()
        {
            DataTable lista = new DataTable();
            try
            {
                string sql = "SELECT * FROM tickets;";
                conn = new MySqlConnection(CadenaConexion.Cadena);
                conn.Open();

                cmd = new MySqlCommand(sql, conn);

                MySqlDataReader reader = cmd.ExecuteReader();
                lista.Load(reader);
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {


            }
            return lista;
        }
    }
}
