/*
 *  CONFIGURACOES DO BANCO
 */

/* Criar usuario do sistema */
create user  vallez with encrypted password '#vallez123@';

/* Criando banco principal do sistema */
create database db_vallez
with owner vallez
connection limit -1
encoding 'UTF8'
template template0;

/*
 *  CONECTAR COM USUÁRIO VALLEZ NO BANCO DB_VALLEZ PARA CONTINUAR O SCRIPT.
 */

/* Criar schema do sistema */
create schema vallez  authorization vallez;

/* Direitos de usuário */
grant all privileges on database db_vallez to vallez;
grant all privileges on schema vallez to vallez;
grant all privileges on all tables in schema vallez to vallez;

/* Habilitar UUID */
create extension if not exists "uuid-ossp";

/* 
 * 	TABELAS DO SISTEMA
 */

/* Pessoas */
create table pessoas(
	id_pessoa 		serial not null,
	uuid_pessoa 	uuid default uuid_generate_v4(),
	nome 			varchar(100) not null,
	data_nascimento date not null,
	cpf 			varchar(14) not null unique,
	rg 				varchar(13) not null unique,
	email 			varchar(255) not null,
	telefone 		varchar(45),
	celular 		varchar(45),
	created_at 		timestamp not null default now(),
	updated_at 		timestamp not null default now(),
	constraint pk_pessoa primary key (id_pessoa)
);

/* Usuarios */
create table usuarios(
	id_usuario 		serial not null,
	uuid_usuario 	uuid not null default uuid_generate_v4(),
	usuario 		varchar(40) not null unique,
	senha 			varchar(255) not null,
	tipo_usuario 	char(1) not null,
	status 			boolean not null default true,
	created_at 		timestamp not null default now(),
	updated_at 		timestamp not null default now(),
	constraint pk_usuario primary key (id_usuario)
);

/* Funcionarios */
create table funcionarios(
	id_funcionario 		serial not null,
	uuid_funcionario 	uuid not null default uuid_generate_v4(),
	id_pessoa 			int not null,
	id_usuario 			int not null,
	ctps 				varchar(15) not null,
	data_admissao 		date not null,
	created_at 			timestamp not null default now(),
	updated_at 			timestamp not null default now(),
	constraint pk_funcionario primary key (id_funcionario),
	constraint fk_pessoa_funcionario foreign key (id_pessoa) references pessoas(id_pessoa),
	constraint fk_usuario_funcionario foreign key (id_usuario) references usuarios(id_usuario)
);

/* Hospedes */
create table hospedes(
	id_hospede 			serial not null,
	uuid_hospede 		uuid not null default uuid_generate_v4(),
	id_pessoa 			int not null,
	id_usuario			int not null,
	consentimento_pais 	boolean not null default false,
	created_at			timestamp not null default now(),
	updated_at			timestamp not null default now(),
	constraint pk_hospede primary key (id_hospede),
	constraint fk_pessoa_hospede foreign key (id_pessoa) references pessoas(id_pessoa),
	constraint fk_usuario_hospede foreign key (id_usuario) references usuarios(id_usuario)
);

/* Tipo de Quarto */
create table tipo_quarto(
	id_tipo 	serial not null,
	uuid_tipo 	uuid not null default uuid_generate_v4(),
	descricao	varchar(45) not null,
	created_at	timestamp not null default now(),
	updated_at	timestamp not null default now(),
	constraint pk_tipo_quarto primary key (id_tipo)
);

/* Quartos */
create table quartos(
	id_quarto		serial not null,
	uuid_quarto		uuid not null default uuid_generate_v4(),
	id_tipo_quarto	int not null,
	bloco 			varchar(2) not null,
	numero 			int not null,
	qtde_banheiros  int not null,
	qtde_camas 		int not null,
	valor_diaria	numeric(15, 2),
	created_at		timestamp not null default now(),
	updated_at		timestamp not null default now(),
	constraint pk_quarto primary key (id_quarto),
	constraint fk_tipo_quarto foreign key (id_tipo_quarto) references tipo_quarto(id_tipo)
);

/* Disponibilidades */
create table disponibilidades(
	id_disponibilidade 		serial not null,
	uuid_disponibilidade	uuid not null default uuid_generate_v4(),
	id_quarto				int not null,
	data					date not null,
	dia_disponivel			boolean not null,
	created_at				timestamp not null default now(),
	updated_at				timestamp not null default now(),
	constraint pk_disponibilidade primary key (id_disponibilidade),
	constraint fk_quarto_disponibilidade foreign key (id_quarto) references quartos(id_quarto)	
);

/* Locacoes */
create table locacoes(
	id_locacao 		serial not null,
	uuid_locacao 	uuid not null default uuid_generate_v4(),
	id_quarto		int not null,
	dt_entrada		timestamp not null,
	dt_saida		timestamp not null,
	dt_checkin		timestamp,
	dt_checkout		timestamp,
	created_at		timestamp not null default now(),
	updated_at		timestamp not null default now(),
	constraint pk_locacao primary key (id_locacao),
	constraint fk_quarto_locacao foreign key (id_quarto) references quartos(id_quarto)
);

/* Faturamentos */
create table faturamentos(
	id_faturamento		serial not null,
	uuid_faturamento	uuid not null default uuid_generate_v4(),
	id_locacao			int not null,
	valor_total			numeric(15,2) not null,
	valor_desconto		numeric(15,2) not null,
	valor_pago			numeric(15,2) not null,
	created_at			timestamp not null default now(),
	updated_at			timestamp not null default now(),
	constraint pk_faturamento primary key (id_faturamento),
	constraint fk_locacao_faturamento foreign key (id_locacao) references locacoes(id_locacao)
);

/* Hospedagens */
create table hospedagens(
	id_locacao		int not null,
	id_hospede		int not null,
	uuid_hospedagem	uuid not null default uuid_generate_v4(),
	detentor		boolean not null,
	created_at		timestamp not null default now(),
	updated_at		timestamp not null default now(),
	constraint pk_hospedagens primary key (id_locacao, id_hospede),
	constraint fk_locacao_hospedagem foreign key (id_locacao) references locacoes(id_locacao),
	constraint fk_hospede_hospedagem foreign key (id_hospede) references hospedes(id_hospede)
);

/* Servicos */
create table servicos(
	id_servico		serial not null,
	uuid_servico	uuid not null default uuid_generate_v4(),
	descricao		varchar(45) not null,
	valor			numeric(15,2) not null,
	created_at		timestamp not null default now(),
	updated_at		timestamp not null default now(),
	constraint pk_servico primary key (id_servico)
);

/* Servicos Solicitados */
create table servicos_solicitados(
	id_servico_solicitado		serial not null,
	uuid_servico_solicitado		uuid not null default uuid_generate_v4(),
	id_servico					int not null,
	id_locacao					int not null,
	data_solicitacao			date not null,
	qtde_solicitacao			int not null,
	created_at					timestamp not null default now(),
	updated_at					timestamp not null default now(),
	constraint pk_servico_solicitado primary key (id_servico_solicitado),
	constraint fk_servico_serv_solic foreign key (id_servico) references servicos(id_servico),
	constraint fk_locacao_serv_solic foreign key (id_locacao) references locacoes(id_locacao)
);








