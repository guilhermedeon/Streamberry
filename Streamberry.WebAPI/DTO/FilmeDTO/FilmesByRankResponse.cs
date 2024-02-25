namespace Streamberry.WebAPI.DTO.FilmeDTO
{
    public class FilmesByRankResponse
    {
        public int Classificacao { get; set; }
        public List<FilmeResponseDTO> Filmes { get; set; }
    }
}
