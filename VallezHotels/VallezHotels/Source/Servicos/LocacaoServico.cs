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
    public class LocacaoServico
    {

        private readonly LocacaoDB _db;
        private readonly QuartoServico _quartoServico;

        public LocacaoServico()
        {
            _db = new LocacaoDB(new PGConexao());
            _quartoServico = new QuartoServico();
        }


        public Locacao InserirLocacao(Locacao locacao)
        {
            try
            {
                Locacao l = _db.Inserir(locacao);
                l.Quarto = _quartoServico.BuscarPeloId(l.Quarto.Id);
                _quartoServico.RemoverDisponibilidades(l.Quarto, locacao);

                return l;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeletarLocacao(Locacao locacao)
        {
            try
            {
                _db.Deletar(locacao);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Locacao BuscarPeloId(int id)
        {
            try
            {

                Locacao l = _db.BuscarPeloID(id);
                l.Quarto = _quartoServico.BuscarPeloId(l.Quarto.Id);

                return l;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Locacao> BuscarTodos()
        {
            try
            {

                List<Locacao> locacaos = new List<Locacao>();

                locacaos = _db.BuscarTodos();

                foreach (Locacao l in locacaos)
                {
                    l.Quarto = _quartoServico.BuscarPeloId(l.Quarto.Id);
                }

                return locacaos;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Locacao EditarLocacao(Locacao locacao)
        {
            try
            {

                Locacao l = _db.Atualizar(locacao);
                l.Quarto = _quartoServico.BuscarPeloId(locacao.Quarto.Id);
                _quartoServico.RemoverDisponibilidades(l.Quarto, locacao);

                return l;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Locacao BuscarPelaDataEQuarto(Quarto q, DateTime data)
        {
            try
            {

                Locacao l = new Locacao(); 
                l = _db.BuscarPelaDataEQuarto(q, data);
                return l;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Locacao BuscarPelaDataEQuarto(Quarto q)
        {
            return this.BuscarPelaDataEQuarto(q, DateTime.Now);
        }

    }
}
