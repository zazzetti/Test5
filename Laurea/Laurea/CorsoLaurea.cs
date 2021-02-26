using System;
using System.Collections.Generic;
using System.Text;

namespace Laurea
{
    public class CorsoLaurea
    {
        public enum NomeCorsoLaurea
        {
            Matematica,
            Fisica,
            Informatica,
            Ingegneria,
            Lettere
        }
        public NomeCorsoLaurea Nome { get; }
        public uint AnniCorso { get; set; }

        public uint Totcfu { get; set; }
        
        public List<Corso> Corsi { get; set; }

        public CorsoLaurea(NomeCorsoLaurea nomecorsoLaurea, uint totcfu, uint anniCorso)
        {
            Nome = nomecorsoLaurea;
            Corsi = new List<Corso>();
            Totcfu = totcfu;
            AnniCorso = anniCorso;
        }

        //private void AddCorso(Corso corso)
        //{
        //    Corsi.Add(corso);
        //}

    }
}
