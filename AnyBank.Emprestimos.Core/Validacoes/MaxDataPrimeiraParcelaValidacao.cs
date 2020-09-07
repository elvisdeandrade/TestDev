using System;
using System.Collections.Generic;
using System.Text;

namespace AnyBank.Emprestimos.Core.Validacoes
{
    public class MaxDataPrimeiraParcelaValidacao
        : IValidacao
    {
        private int maxDias;

        public MaxDataPrimeiraParcelaValidacao(int maxDias)
        {
            this.maxDias = maxDias;
            Mensagem = $"A data máxima para o vencimento da primeira parcela não pode exceder a {DateTime.Today.AddDays(maxDias).ToString("dd/MM/yyyy")}";
        }

        public string Mensagem { get; private set; }

        public bool Validar(Emprestimo e)
        {
            var maxData = DateTime.Today.AddDays(maxDias);

            return e.VencimentoInicial <= maxData;
        }
    }
}
