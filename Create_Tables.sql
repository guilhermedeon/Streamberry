-- Create table for Filmes
CREATE TABLE Filmes (
    id INT PRIMARY KEY,
    titulo VARCHAR(255) NOT NULL,
    mes_lancamento VARCHAR(255),
    ano_lancamento INT
);

-- Create table for Generos
CREATE TABLE Generos (
    id INT PRIMARY KEY,
    nome VARCHAR(255) NOT NULL
);

-- Create table for the many-to-many relationship between Filmes and Generos
CREATE TABLE FilmesGeneros (
    id_filme INT,
    id_genero INT,
    PRIMARY KEY (id_filme, id_genero),
    FOREIGN KEY (id_filme) REFERENCES Filmes(id),
    FOREIGN KEY (id_genero) REFERENCES Generos(id)
);

-- Create table for Streaming
CREATE TABLE Streaming (
    id INT PRIMARY KEY,
    nome VARCHAR(255) NOT NULL
);

-- Create table for the many-to-many relationship between Filmes and Streaming
CREATE TABLE FilmesStreaming (
    id_filme INT,
    id_streaming INT,
    PRIMARY KEY (id_filme, id_streaming),
    FOREIGN KEY (id_filme) REFERENCES Filmes(id),
    FOREIGN KEY (id_streaming) REFERENCES Streaming(id)
);

-- Create table for Avaliacoes
CREATE TABLE Avaliacoes (
    id INT PRIMARY KEY,
    classificacao INT,
    comentario TEXT,
    id_filme INT,
    id_usuario INT,
    FOREIGN KEY (id_filme) REFERENCES Filmes(id),
    FOREIGN KEY (id_usuario) REFERENCES Usuarios(id)
);

-- Create table for Usuarios
CREATE TABLE Usuarios (
    id INT PRIMARY KEY,
    nome VARCHAR(255) NOT NULL,
    email VARCHAR(255) NOT NULL,
    senha VARCHAR(255) NOT NULL
);
