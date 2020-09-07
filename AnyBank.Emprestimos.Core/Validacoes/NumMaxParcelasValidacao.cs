using System;
using System.Collections.Generic;
using System.Text;

namespace AnyBank.Emprestimos.Core.Validacoes
{
    public class NumMaxParcelasValidacao
    : IValidacao
    {
        private int maxParcelas;

        public NumMaxParcelasValidacao(int maxParcelas)
        {
            this.maxParcelas = maxParcelas;
            Mensagem = $"O número de parcelas não pode exceder a {this.maxParcelas} parcelas";
        }

        public string Mensagem { get; private set; }

        public bool Validar(Emprestimo e)
        {
            return e.Parcelas <= maxParcelas;
        }
    }
}
