namespace MenuAdmins;

using MenuControllers;
using Utenti;
public class MenuAdmin {

    public MenuController _menuService;

    public MenuAdmin(MenuController menuService)
    {
        _menuService = menuService;
    }
    public void MostraMenu()
    {
        Console.Clear();
        Console.WriteLine(new string('*',110));
        Console.WriteLine("Menu amministratore");
        Console.WriteLine(new string('*',110));
        Console.WriteLine("Seleziona una delle seguenti opzioni:");
        Console.WriteLine("Libri");
        Console.WriteLine("1L - Nuovo libro");
        Console.WriteLine("2L - Elimina libro");
        Console.WriteLine("3L - Prestito");
        Console.WriteLine("4L - Restituzione");
        Console.WriteLine("5L - Elenco libri disponibili e in prestito");
        Console.WriteLine("6L - Cerca libro e/o autore");
        Console.WriteLine(new string('-',110));
        Console.WriteLine("Utenti");
        Console.WriteLine("1U - Nuovo utente");
        Console.WriteLine("2U - Elimina utente");
        Console.WriteLine("3U - Elenco utenti");
        Console.WriteLine("4U - Modifica ruolo utente");
        Console.WriteLine("5U - Cerca utente");
        Console.WriteLine("Impostazioni");
        Console.WriteLine("M  - Modifica password");
        Console.WriteLine(new string('-',110));
        Console.WriteLine("Invio - Esci dall'applicazione");

        
    }

    public void Menu(Utente utente)
    {
        bool continua = true;

        while(continua)
        {
            MostraMenu();

            string? scelta = Console.ReadLine();
            if (string.IsNullOrEmpty(scelta))
            {
                Console.WriteLine("Esco....ciao!");
                continua = false;
            } else
            {
                continua = _menuService.GestisciOpzioneMenuScelta(scelta, utente);
            }

        }
    }

    

    
}