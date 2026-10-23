-- ==========================================================
-- PROCESSO SELETIVO DESENVOLVEDOR DE SISTEMAS I - SESI/SENAI
-- SCRIPT DDL & DML: BANCO DE DADOS DE CÓDIGO ABERTO (SQLITE)
-- ==========================================================

-- 1. Criação das Tabelas
CREATE TABLE IF NOT EXISTS Cursos (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    NomeCompleto TEXT NOT NULL,
    NomeBreve TEXT NOT NULL,
    Descricao TEXT NOT NULL,
    Categoria TEXT NOT NULL,
    Modalidade TEXT NOT NULL,
    CargaHoraria INTEGER NOT NULL,
    PublicoAlvo TEXT NOT NULL,
    Status TEXT NOT NULL,
    Imagem TEXT NOT NULL,
    IconeCategoria TEXT NOT NULL,
    DataDisponibilizacao TEXT NULL
);

CREATE TABLE IF NOT EXISTS Modulos (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    CursoId INTEGER NOT NULL,
    Ordem INTEGER NOT NULL,
    Titulo TEXT NOT NULL,
    Descricao TEXT NOT NULL,
    FOREIGN KEY (CursoId) REFERENCES Cursos(Id) ON DELETE CASCADE
);

CREATE TABLE IF NOT EXISTS Aulas (
    Id INTEGER PRIMARY KEY AUTOINCREMENT,
    ModuloId INTEGER NOT NULL,
    Ordem INTEGER NOT NULL,
    Titulo TEXT NOT NULL,
    Duracao TEXT NOT NULL,
    Descricao TEXT NOT NULL,
    FOREIGN KEY (ModuloId) REFERENCES Modulos(Id) ON DELETE CASCADE
);

-- Índices para otimização de busca e filtros
CREATE INDEX IF NOT EXISTS IX_Cursos_Categoria ON Cursos(Categoria);
CREATE INDEX IF NOT EXISTS IX_Cursos_Modalidade ON Cursos(Modalidade);
CREATE INDEX IF NOT EXISTS IX_Cursos_Status ON Cursos(Status);
CREATE INDEX IF NOT EXISTS IX_Modulos_CursoId ON Modulos(CursoId);
CREATE INDEX IF NOT EXISTS IX_Aulas_ModuloId ON Aulas(ModuloId);

