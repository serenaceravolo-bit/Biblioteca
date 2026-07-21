using System.Text.Json;

public class Utility
{
    public static string LeggiCampoObbligatorio(string messaggio)
    {
        string? input;

        do
        {
            Console.Write(messaggio);
            input = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Il campo non può essere vuoto.");
            }

        } while (string.IsNullOrWhiteSpace(input));

        return input;
    }
    public static string RecuperaMaxID<T>(List<T> lista, Func<T, string> selector)
    {
        int maxId = lista
            .Select(selector)
            .Where(s => !string.IsNullOrEmpty(s) && int.TryParse(s, out _))
            .Select(int.Parse)
            .DefaultIfEmpty(0)
            .Max();

        return maxId.ToString("D5");
    }

    public static string OttieniCodice<T>(List<T> lista, string path, Func<T, string> selector)
    {
        if (lista == null || lista.Count == 0)
        {
            if (!File.Exists(path))
            {
                var dir = Path.GetDirectoryName(path);
                if (!string.IsNullOrEmpty(dir)) Directory.CreateDirectory(dir);
                return "00000";
            }

            string json = File.ReadAllText(path);
            if (string.IsNullOrEmpty(json))
            {
                return "00000";
            }

            List<T>? listFromFile = System.Text.Json.JsonSerializer.Deserialize<List<T>>(json);
            if (listFromFile == null || listFromFile.Count == 0)
            {
                return "00000";
            }

            lista = listFromFile;
        }

        return RecuperaMaxID(lista, selector);
    }

    

    
    
}