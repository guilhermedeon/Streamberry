# Streamberry

Este projeto é uma aplicação de exemplo para demonstrar operações CRUD, com base nos conceitos de Clean Architecture

## Funcionalidades

- CRUD completo para todas as entidades
- Endpoints personalizados conforme requisitos
- Acesso via Swagger (pode-se também importar o esquema para apps como Insomnia/Postman)

## Autenticação

A autenticação neste projeto é feita através de JSON Web Token (JWT).

## Tecnologias Utilizadas

- C# (.NET 8)
- ASP.NET Core
- Entity Framework Core
- JWT (JSON Web Token)
- SQLite

## Como Usar

1. Clone o repositório.
2. Abra o projeto em seu ambiente de desenvolvimento.
3. Configure a conexão com o banco de dados no arquivo `appsettings.json` (o preset incluso aponta para o arquivo SQLite presente no diretório base).
4. O arquivo SQLite com alguns valores de teste já está incluso, porém também pode ser gerado usando os scripts SQL inclusos no repositório
5. Execute a aplicação
6. Para acessar os endpoints, é necessário efetuar o login e adicionar o Token no Swagger/Postman, no formato: "Bearer <token>"

## AIOController

- Para simplificar o overview do funcionamento, foi adicionado um Controller com nome de AIOController.
- Este controller contém uma função de Login com dados pré configurados de teste, com fim de facilitar a interação.
- Os outros endpoints são referentes aos requisitos conforme especificação, porém são somente "atalhos" para funcionalidades já presentes nos Endpoints oficiais.
- O Login do usuário de testes é: email/senha = "user@example.com"/"string"

## Notas

- O banco escolhido foi o SQLite pela facilidade de transferência e de uso, logo que o mesmo atende a todas as necessidades do projeto;
- Este projeto contempla somente o BackEnd, com documentação e interface via Swagger para facilitar o uso;
- Foram aplicados conceitos de separação em camadas conforme Clean Architecture;
- Para reduzir a quantidade de código duplicado, foram utilizados Generics nas classes de "Services" e "Repositories";
- A aplicação utiliza JWT para autenticação, tornando a api RESTful.
- As validações sobre os dados de entrada (Requests) são feitas nos DTO's, mantendo as entidades mais limpas.
