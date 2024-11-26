-- DROP DATABASE GestaoRebanho;
CREATE DATABASE GestaoRebanho;
USE GestaoRebanho;

-- Tabela Usuario
CREATE TABLE Usuario (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nome_completo VARCHAR(255) NOT NULL,
    nome_usuario VARCHAR(100) NOT NULL,
    senha VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL,
    CPF VARCHAR(14) NOT NULL,
    dataNascimento DATE,
    endereco VARCHAR(255)
);

-- Tabela Animal
CREATE TABLE Animal (
    Codigo_brinco INT PRIMARY KEY,
    Raca VARCHAR(100) NOT NULL,
    peso DOUBLE NOT NULL,
    sexo VARCHAR(10) NOT NULL,
    idade INT NOT NULL
);

-- Tabela Rebanho
CREATE TABLE Rebanho (
    id INT AUTO_INCREMENT PRIMARY KEY,
    fk_Animal_Codigo_brinco INT NOT NULL,
    tipo VARCHAR(100),
    destino VARCHAR(255),
    FOREIGN KEY (fk_Animal_Codigo_brinco) REFERENCES Animal(Codigo_brinco)
);

-- Tabela Controle_pastagem
CREATE TABLE Controle_pastagem (
    id INT AUTO_INCREMENT PRIMARY KEY,
    area_de_pastagem DOUBLE NOT NULL,
    localizacao_pastagem VARCHAR(255),
    periodo INT,
    fk_Animal_Codigo_brinco INT NOT NULL,
    FOREIGN KEY (fk_Animal_Codigo_brinco) REFERENCES Animal(Codigo_brinco)
);

-- Tabela Alimentacao
CREATE TABLE Alimentacao (
    id INT AUTO_INCREMENT PRIMARY KEY,
    fornecedor VARCHAR(255),
    nome VARCHAR(100) NOT NULL,
    quantidade_em_estoque DOUBLE NOT NULL,
    validade DATE,
    data_que_foi_entregue DATE
);

-- Tabela Rebanho_Alimentacao
CREATE TABLE Rebanho_Alimentacao (
    id INT AUTO_INCREMENT PRIMARY KEY,
    fk_rebanho_id INT NOT NULL,
    fk_alimentacao_id INT NOT NULL,
    FOREIGN KEY (fk_rebanho_id) REFERENCES Rebanho(id),
    FOREIGN KEY (fk_alimentacao_id) REFERENCES Alimentacao(id)
);

-- Tabela Saude
CREATE TABLE Saude (
    id INT AUTO_INCREMENT PRIMARY KEY,
    veterinario VARCHAR(255),
    status VARCHAR(100),
    apetite VARCHAR(100),
    temperatura DOUBLE,
    fk_Animal_Codigo_brinco INT NOT NULL,
    data_de_verific DATE,
    FOREIGN KEY (fk_Animal_Codigo_brinco) REFERENCES Animal(Codigo_brinco)
);

-- Tabela Producao
CREATE TABLE Producao (
    id INT AUTO_INCREMENT PRIMARY KEY,
    tipo_de_producao VARCHAR(100) NOT NULL,
    data DATE NOT NULL,
    quantidade_produzida VARCHAR(100) NOT NULL,
    fk_Animal_Codigo_brinco INT NOT NULL,
    FOREIGN KEY (fk_Animal_Codigo_brinco) REFERENCES Animal(Codigo_brinco)
);


SELECT * FROM Animal;
