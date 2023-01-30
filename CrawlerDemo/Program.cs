using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using HtmlAgilityPack;
using System.Text;
using System.Data.Odbc;
using System.Threading.Tasks;

namespace CrawlerDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            double totalSalarioLiquido = 2250;
            htmlCrawler(totalSalarioLiquido);
            Console.ReadLine();
        }

        private static void htmlCrawler(double salarioLiquido)
        {
            var valorDaDespesa = 0.00;
            var doc = new HtmlDocument();
            doc.Load(@"C:\Users\fabio.masao\Desktop\html pasta\teste.html");

            var spans =
            doc.DocumentNode.Descendants("span")
                .Where(node => node.GetAttributeValue("class", "").Equals("to-do-children-unchecked")).ToList();
                       
            foreach(var span in spans)
            {
                string linha = span.InnerText;
                var arrayDaLinha = linha.Split(' ');
                valorDaDespesa = Double.Parse(arrayDaLinha[1]) + valorDaDespesa;
            }

            Console.WriteLine($"Entrada (salário): {salarioLiquido}");
            Console.WriteLine($"Saída: {valorDaDespesa}");
            Console.WriteLine($"Saldo: {salarioLiquido - valorDaDespesa}\n");

            Console.WriteLine("Press Enter to exit the program...");
            ConsoleKeyInfo keyinfor = Console.ReadKey(true);

            if(keyinfor.Key == ConsoleKey.Enter)
            {
                System.Environment.Exit(0);
            }

        }
       
    }
}
