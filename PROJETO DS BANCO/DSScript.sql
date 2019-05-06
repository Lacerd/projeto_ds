create database projeto_ds;

use projeto_ds;

create table cliente (
cod_cliente int auto_increment primary key,
nome varchar (255),
telefone varchar (255),
endereco varchar (255),
email varchar (255),
idade int,
salario double

);

 -- PROCEDURES DO BANCO

 -- Procedure Inserir Cliente

DELIMITER $$
drop procedure if exists `projeto_ds`.`inserirCliente` $$
CREATE PROCEDURE `projeto_ds`.`inserirCliente` (
in v_nome varchar (255),in v_tel varchar (255),
in v_end varchar (255),in v_email varchar (255),
in v_idade int,in v_sal double

)
BEGIN

insert into Cliente (nome, telefone, endereco, email, idade, salario) 
 values (v_nome, v_tel, v_end, v_email, v_idade, v_sal);


END $$
Delimiter ;
-- --------------------------------------------------------------------

 -- Procedure Alterar Cliente

DELIMITER $$
drop procedure if exists `projeto_ds`.`alterarCliente` $$
CREATE PROCEDURE `projeto_ds`.`alterarCliente` (
in v_nome varchar (255),in v_tel varchar (255),
in v_end varchar (255),in v_email varchar (255),
in v_idade int,
in v_sal double,
in v_codcliente int

)
BEGIN

update cliente set nome = v_nome, 
                   telefone = v_tel,
			       endereco = v_end,
				   email = v_email,
				   idade = v_idade, 
                   salario = v_sal
                   where cod_cliente = v_codcliente;

END $$
Delimiter ;
-- --------------------------------------------------------------------


 -- Procedure Excluir Cliente

DELIMITER $$
drop procedure if exists `projeto_ds`.`excluirCliente` $$
CREATE PROCEDURE `projeto_ds`.`excluirCliente` (

in v_codcliente int

)
BEGIN

delete from cliente  where cod_cliente = v_codcliente;

END $$
Delimiter ;
-- --------------------------------------------------------------------


 -- Procedure Listar Todos

DELIMITER $$
drop procedure if exists `projeto_ds`.`listarTodosClientes` $$
CREATE PROCEDURE `projeto_ds`.`listarTodosClientes` ()
BEGIN

select * from cliente;

END $$
Delimiter ;
-- --------------------------------------------------------------------

 -- Procedure Consultar Por nome

DELIMITER $$
drop procedure if exists `projeto_ds`.`buscaPorNome` $$
CREATE PROCEDURE `projeto_ds`.`buscaPorNome` (

	in v_nome varchar(255)

)
BEGIN

select * from cliente where nome= v_nome;

END $$
Delimiter ;
-- --------------------------------------------------------------------
