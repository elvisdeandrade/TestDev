using System;
using System.Collections.Generic;
using System.Text;

namespace AnyBank.Emprestimos.Core.Validacoes
{
    public class ValorMaximoValidacao
     : IValidacao
    {
        private double valorMax;

        public ValorMaximoValidacao(double valorMax)
        {
            this.valorMax = valorMax;
            Mensagem = $"O valor do crédito não pode exceder a {this.valorMax.ToString("N2")}";
        }

        public string Mensagem { get; private set; }

        public bool Validar(Emprestimo e)
        {
            return e.Valor <= valorMax;
        }
    }
}
