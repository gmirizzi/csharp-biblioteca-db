using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class Biblioteca
    {
        public List<Utente> userList = new List<Utente>();
        public List<Prestito> loanList = new List<Prestito>();
        public List<Documento> docList = new List<Documento>();

        public List<Prestito> LoanResearch(string name, string surname)
        {
            List<Prestito> prestitiCercati = new List<Prestito>();
            foreach (Prestito prestito in loanList)
            {
                if (name == prestito.user.name && surname == prestito.user.surname)
                {
                    prestitiCercati.Add(prestito);
                }
            }
            return prestitiCercati;
        }

        public void AddUser (Utente user)
        {
            userList.Add(user);
        }

        public void AddDoc(Documento doc)
        {
            docList.Add(doc);
        }

        public bool isRegistred (string mail, string pw)
        {
            bool registered = false;
            foreach (Utente user in userList)
            {
                if (user.email == mail && user.password == pw)
                    registered = true;
            }
            return registered;
        }
    }
}
