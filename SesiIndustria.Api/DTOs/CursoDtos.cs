namespace SesiIndustria.Api.DTOs;

public class CursoResumoDto
{
    public int Id { get; set; }
    public string NomeCompleto { get; set; } = string.Empty;
    public string NomeBreve { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
    public string Modalidade { get; set; } = string.Empty;
    public int CargaHoraria { get; set; }
    public string PublicoAlvo { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Imagem { get; set; } = string.Empty;
    public string IconeCategoria { get; set; } = string.Empty;
    public DateTime? DataDisponibilizacao { get; set; }
    public int TotalModulos { get; set; }
    public int TotalAulas { get; set; }
}

public class CursoDetalheDto
{
    public int Id { get; set; }
    public string NomeCompleto { get; set; } = string.Empty;
    public string NomeBreve { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
    public string Modalidade { get; set; } = string.Empty;
    public int CargaHoraria { get; set; }
    public string PublicoAlvo { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public string Imagem { get; set; } = string.Empty;
    public string IconeCategoria { get; set; } = string.Empty;
    public DateTime? DataDisponibilizacao { get; set; }
    public List<ModuloDto> Modulos { get; set; } = new();
}

public class ModuloDto
{
    public int Id { get; set; }
    public int Ordem { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public List<AulaDto> Aulas { get; set; } = new();
}

public class AulaDto
{
    public int Id { get; set; }
    public int Ordem { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Duracao { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
}

public class ResultadoCursosDto
{
    public int Total { get; set; }
    public List<CursoResumoDto> Cursos { get; set; } = new();
}

public class FiltrosDisponiveisDto
{
    public List<string> Categorias { get; set; } = new();
    public List<string> Modalidades { get; set; } = new();
    public List<string> Status { get; set; } = new();
}
