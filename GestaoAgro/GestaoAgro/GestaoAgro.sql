-- DROP DATABASE GestaoAgro;
CREATE DATABASE GestaoAgro;
USE GestaoAgro;

-- Tabela Usuario
CREATE TABLE Usuario (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    NomeCompleto VARCHAR(255) NOT NULL,
    NomeUsuario VARCHAR(100) NOT NULL,
    Senha VARCHAR(255) NOT NULL,
    Email VARCHAR(255) NOT NULL,
    CPF VARCHAR(14) NOT NULL,
    DataNascimento DATE,
    Endereco VARCHAR(255)
);

-- Tabela Animal
CREATE TABLE Animal (
	CodigoBrinco VARCHAR(5) NOT NULL  PRIMARY KEY,
    Raca VARCHAR(100) NOT NULL,
    Peso DOUBLE NOT NULL,
    Sexo VARCHAR(10) NOT NULL,
    Idade INT NOT NULL
);


-- Tabela Rebanho
CREATE TABLE Rebanho (
    IdRebanho INT AUTO_INCREMENT PRIMARY KEY,
    fk_Animal_CodigoBrinco VARCHAR(5) NOT NULL,
    Tipo VARCHAR(100),
    Destino VARCHAR(255),
    FOREIGN KEY (fk_Animal_CodigoBrinco) REFERENCES Animal(CodigoBrinco)
);

-- Tabela Pastagem
CREATE TABLE Pastagem (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    AreaPastagem DOUBLE NOT NULL,
    LocalizacaoPastagem VARCHAR(255),
    Periodo INT,
    fk_Animal_CodigoBrinco VARCHAR(5) NOT NULL,
    FOREIGN KEY (fk_Animal_CodigoBrinco) REFERENCES Animal(CodigoBrinco)
);

-- Tabela Alimentacao
CREATE TABLE Alimentacao (
    IdAlimentacao INT AUTO_INCREMENT PRIMARY KEY,
    Fornecedor VARCHAR(255),
    Nome VARCHAR(100) NOT NULL,
    QuantidadeEstoque DOUBLE NOT NULL,
    DataValidade DATE,
    DataEntrega DATE
);

-- Tabela RebanhoAlimentacao
CREATE TABLE RebanhoAlimentacao (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    fk_rebanho_IdRebanho INT NOT NULL,
    fk_alimentacao_IdAlimentacao INT NOT NULL,
    FOREIGN KEY (fk_rebanho_IdRebanho) REFERENCES Rebanho(IdRebanho),
    FOREIGN KEY (fk_alimentacao_IdAlimentacao) REFERENCES Alimentacao(IdAlimentacao)
);

-- Tabela Saude
CREATE TABLE Saude (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Veterinario VARCHAR(255),
    Status VARCHAR(100),
    Apetite VARCHAR(100),
    Temperatura DOUBLE,
    fk_Animal_CodigoBrinco VARCHAR(5) NOT NULL,
    DataVerificacao DATE,
    FOREIGN KEY (fk_Animal_CodigoBrinco) REFERENCES Animal(CodigoBrinco)
);

-- Tabela Producao
CREATE TABLE Producao (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    TipoProducao VARCHAR(100) NOT NULL,
    Data DATE NOT NULL,
    QuantidadeProduzida VARCHAR(100) NOT NULL,
    fk_Animal_CodigoBrinco VARCHAR(5) NOT NULL,
    FOREIGN KEY (fk_Animal_CodigoBrinco) REFERENCES Animal(CodigoBrinco)
);

-- Dados Tabela Usuario
INSERT INTO Usuario (NomeCompleto, NomeUsuario, Senha, Email, CPF, DataNascimento, Endereco)
VALUES
('João Silva', 'joaosilva', 'senha123', 'joao.silva@gmail.com', '123.456.789-00', '1990-01-15', 'Rua A, 123'),
('Maria Oliveira', 'mariaoliveira', 'senha456', 'maria.oliveira@gmail.com', '987.654.321-00', '1985-05-20', 'Avenida B, 456');

