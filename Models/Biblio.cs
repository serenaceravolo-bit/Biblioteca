namespace Biblioteca;

using Utenti;
using Libri;
using Prestiti;

public enum TipoLista
{
    Utenti,
    Libri,
    Prestiti
}

public class Biblio {

    public List<Utente> utenti {get;set;} = new List<Utente>();
    public List<Libro> libri {get;set;} = new List<Libro>();
    public List<Prestito> prestiti {get;set;} = new List<Prestito>();

    public TipoLista tipoLista;

}