using MySql.Data.MySqlClient;
using Projeto_ds.projeto_ds.conexao;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ds.projeto_ds.dao
{
    public class CargoDAO
    {

        private MySqlConnection conexao;
        public CargoDAO(){

            this.conexao = ConnnectionFactory.getConnection();
        }

         public DataTable ListarCargos()
        {
              //1 passo - comando sql
                string sql = @"select * from cargo";
                //2 passo - organizar o sql
                MySqlCommand executacmdsql = new MySqlCommand(sql, conexao);
                //3 passo - abrir a conexao e executar o comando
                conexao.Open();
                executacmdsql.ExecuteNonQuery();
                //4 passo - criar o MySQLDataAdapter
                MySqlDataAdapter da = new MySqlDataAdapter(executacmdsql);
                //5 passo - criar o DataTable
                DataTable tabelaCargo = new DataTable();
                da.Fill(tabelaCargo);                
                //fechar conexão
                conexao.Close();
                //Retornar o DataTable com os dados
                return tabelaCargo;
            }        
              
        
    }
}
