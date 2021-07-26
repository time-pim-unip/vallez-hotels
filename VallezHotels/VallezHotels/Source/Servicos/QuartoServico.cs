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
    public class QuartoServico
    {

        private readonly QuartoDB _db;
        private readonly TipoQuartoServico _tipoQuartoServico;

        public QuartoServico()
        {
            _db = new QuartoDB(new PGConexao());
            _tipoQuartoServico = new TipoQuartoServico();
        }


        public Quarto InserirQuarto(Quarto quarto)
        {
            try
            {
                Quarto q =_db.Inserir(quarto);
                q.TipoQuarto = _tipoQuartoServico.BuscarPeloId(q.TipoQuarto.Id);

                return q;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeletarQuarto(Quarto quarto)
        {
            try
            {
                _db.Deletar(quarto);               

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Quarto BuscarPeloId(int id)
        {
            try
            {

                Quarto q = _db.BuscarPeloID(id);
                q.TipoQuarto = _tipoQuartoServico.BuscarPeloId(q.TipoQuarto.Id);

                return q;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Quarto> BuscarTodos()
        {
            try
            {

                List<Quarto> quartos = new List<Quarto>();

                quartos = _db.BuscarTodos();

                foreach (Quarto q in quartos)
                {
                    q.TipoQuarto = _tipoQuartoServico.BuscarPeloId(q.TipoQuarto.Id);
                }

                return quartos;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Quarto EditarQuarto(Quarto quarto)
        {
            try
            {

                Quarto q = _db.Atualizar(quarto);

                return q;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


    }
}
