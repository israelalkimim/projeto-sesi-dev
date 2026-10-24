# SESI Indústria — Plataforma de Catálogo de Cursos (CTED)

[![.NET 8](https://img.shields.io/badge/.NET-8.0_LTS-512BD4?logo=dotnet)](https://dotnet.microsoft.com/)
[![Entity Framework Core](https://img.shields.io/badge/EF_Core-8.0.10-blue)](https://learn.microsoft.com/ef/core/)
[![SQLite](https://img.shields.io/badge/Database-SQLite_Open_Source-003B57?logo=sqlite)](https://sqlite.org/)
[![License](https://img.shields.io/badge/Status-Concluído-success)](#)

Aplicação Web completa desenvolvida para a avaliação prática do Processo Seletivo de **Desenvolvedor de Sistemas I** do **Centro de Tecnologias e Educação Digital (CTED - SESI/SENAI)** — Edital 519/2026-DEV.

- **Candidato:** Israel Alkimim
- **Repositório GitHub Oficial:** [https://github.com/israelalkimim/projeto-sesi-dev](https://github.com/israelalkimim/projeto-sesi-dev)
- **Aplicação Publicada (Online / Produção):** [https://projeto-sesi-dev.onrender.com](https://projeto-sesi-dev.onrender.com)
- **Documentação Swagger (Online):** [https://projeto-sesi-dev.onrender.com/swagger](https://projeto-sesi-dev.onrender.com/swagger)
- **Arquivo de Publicação (ZIP):** [`SesiIndustria_Publicacao.zip`](https://github.com/israelalkimim/projeto-sesi-dev/blob/main/SesiIndustria_Publicacao.zip)

---

## 📌 Matriz de Conformidade com os 9 Entregáveis Obrigatórios (Edital Seção 5)

| Nº | Entregável Solicitado no Edital | Onde Encontrar no Projeto | Status |
|:---:|---|---|:---:|
| **1** | **Link do repositório no GitHub** | [github.com/israelalkimim/projeto-sesi-dev](https://github.com/israelalkimim/projeto-sesi-dev) | ✅ Entregue |
| **2** | **Link da aplicação publicada** | [projeto-sesi-dev.onrender.com](https://projeto-sesi-dev.onrender.com) | ✅ Entregue |
| **3** | **Código-fonte do front-end** | Pasta [`SesiIndustria.Api/wwwroot/`](https://github.com/israelalkimim/projeto-sesi-dev/tree/main/SesiIndustria.Api/wwwroot) (HTML, CSS e JS) | ✅ Entregue |
| **4** | **Código-fonte do back-end** | Pasta [`SesiIndustria.Api/`](https://github.com/israelalkimim/projeto-sesi-dev/tree/main/SesiIndustria.Api) (C#/.NET 8, Controllers, Models, DTOs) | ✅ Entregue |
| **5** | **Scripts, migrations ou arquivo do banco** | [`Database/schema_and_seed.sql`](https://github.com/israelalkimim/projeto-sesi-dev/blob/main/SesiIndustria.Api/Database/schema_and_seed.sql) e [`Migrations/`](https://github.com/israelalkimim/projeto-sesi-dev/tree/main/SesiIndustria.Api/Migrations) | ✅ Entregue |
| **6** | **Arquivo README.md** | [`README.md`](https://github.com/israelalkimim/projeto-sesi-dev/blob/main/README.md) (raiz do projeto com todos os tópicos) | ✅ Entregue |
| **7** | **Arquivo USO_DE_IA.md** | [`USO_DE_IA.md`](https://github.com/israelalkimim/projeto-sesi-dev/blob/main/USO_DE_IA.md) (raiz do projeto com os 6 tópicos do edital) | ✅ Entregue |
| **8** | **Relação dos arquivos de publicação disponíveis em formato ZIP** | Arquivo [`SesiIndustria_Publicacao.zip`](https://github.com/israelalkimim/projeto-sesi-dev/blob/main/SesiIndustria_Publicacao.zip) + Tabela na Seção 11 deste README | ✅ Entregue |
| **9** | **Relação das limitações ou itens não concluídos (e justificativas do Figma)** | Seção 12 deste README (com justificativas técnicas pontuais) | ✅ Entregue |

---

## 1. Objetivo da Aplicação

Apresentar um catálogo interativo e dinâmico de cursos industriais voltados para o **Ambiente Virtual de Aprendizagem (AVA / Moodle)** do SESI Indústria. A aplicação permite ao usuário:

- Consultar e explorar a vitrine de cursos industriais baseada no protótipo fornecido no Figma;
- Pesquisar cursos em tempo real pelo nome completo, nome breve ou descrição técnica;
- Filtrar cursos combinando múltiplos critérios simultâneos (**Categoria**, **Modalidade** e **Status**);
- Visualizar o quantitativo exato de resultados encontrados e limpar filtros com facilidade;
- Abrir os detalhes completos de qualquer curso em um modal acessível, visualizando ementa, público-alvo, módulos e descrições das aulas;
- Vivenciar uma interface moderna, responsiva, com feedback de carregamento (_skeleton loading_), tratamento de erros e estado vazio amigável.

---

## 2. Tecnologias Utilizadas

### Back-End:

- **C# 12 & .NET 8 (LTS)**: Linguagem e framework robusto de alta performance para a Web API;
- **ASP.NET Core Web API**: Estruturação de controllers RESTful (`CursosController`);
- **Entity Framework Core 8.0.10**: ORM para mapeamento objeto-relacional com suporte a consultas LINQ eficientes (`IQueryable`);
- **SQLite (Microsoft.EntityFrameworkCore.Sqlite)**: Banco de dados relacional leve, de código aberto (_open-source_) e zero-configuration para avaliação local e nuvem;
- **Swagger / OpenAPI**: Interface gráfica para inspeção e testes interativos dos endpoints HTTP.

### Front-End:

- **HTML5 Semântico**: Estruturação acessível com tags semânticas (`<header>`, `<nav>`, `<main>`, `<section>`, `<article>`, `<footer>`);
- **CSS3 Moderno**: Design system alinhado ao protótipo Figma, com variáveis CSS, Grid Layout, Flexbox, media queries e efeitos de foco acessível;
- **JavaScript ES6+ Nativo**: Consumo assíncrono da API com `fetch`, manipulação limpa do DOM, controle de debounce para busca sem travamentos e gestão de acessibilidade por teclado (ESC / TAB).

---

## 3. Arquitetura da Solução

A aplicação adota uma **Arquitetura em Camadas Desacopladas** integrada em um único projeto executável, facilitando tanto a implantação na nuvem quanto a execução local pelo avaliador:

```
┌────────────────────────────────────────────────────────┐
│                   Navegador do Usuário                 │
│         (HTML5 Semântico + CSS3 Figma + JS ES6)        │
└───────────────────────────┬────────────────────────────┘
                            │ Requisições HTTP / JSON
                            ▼
┌────────────────────────────────────────────────────────┐
│               Camada de API (ASP.NET Core)             │
│        - CursosController (Endpoints RESTful)          │
│        - DTOs (Data Transfer Objects)                  │
│        - Middleware de Arquivos Estáticos & CORS       │
└───────────────────────────┬────────────────────────────┘
                            │ LINQ / IQueryable
                            ▼
┌────────────────────────────────────────────────────────┐
│               Camada de Dados & Negócio                │
│        - AppDbContext (Mapeamento EF Core)             │
│        - Modelos de Domínio (Curso, Modulo, Aula)      │
│        - DbInitializer (Carga Inicial Automática)      │
└───────────────────────────┬────────────────────────────┘
                            │ Leitura / Escrita
                            ▼
┌────────────────────────────────────────────────────────┐
│         Banco de Dados Relacional Open-Source          │
│                       (SQLite)                         │
└────────────────────────────────────────────────────────┘
```

---

## 4. Estrutura das Pastas

```
c:\projetoDev_sesi\
│
├── SesiIndustria.sln                     # Arquivo de Solução do .NET
├── Dockerfile                            # Imagem Docker multi-stage para deploy em produção
├── .dockerignore                         # Regras de exclusão de arquivos para o build Docker
├── README.md                             # Documentação técnica completa
├── USO_DE_IA.md                          # Registro obrigatório do uso de Inteligência Artificial
├── checklist_projeto_sesi.md             # Checklist de controle do desenvolvimento
│
├── SesiIndustria.Api/                    # Projeto Principal Web API & Front-End
│   ├── Program.cs                        # Configuração de serviços, DI, CORS, Swagger e Pipeline
│   ├── appsettings.json                  # ConnectionString e configurações da aplicação
│   ├── SesiIndustria.Api.csproj          # Configuração e dependências NuGet (.NET 8)
│   │
│   ├── Models/                           # Entidades de Domínio
│   │   └── Curso.cs                      # Entidades Curso, Modulo e Aula
│   │
│   ├── DTOs/                             # Objetos de Transferência de Dados
│   │   └── CursoDtos.cs                  # CursoResumoDto, CursoDetalheDto, FiltrosDisponiveisDto
│   │
│   ├── Data/                             # Contexto do Banco e Carga Inicial
│   │   ├── AppDbContext.cs               # Mapeamento relacional e configurações do EF Core
│   │   └── DbInitializer.cs              # Seed automático dos cursos, módulos e aulas
│   │
│   ├── Controllers/                      # Controladores RESTful da API
│   │   └── CursosController.cs           # Endpoints de busca, listagem, filtros e detalhes
│   │
│   ├── Database/                         # Scripts SQL e Artefatos do Banco
│   │   └── schema_and_seed.sql           # Script SQL puro com DDL e DML de todos os dados
│   │
│   ├── Migrations/                       # Migrações versionadas do Entity Framework Core
│   │
│   └── wwwroot/                          # Front-End Estático Servido Diretamente
│       ├── index.html                    # Estrutura HTML da Landing Page e Catálogo
│       ├── css/
│       │   └── styles.css                # Estilos baseados no Figma, responsividade e temas
│       ├── js/
│       │   └── app.js                    # Consumo da API, debounce, modal e filtros combinados
│       └── assets/                       # Ícones SVG, imagens e fontes do SESI Indústria
```

---

## 5. Instruções para Execução Local

### Pré-requisitos:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) instalado.

### Passo a passo para rodar:

1. Abra o terminal (PowerShell ou Bash) na raiz do projeto:
   ```bash
   cd c:\projetoDev_sesi\SesiIndustria.Api
   ```
2. Execute a aplicação com o comando:
   ```bash
   dotnet run
   ```
3. Acesse no seu navegador:
   - **Aplicação Web (Front-End Completo):** [http://localhost:5000](http://localhost:5000)
   - **Documentação Interativa da API (Swagger):** [http://localhost:5000/swagger](http://localhost:5000/swagger)

> [!NOTE]
> O banco de dados SQLite (`sesi_cursos.db`) é criado e populado automaticamente na primeira execução através do `DbInitializer`. Não é necessário instalar nenhum servidor de banco de dados prévio.

---

## 6. Configuração do Banco de Dados

A aplicação utiliza o **SQLite**, um banco de dados relacional de código aberto em conformidade com o edital.

- **Arquivo gerado localmente:** `sesi_cursos.db`
- **Configuração no `appsettings.json`:**
  ```json
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=sesi_cursos.db"
  }
  ```
- **Migrations do EF Core:** Geradas na pasta `Migrations/` com a migração inicial `CriacaoInicialCursos`.
- **Script SQL puro:** Disponível em [`SesiIndustria.Api/Database/schema_and_seed.sql`](file:///c:/projetoDev_sesi/SesiIndustria.Api/Database/schema_and_seed.sql) para inspeção ou execução direta em qualquer cliente SQLite/SQL.

---

## 7. Endpoints da API

| Método | Rota                  | Descrição                                               | Parâmetros de Query                           |
| ------ | --------------------- | ------------------------------------------------------- | --------------------------------------------- |
| `GET`  | `/api/cursos`         | Lista cursos com suporte a filtros combinados e busca   | `search`, `categoria`, `modalidade`, `status` |
| `GET`  | `/api/cursos/{id}`    | Retorna detalhes completos do curso com módulos e aulas | `id` (rota)                                   |
| `GET`  | `/api/cursos/filtros` | Retorna categorias, modalidades e status disponíveis    | Nenhum                                        |

### Exemplos de Requisição:

- **Listar todos os cursos:**  
  `GET http://localhost:5000/api/cursos`
- **Busca combinada (Categoria Matemática + Modalidade EAD):**  
  `GET http://localhost:5000/api/cursos?categoria=Matemática&modalidade=EAD / 100% Online`
- **Busca textual pelo tema:**  
  `GET http://localhost:5000/api/cursos?search=Metalurgia`
- **Detalhes do curso ID 1:**  
  `GET http://localhost:5000/api/cursos/1`

---

## 8. Modelo de Dados

### Entidade `Curso`:

- `Id` (int, chave primária)
- `NomeCompleto` (string, 200 caracteres) — ex.: _"Matemática para a Precisão: Medidas e Escalas na Metalurgia"_
- `NomeBreve` (string, 100 caracteres) — ex.: _"Matemática para Metalurgia"_
- `Descricao` (string, texto detalhado)
- `Categoria` (string) — ex.: _"Matemática"_, _"Linguagens"_, _"Ciências da Natureza"_, _"Sustentabilidade"_
- `Modalidade` (string) — ex.: _"EAD / 100% Online"_, _"Semipresencial / Híbrido"_
- `CargaHoraria` (int, em horas) — ex.: `40`, `60`, `80`, `120`
- `PublicoAlvo` (string) — Profissionais e técnicos atendidos
- `Status` (string) — _"Inscrições Abertas"_, _"Em Breve"_, _"Turma Encerrada"_
- `Imagem` (string, URI do asset)
- `IconeCategoria` (string, URI do ícone SVG)
- `DataDisponibilizacao` (DateTime?, quando aplicável)
- `Modulos` (ICollection<Modulo>, relacionamento 1 para N)

### Entidades `Modulo` e `Aula`:

- Cada `Modulo` possui `Ordem`, `Titulo`, `Descricao` e uma lista de `Aulas`.
- Cada `Aula` possui `Ordem`, `Titulo`, `Duracao` (ex.: _"45 min"_) e `Descricao`.

---

## 9. Estratégia de Responsividade

A aplicação foi construída com foco em **Mobile-First e Design Responsivo**:

- **CSS Grid Adaptativo:** Utilização de `grid-template-columns: repeat(auto-fill, minmax(330px, 1fr))` no catálogo, ajustando os cards dinamicamente conforme a resolução da tela;
- **Breakpoints Fluidos:**
  - **Mobile (< 768px):** Menu em hambúrguer interativo, filtros empilhados verticalmente, tipografia proporcional e padding ajustado;
  - **Tablet (768px - 992px):** Filtros organizados em grid de 2 colunas, métricas institucionais em grade de 2x2;
  - **Desktop (> 992px):** Grid completo de 5 colunas para busca e filtros, herói com layout lateralizado e catálogo amplo;
- **Imagens Responsivas:** `max-width: 100%` com `loading="lazy"` para otimizar tempo de carregamento em redes móveis.

---

## 10. Decisões de Acessibilidade (WCAG 2.1 AA)

- **HTML5 Semântico:** Marcação estrutural clara com `<header>`, `<nav>`, `<main>`, `<section>`, `<article>`, `<button>` e `<footer>`;
- **Atributos WAI-ARIA:**
  - `role="search"` no container de busca e filtros;
  - `aria-label` descritivos em todos os inputs, botões e selects;
  - `aria-live="polite"` no contador de resultados para anunciar atualizações em leitores de tela;
  - `role="dialog"`, `aria-modal="true"` e `aria-labelledby` no modal de detalhes;
- **Navegação Completa por Teclado:**
  - Foco visível com `:focus-visible` em cor de alto contraste;
  - Abertura do modal com Enter/Espaço e fechamento imediato com a tecla **ESC**;
  - Foco capturado e redirecionado para o botão de fechar ao abrir o modal;
- **Contraste de Cores:** Combinações validadas com taxa superior a 4.5:1 para conformidade com o nível AA do WCAG.

---

## 11. Processo de Publicação e Relação dos Arquivos do Pacote ZIP (Entregável nº 8)

A aplicação foi publicada tanto em contêiner de nuvem gratuita quanto empacotada no arquivo zip autônomo disponível na raiz do repositório: [`SesiIndustria_Publicacao.zip`](https://github.com/israelalkimim/projeto-sesi-dev/blob/main/SesiIndustria_Publicacao.zip).

### A) Deploy Automatizado em Nuvem (Render.com)
* **Imagem Docker Multi-Stage:** Compilação em `mcr.microsoft.com/dotnet/sdk:8.0` e execução enxuta no runtime `mcr.microsoft.com/dotnet/aspnet:8.0`.
* **Porta de Execução:** `8080` interna mapeada para `443` HTTPS.
* **Link de Produção:** [https://projeto-sesi-dev.onrender.com](https://projeto-sesi-dev.onrender.com)
* **Swagger Online:** [https://projeto-sesi-dev.onrender.com/swagger](https://projeto-sesi-dev.onrender.com/swagger)

### B) Relação dos Arquivos Disponíveis no Pacote ZIP (`SesiIndustria_Publicacao.zip`)
O arquivo ZIP foi gerado via `dotnet publish -c Release` e contém todos os artefatos prontos para execução imediata:

| Arquivo / Diretório no ZIP | Finalidade Técnica |
|---|---|
| `SesiIndustria.Api.dll` / `SesiIndustria.Api.exe` | Binário executável principal da aplicação compilado em Release (.NET 8) |
| `appsettings.json` / `appsettings.Development.json` | Configurações de logging, portas e ConnectionString do SQLite |
| `wwwroot/` | Pasta completa do Front-End (`index.html`, `css/styles.css`, `js/app.js` e subpasta `assets/` com todas as imagens, ícones SVG e fontes) |
| `runtimes/` | Drivers nativos e bibliotecas de compatibilidade do SQLite (`e_sqlite3`) para Windows, Linux (x64/ARM) e macOS |
| `Microsoft.EntityFrameworkCore.*.dll` | Dependências compiladas do Entity Framework Core 8 e do provedor SQLite |
| `Swashbuckle.AspNetCore.*.dll` | Dependências compiladas do gerador de documentação OpenAPI/Swagger |
| `SesiIndustria.Api.deps.json` / `*.runtimeconfig.json` | Metadados de resolução de dependências e configuração do runtime .NET 8 |

> **Como executar a partir do pacote ZIP:**  
> Extraia o ZIP em qualquer pasta e execute no terminal: `dotnet SesiIndustria.Api.dll`. A aplicação iniciará imediatamente na porta configurada.

---

## 12. Relação de Limitações ou Itens Não Concluídos e Justificativa de Diferenças em Relação ao Figma (Entregável nº 9)

### A) Escopo e Limitações Conhecidas (Aderência Estrita ao Edital)
* **Manutenção de Cursos (CRUD):** Conforme estipulado no item 4.c do edital (*"Não será necessário desenvolver o gerenciamento de cadastro, edição ou exclusão de cursos"*), a aplicação foi focada exclusivamente na experiência do aluno: catálogo, pesquisa por texto, filtros combinados, visualização de resultados e detalhamento dos cursos.
* **Integração com Servidor Moodle:** Conforme estabelecido no item 1 do edital (*"Não será necessário acessar, instalar, configurar ou integrar a aplicação a um ambiente Moodle, sendo esta realizada como um diferencial"*), a aplicação não requer um LMS Moodle ativo para operar. O botão *"Quero me Inscrever"* do modal simula a ação de matrícula no AVA com feedback visual imediato.

### B) Identificação e Justificativa de Diferenças/Complementos em Relação ao Figma (Nota de rodapé ***)
O protótipo no Figma fornecido pelo SESI consistia em uma interface estática para ilustrar o design e a identidade visual. Para transformar a maquete em uma **aplicação web plenamente funcional e acessível**, foram implementadas as seguintes melhorias técnicas justificadas:

1. **Barra de Pesquisa Textual com Debounce (300ms):**
   * *Motivo:* Atender à funcionalidade obrigatória da Seção 4.c (*"Pesquisar cursos pelo nome"*). O campo foi inserido de forma harmônica na seção do catálogo, com ícone de lupa e atraso controlado para digitação suave.
2. **Painel de Filtros Combinados (Categoria, Modalidade e Status):**
   * *Motivo:* Atender às regras da Seção 4.c (*"Filtrar por categoria, modalidade ou status"* e *"Combinar pesquisa e filtros"*). No Figma os botões eram estáticos; na aplicação, tornaram-se `<select>` dinâmicos alimentados pela API C#.
3. **Contador de Resultados em Tempo Real com Acessibilidade:**
   * *Motivo:* Atender à Seção 4.c (*"Apresentar a quantidade de resultados"*). Incluído logo abaixo dos filtros com o atributo `aria-live="polite"` para anunciar atualizações a leitores de tela.
4. **Modal de Detalhes do Curso (Grade Curricular e Ementa):**
   * *Motivo:* Atender à Seção 4.c (*"Abrir os detalhes de um curso"* e *"Cursos com diferentes módulos, descrições de aulas e públicos-alvo"*). Desenvolvido como modal flutuante com suporte a fechamento pela tecla **ESC** e clique fora, sem quebrar o layout da página principal.
5. **Estados de Interface (Loading, Vazio e Erro):**
   * *Motivo:* Atender à Seção 4.c (*"Apresentar mensagem quando nenhum curso for encontrado"*, *"Apresentar estado de carregamento"* e *"Apresentar mensagem em caso de erro"*). Criados com cards esqueleto animados e mensagens amigáveis com botão para tentar novamente ou limpar filtros.
6. **Aproveitamento Total dos Assets Oficiais:**
   * *Motivo:* No Figma, alguns ícones como `arrow-navigation` e `add_2.svg` estavam soltos no pacote. Eles foram integrados na paginação visual do catálogo e na listagem de módulos, garantindo 100% de aproveitamento do pacote visual entregue pelo SESI.
