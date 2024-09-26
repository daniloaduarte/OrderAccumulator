using System;
using System.Collections.Generic;
using OrderAccumulator.Models;

namespace OrderAccumulator.Services
{
    public class OrderService
    {
        private const decimal LimiteExposicao = 1000000;
        private static readonly Dictionary<string, decimal> ExposicaoAtivos = new Dictionary<string, decimal>
        {
            { "PETR4", 0 },
            { "VALE3", 0 },
            { "VIIA4", 0 }
        };

        public decimal CalcularExposicaoAtual(string ativo)
        {
            return ExposicaoAtivos[ativo];
        }

        public OrderResponse RegistrarOrdem(Order order)
        {
            decimal exposicaoAtual = CalcularExposicaoAtual(order.Ativo);
            decimal novaExposicao = order.Lado == "C" ? exposicaoAtual + order.ValorTotal : exposicaoAtual - order.ValorTotal;

            if (Math.Abs(novaExposicao) > LimiteExposicao)
            {
                return new OrderResponse
                {
                    Sucesso = false,
                    ExposicaoAtual = exposicaoAtual,
                    MsgErro = $"Exposição financeira ultrapassa o limite de R$ 1.000.000 para o ativo {order.Ativo}"
                };
            }

            ExposicaoAtivos[order.Ativo] = novaExposicao;

            return new OrderResponse
            {
                Sucesso = true,
                ExposicaoAtual = novaExposicao,
                MsgErro = null
            };
        }
    }
}
