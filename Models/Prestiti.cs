namespace Prestiti;
public class Prestito
{
    public string IDPrestito { get; set; }
    public string CodiceTessera { get; set; }

    public string CodiceLibro { get; set; }
    public DateTime DataPrestito { get; set; }

    public Prestito(string idPrestito, string codiceTessera, string codiceLibro)
    {
        IDPrestito = idPrestito;
        CodiceTessera = codiceTessera;
        CodiceLibro = codiceLibro;
        DataPrestito = DateTime.Now;
    }

    
}