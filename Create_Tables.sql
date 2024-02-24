-- Create table for Filmes
CREATE TABLE Filmes (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    titulo VARCHAR(255) UNIQUE NOT NULL,
    mes_lancamento VARCHAR(255),
    ano_lancamento INT
);

-- Create table for Generos
CREATE TABLE Generos (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    nome VARCHAR(255) UNIQUE NOT NULL
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
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    nome VARCHAR(255) UNIQUE NOT NULL
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
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    classificacao INT,
    comentario TEXT,
    id_filme INT,
    id_usuario INT,
    FOREIGN KEY (id_filme) REFERENCES Filmes(id),
    FOREIGN KEY (id_usuario) REFERENCES Usuarios(id)
);

-- Create table for Usuarios
CREATE TABLE Usuarios (
    id INTEGER PRIMARY KEY AUTOINCREMENT,
    nome VARCHAR(255) NOT NULL,
    email VARCHAR(255) UNIQUE NOT NULL,
    senha VARCHAR(255) NOT NULL
);
