-- Drop table

-- DROP TABLE public.tb_servicos;

CREATE TABLE public.tb_servicos (
	id_servicos serial NOT NULL,
	descricao varchar(255) NULL,
	valor numeric(10,2) NULL,
	CONSTRAINT tb_servicos_pkey PRIMARY KEY (id_servicos)
);