-- Dados Tabela Animal
INSERT INTO animal (CodigoBrinco, Raca, Peso, Sexo, Idade) VALUES
('BR001', 'Nelore', 450.5, 'M', 3),
('BR002', 'Angus', 520.3, 'F', 4),
('BR003', 'Brahman', 480.0, 'M', 2),
('BR004', 'Holandesa', 600.7, 'F', 5),
('BR005', 'Jersey', 430.2, 'F', 3),
('BR006', 'Nelore', 460.2, 'M', 2),
('BR007', 'Angus', 510.8, 'F', 3),
('BR008', 'Brahman', 490.5, 'M', 4),
('BR009', 'Holandesa', 620.3, 'F', 6),
('BR010', 'Jersey', 440.1, 'F', 2),
('BR011', 'Nelore', 470.5, 'M', 3),
('BR012', 'Angus', 530.7, 'F', 5),
('BR013', 'Brahman', 485.4, 'M', 2),
('BR014', 'Holandesa', 590.8, 'F', 4),
('BR015', 'Jersey', 420.6, 'F', 3),
('BR016', 'Nelore', 455.3, 'M', 4),
('BR017', 'Angus', 515.6, 'F', 3),
('BR018', 'Brahman', 475.2, 'M', 2),
('BR019', 'Holandesa', 610.4, 'F', 5),
('BR020', 'Jersey', 425.9, 'F', 3),
('BR021', 'Nelore', 465.7, 'M', 4),
('BR022', 'Angus', 525.1, 'F', 5),
('BR023', 'Brahman', 495.8, 'M', 3),
('BR024', 'Holandesa', 605.2, 'F', 6),
('BR025', 'Jersey', 435.4, 'F', 2),
('BR026', 'Nelore', 445.9, 'M', 2),
('BR027', 'Angus', 500.4, 'F', 3),
('BR028', 'Brahman', 490.2, 'M', 4),
('BR029', 'Holandesa', 630.7, 'F', 5),
('BR030', 'Jersey', 415.8, 'F', 3);


-- Dados Tabela Rebanho
INSERT INTO Rebanho (fk_Animal_CodigoBrinco, Tipo, Destino)
VALUES
 ('BR002', 'Produção de Leite', 'Fazenda A'),
 ('BR006', 'Engorda', 'Fazenda B'),
 ('BR008', 'Reprodução', 'Fazenda C');

-- Dados Tabela Pastagem
INSERT INTO Pastagem (AreaPastagem, LocalizacaoPastagem, Periodo, fk_Animal_CodigoBrinco) VALUES
(15.5, 'Fazenda Boa Vista', 120, 'BR002'),
(20.0, 'Sítio São José', 150, 'BR006'),
(12.3, 'Fazenda Nova Vida', 90, 'BR002');

-- Dados Tabela Alimentacao
INSERT INTO Alimentacao (Fornecedor, Nome, QuantidadeEstoque, DataValidade, DataEntrega)
VALUES
('Fornecedor A', 'Ração A', 100.0, '2025-06-01', '2024-12-01'),
('Fornecedor B', 'Ração B', 200.0, '2025-07-01', '2024-12-02'),
('Fornecedor C', 'Ração C', 150.0, '2025-08-01', '2024-12-03');

-- Dados Tabela RebanhoAlimentacao
INSERT INTO RebanhoAlimentacao (fk_rebanho_IdRebanho, fk_alimentacao_IdAlimentacao)
VALUES
(1, 1),
(2, 2),
(3, 3);

-- Dados Tabela Saude
INSERT INTO Saude (Veterinario, Status, Apetite, Temperatura, fk_Animal_CodigoBrinco, DataVerificacao) VALUES
('Dr. Carlos Mendes', 'Saudável', 'Normal', 38.5, 'BR002', '2024-12-05'),
('Dra. Ana Paula', 'Febre', 'Reduzido', 40.2,  'BR006', '2024-12-06'),
('Dr. Roberto Lima', 'Saudável', 'Normal', 38.7, 'BR002', '2024-12-07');

-- Dados Tabela Producao
INSERT INTO Producao (TipoProducao, Data, QuantidadeProduzida, fk_Animal_CodigoBrinco) VALUES
('Leite', '2024-12-08', '20 litros', 'BR002'),
('Carne', '2024-11-30', '300 kg', 'BR006'),
('Leite', '2024-12-08', '18 litros', 'BR002');

-- Consultar dados inseridos
SELECT * FROM Usuario;
SELECT * FROM Animal;
SELECT * FROM Rebanho;
SELECT * FROM Pastagem;
SELECT * FROM Alimentacao;
SELECT * FROM RebanhoAlimentacao;
SELECT * FROM Saude;
SELECT * FROM Producao;
