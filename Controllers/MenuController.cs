namespace MenuControllers;

using UtentiService;
using LibriService;
using PrestitiService;
using Utenti;
using BibliotecaService;
using Biblioteca;

public class MenuController
{

    public readonly BiblioService _biblioService;
    public readonly UtenteService _utenteService;
    public readonly LibroService _libroService;
    public readonly PrestitoService _prestitoService;

    public MenuController (BiblioService biblioService, UtenteService utenteService, LibroService libroService, PrestitoService prestitoService)
    {
        _biblioService = biblioService;
        _utenteService = utenteService;
        _libroService = libroService;
        _prestitoService = prestitoService;
    }

    public bool GestisciOpzioneMenuScelta(string input, Utente utente)
    {

        switch (input)
        {
            case "1L":
                _libroService.AggiungiLibro();
                break;
            case "2L":
                _libroService.EliminaLibro();
                break;
            case "3L":
            case "1":
                _prestitoService.PrestaLibro();
                break;
            case "4L":
            case "2":
                _prestitoService.RestituisciLibro();
                break;
            case "5L":
            case "3":
                _biblioService.ElencoLibri(utente);
                break;
            case "6L":
            case "4":
                _biblioService.CercaInLista(TipoLista.Libri);
                break;
            case "1U":
                _utenteService.AggiungiUtente("RegistrazioneDaAdmin");
                break;
            case "2U":
                _utenteService.EliminaUtente(utente);
                break;
            case "3U":
                _biblioService.ElencoUtenti();
                break;
            case "4U":
                _utenteService.ModificaRuolo();
                break;
            case "5U":
                 _biblioService.CercaInLista(TipoLista.Utenti);
                break;
            case "M":
                _utenteService.ModificaPassword(utente);
                break;
            default:
                Console.WriteLine("Uscita dall'applicazione. Ciao!");
                return false;
        }

        Console.WriteLine(new string('*', 110));
        Console.WriteLine("Premi INVIO per continuare...");
        Console.ReadLine();
        return true;

    }
}