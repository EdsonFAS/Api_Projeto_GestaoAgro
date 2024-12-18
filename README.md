# Api_Projeto_GestaoAgro

## Descrição

API desenvolvida para facilitar a gestão agropecuária, oferecendo ferramentas para automação e controle eficiente de processos em agricultura e pecuária.

## Principais Funcionalidades

### 1. Gestão de Animais

- 🐄 **Cadastro de Animais**: Informações detalhadas (nome, raça, idade, peso, etc.).
- 🔍 **Consulta de Animais**: Critérios como identificação, espécie ou características específicas.

### 2. Gestão de Alimentação

- 🍽️ **Registro de Planos de Alimentação**: Por animal ou grupo do rebanho.
- 📊 **Históricos de Alimentação**: Consulta e acompanhamento.

### 3. Monitoramento de Saúde

- 💉 **Registro de Eventos de Saúde**: Vacinas, exames, tratamentos.
- 🩺 **Indicadores de Bem-Estar Animal**: Acompanhamento.

### 4. Registro de Produção

- 📈 **Cadastro de Produção**: Informações sobre leite, carne, ovos, etc.
- 📄 **Relatórios de Produtividade**: Por animal ou grupo.

### 5. Controle de Pastagem

- 🌿 **Gerenciamento de Lotes de Pasto**: Rodízio de animais.
- 🟢 **Monitoramento de Pastagens**: Disponibilidade e qualidade.

### 6. Gestão de Rebanhos

- 🐑 **Cadastro de Rebanhos**: Descrição de grupos e subgrupos.
- 📋 **Organização de Rebanhos**: Consulta conforme necessidades específicas.

### 7. Gerenciamento de Usuários

- 👥 **Registro de Usuários**: Novos usuários com permissões definidas (administrador, operador, etc.).
- 📝 **Consulta e Edição de Usuários**: Informações de usuários.

## Operações CRUD

Para facilitar a gestão, a API inclui as operações CRUD para todas as entidades:

- **GET**: Recupera todos os registros ou um registro específico por ID.
- **POST**: Adiciona um novo registro.
- **PUT**: Atualiza um registro existente por ID.
- **DELETE**: Remove um registro específico por ID.

## Tecnologias Utilizadas

### C# (ASP.NET Core)

- **Descrição**: Framework robusto e amplamente utilizado no ambiente corporativo.

- **Características**:
  - **Model**: Classes mapeadas usando Entity Framework.
  - **Controller**: Criados com anotações como `[ApiController]` e `[HttpGet]`.
  - **DTO**: Geralmente são classes separadas usadas em Responses.
  - **Integração com MySQL**: Feita com Entity Framework Core e um pacote MySQL.

## Licença

Este projeto está licenciado sob a Licença MIT. Consulte o arquivo LICENSE para obter mais detalhes.