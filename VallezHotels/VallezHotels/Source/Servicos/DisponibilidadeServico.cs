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


    }
}
