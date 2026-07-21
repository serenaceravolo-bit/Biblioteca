namespace PrestitiService;

using Biblioteca;
using Prestiti;
using GestioneFile;
using Libri;
using Utenti;

public class PrestitoService
{
    public readonly Biblio _biblioteca;

    public PrestitoService (Biblio biblioteca)
    {
        _biblioteca = biblioteca;
    }

    public void PrestaLibro()
    {
        string codiceLibro = Utility.LeggiCampoObbligatorio("Inserisci il codice del libro da prestare:");
        Libro? libroDaPrestare = _biblioteca.libri.FirstOrDefault(l => l.CodiceLibro == codiceLibro);
        if (libroDaPrestare == null)
        {
            Console.WriteLine("Codice libro inesistente. Riprova.");
            return;
        }
        string codiceTessera = Utility.LeggiCampoObbligatorio("Inserisci il codice tessera:");
        Utente? utentePrestito = _biblioteca.utenti.FirstOrDefault(u => u.CodiceTessera == codiceTessera);
        if (utentePrestito == null)
        {
            Console.WriteLine("Codice utente inesistente. Riprova.");
            return;
        }
        string codicePrestito = (int.Parse(Utility.OttieniCodice(_biblioteca.prestiti, FileManager.pathPrestiti, p => p.IDPrestito)) + 1).ToString("D5");
        Prestito nuovoPrestito = new Prestito(codicePrestito,codiceTessera,codiceLibro);
        _biblioteca.prestiti.Add(nuovoPrestito);
        FileManager.AggiornaJSON(_biblioteca.prestiti,FileManager.pathPrestiti);
        libroDaPrestare.Disponibilità = Disponibilità.In_Prestito;
        FileManager.AggiornaJSON(_biblioteca.libri,FileManager.pathLibri);
        Console.WriteLine(new string('-',110));
        Console.WriteLine($"Prestito del libro '{codiceLibro}' aggiunto con successo. Codice prestito: {codicePrestito}");
        Console.WriteLine(new string('-',110));
        
    }   

    public void RestituisciLibro()
    {
        Console.WriteLine("Inserisci il codice del libro da restituire e il codice tessera:");
        string codiceLibro = Utility.LeggiCampoObbligatorio("Codice Libro:");
        Libro? libroDaRestituire = _biblioteca.libri.FirstOrDefault(l => l.CodiceLibro == codiceLibro);
        if (libroDaRestituire == null)
        {
            Console.WriteLine("Codice libro inesistente. Riprova.");
            return;
        }
        string codiceTessera = Utility.LeggiCampoObbligatorio("Codice Tessera:");
        Prestito? prestitoDaRimuovere = _biblioteca.prestiti.FirstOrDefault(p => p.CodiceLibro == codiceLibro && p.CodiceTessera == codiceTessera);

        if (prestitoDaRimuovere != null)
        {
            _biblioteca.prestiti.Remove(prestitoDaRimuovere);
            FileManager.AggiornaJSON(_biblioteca.prestiti, FileManager.pathPrestiti);
            libroDaRestituire.Disponibilità = Disponibilità.Disponibile;
            FileManager.AggiornaJSON(_biblioteca.libri,FileManager.pathLibri);
        } else
        {
            Console.WriteLine(new string('*',110));
            Console.WriteLine($"ERRORE - Prestito inesistente. Verifica i dati inseriti e riprova:");
            Console.WriteLine($"Codice Libro: {codiceLibro} - Codice Tessera: {codiceTessera}");
            Console.WriteLine(new string('*',110));
        }
        
    }

}