using SesiIndustria.Api.Models;

namespace SesiIndustria.Api.Data;

public static class DbInitializer
{
    public static void Initialize(AppDbContext context)
    {
        context.Database.EnsureCreated();

        if (context.Cursos.Any())
        {
            return; // Banco já populado
        }

        var cursos = new List<Curso>
        {
            new Curso
            {
                NomeCompleto = "Matemática para a Precisão: Medidas e Escalas na Metalurgia",
                NomeBreve = "Matemática para Metalurgia",
                Descricao = "Domine os cálculos de tolerância dimensional, conversão de escalas métricas e trigonométricas aplicadas à usinagem e caldeiraria de precisão.",
                Categoria = "Matemática",
                Modalidade = "EAD / 100% Online",
                CargaHoraria = 40,
                PublicoAlvo = "Operadores de máquinas operatrizes, torneiros mecânicos, caldeireiros e técnicos em mecânica.",
                Status = "Inscrições Abertas",
                Imagem = "/assets/hero-image.png",
                IconeCategoria = "/assets/icon-matematica-20px.svg",
                DataDisponibilizacao = DateTime.Now.AddDays(-15),
                Modulos = new List<Modulo>
                {
                    new Modulo
                    {
                        Ordem = 1,
                        Titulo = "Módulo 1: Fundamentos de Metrologia e Escalas",
                        Descricao = "Conceitos básicos de medidas milimétricas, polegadas fracionárias e milesimais.",
                        Aulas = new List<Aula>
                        {
                            new Aula { Ordem = 1, Titulo = "Leitura e Interpretação de Paquímetro", Duracao = "45 min", Descricao = "Uso do nônio e escalas de resolução 0,05mm e 0,02mm." },
                            new Aula { Ordem = 2, Titulo = "Micrômetros e Relógios Comparadores", Duracao = "50 min", Descricao = "Medições de alta precisão em peças usinadas." }
                        }
                    },
                    new Modulo
                    {
                        Ordem = 2,
                        Titulo = "Módulo 2: Trigonometria Aplicada ao Torneamento",
                        Descricao = "Cálculo de cones, ângulos de saída e coordenadas para centros de usinagem.",
                        Aulas = new List<Aula>
                        {
                            new Aula { Ordem = 1, Titulo = "Relações Trigonométricas em Peças Cônicas", Duracao = "60 min", Descricao = "Fórmulas de seno, cosseno e tangente para inclinação do carro superior." },
                            new Aula { Ordem = 2, Titulo = "Estudo de Casos Reais na Indústria", Duracao = "40 min", Descricao = "Resolução prática de problemas de cota dimensional." }
                        }
                    }
                }
            },
            new Curso
            {
                NomeCompleto = "Geometria e Modelagem no Design Têxtil",
                NomeBreve = "Modelagem Têxtil",
                Descricao = "Aprenda a aplicar princípios geométricos na construção de moldes industriais, aproveitamento de tecidos e modelagem tridimensional.",
                Categoria = "Linguagens",
                Modalidade = "Semipresencial / Híbrido",
                CargaHoraria = 60,
                PublicoAlvo = "Estudantes e profissionais de moda, modelagem industrial, alfaiataria e confecção têxtil.",
                Status = "Inscrições Abertas",
                Imagem = "/assets/video-thumb.png",
                IconeCategoria = "/assets/icon-linguagens-20px.svg",
                DataDisponibilizacao = DateTime.Now.AddDays(-5),
                Modulos = new List<Modulo>
                {
                    new Modulo
                    {
                        Ordem = 1,
                        Titulo = "Módulo 1: Construção Geométrica de Bases",
                        Descricao = "Traçado de bases retangulares, curvas de decote e cavas industriais.",
                        Aulas = new List<Aula>
                        {
                            new Aula { Ordem = 1, Titulo = "Introdução aos Ângulos e Curvas na Modelagem", Duracao = "50 min", Descricao = "Utilização de réguas técnicas, esquadros e curvas francesas." },
                            new Aula { Ordem = 2, Titulo = "Simetria e Proporção Anatômica", Duracao = "55 min", Descricao = "Adequação dos moldes aos padrões antropométricos da ABNT." }
                        }
                    },
                    new Modulo
                    {
                        Ordem = 2,
                        Titulo = "Módulo 2: Gradação e Encaixe Computadorizado",
                        Descricao = "Ampliação e redução proporcional de moldes com software CAD têxtil.",
                        Aulas = new List<Aula>
                        {
                            new Aula { Ordem = 1, Titulo = "Técnicas de Gradação Geométrica", Duracao = "60 min", Descricao = "Regras de deslocamento nos eixos X e Y para tamanhos P ao GG." }
                        }
                    }
                }
            },
            new Curso
            {
                NomeCompleto = "Estatística e Controle de Qualidade na Produção",
                NomeBreve = "Controle de Qualidade",
                Descricao = "Capacitação completa em Controle Estatístico de Processo (CEP), histogramas, cartas de controle e redução de variabilidade fabril.",
                Categoria = "Matemática",
                Modalidade = "EAD / 100% Online",
                CargaHoraria = 80,
                PublicoAlvo = "Analistas de qualidade, técnicos de processos, operadores líderes e engenheiros de produção.",
                Status = "Em Breve",
                Imagem = "/assets/banner-ava.png",
                IconeCategoria = "/assets/icon-matematica-20px.svg",
                DataDisponibilizacao = DateTime.Now.AddDays(10),
                Modulos = new List<Modulo>
                {
                    new Modulo
                    {
                        Ordem = 1,
                        Titulo = "Módulo 1: Ferramentas Básicas da Qualidade",
                        Descricao = "Estratificação, Folha de Verificação, Diagrama de Pareto e Causa e Efeito (Ishikawa).",
                        Aulas = new List<Aula>
                        {
                            new Aula { Ordem = 1, Titulo = "Coleta e Estratificação de Dados Fabris", Duracao = "45 min", Descricao = "Como estruturar folhas de dados confiáveis no chão de fábrica." },
                            new Aula { Ordem = 2, Titulo = "Construção de Diagramas de Pareto", Duracao = "50 min", Descricao = "Priorização de causas com regra 80/20." }
                        }
                    },
                    new Modulo
                    {
                        Ordem = 2,
                        Titulo = "Módulo 2: Cartas de Controle e Índices de Capacidade (Cp e Cpk)",
                        Descricao = "Interpretação estatística de limites de controle para eliminação de causas especiais.",
                        Aulas = new List<Aula>
                        {
                            new Aula { Ordem = 1, Titulo = "Elaboração de Cartas X-Barra e R", Duracao = "65 min", Descricao = "Monitoramento da média e amplitude amostral em tempo real." }
                        }
                    }
                }
            },
            new Curso
            {
                NomeCompleto = "Física do Movimento e da Energia na Metalurgia",
                NomeBreve = "Física Metalúrgica",
                Descricao = "Estudo aplicado da termodinâmica de fornos industriais, dilatação térmica dos metais, estática e dinâmica de pontes rolantes.",
                Categoria = "Ciências da Natureza",
                Modalidade = "Semipresencial / Híbrido",
                CargaHoraria = 90,
                PublicoAlvo = "Técnicos em metalurgia, operadores de fornos e caldeiras, mantenedores mecânicos.",
                Status = "Inscrições Abertas",
                Imagem = "/assets/hero-image.png",
                IconeCategoria = "/assets/icon-ciencias-natureza-20px.svg",
                DataDisponibilizacao = DateTime.Now.AddDays(-20),
                Modulos = new List<Modulo>
                {
                    new Modulo
                    {
                        Ordem = 1,
                        Titulo = "Módulo 1: Termologia e Calorimetria em Fundição",
                        Descricao = "Comportamento térmico de ligas ferrosas e não ferrosas em altas temperaturas.",
                        Aulas = new List<Aula>
                        {
                            new Aula { Ordem = 1, Titulo = "Calor Específico e Mudança de Fase", Duracao = "55 min", Descricao = "Entenda os pontos de fusão e solidificação de aços e ferros fundidos." },
                            new Aula { Ordem = 2, Titulo = "Transmissão de Calor por Condução e Radiação", Duracao = "50 min", Descricao = "Isolamento refratário e eficiência energética de fornos." }
                        }
                    }
                }
            },
            new Curso
            {
                NomeCompleto = "Química e Sustentabilidade nos Processos Industriais",
                NomeBreve = "Química Sustentável",
                Descricao = "Processos químicos ecoeficientes, tratamento de efluentes, prevenção de corrosão metálica e redução de pegada de carbono.",
                Categoria = "Sustentabilidade",
                Modalidade = "EAD / 100% Online",
                CargaHoraria = 45,
                PublicoAlvo = "Técnicos químicos, laboratoristas industriais, gestores de meio ambiente e operadores de ETE.",
                Status = "Em Breve",
                Imagem = "/assets/banner-ava.png",
                IconeCategoria = "/assets/icon-sustentabilidade-20px.svg",
                DataDisponibilizacao = DateTime.Now.AddDays(15),
                Modulos = new List<Modulo>
                {
                    new Modulo
                    {
                        Ordem = 1,
                        Titulo = "Módulo 1: Química Verde e Descarbonização",
                        Descricao = "Os 12 princípios da química verde aplicados à manufatura paulista.",
                        Aulas = new List<Aula>
                        {
                            new Aula { Ordem = 1, Titulo = "Substituição de Solventes Tóxicos", Duracao = "40 min", Descricao = "Alternativas biodegradáveis na desengraxagem de peças metálicas." }
                        }
                    }
                }
            },
            new Curso
            {
                NomeCompleto = "Ciência dos Materiais na Metalurgia Avançada",
                NomeBreve = "Ciência dos Materiais",
                Descricao = "Estrutura cristalina, ensaios mecânicos destrutivos e não-destrutivos, tratamentos térmicos e ligas especiais.",
                Categoria = "Ciências da Natureza",
                Modalidade = "Semipresencial / Híbrido",
                CargaHoraria = 120,
                PublicoAlvo = "Engenheiros de materiais, inspetores de soldagem e técnicos em ensaios laboratoriais.",
                Status = "Turma Encerrada",
                Imagem = "/assets/video-thumb.png",
                IconeCategoria = "/assets/icon-ciencias-natureza-20px.svg",
                DataDisponibilizacao = DateTime.Now.AddDays(-60),
                Modulos = new List<Modulo>
                {
                    new Modulo
                    {
                        Ordem = 1,
                        Titulo = "Módulo 1: Microestrutura dos Aços e Ferros Fundidos",
                        Descricao = "Diagrama de equilíbrio Ferro-Carbono, fases ferrita, perlita, austenita e martensita.",
                        Aulas = new List<Aula>
                        {
                            new Aula { Ordem = 1, Titulo = "Interpretação do Diagrama Fe-C", Duracao = "60 min", Descricao = "Pontos eutetóides e transformações com aquecimento e resfriamento." }
                        }
                    }
                }
            },
            new Curso
            {
                NomeCompleto = "Gestão Eficiente de Resíduos e Economia Circular",
                NomeBreve = "Economia Circular",
                Descricao = "Logística reversa, reaproveitamento de subprodutos industriais e adequação às normas ambientais vigentes.",
                Categoria = "Sustentabilidade",
                Modalidade = "EAD / 100% Online",
                CargaHoraria = 50,
                PublicoAlvo = "Profissionais de ESG, segurança do trabalho, manutenção predial e supervisores industriais.",
                Status = "Turma Encerrada",
                Imagem = "/assets/banner-ava.png",
                IconeCategoria = "/assets/icon-sustentabilidade-20px.svg",
                DataDisponibilizacao = DateTime.Now.AddDays(-45),
                Modulos = new List<Modulo>
                {
                    new Modulo
                    {
                        Ordem = 1,
                        Titulo = "Módulo 1: Classificação de Resíduos Conforme NBR 10.004",
                        Descricao = "Diferenciação entre resíduos Classe I (perigosos) e Classe II (não perigosos).",
                        Aulas = new List<Aula>
                        {
                            new Aula { Ordem = 1, Titulo = "Mapeamento do Fluxo de Descarte Fabril", Duracao = "45 min", Descricao = "Como identificar oportunidades de reciclagem e redução na fonte." }
                        }
                    }
                }
            },
            new Curso
            {
                NomeCompleto = "Comunicação Técnica e Leitura de Desenho Industrial",
                NomeBreve = "Desenho Industrial",
                Descricao = "Interpretação de vistas ortográficas, cortes, seções, símbolos de solda e rugosidade superficial em projetos mecânicos.",
                Categoria = "Linguagens",
                Modalidade = "Semipresencial / Híbrido",
                CargaHoraria = 75,
                PublicoAlvo = "Desenhistas, montadores de estruturas metálicas, orçamentistas e operadores de máquinas.",
                Status = "Inscrições Abertas",
                Imagem = "/assets/hero-image.png",
                IconeCategoria = "/assets/icon-linguagens-20px.svg",
                DataDisponibilizacao = DateTime.Now.AddDays(-10),
                Modulos = new List<Modulo>
                {
                    new Modulo
                    {
                        Ordem = 1,
                        Titulo = "Módulo 1: Projeções Ortográficas no 1º Diedro",
                        Descricao = "Visualização espacial de peças técnicas a partir de vistas frontal, superior e lateral.",
                        Aulas = new List<Aula>
                        {
                            new Aula { Ordem = 1, Titulo = "Conceitos de Linhas e Tipos de Arestas", Duracao = "50 min", Descricao = "Linhas contínuas, tracejadas de contorno invisível e linhas de centro." },
                            new Aula { Ordem = 2, Titulo = "Cortes Totais e Meio-Corte", Duracao = "55 min", Descricao = "Representação de furos e detalhes internos de componentes usinados." }
                        }
                    }
                }
            }
        };

        context.Cursos.AddRange(cursos);
        context.SaveChanges();
    }
}
