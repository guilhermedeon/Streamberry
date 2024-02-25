using Streamberry.Domain.Entities;
using Streamberry.WebAPI.DTO.AvaliacaoDTO;
using Streamberry.WebAPI.DTO.GeneroDTO;
using Streamberry.WebAPI.DTO.StreamingDTO;
using System.Collections.Generic;

namespace Streamberry.WebAPI.DTO.FilmeDTO
{
    public class FilmeResponseDTO
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string MesLancamento { get; set; }
        public int AnoLancamento { get; set; }
        public double? MediaAvaliacao { get; set; }
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
                    Avaliacoes.Add(new(avaliacao, excludes));
                }
                MediaAvaliacao = CalcularMediaAvaliacao(Avaliacoes);
            }
            if (!excludes.Contains(typeof(GeneroResponseDTO)) && filme.Generos.Count > 0)
            {
                Generos = new();
                foreach (var genero in filme.Generos)
                {
                    Generos.Add(new(genero, excludes));
                }
            }
            if (!excludes.Contains(typeof(StreamingResponseDTO)) && filme.Streamings.Count > 0)
            {
                Streamings = new();
                foreach (var streaming in filme.Streamings)
                {
                    Streamings.Add(new(streaming, excludes));
                }
            }
        }

        private double? CalcularMediaAvaliacao(List<AvaliacaoResponseDTO> avaliacoes)
        {
            if (avaliacoes.Count == 0)
            {
                return null;
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
