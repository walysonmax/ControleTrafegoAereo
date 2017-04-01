using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExercicioAviao.Principal.Entidade;

namespace ExercicioAviao.Principal.TAD
{
    public class Nodo
    {
        private Aviao _info;
        private Nodo _prox;
        public Nodo()
        {
            this.Prox = null;
            this.Info = null;
        }


        public Aviao Info
        {
            get { return _info; }
            set { _info = value; }
        }

        public Nodo Prox
        {
            get { return _prox; }
            set { _prox = value; }
        }

        public override string ToString()
        {
            return "";
        }
    }
}
