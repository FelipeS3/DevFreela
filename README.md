# DevFreela

> Uma API para gerenciar freelancers e projetos, construída com **ASP.NET Core**, seguindo os princípios de **Clean Architecture** e aplicando boas práticas de desenvolvimento.

---

## ✨ Funcionalidades

- **Gerenciamento de Projetos:**
  - Criar, atualizar, remover e listar projetos.
  - Associar freelancers e clientes aos projetos.
- **Notificações:**
  - Notificar usuários em tempo real quando projetos são criados.
- **Paginação e Filtros:**
  - Listagem de projetos com suporte a paginação e filtros.
- **Autenticação e Autorização:**
  - Uso de JWT para autenticar usuários.
- **CQRS e MediatR:**
  - Separação clara entre comandos e consultas para maior organização.
- **Swagger UI:**
  - Documentação interativa dos endpoints.

---

## 🛠️ Tecnologias Utilizadas

- **Back-end:**
  - [ASP.NET Core](https://dotnet.microsoft.com/)
  - [Entity Framework Core](https://learn.microsoft.com/en-us/ef/core/)
  - [MediatR](https://github.com/jbogard/MediatR)
  - [FluentValidation](https://fluentvalidation.net/)
  - [Dapper](https://dapperlib.github.io/Dapper/)

- **Banco de Dados:**
  - SQL Server

- **Outras Ferramentas:**
  - Swagger (documentação)
  - JWT (autenticação)
  - AutoMapper (mapeamento de objetos)

---

📂 Estrutura do Projeto
DevFreela/

├── DevFreela.API/              ## Projeto principal (API - expõe os endpoints da aplicação)

├── DevFreela.Application/      ## Regras de negócio, casos de uso (CQRS)

├── DevFreela.Core/             ## Entidades e contratos (classes de domínio, interfaces)

├── DevFreela.Infrastructure/   ## Implementações de acesso a dados e serviços externos (EF Core, Dapper, etc.)

├── DevFreela.sln               ## Solução do projeto

├── README.md                   ## Documentação do projeto

└── .gitignore                  ## Arquivo para ignorar arquivos temporários e de configuração



## 🚀 Como Executar Localmente

### Pré-requisitos

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/7.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server)
- Git instalado no seu computador.

### Passo a Passo

1. **Clone o repositório:**
   ```bash
   git clone https://github.com/FelipeS3/DevFreela.git
   cd DevFreela
