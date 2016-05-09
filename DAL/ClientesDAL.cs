using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loja.Modelos;

namespace Loja.DAL
{
    public class ClientesDAL
    {
        /// <summary>
        /// Inclusão de clientes
        /// </summary>
        /// <param name="cliente"></param>
        public void Incluir(ClienteInformation cliente)
        {
            //Conexão
            var cn = new SqlConnection();

            try
            {
                cn.ConnectionString = Dados.StringDeConexao;
                //Command

                var cmd = new SqlCommand { Connection = cn, CommandText = "insere_cliente" };
                cmd.CommandType = CommandType.StoredProcedure;

                var pcodigo = new SqlParameter("@codigo", SqlDbType.Int) { Direction = ParameterDirection.Output };
                cmd.Parameters.Add(pcodigo);

                var pnome = new SqlParameter("@nome", SqlDbType.NVarChar, 100) { Value = cliente.Nome };
                cmd.Parameters.Add(pnome);

                var pemail = new SqlParameter("@email", SqlDbType.NVarChar, 80) { Value = cliente.Email };
                cmd.Parameters.Add(pemail);

                var ptelefone = new SqlParameter("@telefone", SqlDbType.NVarChar, 80) { Value = cliente.Telefone };
                cmd.Parameters.Add(ptelefone);

                cn.Open();
                cmd.ExecuteNonQuery();
                cliente.Codigo = (Int32)cmd.Parameters["@codigo"].Value;

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

        /// <summary>
        /// Alteração de Cliente
        /// </summary>
        /// <param name="cliente"></param>
        public void Alterar(ClienteInformation cliente)
        {
            //Conexao
            var cn = new SqlConnection();

            try
            {
                cn.ConnectionString = Dados.StringDeConexao;
                var cmd = new SqlCommand() { Connection = cn, CommandText = "altera_cliente" };
                cmd.CommandType = CommandType.StoredProcedure;

                //Parametros da Stored Procedure
                var pcodigo = new SqlParameter("@codigo", SqlDbType.Int) { Value = cliente.Codigo };
                cmd.Parameters.Add(pcodigo);

                var pnome = new SqlParameter("@nome", SqlDbType.NVarChar, 100) { Value = cliente.Nome };
                cmd.Parameters.Add(pnome);

                var pemail = new SqlParameter("@email", SqlDbType.NVarChar, 40) { Value = cliente.Email };
                cmd.Parameters.Add(pemail);

                var ptelefone = new SqlParameter("@telefone", SqlDbType.NVarChar, 20) { Value = cliente.Telefone };
                cmd.Parameters.Add(ptelefone);

                cn.Open();
                cmd.ExecuteNonQuery();

            }
            catch (SqlException ex)
            {
                throw new Exception("Erro Server" + ex.Number);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Exlusão de cliente
        /// </summary>
        /// <param name="codigo"></param>
        public void Excluir(int codigo)
        {
            var cn = new SqlConnection();

            try
            {
                cn.ConnectionString = Dados.StringDeConexao;
                var cmd = new SqlCommand() { Connection = cn, CommandText = "exclui_cliente" };
                cmd.CommandType = CommandType.StoredProcedure;

                //Parameters
                var pcodigo = new SqlParameter("@codigo", SqlDbType.Int);
                pcodigo.Value = codigo;
                cmd.Parameters.Add(pcodigo);

                cn.Open();

                int resultado = cmd.ExecuteNonQuery();

                if (resultado != 1)
                {
                    throw new Exception("Não foi possivel excluir o cliente" + codigo);
                }
            }
            catch (SqlException ex)
            {
                throw new Exception("Error Server" + ex.Number);
            }
            finally
            {
                cn.Close();
            }
        }

        /// <summary>
        /// Metodo Listagem
        /// </summary>
        /// <param name="filtro"></param>
        /// <returns></returns>
        public DataTable Listagem(string filtro)
        {

            var cn = new SqlConnection();
            var da = new SqlDataAdapter();
            var dt = new DataTable();

            try
            {
                cn.ConnectionString = Dados.StringDeConexao;
                da.SelectCommand = new SqlCommand() { Connection = cn, CommandText = "seleciona_cliente" };
                da.SelectCommand.CommandType = CommandType.StoredProcedure;

                //Parametros
                SqlParameter pfiltro;
                pfiltro = da.SelectCommand.Parameters.Add("@filtro", SqlDbType.Text);
                pfiltro.Value = filtro;

                da.Fill(dt);

                return dt;

            }
            catch (SqlException ex)
            {
                throw new Exception("Erro Server" + ex.Number);
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
