using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROVA
{
    class Candidatos
    {
        private string Nome;
        private int votos = 0;


        public Candidatos(string nome, int votos)
        {
            this.Nome = nome;
            this.votos += votos;

        }
        public Candidatos(string nome)
        {
            this.Nome = nome;

        }
        public void SetVoto(int voto)
        {
            this.votos += voto;
            return;

        }

        public int GetVoto()
        {

            return votos;

        }
        public void setNome(string nome)
        {
            this.Nome = nome;
            return;
        }
        public string getNome()
        {
            return this.Nome;
        }
    }
}