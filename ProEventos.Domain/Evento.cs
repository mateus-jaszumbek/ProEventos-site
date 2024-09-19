using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace ProEventos.Domain
{
    public class Evento
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(150)]
        public string? Local { get; set; } = string.Empty;
        public DateTime? DataEvento { get; set; }
        [MaxLength(150)]
        public string? Tema { get; set; } = string.Empty;
        public int QtdPessoas { get; set; }
        [MaxLength(50)]
        public string? ImagemURL { get; set; } = string.Empty;
        [MaxLength(20)]
        public string Telefone { get; set; } = string.Empty;
        [MaxLength(150)]
        public string Email { get; set; } = string.Empty;

        public IEnumerable<Lote>? Lotes { get; set; }
        public IEnumerable<RedeSocial>? RedesSociais { get; set; }
        public IEnumerable<PalestranteEvento>? PalestrantesEventos { get; set; }

    }
}