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
    public class FuncionarioServico
    {

        private readonly FuncionarioDB _db;
        private readonly PessoaServico _servicoPessoa;
        private readonly UsuarioServico _servicoUsuario;

        public FuncionarioServico()
        {
            _db = new FuncionarioDB(new PGConexao());
            _servicoPessoa = new PessoaServico();
            _servicoUsuario = new UsuarioServico();
        }


        public Funcionario InserirFuncionario(Funcionario funcionario)
        {
            try
            {

                Pessoa p  = _servicoPessoa.InserirPessoa(funcionario);
                
                funcionario.IdPessoa = p.IdPessoa;
                funcionario.UuidPessoa = p.UuidPessoa;
                funcionario.CreatedAtPessoa = p.CreatedAtPessoa;
                funcionario.UpdatedAtPessoa = p.UpdatedAtPessoa;

                funcionario.Usuario = _servicoUsuario.InserirUsuario(funcionario.Usuario);
                
                Funcionario f = _db.Inserir(funcionario);

                funcionario.IdFuncionario = f.IdFuncionario;
                funcionario.UuidFuncionario = f.UuidFuncionario;
                funcionario.CreatedAtFuncionario = f.CreatedAtFuncionario;
                funcionario.UpdatedAtFuncionario = f.UpdatedAtFuncionario;

                return funcionario;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeletarFuncionario(Funcionario funcionario)
        {
            try
            {

                if (_db.Deletar(funcionario))
                {
                    _servicoPessoa.DeletarPessoa(funcionario);
                    _servicoUsuario.DeletarUsuario(funcionario.Usuario);
                }
                else
                {
                    throw new Exception("Não foi possivel deletar o funcionário informado");
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Funcionario BuscarPeloId(int id)
        {
            try
            {

                Funcionario fun = new Funcionario();

                Funcionario f = _db.BuscarPeloID(id);
                Usuario u = _servicoUsuario.BuscarPeloId(f.Usuario.Id);
                Pessoa p = _servicoPessoa.BuscarPeloId(f.IdPessoa);

                // Funcionário
                fun.IdFuncionario = f.IdFuncionario;
                fun.UuidFuncionario = f.UuidFuncionario;
                fun.CTPS = f.CTPS;
                fun.Admissao = f.Admissao;
                fun.CreatedAtFuncionario = f.CreatedAtFuncionario;
                fun.UpdatedAtFuncionario = f.UpdatedAtFuncionario;

                // Pessoa
                fun.IdPessoa = p.IdPessoa;
                fun.UuidPessoa = p.UuidPessoa;
                fun.Nome = p.Nome;
                fun.DataNascimento = p.DataNascimento;
                fun.Cpf = p.Cpf;
                fun.RG = p.RG;
                fun.Email = p.Email;
                fun.Telefone = p.Telefone;
                fun.Celular = p.Celular;
                fun.CreatedAtPessoa = p.CreatedAtPessoa;
                fun.UpdatedAtPessoa = p.UpdatedAtPessoa;

                // Usuario
                fun.Usuario = u;

                return fun;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
