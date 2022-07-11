using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class Utente
    {
        public string surname;
        public string name;
        public string email;
        public string password;
        public int number;

        public Utente(string email, string password)
        {
            this.email = email;
            this.password = password;
        }

        public void EffettuaPrestito (DateTime inizio, DateTime fine, Documento doc, Biblioteca biblioteca)
        {
            Prestito newLoan = new Prestito(inizio, fine, doc);
            biblioteca.loanList.Add(newLoan);
        }

        public Documento CercaPerTitolo (string titolo, Biblioteca biblioteca)
        {
            Documento documentoDaPassare = null;
            foreach (Documento doc in biblioteca.docList)
            {
                if (titolo == doc.title)
                {
                    documentoDaPassare=doc;
                }
            }
            return documentoDaPassare;
        }

        public Documento CercaPerCodice (string id, Biblioteca biblioteca)
        {
            Documento documentoDaPassare = null;
            foreach (Documento doc in biblioteca.docList)
            {
                if (id == doc.GetId())
                {
                    documentoDaPassare = doc;
                }
            }
            return documentoDaPassare;
        }


    }
}
