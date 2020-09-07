using AnyBank.Emprestimos.Core.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnyBank.Emprestimos.Core
{
    public class CreditoPessoaFisica
        : Emprestimo
    {
        public CreditoPessoaFisica()
        {
            Validacoes = new List<IValidacao>
            {
                new ValorMaximoValidacao(1_000_000.0),
                new NumMinParcelasValidacao(5),
                new NumMaxParcelasValidacao(72),
                new MinDataPrimeiraParcelaValidacao(15),
                new MaxDataPrimeiraParcelaValidacao(40)
            };

            TaxaJuros = 0.03;
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
