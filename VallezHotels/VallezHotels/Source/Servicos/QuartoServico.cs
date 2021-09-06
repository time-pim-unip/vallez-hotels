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
        private readonly DisponibilidadeServico _disponibilidadeServico;

        public QuartoServico()
        {
            _db = new QuartoDB(new PGConexao());
            _tipoQuartoServico = new TipoQuartoServico();
            _disponibilidadeServico = new DisponibilidadeServico(this);
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
                q.Disponibilidades = _disponibilidadeServico.BuscarPeloQuarto(q);

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
                    q.Disponibilidades = _disponibilidadeServico.BuscarPeloQuarto(q);
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


        public void RemoverDisponibilidades(Quarto q, Locacao locacao)
        {
            try
            {
                List<Disponibilidade> disponibilidadesQuarto = _disponibilidadeServico.BuscarPeloQuarto(q);
                List<DateTime> datasLocacao = locacao.DataEntrada.RetornarPeriodo(locacao.DataSaida);

                foreach (DateTime dt in datasLocacao)
                {
                    var disponibilidade = disponibilidadesQuarto.Where(x => x.Data.Date == dt.Date);

                    if (disponibilidade.Count() != 0)
                    {

                        Disponibilidade d = disponibilidade.FirstOrDefault();
                        d.Disponivel = false;
                        d.Locacao = locacao;
                        _disponibilidadeServico.EditarDisponibilidade(d);
                    }
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void HabilitarDisponibilidades(Quarto q, Locacao locacao)
        {
            try
            {
                List<Disponibilidade> disponibilidadesQuarto = _disponibilidadeServico.BuscarPeloQuarto(q);
                List<DateTime> datasLocacao = locacao.DataEntrada.RetornarPeriodo(locacao.DataSaida);

                foreach (DateTime dt in datasLocacao)
                {
                    var disponibilidade = disponibilidadesQuarto.Where(x => x.Data.Date == dt.Date);

                    if (disponibilidade.Count() != 0)
                    {

                        Disponibilidade d = disponibilidade.FirstOrDefault();
                        d.Disponivel = true;
                        d.Locacao = null;
                        _disponibilidadeServico.EditarDisponibilidade(d);
                    }
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
