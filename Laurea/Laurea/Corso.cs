using System;
using System.Collections.Generic;
using System.Text;

namespace Laurea
{
    public class Corso
    {
        public string Nome { get; set; }
        public uint CFU { get; set; }

        public Corso(string nome, uint cfu)
        {
            Nome = nome;
            CFU = cfu;
        }

    }
}
