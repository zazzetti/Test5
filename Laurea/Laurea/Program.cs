using System;
using System.Collections.Generic;
using static Laurea.CorsoLaurea;

namespace Laurea
{
    class Program
    {
        static void Main(string[] args)
        {

            // CREAZIONE LISTA DI CORSI DA COMMAND LINE

            List<Corso> CreateListCorsi()
            {
                string name = "nome";
                uint cfu;
                string continua;
                var list = new List<Corso>();
                do
                {
                    Console.WriteLine("Nome corso");
                    name = Console.ReadLine();
                    Console.WriteLine("CFU corso");
                    cfu = uint.Parse(Console.ReadLine());

                    list.Add(new Corso(name, cfu));
                    Console.WriteLine("Altro corso? Altrimenti premi E");
                    continua = Console.ReadLine().ToUpper();

                } while (continua != "E");

                return list;
            }



            // CREAZUIBE LISTA CORSI 
            // lista dummy: cfu sempre 10, nome incrementale
            List<Corso> CreateListCorsiCasuali()
            {
                string name = "nome";
                uint cfu=10;
                int i = 0;
                var list = new List<Corso>();
                do
                {

                    list.Add(new Corso(name + i.ToString(), cfu));

                    i++;
                } while (i<15);

                return list;
            }


            //creo lista di corsi
            List<Corso> listaCorsiTotali = CreateListCorsiCasuali();


            //Creazione corso laurea con indici dei corsi
            CorsoLaurea CreateCorsoLaurea1(NomeCorsoLaurea name, uint totcfu, uint anniCorso, int[] indici)
            {
                var corsoLaurea = new CorsoLaurea(name, totcfu, anniCorso);
               
                foreach(int i in indici)
                {
                    corsoLaurea.Corsi.Add(listaCorsiTotali[i]);
                }
                return corsoLaurea;


            }

            // Creazione corso laurea dummy con tutti i corsi
            CorsoLaurea CreateCorsoLaurea2( NomeCorsoLaurea name, uint totcfu, uint anniCorso)
            {
                var corsoLaurea = new CorsoLaurea(name, totcfu, anniCorso);

                for(int i=0; i<listaCorsiTotali.Count; i++)
                {
                    corsoLaurea.Corsi.Add(listaCorsiTotali[i]);
                }
                return corsoLaurea;


            }

            // Creazione lista corsi laurea con indici dei corsi

            List<CorsoLaurea> CreaListaCorsiLaurea1()
            {
                var listaCorsiLaurea = new List<CorsoLaurea>();
                List<uint> totcfu = new List<uint> { 30, 80, 90, 110 };
                List<uint> anniCorso = new List<uint> { 3, 5, 3, 5 };
                List<int[]> lista_indici = new List<int[]>();
                lista_indici.Add(new int[] { 1, 2, 3, 4, 5, 6 });
                lista_indici.Add(new int[] { 1, 2, 3, 4, 5, 6 });
                lista_indici.Add(new int[] { 1, 2, 3, 4, 5, 6 });
                lista_indici.Add(new int[] { 1, 2, 3, 4, 5, 6 });

                for (int i = 0; i < 4; i++)
                {
                    listaCorsiLaurea.Add(CreateCorsoLaurea1( (NomeCorsoLaurea)i, totcfu[i], anniCorso[i], lista_indici[i] ));
                }
                return listaCorsiLaurea;
            }



            // Creazione lista corsi laurea dummy con tutti i corsi

            List<CorsoLaurea> CreaListaCorsiLaurea2()
            {
                var listaCorsiLaurea = new List<CorsoLaurea>();
                List<uint> totcfu = new List<uint> { 30, 80, 90, 110 };
                List<uint> anniCorso = new List<uint> { 3,5,3,5};
                for (int i=0; i<4; i++)
                {
                    listaCorsiLaurea.Add(CreateCorsoLaurea2((NomeCorsoLaurea) i, totcfu[i], anniCorso[i]));
                }
                return listaCorsiLaurea;
            }



            // uso lista dummy per test


            List<CorsoLaurea> listaCorsiLaurea = CreaListaCorsiLaurea2();

            //creo studente

            Studente s = new Studente("Elena", "Zazzetti", new DateTime(1995, 10, 11), listaCorsiLaurea[0]);

            s.ShowInfoStud();
            //Corso n = new Corso("nome110", 30);
            //s.AddEsame(n); // controllo che non mi faccia aggiungere un corso non presente nel corso di laurea

            s.AddEsame(listaCorsiTotali[0]);
            s.AddEsame(listaCorsiTotali[1]);
            s.AddEsame(listaCorsiTotali[2]);
            s.AddEsame(listaCorsiTotali[3]); // Controllo superamento crediti totali del corso di laurea



            s.ShowMyExames();

            s.EsamePassato(s.Esami[0]);
            s.EsamePassato(s.Esami[1]);
            s.EsamePassato(s.Esami[2]);

            s.ShowMyExames();

            //s.AddEsame(listaCorsiTotali[2]); // controllo che non mi faccia aggiungere corso


            ////////////////
            /// INTERAZIONE CON UTENTE

            Console.WriteLine("Inserisci nome");
            bool flag = true;
            string name = Console.ReadLine();
            Console.WriteLine("Inserisci cognome");
            string surname = Console.ReadLine();
            Console.WriteLine("Inserisci Data di nascita");
            DateTime dateTime=new DateTime();
            do
            {
                flag = true;
                try
                {
                    string date = Console.ReadLine();
                    dateTime = DateTime.Parse(date);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Data incorretta");
                    flag = false;
                }
            } while (flag == false);

            Console.WriteLine("Scegli corso di laurea tra:");
            for(int i=0; i<listaCorsiLaurea.Count; i++)
            {
                Console.WriteLine("{0} per {1}", i, listaCorsiLaurea[i].Nome);
            }

            int j;
            do
            {
                Console.WriteLine("Indica il numero associato:");
                j = Int32.Parse(Console.ReadLine());
            } while (j < 0 || j > listaCorsiLaurea.Count);

            Studente s2 = new Studente(name, surname, dateTime, listaCorsiLaurea[j]);

            s2.ShowInfoStud();

            Console.WriteLine("Aggiungi i corsi che preferisci al tuo piano di studi tra quelli del tuo corso");

            for (int i = 0; i < listaCorsiLaurea[j].Corsi.Count; i++)
            {
                Console.WriteLine("Premi Y per  aggungere {1}", i, listaCorsiLaurea[j].Corsi[i].Nome);
                if (Console.ReadLine() == "Y") s2.AddEsame(listaCorsiLaurea[j].Corsi[i]);
                
            }

            Console.WriteLine("Gli esami scelti sono:");
            s2.ShowMyExames();


        }
    }
}
