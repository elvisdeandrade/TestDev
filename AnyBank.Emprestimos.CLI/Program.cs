using System;
using AnyBank.Emprestimos.Core;

namespace AnyBank.Emprestimos.CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Any Bank - Emprestimos");
            Console.WriteLine("Escolha o tipo um tipo de crédito:(digite o número da opção)");

            Console.WriteLine("1 - Credito Direto");
            Console.WriteLine("2 - Credito Consignado");
            Console.WriteLine("3 - Credito Pessoa Jurídica");
            Console.WriteLine("4 - Credito Pessoa Física");
            Console.WriteLine("5 - Credito Imobiliário");

            Emprestimo emprestimo = null;

            var opt = Console.ReadLine();

            if(int.TryParse(opt, out int x)){
                switch (x)
                {
                    case 1:
                        emprestimo = new CreditoDireto();
                        break;
                    case 2:
                        emprestimo = new CreditoConsignado();
                        break;
                    case 3:
                        emprestimo = new CreditoPessoaJuridica();
                        break;
                    case 4:
                        emprestimo = new CreditoPessoaFisica();
                        break;
                    case 5:
                        emprestimo = new CreditoImobiliario();
                        break;
                    default:
                        Console.WriteLine("Opção inválida");
                        return;
                }
            }

            Console.WriteLine("Entre com o valor do crédito:");
            var vlr = Console.ReadLine();

            if(!double.TryParse(vlr, out double valor))
                Console.WriteLine("Valor inválido!");

            emprestimo.Valor = valor;

            Console.WriteLine("Entre com o número de parcelas:");
            var p = Console.ReadLine();

            if(!int.TryParse(p, out int totalParcelas))
                Console.WriteLine("Número de parcelas inválido!");

            emprestimo.Parcelas = totalParcelas;

            Console.WriteLine("Entre com a data da primeira parcela:(dd/MM/yyyy)");
            var sdt = Console.ReadLine();

            if(!DateTime.TryParseExact(sdt, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime dt))
                Console.WriteLine("Data inválida!");

            Console.WriteLine(dt.ToString());
            emprestimo.VencimentoInicial = dt;

            emprestimo.Simular(); 

            Console.WriteLine(emprestimo.ToString());
            Console.ReadKey();
        }
    }
}
