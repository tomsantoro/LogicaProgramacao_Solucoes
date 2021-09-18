using System;

namespace Mercado
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "Sim";
            string b = "SIM";
            Console.WriteLine($"a {a} e b {b} são iguais case sensitive:{a.Equals(b)}");
            Console.WriteLine($"a {a} e b {b} são iguais insensitive:{a.Equals(b, StringComparison.OrdinalIgnoreCase)}");
            bool possuiCarteira;
            bool estaSol;
            bool possuiEstacionamentoCoberto;
            bool possuiOvos;
            Console.WriteLine("Decisão de ir no mercado");

            possuiCarteira = GetRepostaUsuario("Pegou a carteira?");
            estaSol = GetRepostaUsuario("Esta  Sol?");
            possuiEstacionamentoCoberto = GetRepostaUsuario("O Mercado possui estacionamento coberto?");
            possuiOvos = GetRepostaUsuario("O Mercado possui ovos?");


            int qtdCaixaLeite = 4;
            int qtdOvos = 0;
            
            double precoUnitarioLeite = 3.15;
            double precoDuziaOvo = 7.00;

        
            if (!possuiCarteira)
            {
                Console.WriteLine ($"Fiado de forma alguma, vá para casa espertão");
                Environment.Exit(0);
            }

            if (!estaSol && !possuiEstacionamentoCoberto)
            {
                Console.WriteLine ($"Fica em casa que é melhor");
                Environment.Exit(0);
            }

            if (possuiOvos && precoDuziaOvo < 6) 
            {
                qtdOvos = 6;
            }
            double precoTotalLeite = qtdCaixaLeite * precoUnitarioLeite;
            double precoTotalOvos = (precoDuziaOvo / 12) * qtdOvos;
            double totalCompra = precoTotalLeite + precoTotalOvos;
            
          
            Console.WriteLine($"Quantidade de caixas de leite compradas:{qtdCaixaLeite}");
            Console.WriteLine($"Quantidade de ovos comprados:{qtdOvos}");
            Console.WriteLine($"Total Leite:{precoTotalLeite}");
            Console.WriteLine($"Total Ovos:{precoTotalOvos}");
            Console.WriteLine($"Total de compras:{totalCompra}");
        }

        static bool GetRepostaUsuario(string msg)
        {
            Console.WriteLine(msg);
            string resposta = Console.ReadLine().ToUpper();

            switch (resposta)
            {
                case "SIM":
                    return true;
                case "NAO":
                    return false;
                default:
                    Console.WriteLine("Opção Inválida");
                    Environment.Exit(0);
                    return false;
            }
        }
    }
}
