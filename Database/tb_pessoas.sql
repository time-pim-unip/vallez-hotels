-- Drop table

-- DROP TABLE public.tb_pessoa;

CREATE TABLE public.tb_pessoa (
	id_pessoa serial NOT NULL,
	data_nascimento date NULL,
	cpf varchar(25) NULL,
	nome_completo varchar(200) NOT NULL,
	email varchar(150) NOT NULL,
	CONSTRAINT tb_pessoa_email_key UNIQUE (email),
	CONSTRAINT tb_pessoa_pkey PRIMARY KEY (id_pessoa)
);
