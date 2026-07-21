

namespace Avvio;

using System;
using Biblioteca;
using BibliotecaService;
using LibriService;
using Login;
using GestioneFile;
using Utenti;
using PrestitiService;
using UtentiService;
using Libri;
using Prestiti;
using MenuControllers;
using MenuUtenti;
using MenuAdmins;

class Avvio
{
    public static void Main(string[] args)
    {
        Console.WriteLine(new string('*',110));
        Console.WriteLine("Benvenut* nella biblioteca!");
        Console.WriteLine(new string('*',110));

        Biblio biblioteca = new Biblio();
        BiblioService biblioService = new BiblioService(biblioteca);
        LibroService libriService = new LibroService(biblioteca);
        PrestitoService prestitiService = new PrestitoService(biblioteca);
        UtenteService utentiService = new UtenteService(biblioteca);
        biblioteca.utenti = FileManager.CaricaListaDaFileJSON<Utente>(FileManager.pathUtenti);
        Login login = new Login(utentiService);
        
        Utente? utenteLoggato = login.EffettuaLogin();

        if (utenteLoggato == null)
        {
            Console.WriteLine("Esco dall'applicazione....ciao!");
            return;
        }

        biblioteca.libri = FileManager.CaricaListaDaFileJSON<Libro>(FileManager.pathLibri);
        biblioteca.prestiti = FileManager.CaricaListaDaFileJSON<Prestito>(FileManager.pathPrestiti);

        MenuController menuController = new MenuController(biblioService, utentiService, libriService, prestitiService);
        
        if (utenteLoggato.Ruolo == Ruolo.Utente)
        {
            MenuUtente menu = new MenuUtente(menuController);
            menu.Menu(utenteLoggato);
        }
        else
        {
            MenuAdmin menu = new MenuAdmin(menuController);
            menu.Menu(utenteLoggato);
        }

    }

}