using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto_ds.projeto_ds.modelo
{
   public class Cliente
    {
        //atributos
     
        //getters e setters
        public int Cod_cliente { get; set; }

        public string Nome { get; set; }
        
        public string Telefone { get; set; }

        public string Endereco { get; set; }

        public string Email { get; set; }

        public int Idade { get; set; }

        public double Salario { get; set; }

        public int Cargo_int { get; set; }

        public DateTime data_nasc { get; set; }

    }
}
