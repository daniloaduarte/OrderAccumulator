namespace OrderAccumulator.Models
{
    public class OrderResponse
    {
        public bool Sucesso { get; set; }
        public decimal ExposicaoAtual { get; set; }
        public string MsgErro { get; set; }
    }
}
