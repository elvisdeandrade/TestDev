using AnyBank.Emprestimos.Core.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnyBank.Emprestimos.Core
{
    public class CreditoPessoaJuridica
    : Emprestimo
    {
        public CreditoPessoaJuridica()
        {
            Validacoes = new List<IValidacao>
            {
                new ValorMaximoValidacao(1_000_000.0),
                new ValorMinPJValidacao(15_000.0),
                new NumMinParcelasValidacao(5),
                new NumMaxParcelasValidacao(72),
                new MinDataPrimeiraParcelaValidacao(15),
                new MaxDataPrimeiraParcelaValidacao(40)
            };

            TaxaJuros = 0.05;
        }

        public override void Simular()
        {
            Validar();

            if(Aprovado)
            {
                var taxaAnual = ConverterTaxaMensalParaTaxaAnual(TaxaJuros);
                Console.WriteLine($"taxaAnual: {taxaAnual}");

                var emi = CalcularEMI(taxaAnual);

                ValorFinal = emi * Parcelas;
                Juros = ValorFinal - Valor;
            }
        }
    }
}
