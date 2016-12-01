using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class Exercicio
    {
        private String nome;
        private int calorias;
        private int met;

       

        public Exercicio(string nome, int calorias, int met)
        {
            this.Nome = nome;
            this.Calorias = calorias;
            this.Met = met;
        }


        public string Nome
        {
            get
            {
                return nome;
            }

            set
            {
                nome = value;
            }
        }

        public int Calorias
        {
            get
            {
                return calorias;
            }

            set
            {
                calorias = value;
            }
        }

        public int Met
        {
            get
            {
                return met;
            }

            set
            {
                met = value;
            }
        }

        public override string ToString()
        {
            return nome + " " + calorias + " " + met + " " + Environment.NewLine + "\n";
        }

    }
}
