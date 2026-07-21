namespace LibriService;

using Biblioteca;
using Libri;
using GestioneFile;
public class LibroService
{
    public readonly Biblio _biblioteca;

    public LibroService (Biblio biblioteca) {
        _biblioteca = biblioteca;
    }

    public void AggiungiLibro()
    {
        string titolo = Utility.LeggiCampoObbligatorio("Inserisci il titolo del libro:");
        string autore = Utility.LeggiCampoObbligatorio("Inserisci l'autore del libro:");

        string codiceLibro = (int.Parse(Utility.OttieniCodice(_biblioteca.libri, FileManager.pathLibri, l => l.CodiceLibro)) + 1).ToString("D5");// Inserire lettura elenco libri già inseriti e generazione ID univoco partendo dall'ultimo ID presente

        Libri.Libro nuovoLibro = new Libri.Libro(codiceLibro, titolo, autore);
        _biblioteca.libri.Add(nuovoLibro);
        FileManager.AggiornaJSON(_biblioteca.libri, FileManager.pathLibri);
        Console.WriteLine(new string('-',110));
        Console.WriteLine($"Libro '{titolo}' di {autore} aggiunto con successo. Codice libro: {codiceLibro}");
        Console.WriteLine(new string('-',110));
    }

    public void EliminaLibro()
    {
        string codiceLibro = Utility.LeggiCampoObbligatorio("Inserisci il codice del libro da eliminare:");
        Libro? libroDaEliminare = _biblioteca.libri.FirstOrDefault(l => l.CodiceLibro == codiceLibro);
        if (libroDaEliminare != null)
        {
            _biblioteca.libri.Remove(libroDaEliminare);
            FileManager.AggiornaJSON(_biblioteca.libri,FileManager.pathLibri);
            Console.WriteLine(new string('-',110));
            Console.WriteLine($"Libro con codice {codiceLibro} eliminato con successo.");
            Console.WriteLine(new string('-',110));
        } else
        {
            Console.WriteLine(new string('-',110));
            Console.WriteLine($"Libro con codice '{codiceLibro}' non trovato. Riprova.");
            Console.WriteLine(new string('-',110));
        }
        
    }


}