-- 2. Carga Inicial de Dados (Seed Data)
INSERT INTO Cursos (Id, NomeCompleto, NomeBreve, Descricao, Categoria, Modalidade, CargaHoraria, PublicoAlvo, Status, Imagem, IconeCategoria, DataDisponibilizacao) VALUES
(1, 'Matemática para a Precisão: Medidas e Escalas na Metalurgia', 'Matemática para Metalurgia', 'Domine os cálculos de tolerância dimensional, conversão de escalas métricas e trigonométricas aplicadas à usinagem e caldeiraria de precisão.', 'Matemática', 'EAD / 100% Online', 40, 'Operadores de máquinas operatrizes, torneiros mecânicos, caldeireiros e técnicos em mecânica.', 'Inscrições Abertas', '/assets/hero-image.png', '/assets/icon-matematica-20px.svg', '2026-10-08'),
(2, 'Geometria e Modelagem no Design Têxtil', 'Modelagem Têxtil', 'Aprenda a aplicar princípios geométricos na construção de moldes industriais, aproveitamento de tecidos e modelagem tridimensional.', 'Linguagens', 'Semipresencial / Híbrido', 60, 'Estudantes e profissionais de moda, modelagem industrial, alfaiataria e confecção têxtil.', 'Inscrições Abertas', '/assets/video-thumb.png', '/assets/icon-linguagens-20px.svg', '2026-10-18'),
(3, 'Estatística e Controle de Qualidade na Produção', 'Controle de Qualidade', 'Capacitação completa em Controle Estatístico de Processo (CEP), histogramas, cartas de controle e redução de variabilidade fabril.', 'Matemática', 'EAD / 100% Online', 80, 'Analistas de qualidade, técnicos de processos, operadores líderes e engenheiros de produção.', 'Em Breve', '/assets/banner-ava.png', '/assets/icon-matematica-20px.svg', '2026-11-02'),
(4, 'Física do Movimento e da Energia na Metalurgia', 'Física Metalúrgica', 'Estudo aplicado da termodinâmica de fornos industriais, dilatação térmica dos metais, estática e dinâmica de pontes rolantes.', 'Ciências da Natureza', 'Semipresencial / Híbrido', 90, 'Técnicos em metalurgia, operadores de fornos e caldeiras, mantenedores mecânicos.', 'Inscrições Abertas', '/assets/hero-image.png', '/assets/icon-ciencias-natureza-20px.svg', '2026-10-03'),
(5, 'Química e Sustentabilidade nos Processos Industriais', 'Química Sustentável', 'Processos químicos ecoeficientes, tratamento de efluentes, prevenção de corrosão metálica e redução de pegada de carbono.', 'Sustentabilidade', 'EAD / 100% Online', 45, 'Técnicos químicos, laboratoristas industriais, gestores de meio ambiente e operadores de ETE.', 'Em Breve', '/assets/banner-ava.png', '/assets/icon-sustentabilidade-20px.svg', '2026-11-07'),
(6, 'Ciência dos Materiais na Metalurgia Avançada', 'Ciência dos Materiais', 'Estrutura cristalina, ensaios mecânicos destrutivos e não-destrutivos, tratamentos térmicos e ligas especiais.', 'Ciências da Natureza', 'Semipresencial / Híbrido', 120, 'Engenheiros de materiais, inspetores de soldagem e técnicos em ensaios laboratoriais.', 'Turma Encerrada', '/assets/video-thumb.png', '/assets/icon-ciencias-natureza-20px.svg', '2026-08-24'),
(7, 'Gestão Eficiente de Resíduos e Economia Circular', 'Economia Circular', 'Logística reversa, reaproveitamento de subprodutos industriais e adequação às normas ambientais vigentes.', 'Sustentabilidade', 'EAD / 100% Online', 50, 'Profissionais de ESG, segurança do trabalho, manutenção predial e supervisores industriais.', 'Turma Encerrada', '/assets/banner-ava.png', '/assets/icon-sustentabilidade-20px.svg', '2026-09-08'),
(8, 'Comunicação Técnica e Leitura de Desenho Industrial', 'Desenho Industrial', 'Interpretação de vistas ortográficas, cortes, seções, símbolos de solda e rugosidade superficial em projetos mecânicos.', 'Linguagens', 'Semipresencial / Híbrido', 75, 'Desenhistas, montadores de estruturas metálicas, orçamentistas e operadores de máquinas.', 'Inscrições Abertas', '/assets/hero-image.png', '/assets/icon-linguagens-20px.svg', '2026-10-13');

INSERT INTO Modulos (Id, CursoId, Ordem, Titulo, Descricao) VALUES
(1, 1, 1, 'Módulo 1: Fundamentos de Metrologia e Escalas', 'Conceitos básicos de medidas milimétricas, polegadas fracionárias e milesimais.'),
(2, 1, 2, 'Módulo 2: Trigonometria Aplicada ao Torneamento', 'Cálculo de cones, ângulos de saída e coordenadas para centros de usinagem.'),
(3, 2, 1, 'Módulo 1: Construção Geométrica de Bases', 'Traçado de bases retangulares, curvas de decote e cavas industriais.'),
(4, 3, 1, 'Módulo 1: Ferramentas Básicas da Qualidade', 'Estratificação, Folha de Verificação, Diagrama de Pareto e Ishikawa.'),
(5, 4, 1, 'Módulo 1: Termologia e Calorimetria em Fundição', 'Comportamento térmico de ligas ferrosas e não ferrosas em altas temperaturas.');

INSERT INTO Aulas (Id, ModuloId, Ordem, Titulo, Duracao, Descricao) VALUES
(1, 1, 1, 'Leitura e Interpretação de Paquímetro', '45 min', 'Uso do nônio e escalas de resolução 0,05mm e 0,02mm.'),
(2, 1, 2, 'Micrômetros e Relógios Comparadores', '50 min', 'Medições de alta precisão em peças usinadas.'),
(3, 2, 1, 'Relações Trigonométricas em Peças Cônicas', '60 min', 'Fórmulas de seno, cosseno e tangente para inclinação do carro superior.'),
(4, 3, 1, 'Introdução aos Ângulos e Curvas na Modelagem', '50 min', 'Utilização de réguas técnicas, esquadros e curvas francesas.'),
(5, 4, 1, 'Coleta e Estratificação de Dados Fabris', '45 min', 'Como estruturar folhas de dados confiáveis no chão de fábrica.'),
(6, 5, 1, 'Calor Específico e Mudança de Fase', '55 min', 'Entenda os pontos de fusão e solidificação de aços e ferros fundidos.');
