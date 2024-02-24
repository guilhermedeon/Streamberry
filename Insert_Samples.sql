-- Insert data into Filmes
INSERT INTO Filmes (titulo, mes_lancamento, ano_lancamento) VALUES
('Filme 1', 'Janeiro', 2022),
('Filme 2', 'Fevereiro', 2022),
('Filme 3', 'Março', 2022);

-- Insert data into Generos
INSERT INTO Generos (nome) VALUES
('Ação'),
('Comédia'),
('Drama');

-- Insert data into Streaming
INSERT INTO Streaming (nome) VALUES
('Netflix'),
('Amazon Prime'),
('Disney+');

-- Insert data into Usuarios
INSERT INTO Usuarios (nome, email, senha) VALUES
('Usuário 1', 'usuario1@example.com', 'senha123'),
('Usuário 2', 'usuario2@example.com', 'senha456'),
('Usuário 3', 'usuario3@example.com', 'senha789');

-- Insert data into FilmesGeneros
INSERT INTO FilmesGeneros (id_filme, id_genero) VALUES
(1, 1),  -- Filme 1 is an Action movie
(2, 2),  -- Filme 2 is a Comedy movie
(3, 3);  -- Filme 3 is a Drama movie

-- Insert data into FilmesStreaming
INSERT INTO FilmesStreaming (id_filme, id_streaming) VALUES
(1, 1),  -- Filme 1 is available on Netflix
(2, 2),  -- Filme 2 is available on Amazon Prime
(3, 3);  -- Filme 3 is available on Disney+
