using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ds.projeto_ds.conexao
{
     public class ConnnectionFactory
    {
         //metodo para conectar o banco de dados
         public static MySqlConnection getConnection()
         {
             //acessando a string de conexão
             string conexao = ConfigurationManager.ConnectionStrings["projeto_ds"].ConnectionString;

             return new MySqlConnection(conexao);
         }

    }
}
