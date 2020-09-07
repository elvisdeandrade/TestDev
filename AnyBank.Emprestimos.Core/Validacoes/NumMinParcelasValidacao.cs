using System;
using System.Collections.Generic;
using System.Text;

namespace AnyBank.Emprestimos.Core.Validacoes
{
    public class NumMinParcelasValidacao
    : IValidacao
    {
        private int minParcelas;

        public NumMinParcelasValidacao(int minParcelas)
        {
            this.minParcelas = minParcelas;
            Mensagem = $"O número de parcelas não pode ser inferior a {this.minParcelas} parcelas";        }

        public string Mensagem { get; private set; }

        public bool Validar(Emprestimo e)
        {
            return e.Parcelas >= minParcelas;
        }
    }
}
