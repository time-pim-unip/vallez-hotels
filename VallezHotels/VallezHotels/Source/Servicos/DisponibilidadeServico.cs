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
    public class DisponibilidadeServico
    {

        private readonly DisponibilidadeDB _db;
        private readonly QuartoServico _quartoServico;

        public DisponibilidadeServico()
        {
            _db = new DisponibilidadeDB(new PGConexao());
            _quartoServico = new QuartoServico();
        }

        public DisponibilidadeServico(QuartoServico quartoServico)
        {
            _db = new DisponibilidadeDB(new PGConexao());
            _quartoServico = quartoServico;
        }

        public Disponibilidade InserirDisponibilidade(Disponibilidade disponibilidade)
        {
            try
            {
                Disponibilidade d = _db.Inserir(disponibilidade);
                d.Quarto = _quartoServico.BuscarPeloId(d.Quarto.Id);

                return d;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeletarDisponibilidade(Disponibilidade disponibilidade)
        {
            try
            {
                _db.Deletar(disponibilidade);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Disponibilidade BuscarPeloId(int id)
        {
            try
            {

                Disponibilidade d = _db.BuscarPeloID(id);
                d.Quarto = _quartoServico.BuscarPeloId(d.Quarto.Id);

                return d;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Disponibilidade> BuscarTodos()
        {
            try
            {

                List<Disponibilidade> disponibilidades = new List<Disponibilidade>();

                disponibilidades = _db.BuscarTodos();

                foreach (Disponibilidade d in disponibilidades)
                {
                    d.Quarto = _quartoServico.BuscarPeloId(d.Quarto.Id);
                }

                return disponibilidades;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Disponibilidade EditarDisponibilidade(Disponibilidade disponibilidade)
        {
            try
            {

                Disponibilidade d = _db.Atualizar(disponibilidade);
                d.Quarto = _quartoServico.BuscarPeloId(d.Quarto.Id);

                return d;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Disponibilidade> InserirRangePeloQuarto(Quarto quarto)
        {
            
            try
            {

                List<Disponibilidade> disponibilidades = new List<Disponibilidade>();

                foreach (Disponibilidade d in quarto.Disponibilidades)
                {

                    d.Quarto.Id = quarto.Id;
                    Disponibilidade disponibilidadeInserida = this.InserirDisponibilidade(d);
                    disponibilidades.Add(disponibilidadeInserida);
                }

                return disponibilidades;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            
        }

        public List<Disponibilidade> BuscarPeloQuarto(Quarto quarto)
        {
            try
            {

                List<Disponibilidade> d = _db.BuscarPeloQuarto(quarto);

                return d;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


    }
}
