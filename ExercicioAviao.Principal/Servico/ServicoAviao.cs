using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExercicioAviao.Principal.Entidade;

namespace ExercicioAviao.Principal.Servico
{
    public static class ServicoAviao
    {
        //Quantidade de voltas no circulo que o avião consegue dar
        public static int ObterAutonomia(Aviao aviao, double raioVolta)
        {
            double autonomia = 0;
            double circunferenciaKm = 2*3.14*raioVolta;

            autonomia = (aviao.QtdCombustivel*aviao.ConsumoCombustivelKmLitro)/circunferenciaKm;

            if (autonomia < 0)
            {
                throw new InvalidOperationException("Raio da volta com valor baixo!!!");
            }
            return Convert.ToInt32(autonomia);

        }

        public static int GerarAleatorio(Random random, int min, int max)
        {
            return random.Next(min, max);
        }


        public static void OrdenarAvioesNaFila(this List<Aviao> avioes)
        {
            Aviao aviaoAux;
            bool ordem = false;
            while (ordem == false)
            {
                ordem = true;
                for (int i = 0; i < avioes.Count() - 1; i++)
                {
                    if (avioes[i].Autonomia > avioes[i + 1].Autonomia)
                    {
                        aviaoAux = avioes[i + 1];
                        avioes[i + 1] = avioes[i];
                        avioes[i] = aviaoAux;
                        ordem = false;
                    }
                    //Caso possuem a msm autonomia será ordenado pelo numero de passageiros
                    if (avioes[i].Autonomia == avioes[i + 1].Autonomia)
                    {
                        if (avioes[i].QtdPassageiro > avioes[i + 1].QtdPassageiro)
                        {
                            aviaoAux = avioes[i + 1];
                            avioes[i + 1] = avioes[i];
                            avioes[i] = aviaoAux;
                            ordem = false;
                        }
                    }

                }
            }
        }
    }
}

