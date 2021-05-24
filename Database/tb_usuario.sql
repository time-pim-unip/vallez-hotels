-- Drop table

-- DROP TABLE public.tb_usuario;

CREATE TABLE public.tb_usuario (
	id_usuario serial NOT NULL,
	usuario varchar(150) NOT NULL,
	senha varchar(30) NULL,
	tipo_usuario bpchar(50) NULL,
	status int4 NULL,
	CONSTRAINT tb_usuario_pkey PRIMARY KEY (id_usuario)
);
