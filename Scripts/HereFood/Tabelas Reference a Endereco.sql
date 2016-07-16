create table pais (
idpais int primary key not null identity(1,1),
nomepais varchar(80) not null,
flgAtivo bit not null
)

create table estado (
idestado int primary key not null identity(1,1),
idpais int not null,
UF char(2),
nomeestado varchar(100) not null,
flgativo bit not null,
constraint fk_estado_pais foreign key (idpais) references pais(idpais)
)

create table cidade (
idcidade int primary key not null identity(1,1),
idestado int not null,
nomecidade varchar(100) not null,
cep char(8) not null,
flgativo bit not null,
constraint fk_cidade_estado foreign key (idestado) references estado(idestado)
)

create table tipoendereco(
idtipoendereco int primary key not null identity(1,1),
nometipoEndereco varchar(80) not null,
flgativo bit not null
)

create table tipotelefone(
idtipotelefone int primary key not null identity(1,1),
nometipotelefone varchar(80) not null,
flgativo bit not null
)

create table telefone(
idtelefone int primary key not null identity(1,1),
idpessoa int not null,
idtipotelefone int not null,
ddi varchar(3) not null,
ddd varchar(3) not null,
numero varchar(20) not null,
constraint fk_telefone_pessoa foreign key (idpessoa) references  pessoa(idpessoa),
constraint fk_telefone_tipotelefone foreign key (idtipotelefone) references tipotelefone(idtipotelefone)
)

create table endereco(
idendereco int primary key not null identity(1,1),
idpessoa int not null,
idtipoendereco int not null,
logradouro varchar(300) not null,
complemento varchar(300),
numero int not null,
bairro varchar(100) not null,
idcidade int not null,
idestado int not null,
cep char(8) not null,
constraint fk_endereco_pessoa foreign key (idpessoa) references  pessoa(idpessoa),
constraint fk_endereco_tipoendereco foreign key (idtipoendereco) references tipoendereco(idtipoendereco),
constraint fk_endereco_cidade foreign key (idcidade) references cidade(idcidade),
constraint fk_endereco_estado foreign key (idestado) references estado(idestado)

)