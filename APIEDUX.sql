CREATE DATABASE APIEDUX;

USE APIEDUX;
GO



CREATE TABLE PERFIL(
	IdPerfil INT IDENTITY PRIMARY KEY NOT NULL,
	Permissao VARCHAR(50)
);

CREATE TABLE CATEGORIA(
	IdCategoria INT IDENTITY PRIMARY KEY NOT NULL,
	Tipo VARCHAR(255)
);

CREATE TABLE INSTITUICAO(
	IdInstituicao INT PRIMARY KEY NOT NULL,
	Nome VARCHAR(255),
	logradouro VARCHAR(255),
	Numero VARCHAR(255),
	Complemento VARCHAR(255),
	Bairro VARCHAR(255),
	Cidade VARCHAR(255),
	UF VARCHAR(2),
	CEP VARCHAR(15)
);

CREATE TABLE CURSO(
	IdCurso INT PRIMARY KEY IDENTITY NOT NULL,
	Titulo VARCHAR(255),
	idInstituicao INT FOREIGN KEY REFERENCES INSTITUICAO (IdInstituicao)
);

CREATE TABLE OBJETIVO(
	IdObjetivo INT PRIMARY KEY NOT NULL,
	Descricao VARCHAR(255),
	IdCategoria INT FOREIGN KEY REFERENCES CATEGORIA(IdCategoria)
);

CREATE TABLE TURMA(
	IdTurma INT PRIMARY KEY NOT NULL,
	Descricao VARCHAR(255),
	IdCurso INT FOREIGN KEY REFERENCES CURSO(IdCurso)
);

CREATE TABLE USUARIO(
	IdUsuario INT PRIMARY KEY IDENTITY NOT NULL,
	Nome VARCHAR(255),
	Email VARCHAR(100),
	Senha VARCHAR(255),
	DataCadastro DATETIME,
	DataUltimoAcesso DATETIME,
	IdPerfil INT FOREIGN KEY REFERENCES PERFIL(IdPerfil)
);

CREATE TABLE ALUNOTURMA(
	IdAlunoTurma INT PRIMARY KEY IDENTITY NOT NULL,
	Matricula VARCHAR(50),
	IdUsuario INT FOREIGN KEY REFERENCES USUARIO(IdUsuario),
	IdTurma INT FOREIGN KEY REFERENCES TURMA(IdTurma)
);

CREATE TABLE OBJETIVOALUNO(
	IdObjetivoAluno INT PRIMARY KEY IDENTITY NOT NULL,
	Nota DECIMAL DEFAULT NULL,
	DataAlcancado DATETIME,
	IdAlunoTurma INT FOREIGN KEY REFERENCES ALUNOTURMA(IdAlunoTurma),
	IdObjetivo INT FOREIGN KEY REFERENCES OBJETIVO(IdObjetivo)
);

CREATE TABLE PROFESSORTURMA(
	idProfessorTurma INT PRIMARY KEY IDENTITY NOT NULL,
	Descricao VARCHAR(255) ,
	Idusuario INT FOREIGN KEY REFERENCES USUARIO(IdUsuario) ,
	IdTurma INT FOREIGN KEY REFERENCES TURMA(IdTurma)		
);

CREATE TABLE DICA(
	IdDica INT PRIMARY KEY IDENTITY NOT NULL,
	Texto VARCHAR(255),
	Imagem VARCHAR(255),
	IdUsuario INT FOREIGN KEY REFERENCES USUARIO(IdUsuario)
);

CREATE TABLE CURTIDA(
	IdCurtida INT PRIMARY KEY IDENTITY NOT NULL,
	IdUsuario INT FOREIGN KEY REFERENCES USUARIO(IdUsuario) ,
	IdDica INT FOREIGN KEY REFERENCES DICA(IdDica)
);