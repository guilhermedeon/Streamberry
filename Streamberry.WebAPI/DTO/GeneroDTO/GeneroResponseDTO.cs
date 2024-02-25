using Streamberry.Domain.Entities;
using Streamberry.WebAPI.DTO.FilmeDTO;

namespace Streamberry.WebAPI.DTO.GeneroDTO
{
    public class GeneroResponseDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IList<FilmeResponseDTO> Filmes { get; set; }

        public GeneroResponseDTO(Genero genero, List<Type> excludes = null)
        {
            if (excludes == null)
                excludes = new List<Type>();
            Id = genero.Id;
            Nome = genero.Nome;
            excludes.Add(typeof(GeneroResponseDTO));
            if (!excludes.Contains(typeof(FilmeResponseDTO)) && genero.Filmes.Count > 0)
            {
                Filmes = new List<FilmeResponseDTO>();
                foreach (var filme in genero.Filmes)
                {
                    Filmes.Add(new FilmeResponseDTO(filme, excludes));
                }
            }
        }
    }
}