using System.ComponentModel.DataAnnotations;

namespace Streamberry.Domain.Entities;

public class Streaming
{
    [Key]
    public int? Id { get; set; }

    public string Nome { get; set; } = null!;
}