using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExercicioAviao.Principal.Entidade;
using ExercicioAviao.Principal.Servico;
using ExercicioAviao.Principal.TAD;

namespace ExercicioAviao.Principal
{
    class Program
    {





        static void Main(string[] args)
        {
            int raio;
            int qtdAvioes;
            List<Aviao> Avioes = new List<Aviao>();
            Fila fila = new Fila();

            try
            {

                Console.Write("Raio da volta (km): ");
                raio = Convert.ToInt32(Console.ReadLine());
                Console.Write("Quantidade de aviões: ");
                qtdAvioes = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Gerando valores aleatorios para os aviões...");
                System.Threading.Thread.Sleep(3000);


                Random random = new Random();
                //Preenchendo a lista de avioes com valores aleatorios
                for (int i = 1; i <= qtdAvioes; i++)
                {
                    Aviao aviao = new Aviao(i, random);
                    aviao.Autonomia = ServicoAviao.ObterAutonomia(aviao, raio);
                    Avioes.Add(aviao);
                }


                Console.WriteLine("Ordedando os aviões de acordo com sua autonomia...");
                System.Threading.Thread.Sleep(3000);
                Avioes.OrdenarAvioesNaFila();

                //Incluindo avioes na fila
                Console.WriteLine("Adicionando na fila de espera para pouso...");
                System.Threading.Thread.Sleep(3000);
                for (int i = 0; i < qtdAvioes; i++)
                {
                    fila.inserir(Avioes[i]);
                }

                Console.WriteLine("Aviões inseridos na fila de espera para pouso.");
                System.Threading.Thread.Sleep(3000);
                Console.WriteLine("---------------------------------------------------------");

                Console.WriteLine("              Nº Passageiros     Consumo Comb.     Qtd. Comb.           Autonomia");
                for (int i = 1; i <= qtdAvioes; i++)
                {
                    Console.WriteLine("Avião " + Avioes[i - 1].Id + "               " +
                                       Avioes[i - 1].QtdPassageiro + "                " +
                                       Avioes[i - 1].ConsumoCombustivelKmLitro + "                  " +
                                       Avioes[i - 1].QtdCombustivel + "                " +
                                        Avioes[i - 1].Autonomia+" volta(s)");
                }
                System.Threading.Thread.Sleep(2000);

                int tamanhoFila = fila.Tamanho;
                for (int i = 1; i <= tamanhoFila; i++)
                {
                    Console.WriteLine("-----------------Volta " + i + "-------------------");

                    Nodo aviaoRemovido = fila.remover();
                    Console.WriteLine("Avião " + aviaoRemovido.Info.Id + " pousou.");

                    for (Nodo a = fila.Cabeca; a != null; a = a.Prox)
                    {
                        a.Info.Autonomia -= 1; //Tirando uma volta
                        if (a.Info.Autonomia < 1)
                        {
                            Console.WriteLine("Avião " + a.Info.Id + ", Caiu");
                            fila.remover();
                            tamanhoFila--;
                        }
                        else
                            Console.WriteLine("Avião " + a.Info.Id + ", Autonomia: " + a.Info.Autonomia + " voltas");

                    }
                    Console.WriteLine();
                    System.Threading.Thread.Sleep(3000);
                }

                Console.WriteLine("Pressione qualquer tecla para sair...");


            }
            catch (Exception ex)
            {

                Console.WriteLine("Erro: " + ex.Message);
            }

            Console.ReadKey();


        }
    }
}
