using System.Text.Json.Serialization;

namespace SesiIndustria.Api.Models;

public class Curso
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

    public List<Modulo> Modulos { get; set; } = new();
}

public class Modulo
{
    public int Id { get; set; }
    public int CursoId { get; set; }
    public int Ordem { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;

    [JsonIgnore]
    public Curso? Curso { get; set; }

    public List<Aula> Aulas { get; set; } = new();
}

public class Aula
{
    public int Id { get; set; }
    public int ModuloId { get; set; }
    public int Ordem { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Duracao { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;

    [JsonIgnore]
    public Modulo? Modulo { get; set; }
}
