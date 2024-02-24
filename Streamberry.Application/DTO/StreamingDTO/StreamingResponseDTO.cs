using Streamberry.Domain.Entities;

namespace Streamberry.Domain.DTOs
{
    public class StreamingResponseDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<FilmeResponseDTO> Filmes { get; set; }

        public StreamingResponseDTO(Streaming streaming, List<Type> excludes = null)
        {
            if (excludes == null)
                excludes = new List<Type>();
            Id = streaming.Id;
            Nome = streaming.Nome;

            excludes.Add(this.GetType());
            if (!excludes.Contains(typeof(FilmeResponseDTO)))
            {
                Filmes = new List<FilmeResponseDTO>();
                foreach (var filme in streaming.Filmes)
                {
                    Filmes.Add(new FilmeResponseDTO(filme, excludes));
                }
            }
        }
    }
}