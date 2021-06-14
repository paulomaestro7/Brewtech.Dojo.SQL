drop table IF EXISTS Pessoa_Juridica;
drop table IF EXISTS Pessoa_Fisica;
drop table IF EXISTS Pedido_Produto;
drop table IF EXISTS Pedido;
drop table IF EXISTS Pessoa;
drop table IF EXISTS Produto_Preco_tipo;
drop table IF EXISTS Produto_Preco;
drop table IF EXISTS Produto;
drop table IF EXISTS Tipo_Vigencia;
drop table IF EXISTS Tipo;


Create table IF NOT EXISTS Pessoa
(
	Id serial,
	CONSTRAINT pk_pessoa PRIMARY KEY(Id),
	Nome varchar(250) not null,
	Situacao boolean default true
);
Create table IF NOT EXISTS Pessoa_Fisica
(
	Id serial,
	CONSTRAINT pk_pessoa_fisica PRIMARY KEY(Id),
	CPF varchar(20) not null UNIQUE,
	Id_Pessoa int not null,
	CONSTRAINT fk_Pessoa_Fisica_Pessoa
    FOREIGN KEY(Id_Pessoa) 
	REFERENCES Pessoa(Id)
);
Create table IF NOT EXISTS Pessoa_Juridica
(
	Id serial,
	CONSTRAINT pk_pessoa_juridica PRIMARY KEY(Id),
	Razao_Social varchar(250) not null,
	CNPJ varchar(20) not null UNIQUE,
	Id_Pessoa int not null,
	CONSTRAINT fk_Pessoa_Juridica_Pessoa
    FOREIGN KEY(Id_Pessoa) 
	REFERENCES Pessoa(Id)
);
create table IF NOT EXISTS Produto
(
	Id serial,
	CONSTRAINT pk_produto PRIMARY KEY(Id),
	Nome varchar(250) not null,
	EAN13 varchar(13),
	Situacao boolean default true
);
create table IF NOT EXISTS Produto_Preco
(
	Id serial,
	CONSTRAINT pk_produto_preco
	PRIMARY KEY (Id),
	Id_Produto int not null, 
	CONSTRAINT fk_produto_preco_produto 
	FOREIGN KEY(Id_Produto)
	REFERENCES Produto(Id),
	Preco money not null,
	Data_Inicio date default CURRENT_DATE,
	Data_Final date
);
Create table IF not EXISTS Pedido
(
	Id serial,
	CONSTRAINT pk_pedido PRIMARY KEY (Id),
	Id_Pessoa int not null,
	CONSTRAINT fk_pedido_pessoa
	FOREIGN KEY (Id_Pessoa)
	REFERENCES Pessoa(Id),
	Situacao Char(1) not null,
	Data date default CURRENT_DATE,
	Total money not null
);
Create table IF not EXISTS Pedido_Produto
(
	Id serial,
	CONSTRAINT pk_pedido_produto PRIMARY KEY (Id),
	Id_Pedido int not null,
	CONSTRAINT fk_pedido_produto_pedido
	FOREIGN KEY (Id_Pedido)
	REFERENCES Pedido(Id),
	Id_Produto int not null,
	CONSTRAINT fk_pedido_produto_produto
	FOREIGN KEY (Id_Produto)
	REFERENCES Produto(Id),
	Quantidade int not null,
	Preco money not null
);
Create table IF not EXISTS Tipo
(
	Id int not null,
	CONSTRAINT pk_Tipo PRIMARY KEY(Id),
	Nome varchar(250) not null,
	Situacao boolean default true
);

Create table IF not EXISTS Produto_Preco_Tipo
(
	Id_Tipo int not null,
	CONSTRAINT fk_produto_preco_grupo_tipo
	FOREIGN KEY (Id_Tipo)
	REFERENCES Tipo(Id),
	Id_Produto_Preco int not null,
	CONSTRAINT fk_produto_preco_grupo_produto_preco
	FOREIGN KEY (Id_Produto_Preco)
	REFERENCES Produto_Preco(Id),
	CONSTRAINT pk_produto_preco_grupo
	PRIMARY KEY (Id_Tipo, Id_Produto_Preco),
	Percentual decimal not null default 0.00
);
Create table IF not EXISTS Tipo_Vigencia
(
	Id serial,
	CONSTRAINT pk_tipo_vigencia
	PRIMARY KEY (Id),
	Id_Tipo int not null,
	CONSTRAINT fk_tipo_vigencia_tipo
	FOREIGN KEY (Id_Tipo)
	REFERENCES Tipo(Id),
	Inicio TIMESTAMP not null,
	Fim TIMESTAMP not null,
	Situacao boolean default true
);