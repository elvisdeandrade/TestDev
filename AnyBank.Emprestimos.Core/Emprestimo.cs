using AnyBank.Emprestimos.Core.Validacoes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AnyBank.Emprestimos.Core
{
    public abstract class Emprestimo
    {
        public double Valor { get; set; }

        public double Juros { get; protected set; }

        public double ValorFinal { get; set; }

        public int Parcelas { get; set; }

        public DateTime VencimentoInicial { get; set; }

        public bool Aprovado { get; set; }

        public string MensagemDeErro{get;set;}

        public List<IValidacao> Validacoes { get; set; }

        protected double TaxaJuros { get; set; }

        public abstract void Simular();

        public override string ToString()
        {
            var result = "";

            if (Aprovado)
                result = $"Status: APROVADO \t| Valor total: {ValorFinal.ToString("N2")} \t| Juros: {Juros.ToString("N2")}";
            else
                result = $"Empréstimo não aprovado. Motivo: {MensagemDeErro}";

            return result;
        }

        public double ConverterTaxaMensalParaTaxaAnual(double tm) => (Math.Pow((1 + tm),12))-1;

        public double CalcularEMI(double taxa) => (Valor * Math.Pow((taxa / 12) + 1, Parcelas) * taxa / 12)
                                        / (Math.Pow(taxa / 12 + 1, Parcelas) - 1);

        public void Validar(){
            var error = Validacoes.FirstOrDefault(t => !t.Validar(this));

            if(error != null){
                 MensagemDeErro = error.Mensagem;
            }

            Aprovado = string.IsNullOrEmpty(MensagemDeErro);
        }
    }
}
