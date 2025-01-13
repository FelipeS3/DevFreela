DevFreela - Plataforma de Gerenciamento de Freelancers
O DevFreela é uma API robusta desenvolvida em .NET para facilitar o gerenciamento de projetos freelancers. A plataforma permite que clientes publiquem seus projetos, freelancers se candidatem a oportunidades e ambas as partes acompanhem o progresso e o status das tarefas de forma eficiente e transparente.

Principais Funcionalidades
Cadastro e Gerenciamento de Usuários: Suporte completo para clientes e freelancers, incluindo controle de autenticação e autorização, garantindo a segurança dos dados de usuários.

Gerenciamento de Projetos: Funcionalidades para criação, atualização e cancelamento de projetos, permitindo um fluxo de trabalho flexível. O status do projeto pode ser monitorado em tempo real (criado, em andamento, concluído, etc.).

Sistema de Comentários: Ferramenta de comunicação entre clientes e freelancers para facilitar a troca de feedbacks e atualizações sobre os projetos.

Status Personalizado: Utilização de um enum para gerenciar e visualizar facilmente o progresso de cada projeto, proporcionando clareza sobre a situação atual.

Tecnologias Utilizadas
ASP.NET Core: Framework principal para o desenvolvimento da API, garantindo alta performance e escalabilidade.

Entity Framework Core: Usado para o mapeamento de dados e manipulação eficiente do banco de dados, facilitando operações de leitura e escrita.

Swagger: Ferramenta para documentação automática da API e testes interativos, facilitando a integração e o desenvolvimento contínuo.

SQL Server: Banco de dados relacional robusto e seguro, ideal para armazenar dados estruturados de clientes, freelancers e projetos.

Clean Architecture: Padrão de arquitetura utilizado para organizar o código, garantindo uma estrutura clara, fácil de manter e expandir, além de facilitar a realização de testes.

Arquitetura
O DevFreela segue os princípios da Clean Architecture, proporcionando:

Separação Clara de Responsabilidades: Cada camada da aplicação é responsável por uma parte específica, facilitando a manutenção e evolução do código.

Facilidade de Manutenção: A organização modular do código permite que alterações sejam realizadas de maneira segura, sem impactar outras partes da aplicação.

Testabilidade: A arquitetura facilita a criação de testes automatizados, garantindo que cada componente funcione de forma independente e sem erros.
