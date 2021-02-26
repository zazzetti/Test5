using System;
using System.Collections.Generic;
using System.Text;
using static Laurea.CorsoLaurea;

namespace Laurea
{
    public class Studente
    {

        
        public string Nome { get; set; }

        public string Cognome { get; set; }

        public DateTime AnnoNascita { get; set; }

        public Immatricolazione Immatricolazione { get; set; }

        public List<Esame> Esami { get; set; }

        public bool RichiestaLaurea { get; set; }


        public Studente(string nome, string cognome, DateTime annoNascita, CorsoLaurea CorsoLaurea)
        {
            Nome = nome;
            Cognome = cognome;
            AnnoNascita = annoNascita;
            Immatricolazione = new Immatricolazione(CorsoLaurea);
            Esami = new List<Esame>();
            RichiestaLaurea = false;
        }


        public void ShowInfoStud()
        {
            Console.WriteLine("Info personali: Nome: {0}, Cognome: {1}, Anno di Nascita: {2}", Nome, Cognome, AnnoNascita.ToShortDateString());
            Console.WriteLine("Info Studente : Matricola: {0}, Corso Laurea: {1}, Data inizio {2}", Immatricolazione.Matricola, Immatricolazione.CorsoLaurea.Nome, Immatricolazione.DataInizio.ToShortDateString());
 
        }
        public void ShowMyExames()
        {
            foreach (var item in Esami)
            {
                Console.WriteLine("Esame : {0} , CFU:{1}, Passato: {2}", item.EsameCorso.Nome, item.EsameCorso.CFU, item.Passato);
            }
        }


        public void AddEsame(Corso corso)
        {
            bool exists = false;
        
            foreach(var it in Immatricolazione.CorsoLaurea.Corsi)
            {
                if (it.Nome == corso.Nome)
                    exists = true;
            }
            
            if (exists &&   Immatricolazione.CFUInseriti + corso.CFU <= Immatricolazione.CorsoLaurea.Totcfu && RichiestaLaurea == false)
            {

                Esami.Add(new Esame(corso));
                Immatricolazione.CFUInseriti += corso.CFU;
            }
            else Console.WriteLine("Non puoi aggiungere il corso");

        }
        public void EsamePassato(Esame esame)
        {
            Immatricolazione.CFUAccumulati += esame.EsameCorso.CFU;
            esame.Passato = true;
            if (Immatricolazione.CFUAccumulati == Immatricolazione.CorsoLaurea.Totcfu)
            {
                RichiestaLaurea = true;
                Console.WriteLine("Ti puoi laureare, congratulazioni!");
            }
        }

    }
}
