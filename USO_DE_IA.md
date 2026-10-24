# Registro de Uso de Inteligência Artificial — USO_DE_IA.md

**Processo Seletivo:** Desenvolvedor de Sistemas I — SESI/SENAI (Edital 519/2026-DEV)  
**Candidato:** Israel  
**Projeto:** Catálogo de Cursos para o Ambiente Virtual de Aprendizagem (CTED - SESI Indústria)

---

## 1. Ferramenta Utilizada

- **Ferramenta Principal:** Antigravity / Gemini 3.8 & 4 (Google DeepMind) integrada ao ambiente de desenvolvimento.
- **Função no Desenvolvimento:** Copiloto de produtividade para geração de dados fictícios industriais, apoio na prototipagem de CSS semântico e aceleração de código repetitivo de infraestrutura (Entity Framework Core).

---

## 2. Objetivo do Uso

- **Otimização do ciclo de entrega:** Acelerar a criação da massa de dados técnicos e fictícios (cursos, módulos e aulas alinhados aos setores industrial, metalmecânico, têxtil e sustentabilidade do SESI).
- **Consistência visual e acessibilidade:** Garantir conformidade com as diretrizes WCAG 2.1 AA (contraste de cores, navegação por teclado e semântica ARIA) refletindo fielmente o protótipo do Figma fornecido.
- **Validação de arquitetura:** Revisão das boas práticas no padrão Web API com ASP.NET Core (.NET 8 LTS), garantindo baixo acoplamento entre Models, DTOs e Controllers.

---

## 3. Prompts Relevantes: O que foi Aproveitado ou Descartado

### Prompt 1: Geração de Dados Fictícios Industriais

- **Prompt:** _"Gere uma estrutura relacional de 8 cursos industriais para o SESI com temas de metalurgia, controle de qualidade, design têxtil e química verde, incluindo 3 status diferentes, modalidades EAD e híbrida, carga horária variada, módulos e aulas descritas."_
- **O que foi aproveitado:** A riqueza técnica dos temas, termos específicos da indústria (metrologia, nônio, CEP, cartas de controle, NBR 10.004) e a hierarquia Curso -> Módulos -> Aulas.
- **O que foi descartado:** Uma estrutura excessivamente aninhada com 5 níveis de entidades e tabelas auxiliares desnecessárias, que aumentaria a complexidade do banco de dados sem agregar valor aos requisitos de consulta do edital.

### Prompt 2: Filtros Combinados na API C#

- **Prompt:** _"Como estruturar uma consulta IQueryable em C# ASP.NET Core que receba busca textual por nome e filtros opcionais por categoria, modalidade e status simultaneamente, retornando a contagem total e DTOs?"_
- **O que foi aproveitado:** O encadeamento condicional com `.Where()` sobre `IQueryable` com `.AsNoTracking()` para alta performance em leitura.
- **O que foi descartado:** O uso de bibliotecas de terceiros pesadas para filtros dinâmicos (como GraphQL ou OData), optando por código C# puro e nativo do LINQ, mais legível, auditável e fácil de defender.

---

## 4. Como o Conteúdo foi Validado

1. **Compilação e Execução Estrita:** Todo o código gerado em C# foi compilado via terminal (`dotnet build`) com política de zero warnings e zero erros.
2. **Testes de Integração via HTTP:** Validação manual e automatizada dos endpoints da API (`/api/cursos`, `/api/cursos/{id}`, `/api/cursos/filtros`) utilizando PowerShell (`Invoke-RestMethod`), testando combinações de filtros, termos parciais e casos de borda (nenhum resultado encontrado).
3. **Validação Visual e Responsiva:** Inspeção dos layouts nos breakpoints mobile (360px - 768px), tablet (769px - 992px) e desktop (1200px+), verificando o comportamento de cada seção em relação ao Figma.
4. **Verificação de Acessibilidade:** Teste de navegação exclusiva por teclado (TAB, Shift+TAB, ENTER, ESC) para o modal de detalhes e verificação de foco visível (`:focus-visible`).

---

## 5. Exemplo de Erro ou Inadequação Identificado

Durante a estruturação do script de seed de dados e do `CursosController`, a IA sugeriu inicialmente realizar a filtragem dos cursos em memória através de `IEnumerable.Where()` após carregar todos os registros do banco de dados com `.ToListAsync()`. Além disso, a busca por texto não tratava diferenciação de caixa alta/baixa (case sensitive) no provedor SQLite de forma consistente.

**Problemas identificados:**

1. Filtrar em memória após carregar toda a base causaria sério gargalo de performance em ambientes reais de produção (Overfetching de dados).
2. O comparador de strings padrão causaria divergências em buscas com letras maiúsculas/minúsculas no SQLite.

---

## 6. Correção Realizada

1. **Reestruturação para `IQueryable` no Banco:** O filtro foi reescrito para operar diretamente no banco de dados SQLite via LINQ to Entities (`IQueryable`), transferindo a carga de filtragem e contagem para a engine do banco de dados antes da materialização com `ToListAsync()`.
2. **Normalização de Busca:** Foi aplicada a conversão `.ToLower()` em conjunto com `.Contains()` e `.Trim()`, permitindo buscas flexíveis por partes do nome completo, nome breve ou descrição do curso, independentemente da caixa utilizada pelo usuário.
3. **CORS e Inicialização Resiliente:** Ajustou-se o `Program.cs` para executar `EnsureCreated()` no escopo da aplicação, garantindo que o avaliador consiga clonar o projeto e executá-lo imediatamente com um único comando `dotnet run`.
