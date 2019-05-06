using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto_ds.projeto_ds.modelo;
using MySql.Data.MySqlClient;
using Projeto_ds.projeto_ds.conexao;
using System.Data;

namespace Projeto_ds.projeto_ds.dao
{
    public class ClienteDAO
    {
        //metodos sql
        #region Metodo Cadastrar
        public void cadastrar(Cliente obj)
        {
            using (MySqlConnection conexao = ConnnectionFactory.getConnection())
            {
                //1 passo - comando sql
                string sql = @"insert into cliente (nome, telefone, endereco, email, idade, 
                               salario, cargo_id, data_nasci)
                               values(@nome, @telefone, @endereco, 
                                      @email, @idade, @salario,
                                      @cargo_id, @data_nasci)";

                //2 passo - organizar o sql
                MySqlCommand executacmdsql = new MySqlCommand(sql, conexao);
                executacmdsql.Parameters.AddWithValue("@nome", obj.Nome);
                executacmdsql.Parameters.AddWithValue("@telefone", obj.Telefone);
                executacmdsql.Parameters.AddWithValue("@endereco", obj.Endereco);
                executacmdsql.Parameters.AddWithValue("@email", obj.Email);
                executacmdsql.Parameters.AddWithValue("@idade", obj.Idade);
                executacmdsql.Parameters.AddWithValue("@salario", obj.Salario);

                executacmdsql.Parameters.AddWithValue("@cargo_id", obj.Cargo_int);
                executacmdsql.Parameters.AddWithValue("@data_nasci", obj.data_nasc);

                //3 passo - abrir a conexao e executar o comando
                conexao.Open();
                executacmdsql.ExecuteNonQuery();
                //4 passo - fechar a conexao
                conexao.Close();
            }//fecha o using da conexao

        } //Fecha o metodo cadastrar
        #endregion

        #region Método Alterar
        public void alterar(Cliente obj)
        {
            using (MySqlConnection conexao = ConnnectionFactory.getConnection())
            {
                //1 passo - comando sql
                string sql = @"update cliente set nome= @nome,
                              telefone= @telefone, 
                              endereco = @endereco,
                              email = @email,
                              idade = @idade,
                              salario = @salario 
                              where cod_cliente = @codigocliente";

                //2 passo - organizar o sql
                MySqlCommand executacmdsql = new MySqlCommand(sql, conexao);
                executacmdsql.Parameters.AddWithValue("@nome", obj.Nome);
                executacmdsql.Parameters.AddWithValue("@telefone", obj.Telefone);
                executacmdsql.Parameters.AddWithValue("@endereco", obj.Endereco);
                executacmdsql.Parameters.AddWithValue("@email", obj.Email);
                executacmdsql.Parameters.AddWithValue("@idade", obj.Idade);
                executacmdsql.Parameters.AddWithValue("@salario", obj.Salario);
                executacmdsql.Parameters.AddWithValue("@codigocliente", obj.Cod_cliente);

                //3 passo - abrir a conexao e executar o comando
                conexao.Open();
                executacmdsql.ExecuteNonQuery();
                //4 passo - fechar a conexao
                conexao.Close();
            }//fecha o using da conexao

        } //Fecha o metodo alterar         
        #endregion

        #region Metodo Excluir
        public void exluir(Cliente obj)
        {
            using (MySqlConnection conexao = ConnnectionFactory.getConnection())
            {
                //1 passo - comando sql
                string sql = @"delete from cliente where cod_cliente=@codigocliente";

                //2 passo - organizar o sql
                MySqlCommand executacmdsql = new MySqlCommand(sql, conexao);
                executacmdsql.Parameters.AddWithValue("@codigocliente", obj.Cod_cliente);

                //3 passo - abrir a conexao e executar o comando
                conexao.Open();
                executacmdsql.ExecuteNonQuery();
                //4 passo - fechar a conexao
                conexao.Close();
            }//fecha o using da conexao
        } //Fecha o metodo excluir       
        #endregion

        #region Método ListarTodos

