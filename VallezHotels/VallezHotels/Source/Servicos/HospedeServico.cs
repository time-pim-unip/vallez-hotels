using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VallezHotels.Source.DB;
using VallezHotels.Source.DB.Conexao;
using VallezHotels.Source.Entidades;

namespace VallezHotels.Source.Servicos
{
    public class HospedeServico
    {

        private readonly HospedeDB _db;
        private readonly PessoaServico _servicoPessoa;
        private readonly UsuarioServico _servicoUsuario;

        public HospedeServico()
        {
            _db = new HospedeDB(new PGConexao());
            _servicoPessoa = new PessoaServico();
            _servicoUsuario = new UsuarioServico();
        }


        public Hospede InserirHospede(Hospede hospede)
        {
            try
            {

                Pessoa p  = _servicoPessoa.InserirPessoa(hospede);
                
                hospede.IdPessoa = p.IdPessoa;
                hospede.UuidPessoa = p.UuidPessoa;
                hospede.CreatedAtPessoa = p.CreatedAtPessoa;
                hospede.UpdatedAtPessoa = p.UpdatedAtPessoa;

                hospede.Usuario = _servicoUsuario.InserirUsuario(hospede.Usuario);
                
                Hospede h = _db.Inserir(hospede);

                hospede.IdHospede = h.IdHospede;
                hospede.UuidHospede = h.UuidHospede;
                hospede.CreatedAtHospede = h.CreatedAtHospede;
                hospede.UpdatedAtHospede = h.UpdatedAtHospede;

                return hospede;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeletarHospede(Hospede hospede)
        {
            try
            {

                if (_db.Deletar(hospede))
                {
                    _servicoPessoa.DeletarPessoa(hospede);
                    _servicoUsuario.DeletarUsuario(hospede.Usuario);
                }
                else
                {
                    throw new Exception("Não foi possivel deletar o hospede informado");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Hospede BuscarPeloId(int id)
        {
            try
            {

                Hospede hos = new Hospede();

                Hospede h = _db.BuscarPeloID(id);
                Usuario u = _servicoUsuario.BuscarPeloId(h.Usuario.Id);
                Pessoa p = _servicoPessoa.BuscarPeloId(h.IdPessoa);

                // Funcionário
                hos.IdHospede = h.IdHospede;
                hos.UuidHospede = h.UuidHospede;
                hos.Consentimento = h.Consentimento;
                hos.CreatedAtHospede = h.CreatedAtHospede;
                hos.UpdatedAtHospede = h.UpdatedAtHospede;

                // Pessoa
                hos.IdPessoa = p.IdPessoa;
                hos.UuidPessoa = p.UuidPessoa;
                hos.Nome = p.Nome;
                hos.DataNascimento = p.DataNascimento;
                hos.Cpf = p.Cpf;
                hos.RG = p.RG;
                hos.Email = p.Email;
                hos.Telefone = p.Telefone;
                hos.Celular = p.Celular;
                hos.CreatedAtPessoa = p.CreatedAtPessoa;
                hos.UpdatedAtPessoa = p.UpdatedAtPessoa;

                // Usuario
                hos.Usuario = u;

                return hos;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Hospede> BuscarTodos()
        {
            try
            {

                List<Hospede> hospedes = new List<Hospede>();
                List<Hospede> lista = _db.BuscarTodos();

                foreach (Hospede h in lista)
                {
                    Hospede hos = new Hospede();

                    Pessoa p = _servicoPessoa.BuscarPeloId(h.IdPessoa);
                    Usuario u = _servicoUsuario.BuscarPeloId(h.Usuario.Id);

                    // Funcionário
                    hos.IdHospede = h.IdHospede;
                    hos.UuidHospede = h.UuidHospede;
                    hos.Consentimento = h.Consentimento;
                    hos.CreatedAtHospede = h.CreatedAtHospede;
                    hos.UpdatedAtHospede = h.UpdatedAtHospede;

                    // Pessoa
                    hos.IdPessoa = p.IdPessoa;
                    hos.UuidPessoa = p.UuidPessoa;
                    hos.Nome = p.Nome;
                    hos.DataNascimento = p.DataNascimento;
                    hos.Cpf = p.Cpf;
                    hos.RG = p.RG;
                    hos.Email = p.Email;
                    hos.Telefone = p.Telefone;
                    hos.Celular = p.Celular;
                    hos.CreatedAtPessoa = p.CreatedAtPessoa;
                    hos.UpdatedAtPessoa = p.UpdatedAtPessoa;

                    hos.Usuario = u;

                    hospedes.Add(hos);

                }

                return hospedes;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Hospede EditarHospede(Hospede hospede)
        {
            try
            {

                Hospede hos = new Hospede();

                Hospede h = _db.Atualizar(hospede);
                Pessoa p = _servicoPessoa.AlterarPessoa(hospede);
                Usuario u = _servicoUsuario.EditarUsuario(hospede.Usuario);

                // Funcionário
                hos.IdHospede = h.IdHospede;
                hos.UuidHospede = h.UuidHospede;
                hos.Consentimento = h.Consentimento;
                hos.CreatedAtHospede = h.CreatedAtHospede;
                hos.UpdatedAtHospede = h.UpdatedAtHospede;

                // Pessoa
                hos.IdPessoa = p.IdPessoa;
                hos.UuidPessoa = p.UuidPessoa;
                hos.Nome = p.Nome;
                hos.DataNascimento = p.DataNascimento;
                hos.Cpf = p.Cpf;
                hos.RG = p.RG;
                hos.Email = p.Email;
                hos.Telefone = p.Telefone;
                hos.Celular = p.Celular;
                hos.CreatedAtPessoa = p.CreatedAtPessoa;
                hos.UpdatedAtPessoa = p.UpdatedAtPessoa;

                // Usuario
                hos.Usuario = u;

                return hos;


            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
