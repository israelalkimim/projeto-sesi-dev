using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SesiIndustria.Api.Data;
using SesiIndustria.Api.DTOs;

namespace SesiIndustria.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class CursosController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly ILogger<CursosController> _logger;

    public CursosController(AppDbContext context, ILogger<CursosController> logger)
    {
        _context = context;
        _logger = logger;
    }

    /// <summary>
    /// Consulta e filtra cursos do catálogo com busca textual e filtros combinados
    /// </summary>
    [HttpGet]
    public async Task<ActionResult<ResultadoCursosDto>> GetCursos(
        [FromQuery] string? search,
        [FromQuery] string? categoria,
        [FromQuery] string? modalidade,
        [FromQuery] string? status)
    {
        try
        {
            var query = _context.Cursos
                .Include(c => c.Modulos)
                    .ThenInclude(m => m.Aulas)
                .AsNoTracking()
                .AsQueryable();

            // 1. Pesquisar cursos pelo nome (ou descrição/nome breve)
            if (!string.IsNullOrWhiteSpace(search))
            {
                var term = search.Trim().ToLower();
                query = query.Where(c => 
                    c.NomeCompleto.ToLower().Contains(term) ||
                    c.NomeBreve.ToLower().Contains(term) ||
                    c.Descricao.ToLower().Contains(term));
            }

            // 2. Filtrar por categoria
            if (!string.IsNullOrWhiteSpace(categoria) && !categoria.Equals("todas", StringComparison.OrdinalIgnoreCase))
            {
                query = query.Where(c => c.Categoria == categoria);
            }

            // 3. Filtrar por modalidade
            if (!string.IsNullOrWhiteSpace(modalidade) && !modalidade.Equals("todas", StringComparison.OrdinalIgnoreCase))
            {
                query = query.Where(c => c.Modalidade == modalidade);
            }

            // 4. Filtrar por status
            if (!string.IsNullOrWhiteSpace(status) && !status.Equals("todos", StringComparison.OrdinalIgnoreCase))
            {
                query = query.Where(c => c.Status == status);
            }

            var total = await query.CountAsync();

            var cursos = await query
                .OrderBy(c => c.Id)
                .Select(c => new CursoResumoDto
                {
                    Id = c.Id,
                    NomeCompleto = c.NomeCompleto,
                    NomeBreve = c.NomeBreve,
                    Descricao = c.Descricao,
                    Categoria = c.Categoria,
                    Modalidade = c.Modalidade,
                    CargaHoraria = c.CargaHoraria,
                    PublicoAlvo = c.PublicoAlvo,
                    Status = c.Status,
                    Imagem = c.Imagem,
                    IconeCategoria = c.IconeCategoria,
                    DataDisponibilizacao = c.DataDisponibilizacao,
                    TotalModulos = c.Modulos.Count,
                    TotalAulas = c.Modulos.SelectMany(m => m.Aulas).Count()
                })
                .ToListAsync();

            return Ok(new ResultadoCursosDto
            {
                Total = total,
                Cursos = cursos
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar cursos com filtros.");
            return StatusCode(500, new { mensagem = "Ocorreu um erro interno ao consultar os cursos. Tente novamente mais tarde." });
        }
    }

    /// <summary>
    /// Obtém os detalhes completos de um curso pelo ID, incluindo módulos e aulas
    /// </summary>
    [HttpGet("{id:int}")]
    public async Task<ActionResult<CursoDetalheDto>> GetCursoPorId(int id)
    {
        try
        {
            var curso = await _context.Cursos
                .Include(c => c.Modulos.OrderBy(m => m.Ordem))
                    .ThenInclude(m => m.Aulas.OrderBy(a => a.Ordem))
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == id);

            if (curso == null)
            {
                return NotFound(new { mensagem = $"Curso com ID {id} não foi encontrado." });
            }

            var detalheDto = new CursoDetalheDto
            {
                Id = curso.Id,
                NomeCompleto = curso.NomeCompleto,
                NomeBreve = curso.NomeBreve,
                Descricao = curso.Descricao,
                Categoria = curso.Categoria,
                Modalidade = curso.Modalidade,
                CargaHoraria = curso.CargaHoraria,
                PublicoAlvo = curso.PublicoAlvo,
                Status = curso.Status,
                Imagem = curso.Imagem,
                IconeCategoria = curso.IconeCategoria,
                DataDisponibilizacao = curso.DataDisponibilizacao,
                Modulos = curso.Modulos.Select(m => new ModuloDto
                {
                    Id = m.Id,
                    Ordem = m.Ordem,
                    Titulo = m.Titulo,
                    Descricao = m.Descricao,
                    Aulas = m.Aulas.Select(a => new AulaDto
                    {
                        Id = a.Id,
                        Ordem = a.Ordem,
                        Titulo = a.Titulo,
                        Duracao = a.Duracao,
                        Descricao = a.Descricao
                    }).ToList()
                }).ToList()
            };

            return Ok(detalheDto);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar detalhes do curso {Id}", id);
            return StatusCode(500, new { mensagem = "Erro interno ao buscar detalhes do curso." });
        }
    }

    /// <summary>
    /// Retorna as opções únicas para alimentar os filtros da interface
    /// </summary>
    [HttpGet("filtros")]
    public async Task<ActionResult<FiltrosDisponiveisDto>> GetFiltros()
    {
        try
        {
            var categorias = await _context.Cursos
                .Select(c => c.Categoria)
                .Distinct()
                .OrderBy(c => c)
                .ToListAsync();

            var modalidades = await _context.Cursos
                .Select(c => c.Modalidade)
                .Distinct()
                .OrderBy(m => m)
                .ToListAsync();

            var status = await _context.Cursos
                .Select(c => c.Status)
                .Distinct()
                .OrderBy(s => s)
                .ToListAsync();

            return Ok(new FiltrosDisponiveisDto
            {
                Categorias = categorias,
                Modalidades = modalidades,
                Status = status
            });
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao obter filtros.");
            return StatusCode(500, new { mensagem = "Erro ao carregar opções de filtros." });
        }
    }
}
