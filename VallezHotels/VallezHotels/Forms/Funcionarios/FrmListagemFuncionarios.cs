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

namespace VallezHotels
{
    public partial class FrmListagemFuncionarios : Form
    {

        public FrmListagemFuncionarios()
        {
            InitializeComponent();
        }

        private void btnNovoHospede_Click(object sender, EventArgs e)
        {

            FrmFuncionario funcionario = new FrmFuncionario();
            Helper.StartForm(funcionario, null);
        }
    }
}
