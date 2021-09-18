using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lista2
{


    //8. Se a quantidade de elementos da matriz do usuário for maior ou igual a 3, exiba quantos e quais números da matriz randômica estão contidos na matriz do usuário: 

    //   Exemplo: 

    //   Usuário Digita 4.6,8,9,10,12,13.

    //   Matriz randomica gerada: 5,8,12

    //   O que será exibido: Os números 8,12 da matriz randômica estão presentes na matriz do usuário.



    class OperacoesInteiros
    {
        public OperacoesInteiros()
        {
            this.ExecutarOperacoes();
        }

        private int menorNumero = 0;
        private int maiorNumero = 0;
        void ExecutarOperacoes()
        {

            int[] matriz = GetMatriz();
            this.ExibirInformacoesMatriz(matriz);
            int[] matrizRandomica = this.GetMatrizRandomica();


            //poderiamos utilizar um foreach, mas temos um metodo na string que serve justamente pra juntar elementos de uma matriz
            Console.WriteLine($"Matriz digitada: {String.Join(",", matriz)}");
            Console.WriteLine($"Matriz randomica: {String.Join(",", matrizRandomica)}");
            this.CompararMatrizes(matriz, matrizRandomica);

        }



        /// <summary>
        /// Solicita o usuario a entrar n números e para quando encontra um número primo ou preenche os 10 itens
        /// </summary>
        /// <returns></returns>
        private int[] GetMatriz()
        {
            int[] inputNumeros = new int[10];
            int count = 0;
            Console.WriteLine("Insira números até digitar um número primo ou termos 10 elementos");
            for (int i = 0; i < inputNumeros.Length; i++)
            {
                Console.WriteLine($"{i + 1}º número");
                int input = SolicitarNumero();
                inputNumeros[i] = input;
                count++;
                if (isPrimo(input))
                {
                    Console.WriteLine("Número primo digitado, preenchimento finalizado");
                    break;
                }
            }
            int[] matriz = new int[count];
            for (int i = 0; i < matriz.Length; i++)
                matriz[i] = inputNumeros[i];
            return matriz;
        }

        /// <summary>
        /// Solicita input do usuário até ser um número válido
        /// </summary>
        /// <returns></returns>
        private int SolicitarNumero()
        {
            bool numeroValido = false;
            int input = 0;

            while (!numeroValido)
            {
                numeroValido = int.TryParse(Console.ReadLine(), out input);
                if (!numeroValido)
                {
                    Console.WriteLine("Número inválido, entre um novo número.");
                }

            };
            return input;
        }

        /// <summary>
        /// Verifica se o número avaliado é primo ou não
        /// </summary>
        /// <param name="numero"></param>
        /// <returns></returns>
        bool isPrimo(int numero)
        {
            //se for 1 não é primo
            if (numero == 1)
                return false;
            //se for dois é primo
            if (numero == 2)
                return true;

            int limiteMaximo = numero / 2;//otimizacao de performance, não fazs sentido dividirmos qualquer numero que seja maior que a metade do numero avaliado
            for (int i = 2; i <= limiteMaximo; i++)
            {
                if (numero % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Em um único método logamos as informações pedidas quanto a matriz do usuário, feito em um unico método para diminui leituras no array
        /// </summary>
        /// <param name="matriz"></param>
        private void ExibirInformacoesMatriz(int[] matriz)
        {
            int qtdPar = 0;
            int qtdImpar = 0;

            maiorNumero = matriz[0];
            menorNumero = matriz[0];

            int totalMatriz = 0;

            foreach (int item in matriz)
            {
                if (item % 2 == 0)
                    qtdPar += 1;
                else
                    qtdImpar += 1;

                if (item < menorNumero)
                    menorNumero = item;

                if (item > maiorNumero)
                    maiorNumero = item;

                totalMatriz += item;
            }
            Console.WriteLine($"Quantidade de número ímpares: {qtdImpar}");
            Console.WriteLine($"Quantidade de número pares: {qtdPar}");
            Console.WriteLine($"Menor número: {this.menorNumero}");
            Console.WriteLine($"Maior número: {this.maiorNumero}");
            Console.WriteLine($"TotalMatriz: {totalMatriz}");
        }

        /// <summary>
        /// a partir do menor e maior número gera um numero randomico entre esses dois numeros
        /// </summary>
        /// <returns></returns>
        private int[] GetMatrizRandomica()
        {
            int[] matrizRandomica = new int[3];
            for (int i = 0; i < matrizRandomica.Length; i++)
                matrizRandomica[i] = new Random().Next(menorNumero, maiorNumero);
            return matrizRandomica;
        }


        /// <summary>
        /// Varre as duas matrizes e exibe elementos em comum
        /// </summary>
        /// <param name="matriz"></param>
        /// <param name="matrizRandomica"></param>
        private void CompararMatrizes(int[] matriz, int[] matrizRandomica)
        {
            if (matriz.Length < 3)
                return;
            string numerosComuns = "";

            foreach (int rnd in matrizRandomica)
            {
                foreach (int item in matriz)
                {
                    if (rnd == item)
                        numerosComuns += $"{item},";
                }
            }
            if (numerosComuns == "")
                Console.WriteLine($"Não há números em comum entre as duas matrizes");
            else
                Console.WriteLine($"Os números {numerosComuns.TrimEnd(',')} da matriz randômica estão presentes na matriz do usuário");
        }

    }


}
