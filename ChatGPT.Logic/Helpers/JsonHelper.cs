using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ChatGPT.Logic.Helpers
{
    public static class JsonHelper
    {
        /// <summary>
        /// Serialiserar ett objekt till JSON och sparar det till en fil.
        /// </summary>
        /// <typeparam name="T">Typen av objektet som ska serialiseras.</typeparam>
        /// <param name="data">Objektet som ska serialiseras.</param>
        /// <param name="filePath">Sökvägen där JSON-filen ska sparas.</param>
        public static async Task SaveToJsonFileAsync<T>(T data, string filePath)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true // För att göra JSON mer läsbar
                };

                string jsonString = JsonSerializer.Serialize(data, options);

                // Skapar mappen om den inte finns
                var directory = Path.GetDirectoryName(filePath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                await File.WriteAllTextAsync(filePath, jsonString);
                Console.WriteLine($"Data har sparats till {filePath}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel inträffade när JSON-filen skapades: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Läser JSON från en fil och deserialiserar den till ett objekt.
        /// </summary>
        /// <typeparam name="T">Typen av objektet som ska deserialiseras.</typeparam>
        /// <param name="filePath">Sökvägen till JSON-filen.</param>
        /// <returns>Deserialiserat objekt.</returns>
        public static async Task<T> LoadFromJsonFileAsync<T>(string filePath)
        {
            try
            {
                if (!File.Exists(filePath))
                {
                    throw new FileNotFoundException($"Filen {filePath} hittades inte.");
                }

                string jsonString = await File.ReadAllTextAsync(filePath);
                return JsonSerializer.Deserialize<T>(jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel inträffade när JSON-filen lästes: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Serialiserar ett objekt till en JSON-sträng.
        /// </summary>
        /// <typeparam name="T">Typen av objektet som ska serialiseras.</typeparam>
        /// <param name="data">Objektet som ska serialiseras.</param>
        /// <returns>En JSON-sträng som representerar objektet.</returns>
        public static string SerializeToJson<T>(T data)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true // För att göra JSON mer läsbar
                };

                return JsonSerializer.Serialize(data, options);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel inträffade vid serialisering till JSON: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Deserialiserar en JSON-sträng till ett objekt.
        /// </summary>
        /// <typeparam name="T">Typen av objektet som ska deserialiseras.</typeparam>
        /// <param name="jsonString">JSON-strängen som ska deserialiseras.</param>
        /// <returns>Det deserialiserade objektet.</returns>
        public static T DeserializeFromJson<T>(string jsonString)
        {
            try
            {
                return JsonSerializer.Deserialize<T>(jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel inträffade vid deserialisering från JSON: {ex.Message}");
                throw;
            }
        }

        public static List<T> DeserializeFromJsonToList<T>(string jsonString)
        {
            try
            {
                return JsonSerializer.Deserialize<List<T>>(jsonString);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ett fel inträffade vid deserialisering från JSON till en lista: {ex.Message}");
                throw;
            }
        }
    }
}
