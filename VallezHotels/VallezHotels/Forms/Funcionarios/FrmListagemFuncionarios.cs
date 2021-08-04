using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VallezHotels.Source.Core;

using VallezHotels.Source.Servicos;
using VallezHotels.Source.Entidades;

namespace VallezHotels
{
    public partial class FrmListagemFuncionarios : Form
    {

        private readonly FuncionarioServico _funcionarioServico;

        public FrmListagemFuncionarios()
        {

            _funcionarioServico = new FuncionarioServico();

            InitializeComponent();
        }

        private void AtualizarListaFuncionarios()
        {
            List<Funcionario> funcionarios = _funcionarioServico.BuscarTodos();

            var funcionariosView = from f in funcionarios
                                   orderby f.Nome
                                   where (f.Usuario.Status == chkSomenteAtivos.Checked || false == chkSomenteAtivos.Checked) 
                                   && f.Nome.ToUpper().Contains(txtPesquisaNome.Text.ToUpper().Trim().ToString())
                                   select new
                                   {
                                       Id = f.IdFuncionario,
                                       Nome = f.Nome,
                                       Cpf = f.Cpf,
                                       Rg = f.RG,
                                       Email = f.Email
                                   };

            

            dgFuncionarios.DataSource = funcionariosView.ToList();
        }

        private void FrmListagemFuncionarios_Load(object sender, EventArgs e)
        {
            AtualizarListaFuncionarios();
        }

        private void btnNovoFuncionario_Click(object sender, EventArgs e)
        {

            FrmFuncionario funcionario = new FrmFuncionario();
            funcionario.ShowDialog();

            if (funcionario.AtualizarFuncionarios)
            {
                this.AtualizarListaFuncionarios();
            }

        }

        private void dgFuncionarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgFuncionarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            FrmFuncionario funcionario = new FrmFuncionario();
            funcionario.IdFuncionario = int.Parse(dgFuncionarios.Rows[e.RowIndex].Cells["Id"].Value.ToString());
            funcionario.ShowDialog();

            if (funcionario.AtualizarFuncionarios)
            {
                this.AtualizarListaFuncionarios();
            }

            
        }

        private void txtPesquisaNome_TextChanged(object sender, EventArgs e)
        {
            this.AtualizarListaFuncionarios();
        }

        private void chkSomenteAtivos_CheckedChanged(object sender, EventArgs e)
        {
            AtualizarListaFuncionarios();
        }
    }
}
