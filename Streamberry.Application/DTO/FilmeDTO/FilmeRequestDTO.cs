using System.ComponentModel.DataAnnotations;

namespace Streamberry.Domain.DTOs
{
    public class FilmeRequestDTO
    {
        [Required(ErrorMessage = "O título do filme é obrigatório.")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O mês de lançamento do filme é obrigatório.")]
        public string? MesLancamento { get; set; }

        [Required(ErrorMessage = "O ano de lançamento do filme é obrigatório.")]
        public int? AnoLancamento { get; set; }
    }
}