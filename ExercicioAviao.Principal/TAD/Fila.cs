using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExercicioAviao.Principal.Entidade;

namespace ExercicioAviao.Principal.TAD
{
    public class Fila
    {
        private Nodo _cabeca;
        private Nodo _cauda;
        private int _tamanho;

        public Fila()
        {
            this.Cabeca = null;
            this.Cauda = null;
            Tamanho = 0;
        }

        public int Tamanho
        {
            get { return _tamanho; }
            set { _tamanho = value; }
        }

        public Nodo Cabeca
        {
            get { return _cabeca; }
            set { _cabeca = value; }
        }

        public Nodo Cauda
        {
            get { return _cauda; }
            set { _cauda = value; }
        }

        public bool estaVazia()
        {
            return this._cabeca == null || this._cauda == null;
        }


        public void inserir(Aviao aviao)
        {
            Nodo novo= new Nodo();
            novo.Info = aviao;
            novo.Prox = null;
            if (estaVazia())
                _cabeca = novo;
            else
                _cauda.Prox = novo;
            _cauda = novo;
            _tamanho ++;
        }

        public Nodo remover()
        {
            Nodo n;
            if (estaVazia())
                return null;
            else
            {
                n = this._cabeca;
                _cabeca = _cabeca.Prox;
                _tamanho --;
                if (_tamanho == 0)
                {
                    _cauda = null;
                }
                return n;
            }
        }





        
        public string imprimir()
        {
            for (Nodo n=_cabeca; n != null; n=n.Prox)
            {
                return n.ToString();
            }
            return "";
        }
    }
}
