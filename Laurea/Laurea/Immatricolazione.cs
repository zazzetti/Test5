using System;
using System.Collections.Generic;
using System.Text;
using static Laurea.CorsoLaurea;

namespace Laurea
{
    public class Immatricolazione
    {
        
        
        public string Matricola { get; }

        private static int MatricolaSeed = 800000;
        public CorsoLaurea CorsoLaurea { get; set; }

        public DateTime DataInizio { get; set; }

        public bool FuoriCorso { get; set; }
        public uint CFUInseriti { get; set; }

        public uint CFUAccumulati { get; set; }

        public Immatricolazione(CorsoLaurea corsoLaurea)
        {
            CorsoLaurea = corsoLaurea;
            DataInizio = DateTime.Today;
            Matricola = MatricolaSeed.ToString();
            MatricolaSeed++;
            FuoriCorso = false;
            CFUInseriti = 0;
            CFUAccumulati = 0;

        }
        

    }
}
