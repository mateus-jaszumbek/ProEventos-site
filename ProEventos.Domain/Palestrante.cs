using System.ComponentModel.DataAnnotations;

namespace ProEventos.Domain
{
    public class Palestrante
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Nome { get; set; } = string.Empty;
        [MaxLength(1000)]
        public string MiniCurriculo { get; set; } = string.Empty;
        [MaxLength(50)]
        public string ImagemURL { get; set; } = string.Empty;
        [MaxLength(15)]
        public string Telefone { get; set; } = string.Empty;
        [MaxLength(100)]
        public string Email { get; set; } = string.Empty;
        public IEnumerable<RedeSocial>? RedesSociais { get; set; }
        public IEnumerable<PalestranteEvento>? PalestrantesEventos { get; set; }

    }
}