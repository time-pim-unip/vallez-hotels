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
    public class TipoQuartoServico
    {

        private readonly TipoQuartoDB _db;

        public TipoQuartoServico()
        {

            _db = new TipoQuartoDB(new PGConexao());

        }

        public TipoQuarto InserirTipoQuarto(TipoQuarto tipoQuarto)
        {
            try
            {
                TipoQuarto t = _db.Inserir(tipoQuarto);
                return t;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public bool DeletarTipoQuarto(TipoQuarto tipoQuarto)
        {
            try
            {
                return (_db.Deletar(tipoQuarto)) ? true : false;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public TipoQuarto BuscarPeloId(int id)
        {
            try
            {
                TipoQuarto t = _db.BuscarPeloID(id);
                return t;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<TipoQuarto> BuscarTodos()
        {
            try
            {
                List<TipoQuarto> t = _db.BuscarTodos();
                return t;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public TipoQuarto AlterarTipoQuarto(TipoQuarto tipoQuarto)
        {
            try
            {
                TipoQuarto t = _db.Atualizar(tipoQuarto);
                return t;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
