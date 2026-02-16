# Implementacja Lokalnego Systemu AI w Architekturze C# i Ollama

## 📝 Opis projektu
Projekt przedstawia nowoczesne podejście do integracji sztucznej inteligencji z aplikacjami desktopowymi. System wykorzystuje lokalny model językowy (LLM) **Phi-3 Mini** działający w infrastrukturze **Ollama**, co zapewnia pełną prywatność danych i niezależność od zewnętrznych dostawców API.

Głównym elementem projektu jest aplikacja konsolowa napisana w języku **C# (.NET 8)**, która komunikuje się z modelem AI poprzez asynchroniczne zapytania REST API.

## 🚀 Kluczowe cechy
* **Self-hosted AI:** Wykorzystanie lokalnego silnika Ollama.
* **Asynchroniczność:** Pełna obsługa wzorca `async/await` w komunikacji HTTP.
* **Bezpieczeństwo:** Dane nie opuszczają lokalnej maszyny użytkownika.
* **Automatyzacja:** Profesjonalne parsowanie danych JSON przy użyciu biblioteki `Newtonsoft.Json`.

## 🛠 Struktura projektu
Zgodnie z wymogami akademickimi, repozytorium zawiera:
* `AiExProject.sln` — Główny plik rozwiązania Visual Studio.
* `AiExProject/Program.cs` — Kod źródłowy z logiką komunikacji AI.
* `AiExProject/AiExProject.csproj` — Plik konfiguracji i zależności NuGet.
* `DOKUMENTACJA_AI.pdf` — Pełny raport techniczny (wygenerowany w LaTeX).

## 🔧 Instrukcja uruchomienia
Aby uruchomić projekt lokalnie, należy:
1. Zainstalować [Ollama](https://ollama.com/).
2. Pobrać model Phi-3 komendą: `ollama pull phi3:mini`.
3. Otworzyć plik `.sln` w środowisku Visual Studio 2022.
4. Przywrócić pakiety NuGet (`Newtonsoft.Json`).
5. Uruchomić aplikację.

## 📚 Wykorzystane technologie
* **Język:** C# 12 / .NET 8.0
* **AI Model:** Microsoft Phi-3 Mini (3.8B parameters)
* **Backend:** Ollama REST API
* **Biblioteki:** Newtonsoft.Json, System.Net.Http

---
*Projekt przygotowany w celach edukacyjnych na Wydziale Fizyki i Astronomii w Poznaniu.*
