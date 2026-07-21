namespace BibliotecaService;

using Utenti;
using Biblioteca;
using System.Text;
using GestioneFile;

public class BiblioService
{

    public readonly Biblio _biblioteca;

    public BiblioService (Biblio biblioteca)
    {
        _biblioteca = biblioteca;
    }
    public void ElencoUtenti()
    {
        
        Console.WriteLine(new string('*', 110));

        Console.WriteLine("Elenco degli utenti registrati");
        Console.WriteLine(new string('*', 110));
        
        Console.WriteLine($"{ "Codice Tessera",-20 } { "Nome",-30 } { "Cognome",-30 } { "Ruolo",-20}");
        
        Console.WriteLine(new string('-', 110));

        var utentiOrdinati = _biblioteca.utenti
            .OrderBy(u => u.Ruolo)
            .ThenBy(u => u.Cognome)
            .ThenBy(u => u.Nome);

        foreach (var utente in utentiOrdinati)
        {
            Console.WriteLine($"{utente.CodiceTessera,-20 } {utente.Nome,-30 } {utente.Cognome,-25 } {utente.Ruolo,-20}");
            
        }
        
    }

    public void EsportaElenco()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(new string('*', 110));
        sb.AppendLine("Elenco degli utenti registrati");
        sb.AppendLine(new string('*', 110));

        sb.AppendLine($"{ "Codice Tessera",-20 } { "Nome",-30 } { "Cognome",-30 } { "Ruolo",-20}");
        sb.AppendLine(new string('-', 110));
        foreach (var utente in _biblioteca.utenti)
        {
            sb.AppendLine($"{utente.CodiceTessera,-20 } {utente.Nome,-30 } {utente.Cognome,-25 } {utente.Ruolo,-20}");
        }    

        FileManager.ScriviEApriFileElenco(sb.ToString(), "Utenti" );
    }

    public void ElencoLibri(Utente utente)
    {
        Console.WriteLine(new string('*', 110));
        Console.WriteLine("*  Elenco dei libri");
        Console.WriteLine(new string('*', 110));

        var libriOrdinati = _biblioteca.libri
            .OrderBy(l => l.Autore)
            .ThenBy(l => l.Titolo);

        string intestazione;

        if (utente.Ruolo == Ruolo.Utente)
        {
            intestazione = $"{ "Codice",-10 } { "Titolo",-30 } { "Autore",-25 } { "Disponibilità",-10}";
        }
        else
        {
            intestazione = $"{ "Codice",-10 } { "Titolo",-30 } { "Autore",-25 } { "Disponibilità",-20} {"Tessera prestito",-10}";
            
        }
        Console.WriteLine(intestazione);
        Console.WriteLine(new string('-', 110));

        foreach (var libro in _biblioteca.libri)
        {
            var prestito = _biblioteca.prestiti.FirstOrDefault(p => p.CodiceLibro == libro.CodiceLibro);

            string record = utente.Ruolo == Ruolo.Utente
                ? $"{libro.CodiceLibro,-10} {libro.Titolo,-30} {libro.Autore,-25} {libro.Disponibilità,-10}"
                : $"{libro.CodiceLibro,-10} {libro.Titolo,-30} {libro.Autore,-25} {libro.Disponibilità,-20} {(prestito?.CodiceTessera ?? "-"),-10}";

            Console.WriteLine(record);
        }
        
    }

    public void CercaInLista(TipoLista tipoLista)
    {
        Console.Write("Inserisci il valore da cercare: ");
        string? valoreDaCercare = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(valoreDaCercare))
        {
            Console.WriteLine("È necessario inserire un valore di ricerca.");
            return;
        }

        // Divide la ricerca in più parole
        string[] termini = valoreDaCercare.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

        IEnumerable<object> risultati = Enumerable.Empty<object>();

        if (tipoLista == TipoLista.Libri)
        {
            risultati = _biblioteca.libri
                .Where(l => termini.Any(t =>
                    l.Titolo.Contains(t, StringComparison.OrdinalIgnoreCase) ||
                    l.Autore.Contains(t, StringComparison.OrdinalIgnoreCase) ||
                    l.CodiceLibro.Contains(t, StringComparison.OrdinalIgnoreCase)))
                .Cast<object>();

            Console.WriteLine($"{ "Codice",-10 } { "Titolo",-30 } { "Autore",-25 } { "Disponibilità",-10}");
            Console.WriteLine(new string('-', 110));
        }
        else if (tipoLista == TipoLista.Utenti)
        {
            risultati = _biblioteca.utenti
                .Where(u => termini.Any(t =>
                    u.Nome.Contains(t, StringComparison.OrdinalIgnoreCase) ||
                    u.Cognome.Contains(t, StringComparison.OrdinalIgnoreCase) ||
                    u.CodiceTessera.Contains(t, StringComparison.OrdinalIgnoreCase) ||
                    u.Ruolo.ToString().Contains(t, StringComparison.OrdinalIgnoreCase)))
                .Cast<object>();

            Console.WriteLine($"{ "Codice Tessera",-20 } { "Nome",-30 } { "Cognome",-30 } { "Ruolo",-20}");
            Console.WriteLine(new string('-', 110));
        }

        if (!risultati.Any())
        {
            Console.WriteLine("Nessun risultato trovato.");
            Console.WriteLine(new string('-', 110));
            return;
        }

        foreach (var risultato in risultati)
        {
            Console.WriteLine(risultato);
        }
    }
    
        
}