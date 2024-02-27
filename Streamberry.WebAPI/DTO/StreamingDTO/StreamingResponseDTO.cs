using Streamberry.Domain.Entities;
using Streamberry.WebAPI.DTO.FilmeDTO;

namespace Streamberry.WebAPI.DTO.StreamingDTO
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

            excludes.Add(GetType());
            if (!excludes.Contains(typeof(FilmeResponseDTO)) && streaming.Filmes.Count > 0)
            {
                Filmes = new List<FilmeResponseDTO>();
                foreach (var filme in streaming.Filmes)
                {
                    var ex = new List<Type>();
                    excludes.ForEach(e => ex.Add(e));
                    Filmes.Add(new FilmeResponseDTO(filme, ex));
                }
            }
        }
    }
}