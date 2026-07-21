namespace GestioneFile;

using System.Text;
using System.Text.Json;
using System.Diagnostics;

public class FileManager
{
    public static readonly string RootPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "..", "..", ".."));
    public static readonly string pathUtenti = Path.Combine(RootPath, "Documenti", "utenti.json");
    public static readonly string pathLibri = Path.Combine(RootPath, "Documenti", "libri.json");
    public static readonly string pathPrestiti = Path.Combine(RootPath, "Documenti", "prestiti.json");

    public static List<T> CaricaListaDaFileJSON<T>(string pathJSON)
    {
        if (File.Exists(pathJSON))
        {
            string json = File.ReadAllText(pathJSON);
            return System.Text.Json.JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }

        return new List<T>();
    }

    public static void AggiornaJSON<T>(List<T> lista, string pathJSON)
    {
        string json = JsonSerializer.Serialize(lista, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(pathJSON, json);
    }

    public static void ScriviEApriFileElenco(string sb, string tipoFile )
    {
        string nomeFile;
        switch(tipoFile)
        {
            case "Utenti":
                nomeFile = $"ElencoUtenti_{Guid.NewGuid()}.txt";
                break;
            case "Libri":
                nomeFile = $"ElencoLibri_{Guid.NewGuid()}.txt";
                break;
            case "Ricerca":
                nomeFile = $"Ricerca_{Guid.NewGuid()}.txt";
                break;
            default:
                Console.WriteLine($"Tipo file non valido: {tipoFile}");
                return;
        }

        string percorso = Path.Combine(Path.GetTempPath(),nomeFile);
        File.WriteAllText(percorso, sb, Encoding.UTF8);

        Process? p = Process.Start(new ProcessStartInfo { FileName = percorso, UseShellExecute = true });
        if (p != null)
        {
            p.WaitForExit();
            p.Dispose();
        }

        File.Delete(percorso);
    }

}