using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExercicioAviao.Principal.Servico;

namespace ExercicioAviao.Principal.Entidade
{
    public class Aviao
    {
        public int Id { get; set; }
        public int QtdCombustivel { get; set; }
        public double ConsumoCombustivelKmLitro { get; set; }
        public double QtdPassageiro { get; set; }
        public int Autonomia { get; set; }
        public bool pousou { get; set; }



        public Aviao(int id, Random random=null)
        {
     
            Id = id;
            QtdCombustivel = ServicoAviao.GerarAleatorio(random,10, 500);
            ConsumoCombustivelKmLitro = ServicoAviao.GerarAleatorio(random,3, 10);
            QtdPassageiro = ServicoAviao.GerarAleatorio(random,0, 150);
        }
    }
}
