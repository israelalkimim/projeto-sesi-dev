# 📋 Checklist Geral — Projeto Prático SESI Indústria (Desenvolvedor de Sistemas I)

> [!IMPORTANT]
> **Prazo Final de Entrega:** Segunda-feira, **26/10/2026 às 08h00**  
> **Apresentação Técnica:** Presencial (no momento da entrevista)  
> **Documentos Base:** [Instruções PDF](file:///c:/projetoDev_sesi/Instru%C3%A7%C3%B5es_Atividade%20pr%C3%A1tica_519_2026_DEV.pdf) | [Instruções E-mail](file:///c:/projetoDev_sesi/Intru%C3%A7%C3%B5es_email_519_2026-DEV.docx) | [Assets ZIP](file:///c:/projetoDev_sesi/Arquivos_Atividade%20pr%C3%A1tica_519_2026_DEV.zip)

---

## 🛠️ Fase 1: Preparação do Ambiente e Estrutura Inicial
- [ ] **1.1.** Instalar o **.NET 8 SDK (LTS)** na máquina e validar no terminal (`dotnet --version`).
- [ ] **1.2.** Descompactar os arquivos visuais de [Arquivos_Atividade prática_519_2026_DEV.zip](file:///c:/projetoDev_sesi/Arquivos_Atividade%20pr%C3%A1tica_519_2026_DEV.zip) (fontes `Open Sans`, ícones `.svg` e imagens `.png`).
- [ ] **1.3.** Inicializar o repositório Git local com `.gitignore` adequado para projetos C#/.NET.
- [ ] **1.4.** Terei que criar a estrutura da solução em C#/.NET (`SesiIndustria.Api` / aplicação web) organizada em pastas claras (`Models`, `Data`, `Controllers`, `DTOs`, `wwwroot`).

---

## 🗄️ Fase 2: Banco de Dados e Back-End em C#/.NET (API REST)
- [ ] **2.1.** Terei que criar a modelagem de dados em C# atendendo a todos os campos obrigatórios do edital:
  - [ ] `Curso`: Id, Nome Completo, Nome Breve, Descrição, Categoria, Modalidade, Carga Horária, Público-Alvo, Status, Imagem de Apresentação, Data de Disponibilização (quando aplicável).
  - [ ] `Modulo` / `Aula`: Estrutura de módulos e descrições de aulas vinculadas a cada curso para exibição nos detalhes.
- [ ] **2.2.** Configurar o banco de dados de código aberto (**SQLite** com **Entity Framework Core**).
- [ ] **2.3.** Gerar as **Migrations** e o **Script SQL** do banco (para cumprir o Entregável nº 5).
- [ ] **2.4.** Terei que criar o *Data Seeding* (carga inicial de dados fictícios) respeitando os mínimos exigidos:
  - [ ] Mínimo de **6 cursos** (criaremos 8 cursos baseados nos cards do Figma: Metalurgia, Têxtil, Qualidade, Física, Química/Sustentabilidade, Ciência dos Materiais, etc.);
  - [ ] Mínimo de **3 categorias** (ex.: *Ciências da Natureza*, *Matemática*, *Linguagens*, *Sustentabilidade*);
  - [ ] Mínimo de **2 modalidades** (ex.: *EAD / 100% Online* e *Semipresencial / Híbrido*);
  - [ ] Mínimo de **3 status diferentes** (ex.: *Inscrições Abertas*, *Em Breve*, *Encerrado*);
  - [ ] Diferentes cargas horárias, módulos, descrições de aulas e públicos-alvo.
- [ ] **2.5.** Desenvolver os Endpoints da API REST em C#:
  - [ ] `GET /api/cursos` — Listagem com suporte a busca por nome (`search`) e filtros combinados (`categoria`, `modalidade`, `status`), retornando também o total de resultados encontrados.
  - [ ] `GET /api/cursos/{id}` — Retorno dos detalhes completos de um curso específico (incluindo módulos e aulas).
  - [ ] `GET /api/cursos/filtros` — Retorno das categorias, modalidades e status disponíveis para alimentar os seletores do front-end.
- [ ] **2.6.** Configurar o **Swagger / OpenAPI** e o **CORS** para facilitar testes e demonstração na entrevista.

---

## 🎨 Fase 3: Front-End Baseado no Figma (Responsivo e Acessível)
- [ ] **3.1.** Implementar a **Identidade Visual do Figma** (Fontes `Open Sans`, paleta vermelha/bege/escura do SESI Indústria, ícones e imagens oficiais).
- [ ] **3.2.** Construir as seções institucionais do protótipo:
  - [ ] Cabeçalho (`SESI+INDÚSTRIA`) com menu de navegação (`Início`, `Cursos`, `Sobre`, `Área do Aluno`);
  - [ ] Hero Banner (*"Impulsione sua carreira na indústria"*);
  - [ ] Seção *"Principais cursos"* em destaque;
  - [ ] Seção *"Impacto transformador"* (`25.000+`, `500+`, `4.8/5`, `2.5M+` + diferenciais);
  - [ ] Seção *"Quem fez recomenda"* (carrossel de depoimentos);
  - [ ] Seção *"Pronto para transformar sua carreira?"* + Rodapé completo.
- [ ] **3.3.** Desenvolver a **Área de Catálogo e Consulta de Cursos** (integrada à API C#) com todas as funcionalidades obrigatórias:
  - [ ] Listagem dinâmica consumindo a API;
  - [ ] Campo de pesquisa por nome do curso;
  - [ ] Filtros por **Categoria**, **Modalidade** e **Status**;
  - [ ] Combinação simultânea de pesquisa + múltiplos filtros;
  - [ ] Contador visível com a **quantidade de resultados** encontrados;
  - [ ] Botão **"Limpar filtros"**;
  - [ ] Modal/Página de **Detalhes do Curso** (exibindo nome completo, nome breve, categoria, modalidade, status, carga horária, data de disponibilização, público-alvo, módulos e aulas);
  - [ ] **Estado de Carregamento** (*Loading spinner / skeleton*);
  - [ ] **Estado Vazio** (*Mensagem amigável quando nenhum curso for encontrado*);
  - [ ] **Estado de Erro** (*Mensagem amigável caso a API falhe, com botão de tentar novamente*).
- [ ] **3.4.** Garantir **Responsividade** (Mobile, Tablet e Desktop) e **Acessibilidade** (HTML semântico, `aria-label`, navegação por teclado, foco visível e contraste).

---

## 📄 Fase 4: Documentação Obrigatória e Entregáveis
- [ ] **4.1.** Escrever o arquivo `README.md` contendo todos os **12 tópicos obrigatórios** do edital:
  1. Objetivo da aplicação;
  2. Tecnologias utilizadas;
  3. Arquitetura da solução;
  4. Estrutura das pastas;
  5. Instruções para execução local;
  6. Configuração do banco;
  7. Endpoints da API;
  8. Modelo de dados;
  9. Estratégia de responsividade;
  10. Decisões de acessibilidade;
  11. Processo de publicação;
  12. Limitações conhecidas e justificativa de eventuais diferenças/complementos em relação ao Figma.
- [ ] **4.2.** Escrever o arquivo `USO_DE_IA.md` contendo todos os **6 tópicos obrigatórios** do edital:
  1. Ferramenta utilizada;
  2. Objetivo do uso;
  3. Prompts relevantes (o que foi aproveitado ou descartado);
  4. Como o conteúdo foi validado;
  5. Um exemplo real de erro ou inadequação identificado;
  6. Correção realizada pelo desenvolvedor.
- [ ] **4.3.** Gerar a pasta de publicação (`dotnet publish`) e compactar no **arquivo `.zip` de publicação** (Entregável nº 8).
- [ ] **4.4.** Subir o código-fonte organizado para o **repositório público no GitHub** (Entregável nº 1).
- [ ] **4.5.** Publicar a aplicação em uma **plataforma gratuita** (ex.: Render.com / Fly.io) e testar o link online (Entregável nº 2).

---

## 🎤 Fase 5: Preparação para a Apresentação Técnica Presencial
- [ ] **5.1.** Revisão guiada de todo o código C# (entender `Program.cs`, `AppDbContext.cs`, `Curso.cs`, `CursosController.cs` e o `app.js` do Front-End).
- [ ] **5.2.** Roteiro prático do que falar e mostrar nos primeiros 5 a 10 minutos da entrevista presencial.
- [ ] **5.3.** Simulação das principais perguntas técnicas que os avaliadores do SESI podem fazer sobre o projeto.
