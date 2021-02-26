using System;
using System.Collections.Generic;
using System.Text;

namespace Laurea
{
    public class Esame
    {
        public Corso EsameCorso { get; set; }

        public bool Passato { get; set; }

        public Esame(Corso corso)
        {
            EsameCorso = corso;
            Passato = false;
        }
    }
}
