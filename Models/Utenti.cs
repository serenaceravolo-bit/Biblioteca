namespace Utenti;

public enum Ruolo
{
    Amministratore,
    Utente
}
public class Utente
{
    public string CodiceTessera { get; set; }
    public string Nome { get; set; }  
    public string Cognome { get; set; }

    public Ruolo Ruolo { get; set; } 

    public string PasswordHash {get;set;}
    public string Salt {get;set;}

    public Utente(string codiceTessera, string nome, string cognome, string passwordHash,string salt)
    {
        CodiceTessera = codiceTessera;
        Nome = nome;
        Cognome = cognome;
        Ruolo = Ruolo.Utente;
        PasswordHash = passwordHash;
        Salt = salt;
    }

    public string Denominazione(string codiceTessera)
    {
        return $"Utente: {Nome} {Cognome}";
    }

    public override string ToString()
    {
        return $"{CodiceTessera,-20} {Nome,-30} {Cognome,-25} {Ruolo,-20}";
    }

    
}