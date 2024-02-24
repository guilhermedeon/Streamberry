﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Streamberry.Domain.Entities
{
    public partial class Avaliacao : BaseEntity
    {

        [Required(ErrorMessage = "A classificação é obrigatória.")]
        public int? Classificacao { get; set; }

        [Required(ErrorMessage = "O comentário é obrigatório.")]
        public string? Comentario { get; set; }

        [Required(ErrorMessage = "O Id do filme é obrigatório.")]
        public int? IdFilme { get; set; }

        [Required(ErrorMessage = "O Id do usuário é obrigatório.")]
        public int? IdUsuario { get; set; }

        public Filme? Filme { get; set; }

        public Usuario? Usuario { get; set; }
    }
}
