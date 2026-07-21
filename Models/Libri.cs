namespace Libri;

public enum Disponibilità
{
    Disponibile,
    In_Prestito,
    In_Arrivo
}
public class Libro
{
    public string Titolo { get; set; }
    public string Autore { get; set; }
    public string CodiceLibro { get; set; }
    public Disponibilità Disponibilità {get;set;} 

    public Libro(string codiceLibro, string titolo, string autore)
    {
        CodiceLibro = codiceLibro;
        Titolo = titolo;
        Autore = autore;
        Disponibilità = Disponibilità.Disponibile;
    }

    public string Denominazione()
    {
        return $"Titolo: {Titolo}, Autore: {Autore}";
    }

    public override string ToString()
    {
        return $"{CodiceLibro,-10} {Titolo,-30} {Autore,-25} {Disponibilità,-10}";
    }


    
}