        public DataTable ListarTodosClientes()
        {
            using (MySqlConnection conexao = ConnnectionFactory.getConnection())
            {
                //1 passo - comando sql
                string sql = @"select  cli.cod_cliente, 
                                        cli.nome, 
                                        cli.telefone,
		                                cli.endereco as 'Endereço do cliente',
		                                cli.email,
		                                cli.idade,
		                                cli.salario,
                                        c.descricao as 'Cargo',
		                                cli.data_nasci from cliente as cli

                                inner join cargo as c on (cli.cargo_id = c.id);";
                //2 passo - organizar o sql
                MySqlCommand executacmdsql = new MySqlCommand(sql, conexao);
                //3 passo - abrir a conexao e executar o comando
                conexao.Open();
                executacmdsql.ExecuteNonQuery();
                //4 passo - criar o MySQLDataAdapter
                MySqlDataAdapter da = new MySqlDataAdapter(executacmdsql);
                //5 passo - criar o DataTable
                DataTable tabelaCliente = new DataTable();
                da.Fill(tabelaCliente);                
                //fechar conexão
                conexao.Close();
                //Retornar o DataTable com os dados
                return tabelaCliente;
            }        

        }
        #endregion

        #region Metodo Pesquisar por Nome

        public DataTable ConsultarPorNome(string nome)
        {
            using (MySqlConnection conexao = ConnnectionFactory.getConnection())
            {
                //1 passo - comando sql
                string sql = @"select * from cliente where nome like '%' @nome 
";
                //2 passo - organizar o sql
                MySqlCommand executacmdsql = new MySqlCommand(sql, conexao);
                executacmdsql.Parameters.AddWithValue("@nome", nome);
            
                //3 passo - abrir a conexao e executar o comando
                conexao.Open();
                executacmdsql.ExecuteNonQuery();
                //4 passo - criar o MySQLDataAdapter
                MySqlDataAdapter da = new MySqlDataAdapter(executacmdsql);
                //5 passo - criar o DataTable
                DataTable tabelaCliente = new DataTable();
                da.Fill(tabelaCliente);
                //fechar conexão
                conexao.Close();
                //Retornar o DataTable com os dados
                return tabelaCliente;
            }

        }


        #endregion


        //Metodos com Procedures

        #region Metodo Cadastrar com Procedure
        public void cadastrarComProcedure(Cliente obj)
        {
            using (MySqlConnection conexao = ConnnectionFactory.getConnection())
            {
                //1 passo - comando sql
                string sql = "call InserirClientes(@v_nome, @v_tel)";
                //2 passo - organizar o sql
                MySqlCommand executacmdsql = new MySqlCommand(sql, conexao);
               
                executacmdsql.Parameters.AddWithValue("@v_nome", obj.Nome);
                executacmdsql.Parameters.AddWithValue("@v_tel", obj.Telefone);
                executacmdsql.Parameters.AddWithValue("@v_end", obj.Endereco);
                executacmdsql.Parameters.AddWithValue("@v_email", obj.Email);
                executacmdsql.Parameters.AddWithValue("@v_idade", obj.Idade);
                executacmdsql.Parameters.AddWithValue("@v_sal", obj.Salario);

                // Obs: Para recuperar o parametro de retorno da procedure (msg)
                // MySqlParameter parametroRetorno = executacmdsql.Parameters.Add("@msg", SqlDbType.VarChar);
                // System.Windows.Forms.MessageBox.Show("Teste" + parametroRetorno.ToString());
               
                executacmdsql.CommandType = CommandType.StoredProcedure;
              
                //3 passo - abrir a conexao e executar o comando
                conexao.Open();
                executacmdsql.ExecuteReader();
                //4 passo - fechar a conexao
                conexao.Close();
            }//fecha o using da conexao

        } //Fecha o metodo cadastrar
        #endregion


