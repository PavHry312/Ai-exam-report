using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ProjektAiEx
{
    // Klasa reprezentująca strukturę zapytania do modelu Ollama
    public class ZadanieChat
    {
        [JsonProperty("model")]
        public string Model { get; set; }

        [JsonProperty("prompt")]
        public string Prompt { get; set; }

        [JsonProperty("stream")]
        public bool Stream { get; set; }
    }

    class Program
    {
        // Lokalny adres serwera Ollama
        private const string UrlModelu = "http://localhost:11434/api/generate";

        static async Task Main(string[] args)
        {
            Console.Title = "Interfejs AI - Model Lokalny Phi-3";
            Console.WriteLine("=================================================");
            Console.WriteLine("   Integracja z Nowoczesnym AI: Klient Ollama    ");
            Console.WriteLine("=================================================\n");

            using (var klient = new HttpClient())
            {
                // Główna pętla czatu
                while (true)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Użytkownik > ");
                    Console.ResetColor();

                    string wejscie = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(wejscie)) break;

                    try
                    {
                        // Wywołanie metody do komunikacji z modelem
                        string odpowiedź = await PobierzOdpowiedzAI(klient, wejscie);

                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\nAsystent AI > {odpowiedź}\n");
                        Console.ResetColor();
                    }
                    catch (Exception wyjatek)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"\n[Błąd Krytyczny]: {wyjatek.Message}");
                        Console.WriteLine("Upewnij się, że serwer Ollama jest uruchomiony (komenda: ollama serve)\n");
                        Console.ResetColor();
                    }
                }
            }
        }

        private static async Task<string> PobierzOdpowiedzAI(HttpClient klient, string zapytanieUzytkownika)
        {
            // Przygotowanie danych dla modelu Phi-3 Mini
            var daneZapytania = new
            {
                model = "phi3:mini",
                prompt = zapytanieUzytkownika,
                stream = false
            };

            var zawartoscJson = JsonConvert.SerializeObject(daneZapytania);
            var trescPost = new StringContent(zawartoscJson, Encoding.UTF8, "application/json");

            // Wysłanie zapytania POST do lokalnego API
            var odpowiedzSerwera = await klient.PostAsync(UrlModelu, trescPost);

            // Sprawdzenie, czy zapytanie zakończyło się sukcesem (Status 200 OK)
            odpowiedzSerwera.EnsureSuccessStatusCode();

            var tekstOdpowiedzi = await odpowiedzSerwera.Content.ReadAsStringAsync();

            // Deserializacja odpowiedzi JSON za pomocą biblioteki Newtonsoft.Json
            dynamic wynik = JsonConvert.DeserializeObject(tekstOdpowiedzi);

            // Zwrócenie wygenerowanego tekstu
            return wynik.response.ToString();
        }
    }
}