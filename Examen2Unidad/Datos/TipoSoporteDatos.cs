using MySql.Data.MySqlClient;
using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Datos
{
    public class TipoSoporteDatos
    {
        public async Task<DataTable> DevolverTipoSoporteAsync()
        {
            DataTable dt = new DataTable();
            try
            {
                string sql = "SELECT * FROM tiposoporte;";

                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        MySqlDataReader dr = (MySqlDataReader)await comando.ExecuteReaderAsync();
                        dt.Load(dr);
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return dt;
        }
        public async Task<bool> InsertarAsync(TipoSoporte soporte )
        {
            bool inserto = false;
            try
            {
                string sql = "INSERT INTO tiposoporte VALUES (@Codigo, @TSoporte,@Descripcion,@ValorSoporte);";

                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add("@Codigo", MySqlDbType.VarChar, 20).Value = soporte.Codigo;
                        comando.Parameters.Add("@TSoporte", MySqlDbType.VarChar, 45).Value = soporte.TSoporte;
                        comando.Parameters.Add("@Descripcion", MySqlDbType.VarChar, 100).Value = soporte.Descripcion;
                        comando.Parameters.Add("@ValorSoporte", MySqlDbType.Decimal ).Value = soporte.ValorSoporte;
                        await comando.ExecuteNonQueryAsync();
                        inserto = true;
                    }
                }
            }
            catch (Exception)
            {
            }
            return inserto;
        }

        public async Task<bool> ActualizarAsync(TipoSoporte soporte)
        {
            bool actualizo = false;
            try
            {
                string sql = "UPDATE tiposoporte SET TSoporte=@TSoporte, Descripcion=@Descripcion,ValorSoporte=@ValorSoporte WHERE Codigo=@Codigo;";

                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add("@Codigo", MySqlDbType.VarChar, 20).Value = soporte.Codigo;
                        comando.Parameters.Add("@TSoporte", MySqlDbType.VarChar, 45).Value = soporte.TSoporte;
                        comando.Parameters.Add("@Descripcion", MySqlDbType.VarChar, 100).Value = soporte.Descripcion;
                        comando.Parameters.Add("@ValorSoporte", MySqlDbType.Decimal).Value = soporte.ValorSoporte;

                        await comando.ExecuteNonQueryAsync();
                        actualizo = true;
                    }
                }
            }
            catch (Exception)
            {
            }
            return actualizo;
        }

        public async Task<bool> EliminarAsync(string codigo)
        {
            bool elimino = false;
            try
            {
                string sql = "DELETE FROM tiposoporte WHERE Codigo = @Codigo;";

                using (MySqlConnection _conexion = new MySqlConnection(CadenaConexion.Cadena))
                {
                    await _conexion.OpenAsync();
                    using (MySqlCommand comando = new MySqlCommand(sql, _conexion))
                    {
                        comando.CommandType = System.Data.CommandType.Text;
                        comando.Parameters.Add("@Codigo", MySqlDbType.VarChar, 20).Value = codigo;
                        await comando.ExecuteNonQueryAsync();
                        elimino = true;
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return elimino;
        }
    }
}
