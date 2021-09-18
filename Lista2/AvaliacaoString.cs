using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista2
{
    
//1. Criar uma aplicação que auxilie na avaliação de strings e suas operações.Os requisitos são:
//   1. Receber uma string e verificar a quantidade de caracteres dela.
//   2. Se a quantidade de caracteres for PAR trocar cada caracter com o proximo caracter. Exemplo: BATATA => ABATAT
//   3. Se a quantidade de caracteres for impar inverta a string. Exemplo: EMAIL=> LIAME
//   4. Indicar se a string é um palíndromo (se a palavra for lida de trás para frente ou normalmente são iguais) Ex: OVO, Radar, reviver, saias,2002, "Lava esse aval"...
//   5. Retirar todas as letras repetidas dentro da string. Exemplo BATATA => BAT.IGUAIS => IGUAS

    class AvaliacaoString
    {
        public AvaliacaoString()
        {
            this.ExecutarAvaliacao();
        }
        void ExecutarAvaliacao()
        {
            Console.WriteLine("Digite uma palavra ou frase");
            string strAvaliacao = Console.ReadLine();
            int tamanho = strAvaliacao.Length;
            Console.WriteLine("Operações com string");
            if (tamanho % 2 ==0)
            {
                Console.WriteLine($"Trocar vizinhas:{this.TrocarVizinhos(strAvaliacao)}");
            }
            else
            {
                Console.WriteLine($"Inverter:{this.Inverter(strAvaliacao)}");
            }
            Console.WriteLine($"É um palindromo?: {(this.IsPalindromo(strAvaliacao) ? "Sim" :"Não")}");
            Console.WriteLine($"Remover letras repetidas: {this.RemoverRepetidas(strAvaliacao)}");
        }

        string Inverter(string strAvaliacao)
        {
            string invertida = "";
            for (int i = strAvaliacao.Length-1; i>=0; i--)
            {
                invertida += strAvaliacao[i];
            }
            return invertida;
        }

        string TrocarVizinhos(string strAvaliacao)
        {
            string trocado = "";
            for (int i=0; i < strAvaliacao.Length; i+=2)
            {
                trocado += strAvaliacao[i + 1];
                trocado += strAvaliacao[i];
            }
            return trocado;
        }

        bool IsPalindromo(string strAvaliacao)
        {
            //retorno com if
            //if (strAvaliacao == Inverter(strAvaliacao))
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
            //não há necessidade podemos retornar somente o resultado da comparação entre a string avaliada e ela invertida
            return strAvaliacao == Inverter(strAvaliacao);
        }

        string RemoverRepetidas(string strAvaliacao)
        {
            string retorno = "";
            retorno += strAvaliacao[0];
            for (int i = 0; i < strAvaliacao.Length; i++)
            {
                bool achouLetra = false;
                for (int j =0; j< retorno.Length;j++)
                {

                    if (strAvaliacao[i] == retorno[j])
                    {
                        achouLetra = true;
                        break;//break para sair do for, pois se ele ja achou a letra nao faz sentido continuar olhando
                    }
                }
                if (!achouLetra)
                {
                    retorno += strAvaliacao[i];
                }
            }
            return retorno;
        }
    }
}
