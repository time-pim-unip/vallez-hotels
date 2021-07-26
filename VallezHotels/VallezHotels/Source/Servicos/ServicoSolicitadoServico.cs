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
    public class ServicoSolicitadoServico
    {

        private readonly ServicoSolicitadoDB _db;
        private readonly LocacaoServico _locacaoServico;
        private readonly ServicoServico _servicoServico;

        public ServicoSolicitadoServico()
        {
            _db = new ServicoSolicitadoDB(new PGConexao());
            _locacaoServico = new LocacaoServico();
            _servicoServico = new ServicoServico();
        }


        public ServicoSolicitado InserirServicoSolicitado(ServicoSolicitado servicoSolicitado)
        {
            try
            {
                ServicoSolicitado ss = _db.Inserir(servicoSolicitado);
                ss.Locacao = _locacaoServico.BuscarPeloId(ss.Locacao.Id);
                ss.Servico = _servicoServico.BuscarPeloId(ss.Servico.Id);

                return ss;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void DeletarServicoSolicitado(ServicoSolicitado servicoSolicitado)
        {
            try
            {
                _db.Deletar(servicoSolicitado);

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ServicoSolicitado BuscarPeloId(int id)
        {
            try
            {

                ServicoSolicitado ss = _db.BuscarPeloID(id);
                ss.Locacao = _locacaoServico.BuscarPeloId(ss.Locacao.Id);
                ss.Servico = _servicoServico.BuscarPeloId(ss.Servico.Id);

                return ss;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<ServicoSolicitado> BuscarTodos()
        {
            try
            {

                List<ServicoSolicitado> servicoSolicitados = new List<ServicoSolicitado>();

                servicoSolicitados = _db.BuscarTodos();

                foreach (ServicoSolicitado ss in servicoSolicitados)
                {
                    ss.Locacao = _locacaoServico.BuscarPeloId(ss.Locacao.Id);
                    ss.Servico = _servicoServico.BuscarPeloId(ss.Servico.Id);
                }

                return servicoSolicitados;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ServicoSolicitado EditarServicoSolicitado(ServicoSolicitado servicoSolicitado)
        {
            try
            {

                ServicoSolicitado ss = _db.Atualizar(servicoSolicitado);
                ss.Locacao = _locacaoServico.BuscarPeloId(ss.Locacao.Id);
                ss.Servico = _servicoServico.BuscarPeloId(ss.Servico.Id);

                return ss;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


    }
}
