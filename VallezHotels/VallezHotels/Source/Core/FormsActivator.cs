using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VallezHotels.Source.Core
{


    /*
        Classe de apoio destinada a controlar os formulários que serão ativados dentro do painel principal do FrmPrincipal.     
     */
    public class FormsActivator
    {

        private Panel Painel;
        private Label Titulo;

        public FormsActivator(System.Windows.Forms.Panel painel, System.Windows.Forms.Label label)
        {
            this.Painel = painel;
            this.Titulo = label;
        }

        // Ativar o formulário FrmDashboard no painel principal
        public void AtivarForm(Form form)
        {

            this.Titulo.Text = form.Text;
            this.Painel.Controls.Clear();
            form.TopLevel = false;
            form.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Painel.Controls.Add(form);
            form.Show();

        }


    }


}
