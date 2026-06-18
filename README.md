# 🏗️ API Produtos - Clean Architecture

API desenvolvida em .NET utilizando os princípios de Clean Architecture para gerenciamento de produtos.

## 📋 Sobre o Projeto

Este projeto foi criado com o objetivo de aplicar boas práticas de desenvolvimento backend utilizando:

- Clean Architecture
- ASP.NET Core
- Entity Framework Core
- SQL Server
- Injeção de Dependência
- Repository Pattern
- Swagger/OpenAPI

A aplicação permite o gerenciamento de produtos através de endpoints RESTful.

---

## 🚀 Tecnologias Utilizadas

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Swagger
- C#
- Clean Architecture

---

## 📂 Estrutura do Projeto

```text
src/
├── ApiProdutos.API
├── ApiProdutos.Application
├── ApiProdutos.Domain
├── ApiProdutos.Infrastructure
```

### Camadas

#### Domain
Contém as entidades e regras de negócio centrais.

#### Application
Contém casos de uso, DTOs, interfaces e regras da aplicação.

#### Infrastructure
Responsável pelo acesso a dados, persistência e integrações externas.

#### API
Camada responsável pelos endpoints e configuração da aplicação.

---

## ⚙️ Configuração

### Clonar o projeto

```bash
git clone https://github.com/Wagner-Vale12/api-produtos-clean-architecture.git
```

### Entrar na pasta

```bash
cd api-produtos-clean-architecture
```

### Restaurar dependências

```bash
dotnet restore
```

### Executar migrations

```bash
dotnet ef database update
```

### Executar projeto

```bash
dotnet run
```

---

## 📖 Documentação da API

Após iniciar a aplicação:

```text
https://localhost:5001/swagger
```

ou

```text
http://localhost:5000/swagger
```

---

## 📌 Funcionalidades

- Cadastro de produtos
- Consulta de produtos
- Atualização de produtos
- Exclusão de produtos
- Persistência em banco de dados
- Documentação automática com Swagger

---

## 🎯 Conceitos Aplicados

- SOLID
- Clean Architecture
- Separation of Concerns
- Dependency Injection
- Repository Pattern
- REST API
- Entity Framework Core

---

## 👨‍💻 Autor

**Wagner Vale**

- GitHub: https://github.com/Wagner-Vale12
- LinkedIn: https://www.linkedin.com/in/wagner-vale

---

## 📄 Licença

Projeto desenvolvido para fins de estudo e demonstração técnica.
