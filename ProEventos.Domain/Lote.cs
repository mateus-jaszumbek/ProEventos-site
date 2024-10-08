﻿using System.ComponentModel.DataAnnotations;

namespace ProEventos.Domain
{
    public class Lote
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string Nome { get; set; } = string.Empty;
        public decimal Preco { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
        public int Quantidade { get; set; }
        public int EventoId { get; set; }
        public Evento? Evento { get; set; }

    }
}