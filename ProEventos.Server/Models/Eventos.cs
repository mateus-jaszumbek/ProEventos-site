using System.ComponentModel.DataAnnotations;

namespace ProEventos.Server.Models
{
    public class Eventos
    {
        [Key]
        public int EventoId { get; set; }
        [MaxLength(150)]
        public string? Local { get; set; } = string.Empty;
        [MaxLength(11)]
        public string? DataEvento { get; set; } = string.Empty;
        [MaxLength(150)]
        public string? Tema { get; set; } = string.Empty;
        public int QtdPessoas { get; set; }
        [MaxLength(20)]
        public string? Lote { get; set; } = string.Empty;
        [MaxLength(50)]
        public string? ImagemURL { get; set; } = string.Empty;
    }
}