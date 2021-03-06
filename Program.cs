//una serie di istanze per "popolare" il nostro "fake db"
// 2 o 3 utenti -> registrati
// 2 o 3 libri --> tutti disponibili
// Gli utenti si possono registrare specificando i dati ...


// Biblioteca online
// 1. registrati
// 2. login

//login 
// email: ..
// passowrd: ..

// Biblioteca online
// 1. Cerca libri
// 2. Cerca dvd

// Registrazione
// Scrivmi il nome: 
// scrivimi il cognome.. etc
// scrivi la passowrd: 

// Menu libro (titolo)
// 1. visualizza dettagli libro
// 2. richiedi prestito
// 3. restitutisci


// tutti i menu hanno esci o torna indietro
using csharp_biblioteca;
using System.Data.SqlClient;

string stringaDiConnessione = "Data Source=localhost;Initial Catalog=db-biblioteca;Integrated Security=True";

//Reader per la tabella dei libri
using (SqlConnection connessioneSql = new SqlConnection(stringaDiConnessione))
{
    try
    {
        connessioneSql.Open();
        string query = "SELECT title, author, year FROM books";
        Console.WriteLine("Titolo\tAutore\tAnno");
        using (SqlCommand cmd = new SqlCommand(query, connessioneSql))
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                Console.WriteLine($"{reader.GetString(0)}\t{reader.GetString(1)}\t{reader.GetInt16(2)}");
            }
        }

    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
}
Console.WriteLine();
Console.Write("Vuoi effettuare un prestito? (sì/no) ");
string scelta = Console.ReadLine();
if (scelta == "sì")
    Console.Write("Inserisci il titolo del libro ");
string titolo = Console.ReadLine();
int idBook;
using (SqlConnection connessioneSql = new SqlConnection(stringaDiConnessione))
{
    try
    {
        connessioneSql.Open();
        string query = $"SELECT copies.id, conditions.name FROM copies LEFT JOIN books ON books.id = copies.book_id LEFT JOIN conditions ON conditions.id = copies.condition_id WHERE books.title = '{titolo}'";
        using (SqlCommand cmd = new SqlCommand(query, connessioneSql))
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                Console.Write(reader.GetInt32(0) + ". ");
                Console.Write(reader.GetString(1) + "\n");
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.ToString());
    }
}

Biblioteca newBiblio = new Biblioteca();
//Creare 3 nuovi utenti
Utente user1 = new Utente("mail@prova.it", "1234");
user1.name = "Giuseppe";
user1.surname = "Mirizzi";
newBiblio.AddUser(user1);
Utente user2 = new Utente("mail@prova.it", "1234");
user2.name = "Paolo";
user2.surname = "Sempronio";
newBiblio.AddUser(user2);
Utente user3 = new Utente("mail@prova.it", "1234");
user3.name = "Gianluca";
user3.surname = "Tizio";
newBiblio.AddUser(user3);
//Creare 3 nuovi libri
Libro libro1 = new Libro("Titolo casuale");
newBiblio.AddDoc(libro1);
Libro libro2 = new Libro("Titolo random");
newBiblio.AddDoc(libro2);
Libro libro3 = new Libro("Titolo bellissimo");
newBiblio.AddDoc(libro3);

//Console.WriteLine("Biblioteca online");
//Console.WriteLine("1. Registrati");
//Console.WriteLine("2. Login");
//string scelta = Console.ReadLine();
//if (scelta == "1")
//{
//    Console.Write("Inserisci mail ");
//    string mail = Console.ReadLine();
//    Console.Write("Inserisci password ");
//    string pw = Console.ReadLine();
//    Utente newUser = new Utente(mail, pw);
//    newBiblio.AddUser(newUser);
//    Console.WriteLine("Nuovo utente registrato");
//}
//else
//{
//    Console.Write("Inserisci mail ");
//    string mail = Console.ReadLine();
//    Console.Write("Inserisci password ");
//    string pw = Console.ReadLine();
//    if (newBiblio.isRegistred(mail, pw))
//    {
//        Console.WriteLine("Sei loggato");
//        Console.WriteLine("1. Cerca Libri");
//        Console.WriteLine("2. Cerca DVD");
//        string scelta2 = Console.ReadLine();
//        if (scelta2 == "1")
//        {
//            Console.WriteLine("Inserisci titolo ");
//            string titolo = Console.ReadLine();
//        }
//    }
//    else
//    {
//        Console.WriteLine("Non sei registrato");
//    }
//}


