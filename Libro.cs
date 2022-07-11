using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca
{
    internal class Libro : Documento
    {
        public Libro(string title) : base(title)
        {
            base.id = this.GenerateISBN();
        }

        public int Pagine { get; set; }

        private string GenerateISBN()
        {
            string id = "";
            for (int i = 0; i < 13; i++)
            {
                id += new Random().Next(10);
            }
            return id;
        }
    }
}
