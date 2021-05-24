-- Drop table

-- DROP TABLE public.tb_funcionario;

CREATE TABLE public.tb_funcionario (
	id_funcionario serial NOT NULL,
	ctps int4 NOT NULL,
	data_admissao date NOT NULL,
	id_pessoa int4 NOT NULL,
	id_usuario int4 NOT NULL,
	CONSTRAINT tb_funcionario_id_pessoa_fkey FOREIGN KEY (id_pessoa) REFERENCES tb_pessoa(id_pessoa),
	CONSTRAINT tb_funcionario_id_usuario_fkey FOREIGN KEY (id_usuario) REFERENCES tb_usuario(id_usuario)
);
