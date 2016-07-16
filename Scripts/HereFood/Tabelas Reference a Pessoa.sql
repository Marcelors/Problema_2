create table categoriaPessoa(
idcategoriaPessoa int primary key not null identity(1,1),
nomecategoriaPessoa varchar(80) not null,
flgativo bit not null
)

create table pessoa(
idpessoa int primary key not null identity(1,1),
nome varchar(120) not null,
nomeFantasia varchar(120) not null,
email varchar(300) not null,
flgativo bit not null,
cpfCnpj varchar(14) not null,
idpessoaresponsavel int,
datanacimento date,
idcategoriaPessoa int not null,
tipopessoa char(1) not null,
constraint fk_pessoa_pessoaResposavel foreign key (idpessoaresponsavel) references pessoa(idpessoa),
constraint fk_pessoa_categoria foreign key (idcategoriapessoa) references categoriapessoa(idcategoriapessoa)
)

