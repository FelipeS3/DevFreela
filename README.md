# DevFreela - Plataforma de Gerenciamento de Freelancers
O DevFreela é uma API desenvolvida em .NET, projetada para gerenciar projetos freelancers de forma eficiente. A aplicação permite que clientes publiquem projetos, freelancers se candidatem, e ambos acompanhem o progresso e status de seus trabalhos.

Principais Funcionalidades
Cadastro e Gerenciamento de Usuários:
Suporte para clientes e freelancers com controle de autenticação e autorização.
Gerenciamento de Projetos:
Criação, atualização e cancelamento de projetos.
Acompanhamento do status do projeto (criado, em andamento, concluído, etc.).
Comentários:
Sistema de comentários para melhorar a comunicação entre clientes e freelancers.
Status Personalizado:
Gerenciamento de status do projeto através de um enum, facilitando a visualização do progresso.
Tecnologias Utilizadas
ASP.NET Core para o desenvolvimento da API.
Entity Framework Core para mapeamento e manipulação do banco de dados.
Swagger para documentação e testes da API.
SQL Server como banco de dados relacional.
Clean Architecture para uma estrutura organizada e de fácil manutenção.
Arquitetura
O projeto foi desenvolvido seguindo o padrão de Clean Architecture, garantindo:

Separação clara de responsabilidades.
Facilidade de manutenção e evolução do código.
Testabilidade com a separação de camadas.
