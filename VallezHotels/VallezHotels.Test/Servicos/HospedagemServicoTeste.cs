using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using VallezHotels.Source.Servicos;
using VallezHotels.Source.Entidades;

namespace VallezHotels.Test.Servicos
{
    public class HospedagemServicoTeste : IDisposable
    {

        private readonly QuartoServico _quartoServico = new QuartoServico();
        private readonly TipoQuartoServico _tipoQuartoServico = new TipoQuartoServico();
        private readonly LocacaoServico _locacaoServico = new LocacaoServico();
        private readonly HospedeServico _hospedeServico = new HospedeServico();
        private readonly UsuarioServico _usuarioServico = new UsuarioServico();
        private Quarto Q1;
        private Quarto Q2;
        private TipoQuarto Tq1;
        private TipoQuarto Tq2;
        private Locacao L1;
        private Locacao L2;
        private Hospede H1;
        private Usuario U1;


        public HospedagemServicoTeste()
        {

            TipoQuarto tq1 = new TipoQuarto()
            {
                Descricao = "Casal"
            };

            TipoQuarto tq2 = new TipoQuarto()
            {
                Descricao = "Simples"
            };

            Tq1 = _tipoQuartoServico.InserirTipoQuarto(tq1);
            Tq2 = _tipoQuartoServico.InserirTipoQuarto(tq2);

            Quarto q1 = new Quarto()
            {
                TipoQuarto = Tq1,
                Bloco = "A",
                Numero = 1,
                QuantidadeBanheiros = 1,
                QuantidadeCamas = 1,
                ValorDiaria = 22.58
            };

            Quarto q2 = new Quarto()
            {
                TipoQuarto = Tq2,
                Bloco = "B",
                Numero = 1,
                QuantidadeBanheiros = 1,
                QuantidadeCamas = 1,
                ValorDiaria = 22.58
            };

            Q1 = _quartoServico.InserirQuarto(q1);
            Q2 = _quartoServico.InserirQuarto(q2);

            Locacao l1 = new Locacao()
            {
                Quarto = Q1,
                DataEntrada = new DateTime(2021, 03, 01),
                DataSaida = new DateTime(2021, 03, 07),
                CheckIn = new DateTime(2021, 03, 01),
                CheckOut = new DateTime(2021, 03, 07),
            };

            Locacao l2 = new Locacao()
            {
                Quarto = Q2,
                DataEntrada = new DateTime(2021, 03, 01),
                DataSaida = new DateTime(2021, 03, 07),
                CheckIn = new DateTime(2021, 03, 01),
                CheckOut = new DateTime(2021, 03, 07),
            };

            L1 = _locacaoServico.InserirLocacao(l1);
            L2 = _locacaoServico.InserirLocacao(l2);

            Hospede h = new Hospede()
            {
                Nome = "Hospede Teste",
                DataNascimento = new DateTime(1997, 03, 15),
                Cpf = "111",
                RG = "111",
                Email = "hospede@email.com",
                Telefone = "(11) 11111-1111",
                Celular = "(11) 11111-1111",
                Consentimento = true
            };

            h.Usuario = new Usuario()
            {
                NomeUsuario = "usuario.teste.hospede",
                Senha = "123456",
                TipoUsuario = "U",
                Status = true
            };

            H1 = _hospedeServico.InserirHospede(h);
            
        }

        [Fact]
        public void Deve_Inserir_Um_Novo_Hospedagem()
        {

            Hospedagem h = new Hospedagem()
            {
                Locacao = L1,
                Hospede = H1,
                Detentor = true
            };


            HospedagemServico hospedagemServico = new HospedagemServico();

            Hospedagem novo = hospedagemServico.InserirHospedagem(h);

            Assert.NotNull(novo.Uuid);
            Assert.NotNull(novo.Locacao.Uuid);
            Assert.NotNull(novo.Hospede.UuidHospede);

            hospedagemServico.DeletarHospedagem(novo);

        }



        [Fact]
        public void Deve_Excluir_Um_Hospedagem()
        {

            Hospedagem h = new Hospedagem()
            {
                Locacao = L1,
                Hospede = H1,
                Detentor = true
            };


            HospedagemServico hospedagemServico = new HospedagemServico();

            Hospedagem novo = hospedagemServico.InserirHospedagem(h);

            hospedagemServico.DeletarHospedagem(novo);

            Assert.NotNull(novo);
        }


        [Fact]
        public void Deve_Buscar_Um_Hospedagem()
        {
            Hospedagem h = new Hospedagem()
            {
                Locacao = L1,
                Hospede = H1,
                Detentor = true
            };


            HospedagemServico hospedagemServico = new HospedagemServico();

            Hospedagem novo = hospedagemServico.InserirHospedagem(h);

            Hospedagem busca = hospedagemServico.BuscarPeloId(novo.Locacao.Id, novo.Hospede.IdHospede);

            Assert.NotNull(busca);
            Assert.NotNull(busca.Uuid);

            hospedagemServico.DeletarHospedagem(busca);

        }


        [Fact]
        public void Deve_Buscar_Todos_Hospedagems()
        {
            Hospedagem h1 = new Hospedagem()
            {
                Locacao = L1,
                Hospede = H1,
                Detentor = true
            };


            Hospedagem h2 = new Hospedagem()
            {
                Locacao = L2,
                Hospede = H1,
                Detentor = true
            };


            HospedagemServico hospedagemServico = new HospedagemServico();

            hospedagemServico.InserirHospedagem(h1);
            hospedagemServico.InserirHospedagem(h2);

            List<Hospedagem> hospedagems = hospedagemServico.BuscarTodos();

            Assert.NotEmpty(hospedagems);
            Assert.Equal(2, hospedagems.Count);

            hospedagemServico.DeletarHospedagem(hospedagems[0]);
            hospedagemServico.DeletarHospedagem(hospedagems[1]);

        }


        [Fact]
        public void Deve_Alterar_Um_Hospedagem()
        {

            Hospedagem h = new Hospedagem()
            {
                Locacao = L1,
                Hospede = H1,
                Detentor = true
            };

            HospedagemServico hospedagemServico = new HospedagemServico();

            Hospedagem criado = hospedagemServico.InserirHospedagem(h);

            Hospedagem alterado = new Hospedagem()
            {
                Uuid = criado.Uuid,
                Locacao = criado.Locacao,
                Hospede = criado.Hospede,
                Detentor = false,
                CreatedAt = criado.CreatedAt,
                UpdatedAt = criado.UpdatedAt
            };


            Hospedagem busca = hospedagemServico.EditarHospedagem(alterado);

            Assert.NotEqual(h.Detentor, busca.Detentor);

            hospedagemServico.DeletarHospedagem(busca);

        }

        public void Dispose()
        {
            _hospedeServico.DeletarHospede(H1);

            _locacaoServico.DeletarLocacao(L1);
            _locacaoServico.DeletarLocacao(L2);

            _quartoServico.DeletarQuarto(Q1);
            _quartoServico.DeletarQuarto(Q2);

            _tipoQuartoServico.DeletarTipoQuarto(Tq1);
            _tipoQuartoServico.DeletarTipoQuarto(Tq2);
        }
    }

}
