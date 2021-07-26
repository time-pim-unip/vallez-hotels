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
    public class HospedagemServico
    {

        private readonly HospedagemDB _db;
        private readonly LocacaoServico _locacaoServico;
        private readonly HospedeServico _hospedeServico;

        public HospedagemServico()
        {
            _db = new HospedagemDB(new PGConexao());
            _locacaoServico = new LocacaoServico();
            _hospedeServico = new HospedeServico();
        }


        public Hospedagem InserirHospedagem(Hospedagem hospedagem)
        {
            try
            {
                Hospedagem h = _db.Inserir(hospedagem);
                h.Locacao = _locacaoServico.BuscarPeloId(h.Locacao.Id);
                h.Hospede = _hospedeServico.BuscarPeloId(h.Hospede.IdHospede);

                return h;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeletarHospedagem(Hospedagem hospedagem)
        {
            try
            {
                _db.Deletar(hospedagem);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Hospedagem BuscarPeloId(int idLocacao, int idHospede)
        {
            try
            {

                Hospedagem h = _db.BuscarPeloID(idLocacao, idHospede);
                h.Locacao = _locacaoServico.BuscarPeloId(idLocacao);
                h.Hospede = _hospedeServico.BuscarPeloId(idHospede);

                return h;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<Hospedagem> BuscarTodos()
        {
            try
            {

                List<Hospedagem> hospedagems = new List<Hospedagem>();

                hospedagems = _db.BuscarTodos();

                foreach (Hospedagem h in hospedagems)
                {
                    h.Locacao = _locacaoServico.BuscarPeloId(h.Locacao.Id);
                    h.Hospede = _hospedeServico.BuscarPeloId(h.Hospede.IdHospede);
                }

                return hospedagems;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Hospedagem EditarHospedagem(Hospedagem hospedagem)
        {
            try
            {

                Hospedagem h = _db.Atualizar(hospedagem);
                h.Locacao = _locacaoServico.BuscarPeloId(h.Locacao.Id);
                h.Hospede = _hospedeServico.BuscarPeloId(h.Hospede.IdHospede);

                return h;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


    }
}
