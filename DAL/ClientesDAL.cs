using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loja.Modelos;

namespace DAL
{
    public class ClientesDAL
    {
        public void Incluir(ClienteInformation cliente)
        {
            //Conexão
            var cn = new SqlConnection();

            try
            {
                cn.ConnectionString = Dados.StringDeConexao;
                //Command
                var cmd = new SqlCommand {Connection = cn, CommandText = "insere_cliente"};
                var pcodigo = new SqlParameter("@codigo", SqlDbType.Int) {Direction = ParameterDirection.Output};
                cmd.Parameters.Add(pcodigo);
                var pnome = new SqlParameter("@nome", SqlDbType.NVarChar, 100) {Value = cliente.Nome};
                cmd.Parameters.Add(pnome);
                var pemail = new SqlParameter("@email", SqlDbType.NVarChar, 80) {Value = cliente.Email};
                cmd.Parameters.Add(pemail);
                var ptelefone = new SqlParameter("@telefone", SqlDbType.NVarChar, 80) {Value = cliente.Telefone};
                cmd.Parameters.Add(ptelefone);

                cn.Open();
                cmd.ExecuteNonQuery();
                cliente.Codigo = (Int32) cmd.Parameters["@codigo"].Value;

            }
            catch (SqlException ex)
            {
                throw new Exception("Servidor SQL Error:" + ex.Number);
            }

            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }
    }
}
