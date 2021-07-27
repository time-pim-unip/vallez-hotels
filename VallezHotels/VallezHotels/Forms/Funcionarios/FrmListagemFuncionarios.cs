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

        private void FrmListagemFuncionarios_Load(object sender, EventArgs e)
        {

            List<Funcionario> funcionarios = _funcionarioServico.BuscarTodos();

            var funcionariosView = from f in funcionarios
                                   select new { 
                                        Id = f.IdFuncionario,
                                        Nome = f.Nome,
                                        Cpf = f.Cpf,
                                        Rg = f.RG,
                                        Email = f.Email
                                   };

            
            dgFuncionarios.DataSource = funcionariosView.ToList();

        }

        private void btnNovoHospede_Click(object sender, EventArgs e)
        {

            FrmFuncionario funcionario = new FrmFuncionario();
            Helper.StartForm(funcionario, null);
        }

        private void dgFuncionarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgFuncionarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(dgFuncionarios.Rows[0].Cells["Nome"].Value.ToString());
        }
    }
}
