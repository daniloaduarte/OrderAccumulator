using System;

namespace OrderAccumulator.Models
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Ativo { get; set; }
        public string Lado { get; set; } // "C" para Compra, "V" para Venda
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }

        public decimal ValorTotal => Quantidade * Preco;
    }
}
