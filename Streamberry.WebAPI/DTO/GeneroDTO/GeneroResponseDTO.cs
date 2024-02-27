using Streamberry.Domain.Entities;
using Streamberry.WebAPI.DTO.AvaliacaoDTO;
using Streamberry.WebAPI.DTO.FilmeDTO;

namespace Streamberry.WebAPI.DTO.GeneroDTO
{
    public class GeneroResponseDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public double MediaAvaliacao { get; set; }
        public List<FilmeResponseDTO> Filmes { get; set; }

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
                    var ex = new List<Type>();
                    excludes.ForEach(e => ex.Add(e));
                    Filmes.Add(new FilmeResponseDTO(filme, ex));
                }
                var media = CalcularMediaAvaliacao(Filmes);
                if (media > 0)
                {
                    MediaAvaliacao = media;
                }
            }
        }

        private double CalcularMediaAvaliacao(List<FilmeResponseDTO> filmes)
        {
            if (filmes.Count == 0)
            {
                return 0;
            }
            double media = 0;
            foreach (var filme in filmes)
            {
                media += filme.MediaAvaliacao;
            }
            return media / filmes.Count;
        }
    }
}