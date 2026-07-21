namespace MenuUtenti;

using MenuControllers;
using Utenti;

public class MenuUtente
{
    public MenuController _menuController;
    public MenuUtente (MenuController menuController)
    {
        _menuController = menuController;
    }
    public void MostraMenu()
    {
        Console.Clear();
        Console.WriteLine(new string('*',110));
        Console.WriteLine("                   Menu");
        Console.WriteLine(new string('*',110));
        Console.WriteLine("Seleziona una delle seguenti opzioni:");
        Console.WriteLine("1    - Prestito");
        Console.WriteLine("2    - Restituzione");
        Console.WriteLine("3    - Elenco libri");
        Console.WriteLine("4    - Ricerca");
        Console.WriteLine(new string('-',110));
        Console.WriteLine("M    - Modifica password");
        Console.WriteLine(new string('-',110));
        Console.WriteLine("Invio - Esci dall'applicazione");
        
    }

    public void Menu(Utente utente)
    {
        
        bool continua = true;

        while (continua)
        {
            MostraMenu();
            string? scelta = Console.ReadLine();
            if (string.IsNullOrEmpty(scelta))
            {
                Console.WriteLine("Esco...ciao!");
                continua = false;
            } else
            {
                _menuController.GestisciOpzioneMenuScelta(scelta, utente);
            }
            
        }

        
    }

    

    

    
    
}
