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
    public class FaturamentoServico
    {

        private readonly FaturamentoDB _db;
        private readonly LocacaoServico _locacaoServico;

        public FaturamentoServico()
        {
            _db = new FaturamentoDB(new PGConexao());
            _locacaoServico = new LocacaoServico();
        }


        public Faturamento InserirFaturamento(Faturamento faturamento)
        {
            try
            {
                Faturamento f = _db.Inserir(faturamento);
                f.Locacao = _locacaoServico.BuscarPeloId(f.Locacao.Id);

                return f;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeletarFaturamento(Faturamento faturamento)
        {
            try
            {
                _db.Deletar(faturamento);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Faturamento BuscarPeloId(int id)
        {
            try
            {

                Faturamento f = _db.BuscarPeloID(id);
                f.Locacao = _locacaoServico.BuscarPeloId(f.Locacao.Id);

                return f;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Faturamento> BuscarTodos()
        {
            try
            {

                List<Faturamento> faturamentos = new List<Faturamento>();

                faturamentos = _db.BuscarTodos();

                foreach (Faturamento f in faturamentos)
                {
                    f.Locacao = _locacaoServico.BuscarPeloId(f.Locacao.Id);
                }

                return faturamentos;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Faturamento EditarFaturamento(Faturamento faturamento)
        {
            try
            {

                Faturamento f = _db.Atualizar(faturamento);
                f.Locacao = _locacaoServico.BuscarPeloId(f.Locacao.Id);

                return f;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


    }
}
