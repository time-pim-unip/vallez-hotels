using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VallezHotels.Source.DB;
using VallezHotels.Source.DB.Conexao;
using VallezHotels.Source.DB.Exceptions;
using VallezHotels.Source.Entidades;

namespace VallezHotels.Source.Servicos
{
    public class PessoaServico
    {

        private readonly PessoaDB _db;

        public PessoaServico()
        {
            _db = new PessoaDB(new PGConexao());
        }

        public Pessoa InserirPessoa(Pessoa pessoa)
        {

            try
            {

                Pessoa p = _db.Inserir(pessoa);
                return p;

            }
            catch (Exception ex)
            {
                throw new Exception("SERVICE: " + ex.Message);
            }

        }

        public void DeletarPessoa(Pessoa pessoa)
        {
            try
            {
                _db.Deletar(pessoa);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Pessoa BuscarPeloId(int id)
        {
            try
            {
                if (id <= 0) throw new ArgumentException("Id não pode ser menor ou igual a zero !");

                Pessoa p = _db.BuscarPeloID(id);

                if (p == null) throw new NullReturnException("Não foi possivel localizar uma pessoa com o ID Informado.");

                return p;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Pessoa> BuscarTodas()
        {
            try
            {
                List<Pessoa> pessoas = _db.BuscarTodos();
                return pessoas;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Pessoa AlterarPessoa(Pessoa pessoa)
        {
            try
            {
                Pessoa p = _db.Atualizar(pessoa);
                return p;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
