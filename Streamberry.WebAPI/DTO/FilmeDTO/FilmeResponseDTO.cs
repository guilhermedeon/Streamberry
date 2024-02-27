using Streamberry.Domain.Entities;
using Streamberry.WebAPI.DTO.AvaliacaoDTO;
using Streamberry.WebAPI.DTO.GeneroDTO;
using Streamberry.WebAPI.DTO.StreamingDTO;

namespace Streamberry.WebAPI.DTO.FilmeDTO
{
    public class FilmeResponseDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string MesLancamento { get; set; }
        public int AnoLancamento { get; set; }
        public double MediaAvaliacao { get; set; }
        public List<AvaliacaoResponseDTO> Avaliacoes { get; set; }
        public List<GeneroResponseDTO> Generos { get; set; }
        public List<StreamingResponseDTO> Streamings { get; set; }

        public FilmeResponseDTO(Filme filme, List<Type> excludes = null)
        {
            if (excludes == null)
                excludes = new List<Type>();
            Id = filme.Id;
            Titulo = filme.Titulo;
            MesLancamento = filme.MesLancamento;
            AnoLancamento = filme.AnoLancamento;
            excludes.Add(GetType());
            if (!excludes.Contains(typeof(AvaliacaoResponseDTO)) && filme.Avaliacoes.Count > 0)
            {
                Avaliacoes = new();
                foreach (var avaliacao in filme.Avaliacoes)
                {
                    var ex = new List<Type>();
                    excludes.ForEach(e => ex.Add(e));
                    Avaliacoes.Add(new(avaliacao, ex));
                }
                var media = CalcularMediaAvaliacao(Avaliacoes);
                if (media > 0)
                {
                    MediaAvaliacao = media;
                }
            }
            if (!excludes.Contains(typeof(GeneroResponseDTO)) && filme.Generos.Count > 0)
            {
                Generos = new();
                foreach (var genero in filme.Generos)
                {
                    var ex = new List<Type>();
                    excludes.ForEach(e => ex.Add(e));
                    Generos.Add(new(genero, ex));
                }
            }
            if (!excludes.Contains(typeof(StreamingResponseDTO)) && filme.Streamings.Count > 0)
            {
                Streamings = new();
                foreach (var streaming in filme.Streamings)
                {
                    var ex = new List<Type>();
                    excludes.ForEach(e => ex.Add(e));
                    Streamings.Add(new(streaming, ex));
                }
            }
        }

        private double CalcularMediaAvaliacao(List<AvaliacaoResponseDTO> avaliacoes)
        {
            if (avaliacoes.Count == 0)
            {
                return 0;
            }
            double media = 0;
            foreach (var avaliacao in avaliacoes)
            {
                media += avaliacao.Classificacao;
            }
            return media / avaliacoes.Count;
        }
    }
}