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
    public class ServicoServico
    {

        private readonly ServicoDB _db;

        public ServicoServico()
        {

            _db = new ServicoDB(new PGConexao());

        }

        public Servico InserirServico(Servico servico)
        {
            try
            {
                Servico s = _db.Inserir(servico);
                return s;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool DeletarServico(Servico servico)
        {
            try
            {
                return (_db.Deletar(servico)) ? true : false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Servico BuscarPeloId(int id)
        {
            try
            {
                Servico s = _db.BuscarPeloID(id);
                return s;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Servico> BuscarTodos()
        {
            try
            {
                List<Servico> s = _db.BuscarTodos();
                return s;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Servico AlterarServico(Servico servico)
        {
            try
            {
                Servico s = _db.Atualizar(servico);
                return s;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }





    }
}
