using System;
using System.Threading;

namespace JogoDaVelha
{
    class Program
    {
        static char[] array = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int jogador = 1;
        static int escolha;
        static int marcacao = 0;
        static void Main(string[] args)
        {
            do
            {
                Console.Clear();
                Console.WriteLine("Jogador1:X e Jogador2:O");
                Console.WriteLine("\n");
                if (jogador % 2 == 0)
                    Console.WriteLine("Vez do Jogador 2");
                else
                    Console.WriteLine("Vez do Jogador 1");


                Console.WriteLine("\n");
                Tabuleiro();
                try
                {
                    escolha = int.Parse(Console.ReadLine());

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Favor inserir um número de 1 a 9");
                    Console.WriteLine("\n");
                    Console.WriteLine("Aguarde enquanto remontamos o tabuleiro...");
                    Thread.Sleep(2000);
                }

                if (escolha > 9 || escolha == 0)
                {
                    Console.WriteLine("Favor inserir um número de 1 a 9");
                    Console.WriteLine("\n");
                    Console.WriteLine("Aguarde enquanto remontamos o tabuleiro...");
                    Thread.Sleep(2000);
                }
                else if (array[escolha] != 'X' && array[escolha] != 'O')
                {
                    if (jogador % 2 == 0)
                    {
                        array[escolha] = 'O';
                        jogador++;
                    }
                    else
                    {
                        array[escolha] = 'X';
                        jogador++;
                    }
                }
                else
                {
                    Console.WriteLine("A linha {0} já está marcada com {1}", escolha, array[escolha]);
                    Console.WriteLine("\n");
                    Console.WriteLine("Aguarde enquanto remontamos o tabuleiro...");
                    Thread.Sleep(2000);
                }
                marcacao = VerificarVencedor();
            }

            while (marcacao != 1 && marcacao != -1);
            Console.Clear();
            Tabuleiro();

            if (marcacao == 1)
                Console.WriteLine(" O Jogador {0} Ganhou", (jogador % 2) + 1);

            else
                Console.WriteLine("Empate, não há mais jogadas disponíveis");

            Console.ReadLine();
        }
        private static void Tabuleiro()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", array[1], array[2], array[3]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", array[4], array[5], array[6]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", array[7], array[8], array[9]);
            Console.WriteLine("     |     |      ");
        }
        private static int VerificarVencedor()
        {
            #region Horizontal

            if (array[1] == array[2] && array[2] == array[3])
                return 1;

            else if (array[4] == array[5] && array[5] == array[6])
                return 1;

            else if (array[6] == array[7] && array[7] == array[8])
                return 1;

            #endregion

            #region Vertical 
            else if (array[1] == array[4] && array[4] == array[7])
                return 1;

            else if (array[2] == array[5] && array[5] == array[8])
                return 1;

            else if (array[3] == array[6] && array[6] == array[9])
                return 1;

            #endregion

            #region Diagonal 

            else if (array[1] == array[5] && array[5] == array[9])
                return 1;

            else if (array[3] == array[5] && array[5] == array[7])
                return 1;

            #endregion

            #region Empate

            else if (array[1] != '1' && array[2] != '2' && array[3] != '3' && array[4] != '4' && array[5] != '5' && array[6] != '6' && array[7] != '7' && array[8] != '8' && array[9] != '9')
                return -1;

            #endregion

            else
                return 0;
        }
    }
}
