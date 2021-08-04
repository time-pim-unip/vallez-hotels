using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VallezHotels.Source.Entidades
{
    public class Funcionario : Pessoa
    {

        public int IdFuncionario { get; set; }
        public string UuidFuncionario { get; set; }
        //public Pessoa Pessoa { get; set; }
        public Usuario Usuario { get; set; }
        public string CTPS { get; set; }
        public DateTime Admissao { get; set; }
        public DateTime CreatedAtFuncionario { get; set; }
        public DateTime UpdatedAtFuncionario { get; set; }

        public Funcionario()
        {
            Usuario = new Usuario();
            CreatedAtFuncionario = new DateTime();
            UpdatedAtFuncionario = new DateTime();
        }

        public Funcionario(int id, string uuid, Usuario usuario, string ctps, DateTime admissao)
        {
            IdFuncionario = id;
            UuidFuncionario = uuid;
            //Pessoa = pessoa;
            Usuario = usuario;
            CTPS = ctps;
            Admissao = admissao;
            CreatedAtFuncionario = new DateTime();
            UpdatedAtFuncionario = new DateTime();
        }
    }
}
