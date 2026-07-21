namespace Login;

using UtentiService;
using PasswordHelpers;
using Utenti;

public class Login
{
    public UtenteService _utenteService;
    public Login(UtenteService utenteService)
    {
        _utenteService = utenteService;
    }
    
    public Utente? EffettuaLogin()
    {
        
        Console.WriteLine("Sono necessarie le credenziali per accedere, digita:");
        Console.WriteLine("1 - Per registrarti");
        Console.WriteLine("2 - Per effettuare il login");
        Console.WriteLine("Invio - Esci dall'applicazione.");

        string? scelta = Console.ReadLine();

        if (string.IsNullOrEmpty(scelta))
        {
            Console.WriteLine("Esco... ciao!");
            Environment.Exit(0);
        }

        if (scelta == "1")
            _utenteService.AggiungiUtente("RegistrazioneDaUtente");

        Console.WriteLine("Inserisci il codice tessera:");
        string codiceTessera = Utility.LeggiCampoObbligatorio("Codice tessera: ");

        Utente? utente = _utenteService.CercaUtente(codiceTessera);

        if (utente == null)
        {
            Console.WriteLine(new string('*',110));
            Console.WriteLine("[ERRORE] Utente non trovato.");
            Console.WriteLine(new string('*',110));
            EffettuaLogin();
            return null;
        }

        int tentativi = 3;

        while (tentativi > 0)
        {
            Console.Write($"Password ({tentativi} tentativi rimasti, Invio per uscire): ");
            string? password = Console.ReadLine();

            if (string.IsNullOrEmpty(password))
            {
                Console.WriteLine("Login annullato. Esco...ciao!");
                return null;
            }

            if (PasswordHelper.VerificaPassword(password, utente.PasswordHash, utente.Salt))
            {
             // Login riuscito
                return utente;
            }

            tentativi--;
            Console.WriteLine("Password errata.");

            if (tentativi == 0)
            {
                Console.WriteLine("Hai esaurito i tentativi di accesso.");
                EffettuaLogin();
                return null;
            }
        }

        return null;
    }
    
}