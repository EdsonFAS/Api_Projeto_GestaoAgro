﻿using System.ComponentModel.DataAnnotations;

namespace GestaoAgro.Dtos
{
    public class UsuarioDtos
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? NomeCompleto { get; set; }

        [Required]
        public string? NomeUsuario { get; set; }

        [Required]
        public string? Senha { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? CPF { get; set; }

        [Required]
        public DateTime DataNascimento { get; set; }

        [Required]
        public string Endereco { get; set; }
    }
}
