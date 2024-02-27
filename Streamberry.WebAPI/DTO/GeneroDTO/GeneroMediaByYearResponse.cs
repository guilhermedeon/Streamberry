namespace Streamberry.WebAPI.DTO.GeneroDTO
{
    public class GeneroMediaByYearResponse
    {
        public int InitialYear { get; set; }
        public int FinalYear { get; set; }
        public List<GeneroResponseDTO> Generos { get; set; } = new();
    }
}
