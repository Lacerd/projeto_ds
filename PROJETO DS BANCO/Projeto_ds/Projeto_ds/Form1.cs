using Projeto_ds.projeto_ds.dao;
using Projeto_ds.projeto_ds.modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projeto_ds
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btncad_Click(object sender, EventArgs e)
        {
           try
            {
                Cliente obj = new Cliente();
                obj.Nome = txtnome.Text;
                obj.Telefone = txttelefone.Text;
                obj.Endereco = txtendereco.Text;
                obj.Email = txtemail.Text;
                obj.Idade = int.Parse(txtidade.Text);
                obj.Salario = double.Parse(txtsalario.Text);

                obj.Cargo_int = (int)cbcargo.SelectedValue;

                obj.data_nasc = Convert.ToDateTime(txtdatanascimento.Text);

                ClienteDAO dao = new ClienteDAO();
                dao.cadastrar(obj);
                MessageBox.Show("Cadastrado!");

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao cadastrar!" + erro);
 
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {
                            ClienteDAO dao = new ClienteDAO();
            dg_tabelacliente.DataSource = dao.ListarTodosClientes();

            CargoDAO dao_cargo = new CargoDAO();
            cbcargo.DataSource = dao_cargo.ListarCargos();
            cbcargo.DisplayMember = "descricao";
            cbcargo.ValueMember = "id";
            }
            catch (Exception erro)
            {

                MessageBox.Show(erro.ToString());
            }

        }


        private void dg_tabelacliente_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dg_tabelacliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //Pegando dados do datagridview
            txtcodigo.Text =    dg_tabelacliente.CurrentRow.Cells[0].Value.ToString();
            txtnome.Text =      dg_tabelacliente.CurrentRow.Cells[1].Value.ToString();
            txttelefone.Text =  dg_tabelacliente.CurrentRow.Cells[2].Value.ToString();
            txtendereco.Text =  dg_tabelacliente.CurrentRow.Cells[3].Value.ToString();
            txtemail.Text =     dg_tabelacliente.CurrentRow.Cells[4].Value.ToString();
            txtidade.Text =     dg_tabelacliente.CurrentRow.Cells[5].Value.ToString();
            txtsalario.Text =   dg_tabelacliente.CurrentRow.Cells[6].Value.ToString();
            cbcargo.Text = dg_tabelacliente.CurrentRow.Cells[7].Value.ToString();
            txtdatanascimento.Text = dg_tabelacliente.CurrentRow.Cells[8].Value.ToString();

        }

        private void btnalterar_Click(object sender, EventArgs e)
        {

            try
            {
                Cliente obj = new Cliente();
                obj.Nome = txtnome.Text;
                obj.Telefone = txttelefone.Text;
                obj.Endereco = txtendereco.Text;
                obj.Email = txtemail.Text;
                obj.Idade = int.Parse(txtidade.Text);
                obj.Salario = double.Parse(txtsalario.Text);
                obj.Cod_cliente = int.Parse(txtcodigo.Text);
                
                ClienteDAO dao = new ClienteDAO();
                dao.AlterarcomProcure(obj);
                MessageBox.Show("Alterado com Procedures com sucesso!");

                dg_tabelacliente.DataSource = dao.ListarTodosClientesProcedure();

            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro ao alterar!" + erro);

            }




           
        }

        private void btnexcluir_Click(object sender, EventArgs e)
        {
            try
            {
                //Metodo Excluir
                Cliente obj = new Cliente();
                obj.Cod_cliente = int.Parse(txtcodigo.Text);

                ClienteDAO dao = new ClienteDAO();
                dao.ExcluircomProcure(obj);

                MessageBox.Show("Excluido com sucesso!");
                dg_tabelacliente.DataSource = dao.ListarTodosClientesProcedure();
               

            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro ao excluir: " + erro);
            
            }
        }

        private void btnconsultar_Click(object sender, EventArgs e)
        {
                //Botao consulta por nome
                Cliente obj = new Cliente();
                obj.Nome = "%" + txtpesquisa.Text + "%";
                ClienteDAO dao = new ClienteDAO();             
                dg_tabelacliente.DataSource = dao.buscarPorNome(obj);       
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //1 passo - Instanciar o modelo
            Cliente obj = new Cliente();
            obj.Nome = txtnome.Text;
            obj.Telefone = txttelefone.Text;
            obj.Endereco = txtendereco.Text;
            obj.Email = txtemail.Text;
            obj.Idade = int.Parse(txtidade.Text);
            obj.Salario = double.Parse(txtsalario.Text);

            ClienteDAO dao = new ClienteDAO();
            dao.cadastrarComProcedure(obj);
            MessageBox.Show("Cadastrado!");
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void txtcodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