        #region Metodo Alterar com Procedure
        public void AlterarcomProcure(Cliente obj)
        {
            using (MySqlConnection conexao = ConnnectionFactory.getConnection())
            {
                //1 passo - comando sql

                //2 passo - organizar o sql
                MySqlCommand executacmdsql = new MySqlCommand("alterarCliente", conexao);

                executacmdsql.Parameters.AddWithValue("@v_nome", obj.Nome);
                executacmdsql.Parameters.AddWithValue("@v_tel", obj.Telefone);
                executacmdsql.Parameters.AddWithValue("@v_end", obj.Endereco);
                executacmdsql.Parameters.AddWithValue("@v_email", obj.Email);
                executacmdsql.Parameters.AddWithValue("@v_idade", obj.Idade);
                executacmdsql.Parameters.AddWithValue("@v_sal", obj.Salario);
                executacmdsql.Parameters.AddWithValue("@v_codcliente", obj.Cod_cliente);


                executacmdsql.CommandType = CommandType.StoredProcedure;

                //3 passo - abrir a conexao e executar o comando
                conexao.Open();
                executacmdsql.ExecuteReader();
                //4 passo - fechar a conexao
                conexao.Close();
            }//fecha o using da conexao

        } //Fecha o metodo cadastrar
        #endregion

        #region Metodo Excluir com Procedure
        public void ExcluircomProcure(Cliente obj)
        {
            using (MySqlConnection conexao = ConnnectionFactory.getConnection())
            {
                //1 passo - comando sql

                //2 passo - organizar o sql
                MySqlCommand executacmdsql = new MySqlCommand("excluirCliente", conexao);

                executacmdsql.Parameters.AddWithValue("@v_codcliente", obj.Cod_cliente);


                executacmdsql.CommandType = CommandType.StoredProcedure;

                //3 passo - abrir a conexao e executar o comando
                conexao.Open();
                executacmdsql.ExecuteReader();
                //4 passo - fechar a conexao
                conexao.Close();
            }//fecha o using da conexao

        } //Fecha o metodo cadastrar
        #endregion

        #region Método ListarTodos com Procedure

        public DataTable ListarTodosClientesProcedure()
        {
            using (MySqlConnection conexao = ConnnectionFactory.getConnection())
            {
                //1 passo - comando sql
             //   string sql = @"select * from cliente";
                //2 passo - organizar o sql
                MySqlCommand executacmdsql = new MySqlCommand("listarTodosClientes", conexao);
                //3 passo - abrir a conexao e executar o comando
                conexao.Open();
                executacmdsql.ExecuteNonQuery();
                //4 passo - criar o MySQLDataAdapter
                MySqlDataAdapter da = new MySqlDataAdapter(executacmdsql);
                //5 passo - criar o DataTable
                DataTable tabelaCliente = new DataTable();
                da.Fill(tabelaCliente);
                //fechar conexão
                conexao.Close();
                //Retornar o DataTable com os dados
                return tabelaCliente;
            }

        }
        #endregion

        #region Metodo Pesquisar por Nome com Procedures

        public DataTable buscarPorNome(Cliente obj)
        {
            using (MySqlConnection conexao = ConnnectionFactory.getConnection())
            {
                //1 passo - comando sql
            //    string sql = @"select * from cliente where nome like '%' @nome 

                //2 passo - organizar o sql
                MySqlCommand executacmdsql = new MySqlCommand("buscaPorNome", conexao);
                executacmdsql.CommandType = CommandType.StoredProcedure;

                executacmdsql.Parameters.AddWithValue("@v_nome", obj.Nome);

                //3 passo - abrir a conexao e executar o comando
                conexao.Open();
                executacmdsql.ExecuteNonQuery();
                //4 passo - criar o MySQLDataAdapter
                MySqlDataAdapter da = new MySqlDataAdapter(executacmdsql);
                //5 passo - criar o DataTable
                DataTable tabelaCliente = new DataTable();
                da.Fill(tabelaCliente);
                //fechar conexão
                conexao.Close();
                //Retornar o DataTable com os dados
                return tabelaCliente;
            }

        }


        #endregion

    }//fecha a classe
}
