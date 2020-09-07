using System;
using System.Collections.Generic;
using System.Text;

namespace AnyBank.Emprestimos.Core.Validacoes
{
    public class ValorMinPJValidacao
    : IValidacao
    {
        private double valorMin;

        public ValorMinPJValidacao(double valorMin)
        {
            this.valorMin = valorMin;
            Mensagem = $"O valor do crédito para pessoa jurídica não pode ser inferior a {this.valorMin.ToString("N2")}";
        }

        public string Mensagem { get; private set; }

        public bool Validar(Emprestimo e)
        {
            return e.Valor >= valorMin;
        }
    }
}
