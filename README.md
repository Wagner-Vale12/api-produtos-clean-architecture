# 🏗️ API Produtos — Arquitetura em Camadas

API REST para gerenciamento de produtos e categorias, desenvolvida com ASP.NET Core, PostgreSQL, Entity Framework Core e Dapper.

O projeto aplica separação de responsabilidades, Dependency Injection, Repository Pattern e uma organização em camadas inspirada nos princípios da Clean Architecture.

![.NET](https://img.shields.io/badge/.NET_10-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-4169E1?style=for-the-badge&logo=postgresql&logoColor=white)
![Entity Framework Core](https://img.shields.io/badge/Entity_Framework_Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Dapper](https://img.shields.io/badge/Dapper-2C3E50?style=for-the-badge&logoColor=white)
![Swagger](https://img.shields.io/badge/Swagger-85EA2D?style=for-the-badge&logo=swagger&logoColor=black)

---

## 📌 Sobre o projeto

A **API Produtos** foi desenvolvida para demonstrar a construção de uma API REST com ASP.NET Core, persistência em PostgreSQL e separação de responsabilidades.

A aplicação permite cadastrar, consultar, atualizar e excluir produtos, além de relacioná-los com categorias.

O projeto também possui uma consulta utilizando Dapper, demonstrando uma alternativa ao Entity Framework Core para consultas SQL diretas.

---

## 🚀 Funcionalidades

- Cadastro de produtos.
- Consulta de todos os produtos.
- Consulta de produto por ID.
- Atualização de produtos.
- Exclusão de produtos.
- Relacionamento entre produtos e categorias.
- Validação de nome, preço e estoque.
- Persistência de dados com PostgreSQL.
- Consultas com Entity Framework Core.
- Consulta de relatório utilizando Dapper.
- Migrations para criação e evolução do banco.
- Documentação interativa com Swagger/OpenAPI.

---

## 🛠️ Tecnologias utilizadas

- .NET 10
- C#
- ASP.NET Core Web API
- PostgreSQL
- Entity Framework Core
- Npgsql
- Dapper
- Swagger / OpenAPI
- LINQ
- Dependency Injection
- Repository Pattern
- Migrations

---

## 🏗️ Arquitetura

O projeto está organizado em camadas, separando as responsabilidades da aplicação:

```text
HTTP Request
     │
     ▼
ProductController
     │
     ▼
IProductService
     │
     ▼
ProductService
     │
     ▼
IProductRepository
     │
     ▼
ProductRepository
     │
     ├── Entity Framework Core
     └── Dapper
             │
             ▼
        PostgreSQL
```

### Responsabilidades das camadas

- **Controllers:** recebem as requisições HTTP e retornam as respostas.
- **Application/Services:** concentram as regras de negócio.
- **Application/Interfaces:** definem os contratos entre as camadas.
- **Application/DTOs:** definem os modelos específicos de resposta.
- **Domain/Entities:** representam as entidades do domínio.
- **Infrastructure/Repositories:** implementam o acesso aos dados.
- **Data:** configura o `DbContext` do Entity Framework Core.
- **Program.cs:** registra as dependências e configura a aplicação.

---

## 📂 Estrutura do projeto

```text
api-produtos-clean-architecture/
├── Application/
│   ├── Dtos/
│   │   └── ProductResponseDto.cs
│   ├── Interfaces/
│   │   ├── IProductRepository.cs
│   │   └── IProductService.cs
│   └── Services/
│       └── ProductService.cs
├── Controllers/
│   └── ProductController.cs
├── Data/
│   └── AppDbContext.cs
├── Domain/
│   └── Entities/
│       ├── Category.cs
│       └── Product.cs
├── Infrastructure/
│   └── Repositories/
│       └── ProductRepository.cs
├── Migrations/
├── Properties/
├── Program.cs
├── ApiProdutos.csproj
├── appsettings.json
└── README.md
```

---

## 🔗 Endpoints

| Método | Endpoint | Descrição |
|---|---|---|
| `GET` | `/api/products` | Lista todos os produtos |
| `GET` | `/api/products/{id}` | Consulta um produto por ID |
| `POST` | `/api/products` | Cadastra um novo produto |
| `PUT` | `/api/products/{id}` | Atualiza um produto |
| `DELETE` | `/api/products/{id}` | Exclui um produto |
| `GET` | `/api/products/report` | Retorna relatório de produtos com Dapper |
| `GET` | `/api/products/dapper` | Retorna relatório de produtos com Dapper |

---

## 📋 Regras de negócio

Durante o cadastro de um produto:

- O nome é obrigatório.
- O preço deve ser maior que zero.
- O estoque não pode ser negativo.
- O produto deve estar relacionado a uma categoria existente.

---

## 📦 Modelo de produto

```json
{
  "name": "Notebook",
  "price": 4500.00,
  "stock": 10,
  "categoryId": 1
}
```

### Modelo de resposta do relatório

```json
{
  "id": 1,
  "name": "Notebook",
  "price": 4500.00,
  "categoryName": "Eletrônicos"
}
```

---

## ⚙️ Como executar

### Pré-requisitos

- .NET SDK 10
- PostgreSQL
- Git
- Entity Framework Core CLI

### Clonar o projeto

```bash
git clone https://github.com/Wagner-Vale12/api-produtos-clean-architecture.git
cd api-produtos-clean-architecture
```

### Restaurar as dependências

```bash
dotnet restore
```

### Instalar o Entity Framework Core CLI

```bash
dotnet tool install --global dotnet-ef
```

Caso já esteja instalado:

```bash
dotnet tool update --global dotnet-ef
```

### Configurar a conexão com PostgreSQL

Inicialize o gerenciamento de segredos:

```bash
dotnet user-secrets init
```

Configure a connection string:

```bash
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Host=localhost;Port=5432;Database=ApiProdutosDb;Username=postgres;Password=SUA_SENHA"
```

### Criar o banco de dados

```bash
dotnet ef database update
```

### Executar a aplicação

```bash
dotnet run
```

O endereço da aplicação será exibido no terminal.

A documentação Swagger poderá ser acessada adicionando `/swagger` ao endereço apresentado.

Exemplo:

```text
http://localhost:5000/swagger
```

---

## 🗄️ Criando uma categoria para teste

Atualmente, o projeto ainda não possui endpoints específicos para gerenciamento de categorias.

Uma categoria pode ser inserida diretamente no PostgreSQL:

```sql
INSERT INTO "Categories" ("Name")
VALUES ('Eletrônicos');
```

Depois, utilize o ID da categoria no campo `categoryId` ao cadastrar um produto.

---

## 🧠 Conceitos aplicados

- Separação de responsabilidades.
- Dependency Injection.
- Dependency Inversion.
- Repository Pattern.
- Interfaces para desacoplamento.
- Arquitetura em camadas.
- DTOs.
- Programação assíncrona.
- LINQ.
- Mapeamento objeto-relacional.
- Relacionamento entre entidades.
- Migrations.
- Consultas SQL com Dapper.

---

## ⚠️ Limitações atuais

- A solução está organizada em um único projeto `.csproj`.
- Não possui endpoints para gerenciamento de categorias.
- Não possui autenticação e autorização.
- Não possui testes automatizados.
- Não possui Docker.
- Não possui pipeline de CI/CD.
- Não possui paginação ou filtros.
- A validação ainda é realizada diretamente no Service.

---

## 📈 Próximas melhorias

- [ ] Separar a solução em projetos `API`, `Application`, `Domain` e `Infrastructure`.
- [ ] Criar CRUD de categorias.
- [ ] Criar DTOs específicos para entrada e atualização.
- [ ] Adicionar FluentValidation.
- [ ] Implementar tratamento global de exceções.
- [ ] Adicionar paginação, filtros e ordenação.
- [ ] Implementar testes unitários.
- [ ] Implementar testes de integração.
- [ ] Adicionar autenticação e autorização com JWT.
- [ ] Adicionar Docker e Docker Compose.
- [ ] Criar pipeline de CI/CD com GitHub Actions.
- [ ] Adicionar logs estruturados.
- [ ] Implementar observabilidade com OpenTelemetry.
- [ ] Adicionar versionamento da API.

---

## 🎯 Objetivo do projeto

Este projeto foi criado para praticar e demonstrar conhecimentos em:

- Desenvolvimento de APIs REST com ASP.NET Core.
- Organização de aplicações em camadas.
- Princípios de Clean Architecture.
- Dependency Injection.
- Repository Pattern.
- Entity Framework Core.
- PostgreSQL.
- Dapper.
- Regras de negócio.
- Relacionamento entre entidades.
- Persistência de dados.

---

## 👨‍💻 Autor

Desenvolvido por **Wagner Vale**.

[![GitHub](https://img.shields.io/badge/GitHub-Wagner--Vale12-181717?style=for-the-badge&logo=github)](https://github.com/Wagner-Vale12)

[![LinkedIn](https://img.shields.io/badge/LinkedIn-Wagner_Vale-0077B5?style=for-the-badge&logo=linkedin&logoColor=white)](https://www.linkedin.com/in/wagner12)
