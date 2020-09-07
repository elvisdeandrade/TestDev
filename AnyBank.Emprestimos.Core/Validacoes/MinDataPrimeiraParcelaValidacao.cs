using System;
using System.Collections.Generic;
using System.Text;

namespace AnyBank.Emprestimos.Core.Validacoes
{
    public class MinDataPrimeiraParcelaValidacao
    : IValidacao
    {
        private int minDias;
        public MinDataPrimeiraParcelaValidacao(int minDias)
        {
            this.minDias = minDias;
            Mensagem = $"A data mínima para o vencimento da primeira parcela não pode ser inferior a {DateTime.Today.AddDays(minDias).ToString("dd/MM/yyyy")}";
        }

        public string Mensagem { get; private set; }

        public bool Validar(Emprestimo e)
        {
            var minData = DateTime.Today.AddDays(minDias);

            return e.VencimentoInicial >= minData;
        }
    }
}
