using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Streamberry.Domain.Entities;

public partial class Streaming
{
    [Key]
    public int? Id { get; set; }

    public string Nome { get; set; } = null!;
}
