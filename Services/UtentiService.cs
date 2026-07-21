namespace UtentiService;

using Biblioteca;
using Utenti;
using GestioneFile;
using PasswordHelpers;

public class UtenteService
{
    public readonly Biblio _biblioteca;

    public UtenteService (Biblio biblioteca)
    {
        _biblioteca = biblioteca;
    }

    public Utente? CercaUtente(string codiceTessera)
    {
        Utente? utente = _biblioteca.utenti.FirstOrDefault(u => u.CodiceTessera == codiceTessera);
        return utente;
    }

    public void AggiungiUtente(string tipoRegistrazione)
    {
        string nome = Utility.LeggiCampoObbligatorio("Inserisci il nome:");
        string cognome = Utility.LeggiCampoObbligatorio("Inserisci il cognome:");
        string password = Utility.LeggiCampoObbligatorio("Inserisci il password:");
        string codiceTessera = (int.Parse(Utility.OttieniCodice(_biblioteca.utenti, FileManager.pathUtenti, u => u.CodiceTessera)) + 1).ToString("D5");
        
        var (hash,salt) = PasswordHelper.CreaPassword(password);
        Utenti.Utente nuovoUtente = new Utenti.Utente(codiceTessera, nome, cognome, hash,salt);

        // Determina il ruolo dell'utente
        if (tipoRegistrazione == "RegistrazioneDaAdmin")
        {
            string ruoloInput = Utility.LeggiCampoObbligatorio("Inserisci il ruolo dell'utente (1 per utente, 2 per amministratore):");
            if (ruoloInput != "1" && ruoloInput != "2")
            {
                Console.WriteLine("Ruolo non valido. Impostazione predefinita a Utente.");
            }
            else
            {
                // Non gestisco il tipo "1" perchè il default è Utente
                if (ruoloInput == "2")
                    nuovoUtente.Ruolo = Ruolo.Amministratore; 
            }
        }
        _biblioteca.utenti.Add(nuovoUtente);
        FileManager.AggiornaJSON(_biblioteca.utenti, FileManager.pathUtenti);
        Console.WriteLine("**-------------------------------------------------------------------------**");
        Console.WriteLine($"  Utente '{nome}' aggiunto con successo. Codice tessera: {codiceTessera}");
        Console.WriteLine("**-------------------------------------------------------------------------**");
    }

    public void EliminaUtente(Utente utente)
    {
        string codiceTessera = Utility.LeggiCampoObbligatorio("Inserisci il codice tessera dell'utente da eliminare:");
        Utente? utenteDaEliminare = _biblioteca.utenti.FirstOrDefault(u => u.CodiceTessera == codiceTessera);
        if (utenteDaEliminare != null)
        {
            _biblioteca.utenti.Remove(utenteDaEliminare);
            FileManager.AggiornaJSON(_biblioteca.utenti,FileManager.pathUtenti);
            Console.WriteLine(new string('-',110));
            Console.WriteLine($"Utente con codice tessera {codiceTessera} eliminato con successo.");
            Console.WriteLine(new string('-',110));
        } else
        {
            Console.WriteLine(new string('-',110));
            Console.WriteLine($"Utente con codice tessera {codiceTessera} non trovato. Riprova.");
            Console.WriteLine(new string('-',110));
        }
        
    }

    public void ModificaRuolo()
    {
        string codiceTessera = Utility.LeggiCampoObbligatorio("Codice tessera dell'utente: ");
        Utente? utente = _biblioteca.utenti.FirstOrDefault(u => u.CodiceTessera == codiceTessera);
        
        if (utente == null)
        {
            Console.WriteLine("Utente non trovato");
            return;
        } 

        string nuovoRuolo = Utility.LeggiCampoObbligatorio("Nuovo Ruolo (1 per Utente, 2 per Amministratore): ");
        switch (nuovoRuolo)
        {
            case "1":
                utente.Ruolo = Ruolo.Utente;
                break;
            case "2":
                utente.Ruolo = Ruolo.Amministratore;
                break;
            default:
                Console.WriteLine("Ruolo non valido");
                return;        
        }

        FileManager.AggiornaJSON(_biblioteca.utenti, FileManager.pathUtenti);
        Console.WriteLine("Ruolo modificato con successo.");
    }

    public bool ModificaPassword(Utente utente)
    {
        string vecchiaPassword = Utility.LeggiCampoObbligatorio("Vecchia password: ");
        string nuovaPassword = Utility.LeggiCampoObbligatorio("Nuova password: ");
        if (!PasswordHelper.VerificaPassword(vecchiaPassword,utente.PasswordHash,utente.Salt))
        {
            return false;
        }
        var (hash,salt) = PasswordHelper.CreaPassword(nuovaPassword);
        utente.Salt = salt;
        utente.PasswordHash = hash;

        FileManager.AggiornaJSON(_biblioteca.utenti,FileManager.pathUtenti);
        return true;
    }
}